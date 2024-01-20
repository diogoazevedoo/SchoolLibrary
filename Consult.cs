using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SchoolLibrary
{
    public partial class Consult : Form
    {
        public Consult()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private async void Consult_Load(object sender, EventArgs e)
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

            FirebaseResponse res = await client.GetAsync(@"livros");
            Dictionary<string, Livro> data = JsonConvert.DeserializeObject<Dictionary<string, Livro>>(res.Body.ToString());
            PopulateDataGrid(data);
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

                    for (int i = 0; i < rowIndex.Count; i++)
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();

            AdminPanel adminPanel = new AdminPanel();
            adminPanel.ShowDialog();

            this.Close();
        }
    }
}
