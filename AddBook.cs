using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SchoolLibrary
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private void AddBook_Load(object sender, EventArgs e)
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

            AdminPanel AdminPanel = new AdminPanel();
            AdminPanel.ShowDialog();

            this.Close();
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbImagem.Image = new Bitmap(openFileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Introduza um formato correto de imagem");
                }
            }
        }

        public static string ImageIntoBase64String(PictureBox pictureBox)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
            return Convert.ToBase64String(ms.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTitulo.Text) && string.IsNullOrEmpty(txtAutor.Text) && string.IsNullOrEmpty(txtISBN.Text) && string.IsNullOrEmpty(txtEditora.Text) && string.IsNullOrEmpty(txtAno.Text) && string.IsNullOrEmpty(txtIdioma.Text) && string.IsNullOrEmpty(txtPaginas.Text) && pbImagem.Image == null && pbImagem == null)
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }
            else
            {
                Livro livro = new Livro()
                {
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    ISBN = txtISBN.Text,
                    Editora = txtEditora.Text,
                    Ano = txtAno.Text,
                    Idioma = txtIdioma.Text,
                    Paginas = txtPaginas.Text,
                    ImgString = ImageIntoBase64String(pbImagem),
                    Requisitado = "Disponível",
                    RequisitadoPor = ""
                };

                FirebaseResponse response = client.Set(@"livros/" + txtTitulo.Text, livro);
                MessageBox.Show("Livro adicionado com sucesso!");
            }
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDay.Text = DateTime.Now.ToLongDateString();
            lblHour.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
