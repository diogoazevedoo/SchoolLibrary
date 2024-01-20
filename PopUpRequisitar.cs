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
using System.IO;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SchoolLibrary
{
    public partial class PopUpRequisitar : Form
    {
        public string Nome { get; set; }
        public string Password { get; set; }

        public PopUpRequisitar()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private async void PopUpRequisitar_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

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

            foreach(var item in data)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Titulo");
                dt.Rows.Add(item.Value.Titulo);

                if (item.Value.Requisitado == "Disponível")
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        comboBox1.Items.Add(row["Titulo"].ToString());
                    }
                }
            }           
        }

        public static Image Base64StringIntoImage(string str64)
        {
            byte[] img = Convert.FromBase64String(str64);
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;

            string titulo = comboBox1.SelectedItem.ToString();

            FirebaseResponse res = await client.GetAsync(@"livros/" + titulo);
            Livro resLivro = res.ResultAs<Livro>();

            pbCapa.Image = Base64StringIntoImage(resLivro.ImgString);
            lblTitulo.Text = titulo;
            lblAutor.Text = resLivro.Autor;
            lblEditora.Text = resLivro.Editora;
            lblAno.Text = resLivro.Ano;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private async void btnRequisitar_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "Home")
                {
                    frm.Hide();
                    frm.Close();
                }
            }

            string titulo = comboBox1.SelectedItem.ToString();

            FirebaseResponse res = await client.GetAsync(@"livros/" + titulo);
            Livro resLivro = res.ResultAs<Livro>();

            this.Hide();

            Requisitar requisitar = new Requisitar();
            requisitar.Nome = Nome;
            requisitar.Password = Password;
            requisitar.Titulo = titulo;
            requisitar.Autor = resLivro.Autor;
            requisitar.ImgString = resLivro.ImgString;
            requisitar.ISBN = resLivro.ISBN;
            requisitar.Editora = resLivro.Editora;
            requisitar.Ano = resLivro.Ano;
            requisitar.Idioma = resLivro.Idioma;
            resLivro.Paginas = resLivro.Paginas;
            requisitar.ShowDialog();

            this.Close();
        }
    }
}
