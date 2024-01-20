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
    public partial class Requisitar : Form
    {
        public string Nome { get; set; }

        public string Password { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string ImgString { get; set; }

        public string ISBN { get; set; }

        public string Editora { get; set; }

        public string Ano { get; set; }

        public string Idioma { get; set; }

        public string Paginas { get; set; }

        public Requisitar()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDay.Text = DateTime.Now.ToLongDateString();
            lblHour.Text = DateTime.Now.ToLongTimeString();
        }  

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();

            Home home = new Home();
            home.Nome = Nome;
            home.ShowDialog();

            this.Close();
        }

        private void Requisitar_Load(object sender, EventArgs e)
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

            FirebaseResponse res = client.Get(@"livros/" + Titulo);
            Livro resLivro = res.ResultAs<Livro>();

            lblTitulo.Text = Titulo;
            lblAutor.Text = Autor;
            pbImagem.Image = Base64StringIntoImage(ImgString);
            lblDataAtual.Text = DateTime.Now.ToLongDateString();
            dtpRequisitar.MinDate = DateTime.Now.AddDays(+1);
            dtpRequisitar.MaxDate = DateTime.Now.AddDays(+7);
        }

        public static Image Base64StringIntoImage(string str64)
        {
            byte[] img = Convert.FromBase64String(str64);
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }

        private void btnRequisitar_Click(object sender, EventArgs e)
        {
            if (cbTermos.Checked)
            {
                Random r = new Random();
                var id = r.Next(0, 1000000);

                Livro livro = new Livro()
                {
                    Titulo = Titulo,
                    Autor = Autor,
                    ISBN = ISBN,
                    Editora = Editora,
                    Ano = Ano,
                    Idioma = Idioma,
                    Paginas = Paginas,
                    ImgString = ImgString,
                    Requisitado = "Pendente",
                    RequisitadoPor = Nome
                };

                FirebaseResponse res2 = client.Update(@"livros/" + Titulo, livro);
                MessageBox.Show("O seu pedido de requisição foi enviado. Aguarde uma resposta.");

                RequisitarLivro Requisição = new RequisitarLivro()
                {
                    IdRequisicao = Convert.ToString(id),
                    ImgString = ImgString,
                    Titulo = Titulo,
                    Nome = Nome,
                    DataLevantamento = DateTime.Now.ToShortDateString(),
                    DataEntrega = dtpRequisitar.Value.ToShortDateString(),
                    EstadoRequisicao = "pendente"
                };

                FirebaseResponse res3 = client.Set(@"requisicoes/" + id, Requisição);

                Utilizador user = new Utilizador()
                {
                    Nome = Nome,
                    Password = Password,
                    LivroRequisitado = "sim"
                };

                FirebaseResponse res4 = client.Update(@"users/" + Nome, user);
            }
            else
            {
                MessageBox.Show("Aceite os Termos e Condições!");
            }
        }
    }
}
