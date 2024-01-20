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
using Newtonsoft.Json;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SchoolLibrary
{
    public partial class UserNotifications : Form
    {
        public string Nome { get; set; }

        public UserNotifications()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private async void UserNotifications_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fbconfig);
            }
            catch
            {
                MessageBox.Show("Falha na ligação.");
            }

            FirebaseResponse res = await client.GetAsync(@"requisicoes");
            Dictionary<string, RequisitarLivro> dataRequisitar = JsonConvert.DeserializeObject<Dictionary<string, RequisitarLivro>>(res.Body.ToString());

            foreach(var item in dataRequisitar)
            {
                if (item.Value.Nome == Nome && item.Value.EstadoRequisicao == "aceite")
                {
                    FirebaseResponse res2 = await client.GetAsync(@"livros/" + item.Value.Titulo);
                    Livro resLivro = res2.ResultAs<Livro>();

                    pictureBox1.Image = Base64StringIntoImage(item.Value.ImgString);
                    lblTitulo.Text = item.Value.Titulo;
                    lblAutor.Text = resLivro.Autor;
                    lblDataLevantamento.Text = item.Value.DataLevantamento;
                    lblDataEntrega.Text = item.Value.DataEntrega;
                }
            }
        }

        public static Image Base64StringIntoImage(string str64)
        {
            byte[] img = Convert.FromBase64String(str64);
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            FirebaseResponse res1 = client.Get(@"livros/" + lblTitulo.Text);
            Livro resLivro = res1.ResultAs<Livro>();

            Livro recusoRequisitado = new Livro
            {
                Titulo = resLivro.Titulo,
                Autor = resLivro.Autor,
                ISBN = resLivro.ISBN,
                Editora = resLivro.Editora,
                Ano = resLivro.Ano,
                Idioma = resLivro.Idioma,
                Paginas = resLivro.Paginas,
                ImgString = resLivro.ImgString,
                Requisitado = "Disponível",
                RequisitadoPor = ""
            };

            FirebaseResponse res2 = await client.UpdateAsync(@"livros/" + resLivro.Titulo, recusoRequisitado);

            FirebaseResponse res3 = client.Get(@"requisicoes");
            Dictionary<string, RequisitarLivro> dataRequisitar = JsonConvert.DeserializeObject<Dictionary<string, RequisitarLivro>>(res3.Body.ToString());

            string ID = "";

            foreach (var item in dataRequisitar)
            {
                if (item.Value.Nome == Nome && item.Value.EstadoRequisicao == "aceite")
                {
                    ID = item.Value.IdRequisicao;
                }
            }

            FirebaseResponse resRequisitar2 = client.Get(@"requisicoes/" + ID);
            RequisitarLivro resRequisitar = resRequisitar2.ResultAs<RequisitarLivro>();

            RequisitarLivro recusarRequisicao = new RequisitarLivro()
            {
                IdRequisicao = resRequisitar.IdRequisicao,
                ImgString = resRequisitar.ImgString,
                Titulo = resRequisitar.Titulo,
                Nome = resRequisitar.Nome,
                DataLevantamento = resRequisitar.DataLevantamento,
                DataEntrega = resRequisitar.DataEntrega,
                EstadoRequisicao = "cancelado"
            };

            FirebaseResponse res4 = await client.UpdateAsync(@"requisicoes/" + resRequisitar.IdRequisicao, recusarRequisicao);

            FirebaseResponse res5 = await client.GetAsync(@"users/" + resRequisitar.Nome);
            Utilizador resUser = res5.ResultAs<Utilizador>();

            Utilizador recusaUser = new Utilizador()
            {
                Nome = resRequisitar.Nome,
                Password = resUser.Password,
                LivroRequisitado = "não"
            };

            FirebaseResponse res6 = await client.UpdateAsync(@"users/" + resRequisitar.Nome, recusaUser);

            MessageBox.Show("A sua requisição foi cancelada!");

            this.Hide();
            this.Close();
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            FirebaseResponse res1 = client.Get(@"livros/" + lblTitulo.Text);
            Livro resLivro = res1.ResultAs<Livro>();

            Livro aceiteRequisito = new Livro
            {
                Titulo = resLivro.Titulo,
                Autor = resLivro.Autor,
                ISBN = resLivro.ISBN,
                Editora = resLivro.Editora,
                Ano = resLivro.Ano,
                Idioma = resLivro.Idioma,
                Paginas = resLivro.Paginas,
                ImgString = resLivro.ImgString,
                Requisitado = "Requisitado",
                RequisitadoPor = resLivro.RequisitadoPor
            };

            FirebaseResponse res2 = await client.UpdateAsync(@"livros/" + resLivro.Titulo, aceiteRequisito);

            FirebaseResponse res3 = client.Get(@"requisicoes");
            Dictionary<string, RequisitarLivro> dataRequisitar = JsonConvert.DeserializeObject<Dictionary<string, RequisitarLivro>>(res3.Body.ToString());

            string ID = "";

            foreach (var item in dataRequisitar)
            {
                if (item.Value.Nome == Nome && item.Value.EstadoRequisicao == "aceite")
                {
                    ID = item.Value.IdRequisicao;
                }
            }

            FirebaseResponse resRequisitar2 = client.Get(@"requisicoes/" + ID);
            RequisitarLivro resRequisitar = resRequisitar2.ResultAs<RequisitarLivro>();

            RequisitarLivro aceitarRequisicao = new RequisitarLivro()
            {
                IdRequisicao = resRequisitar.IdRequisicao,
                ImgString = resRequisitar.ImgString,
                Titulo = resRequisitar.Titulo,
                Nome = resRequisitar.Nome,
                DataLevantamento = resRequisitar.DataLevantamento,
                DataEntrega = resRequisitar.DataEntrega,
                EstadoRequisicao = "requisitado"
            };

            FirebaseResponse res4 = await client.UpdateAsync(@"requisicoes/" + resRequisitar.IdRequisicao, aceitarRequisicao);

            MessageBox.Show("Livro requisitado! Dirija-se a biblioteca para o levantar.");

            this.Hide();
            this.Close();
        }
    }
}
