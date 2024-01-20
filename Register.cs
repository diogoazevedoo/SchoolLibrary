using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SchoolLibrary
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private void Register_Load(object sender, EventArgs e)
        {
            timerDateTime.Start();

            try
            {
                client = new FireSharp.FirebaseClient(fbconfig);
            }
            catch
            {
                MessageBox.Show("Falha na ligação.");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login Login = new Login();
            Login.ShowDialog();

            this.Close();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Nome")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Nome";
                txtUser.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtPasswordConfirmar_Enter(object sender, EventArgs e)
        {
            if (txtPasswordConfirmar.Text == "Confirmar password")
            {
                txtPasswordConfirmar.Text = "";
                txtPasswordConfirmar.ForeColor = Color.Black;
                txtPasswordConfirmar.UseSystemPasswordChar = true;
            }
        }

        private void txtPasswordConfirmar_Leave(object sender, EventArgs e)
        {
            if (txtPasswordConfirmar.Text == "")
            {
                txtPasswordConfirmar.Text = "Confirmar password";
                txtPasswordConfirmar.ForeColor = Color.Silver;
                txtPasswordConfirmar.UseSystemPasswordChar = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == "Nome" || string.IsNullOrEmpty(txtUser.Text) || txtPassword.Text == "Password" || string.IsNullOrEmpty(txtPassword.Text) || txtPasswordConfirmar.Text == "Confirmar password" || string.IsNullOrEmpty(txtPasswordConfirmar.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }
            else
            {
                if (txtPassword.Text == txtPasswordConfirmar.Text)
                {
                    Utilizador user = new Utilizador()
                    {
                        Nome = txtUser.Text,
                        Password = txtPassword.Text,
                        LivroRequisitado = "não"
                    };

                    FirebaseResponse response = client.Set(@"users/" + txtUser.Text, user);
                    MessageBox.Show("Registo efetuado com sucesso!");
                }
                else
                {
                    MessageBox.Show("As passwords não correspondem!");
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnHide.BringToFront();
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == false)
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShow.BringToFront();
            }
        }

        private void btnHide2_Click(object sender, EventArgs e)
        {
            if (txtPasswordConfirmar.UseSystemPasswordChar == false)
            {
                txtPasswordConfirmar.UseSystemPasswordChar = true;
                btnShow2.BringToFront();
            }
        }

        private void btnShow2_Click(object sender, EventArgs e)
        {
            if (txtPasswordConfirmar.UseSystemPasswordChar == true)
            {
                txtPasswordConfirmar.UseSystemPasswordChar = false;
                btnHide2.BringToFront();
            }
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDay.Text = DateTime.Now.ToLongDateString();
            lblHour.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
