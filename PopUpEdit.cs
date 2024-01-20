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
    public partial class PopUpEdit : Form
    {
        public PopUpEdit()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private async void PopUpEdit_Load(object sender, EventArgs e)
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

            foreach (var item in data)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Titulo");
                dt.Rows.Add(item.Value.Titulo);

                foreach (DataRow row in dt.Rows)
                {
                    comboBox1.Items.Add(row["Titulo"].ToString());
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

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "AdminPanel")
                {
                    frm.Hide();
                    frm.Close();
                }
            }

            string titulo = comboBox1.SelectedItem.ToString();

            FirebaseResponse res1 = await client.GetAsync(@"livros/" + titulo);
            Livro resLivro = res1.ResultAs<Livro>();

            this.Hide();

            EditBook editBook = new EditBook();
            editBook.Titulo = titulo;
            editBook.Autor = resLivro.Autor;
            editBook.ISBN = resLivro.ISBN;
            editBook.Editora = resLivro.Editora;
            editBook.Ano = resLivro.Ano;
            editBook.Idioma = resLivro.Idioma;
            editBook.Paginas = resLivro.Paginas;
            editBook.ImgString = resLivro.ImgString;
            editBook.ShowDialog();

            this.Close();
        }
    }
}
