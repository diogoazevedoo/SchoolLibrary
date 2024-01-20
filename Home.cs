using System;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SchoolLibrary
{
    public partial class Home : Form
    {
        public string Nome { get; set; }

        public string Password { get; set; }

        public Home()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private async void Home_Load(object sender, EventArgs e)
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
                lblSaudacao.Text = "Boa noite " + Nome + ",";
            }
            else if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 12)
            {
                lblSaudacao.Text = "Bom dia " + Nome + ",";
            }
            else if(DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 20)
            {
                lblSaudacao.Text = "Boa tarde " + Nome + ",";
            }
            else if(DateTime.Now.Hour >= 20)
            {
                lblSaudacao.Text = "Boa noite " + Nome + ",";
            }

            FirebaseResponse res = await client.GetAsync(@"livros");
            Dictionary<string, Livro> data = JsonConvert.DeserializeObject<Dictionary<string, Livro>>(res.Body.ToString());
            PopulateDataGrid(data);

            FirebaseResponse res2 = await client.GetAsync(@"requisicoes");
            Dictionary<string, RequisitarLivro> dataRequisitar = JsonConvert.DeserializeObject<Dictionary<string, RequisitarLivro>>(res2.Body.ToString());

            if(dataRequisitar.Where(ep => ep.Value.Nome == Nome && ep.Value.EstadoRequisicao == "aceite").Count() <= 0)
            {
                panel2.Visible = false;
                lblNotifications.Visible = false;
            }
            else
            {
                panel2.Visible = true;
                lblNotifications.Visible = true;
                lblNotifications.Text = "1";
            }
        }

        public static Image Base64StringIntoImage(string str64)
        {
            byte[] img = Convert.FromBase64String(str64);
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }

        void PopulateDataGrid(Dictionary<string, Livro> record)
        {
            dtvLivros.Rows.Clear();
            dtvLivros.Columns.Clear();

            dtvLivros.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtvLivros.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtvLivros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtvLivros.RowTemplate.Height = 100; 

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img.HeaderText = "Capa";
            img.Name = "Capa";
            dtvLivros.Columns.Add(img);
            dtvLivros.Columns.Add("Titulo", "Título");
            dtvLivros.Columns.Add("Autor", "Autor");
            dtvLivros.Columns.Add("Editora", "Editora");
            dtvLivros.Columns.Add("Ano", "Ano");
            dtvLivros.Columns.Add("Idioma", "Idioma");
            dtvLivros.Columns.Add("Estado", "Estado");

            foreach (var item in record)
            {
                dtvLivros.Rows.Add(Base64StringIntoImage(item.Value.ImgString), item.Key, item.Value.Autor, item.Value.Editora, item.Value.Ano, item.Value.Idioma, item.Value.Requisitado);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login Login = new Login();
            Login.ShowDialog();

            this.Close();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDay.Text = DateTime.Now.ToLongDateString();
            lblHour.Text = DateTime.Now.ToLongTimeString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dtvLivros.ClearSelection();

            String searchValue = txtSearch.Text;
            var rowIndex = new List<int>();

            foreach (DataGridViewRow row in dtvLivros.Rows)
            {
                string titulo = RemoveDiacritics(row.Cells["Titulo"].Value.ToString().ToLower());
                string autor = RemoveDiacritics(row.Cells["Autor"].Value.ToString().ToLower());

                if (txtSearch.Text == "" || txtSearch.Text == "Procure por título ou autor")
                {
                    row.Visible = true;
                    dtvLivros.FirstDisplayedScrollingRowIndex = 0;
                }
                else if (titulo.Contains(searchValue.ToLower()) || autor.Contains(searchValue.ToLower()))
                {
                    rowIndex.Add(row.Index);

                    for(int i = 0; i < rowIndex.Count; i++)
                    {
                        dtvLivros.Rows[rowIndex[i]].Visible = true;
                    }               
                }               
                else
                {     
                    row.Visible = false;
                }
            }
        }

        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Procure por título ou autor")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Procure por título ou autor";
                txtSearch.ForeColor = Color.Silver;
            }
        }

        private async void btnRequisitar_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await client.GetAsync(@"users/" + Nome);
            Utilizador resUser = res.ResultAs<Utilizador>();

            if(resUser.LivroRequisitado == "não")
            {
                PopUpRequisitar popUpRequisitar = new PopUpRequisitar();
                popUpRequisitar.Nome = Nome;
                popUpRequisitar.Password = Password;
                popUpRequisitar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Você já tem um livro requisitado. Limite de um livro por aluno.");
            }
        }

        private async void btnNotification_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await client.GetAsync(@"requisicoes");
            Dictionary<string, RequisitarLivro> dataRequisitar = JsonConvert.DeserializeObject<Dictionary<string, RequisitarLivro>>(res.Body.ToString());

            if (dataRequisitar.Where(ep => ep.Value.Nome == Nome && ep.Value.EstadoRequisicao == "aceite").Count() <= 0)
            {
                MessageBox.Show("Não tem notificações!");               
            }
            else
            {
                UserNotifications userNotifications = new UserNotifications();
                userNotifications.Nome = Nome;
                userNotifications.ShowDialog();
            }
        }
    }
}
