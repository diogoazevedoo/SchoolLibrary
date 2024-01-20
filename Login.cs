using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private void Form1_Load(object sender, EventArgs e)
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            Register Register = new Register();
            Register.ShowDialog();

            this.Close();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "Nome")
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            if(txtPassword.UseSystemPasswordChar == true)
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Nome" || string.IsNullOrEmpty(txtUser.Text) || txtPassword.Text == "Password" || string.IsNullOrEmpty(txtPassword.Text)) 
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            FirebaseResponse response = client.Get(@"users/" + txtUser.Text);
            Utilizador resUser = response.ResultAs<Utilizador>();

            Utilizador curUser = new Utilizador()
            {
                Nome = txtUser.Text,
                Password = txtPassword.Text,
            };

            if(Utilizador.IsEqual(resUser, curUser))
            {
                if (txtUser.Text == "adminBiblioteca" && txtPassword.Text == "admin2022")
                {
                    this.Hide();

                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.ShowDialog();

                    this.Close();
                }
                else
                { 
                    this.Hide();

                    Home home = new Home();
                    home.Nome = txtUser.Text;
                    home.Password = txtPassword.Text;
                    home.ShowDialog();

                    this.Close();
                }
            }
            else
            {
                Utilizador.ShowError();
            }
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDay.Text = DateTime.Now.ToLongDateString();
            lblHour.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
