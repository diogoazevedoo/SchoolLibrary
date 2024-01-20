using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SchoolLibrary
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private async void AdminPanel_Load(object sender, EventArgs e)
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

            if (DateTime.Now.Hour < 6)
            {
                lblSaudacao.Text = "Boa noite admin,";
            }
            else if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 12)
            {
                lblSaudacao.Text = "Bom dia admin,";
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 20)
            {
                lblSaudacao.Text = "Boa tarde admin,";
            }
            else if (DateTime.Now.Hour >= 20)
            {
                lblSaudacao.Text = "Boa noite admin,";
            }

            FirebaseResponse res = await client.GetAsync(@"requisicoes");
            Dictionary<string, RequisitarLivro> data = JsonConvert.DeserializeObject<Dictionary<string, RequisitarLivro>>(res.Body.ToString());

            if(data.Where(ep => ep.Value.EstadoRequisicao == "pendente").Count() <= 0)
            {
                lblNotifications.Visible = false;
                panel2.Visible = false;
            }
            else
            {
                lblNotifications.Text = Convert.ToString(data.Where(ep => ep.Value.EstadoRequisicao == "pendente").Count());
            }           
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login Login = new Login();
            Login.ShowDialog();

            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();

            AddBook AddBook = new AddBook();
            AddBook.ShowDialog();

            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PopUpDelete popUpDelete = new PopUpDelete();
            popUpDelete.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PopUpEdit popUpEdit = new PopUpEdit();
            popUpEdit.ShowDialog();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDay.Text = DateTime.Now.ToLongDateString();
            lblHour.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            this.Hide();

            Consult consult = new Consult();
            consult.ShowDialog();

            this.Close();
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            this.Hide();

            Notifications notifications = new Notifications();
            notifications.ShowDialog();

            this.Close();
        }
    }
}
