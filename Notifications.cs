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
    public partial class Notifications : Form
    {
        public Notifications()
        {
            InitializeComponent();
        }

        IFirebaseConfig fbconfig = new FirebaseConfig()
        {
            AuthSecret = "pNEPZanEUf6xI3kpn17jaJx2IEs69uLQHtJC3I36",
            BasePath = "https://schoollibrary-c1a8a-default-rtdb.europe-west1.firebasedatabase.app"
        };

        IFirebaseClient client;

        private async void Notifications_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(0, 40);
            timerDateTime.Start();
            btnAceitar.BringToFront();
            btnRecusar.BringToFront();

            try
            {
                client = new FireSharp.FirebaseClient(fbconfig);
            }
            catch
            {
                MessageBox.Show("Falha na ligação.");
            }

            FirebaseResponse res = await client.GetAsync(@"requisicoes");
            Dictionary<string, RequisitarLivro> data = JsonConvert.DeserializeObject<Dictionary<string, RequisitarLivro>>(res.Body.ToString());
            PopulateDataGridPendentes(data);
            PopulateDataGridEntregas(data);
            PopulateDataGridHistorico(data);
        }

        public static Image Base64StringIntoImage(string str64)
        {
            byte[] img = Convert.FromBase64String(str64);
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }

        void PopulateDataGridPendentes(Dictionary<string, RequisitarLivro> record)
        {
            dgvPendentes.Rows.Clear();
            dgvPendentes.Columns.Clear();

            dgvPendentes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPendentes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPendentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendentes.RowTemplate.Height = 100;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img.HeaderText = "Capa";
            img.Name = "Capa";
            dgvPendentes.Columns.Add("ID", "ID");
            dgvPendentes.Columns.Add(img);
            dgvPendentes.Columns.Add("Titulo", "Título");
            dgvPendentes.Columns.Add("Nome", "Nome");
            dgvPendentes.Columns.Add("Data Levantamento", "Data Levantamento");
            dgvPendentes.Columns.Add("Data Entrega", "Data Entrega");

            foreach (var item in record)
            {
                if(item.Value.EstadoRequisicao == "pendente" || item.Value.EstadoRequisicao == "aceite")
                {
                    dgvPendentes.Rows.Add(item.Key, Base64StringIntoImage(item.Value.ImgString), item.Value.Titulo, item.Value.Nome, item.Value.DataLevantamento, item.Value.DataEntrega);
                }
                
                foreach(DataGridViewRow row in dgvPendentes.Rows)
                {
                    if(item.Value.EstadoRequisicao == "aceite")
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }

        void PopulateDataGridEntregas(Dictionary<string, RequisitarLivro> record)
        {
            dgvEntregas.Rows.Clear();
            dgvEntregas.Columns.Clear();

            dgvEntregas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEntregas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntregas.RowTemplate.Height = 100;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img.HeaderText = "Capa";
            img.Name = "Capa";
            dgvEntregas.Columns.Add("ID", "ID");
            dgvEntregas.Columns.Add(img);
            dgvEntregas.Columns.Add("Titulo", "Título");
            dgvEntregas.Columns.Add("Nome", "Nome");
            dgvEntregas.Columns.Add("Data Levantamento", "Data Levantamento");
            dgvEntregas.Columns.Add("Data Entrega", "Data Entrega");

            foreach (var item in record)
            {
                if (item.Value.EstadoRequisicao == "requisitado")
                {
                    dgvEntregas.Rows.Add(item.Key, Base64StringIntoImage(item.Value.ImgString), item.Value.Titulo, item.Value.Nome, item.Value.DataLevantamento, item.Value.DataEntrega);
                }
            }
        }

        void PopulateDataGridHistorico(Dictionary<string, RequisitarLivro> record)
        {
            dgvHistorico.Rows.Clear();
            dgvHistorico.Columns.Clear();

            dgvHistorico.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorico.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorico.RowTemplate.Height = 100;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img.HeaderText = "Capa";
            img.Name = "Capa";
            dgvHistorico.Columns.Add("ID", "ID");
            dgvHistorico.Columns.Add(img);
            dgvHistorico.Columns.Add("Titulo", "Título");
            dgvHistorico.Columns.Add("Nome", "Nome");
            dgvHistorico.Columns.Add("Data Levantamento", "Data Levantamento");
            dgvHistorico.Columns.Add("Data Entrega", "Data Entrega");

            foreach (var item in record)
            {
                if (item.Value.EstadoRequisicao == "entregue")
                {
                    dgvHistorico.Rows.Add(item.Key, Base64StringIntoImage(item.Value.ImgString), item.Value.Titulo, item.Value.Nome, item.Value.DataLevantamento, item.Value.DataEntrega);
                }
            }
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDay.Text = DateTime.Now.ToLongDateString();
            lblHour.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();

            AdminPanel adminPanel = new AdminPanel();
            adminPanel.ShowDialog();

            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab.Name == "tpEntregas")
            {
                btnAceitar.Hide();
                btnEntregue.Show();
                btnEntregue.BringToFront();
            }

            if(tabControl1.SelectedTab.Name == "tpPendentes")
            {
                btnAceitar.Show();
                btnRecusar.Show();
                btnRecusar.BringToFront();
            }

            if(tabControl1.SelectedTab.Name == "tpHistorico")
            {
                btnAceitar.Hide();
                btnRecusar.Hide();
                btnEntregue.Hide();
            }
        }

        private async void btnAceitar_Click(object sender, EventArgs e)
        {
            if (dgvPendentes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvPendentes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvPendentes.Rows[selectedrowindex];
                string cellValueTitulo = Convert.ToString(selectedRow.Cells["Titulo"].Value);
                string cellValueID = Convert.ToString(selectedRow.Cells["ID"].Value);

                FirebaseResponse res1 = client.Get(@"livros/" + cellValueTitulo);
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
                    Requisitado = "Pendente",
                    RequisitadoPor = resLivro.RequisitadoPor
                };

                FirebaseResponse res2 = await client.UpdateAsync(@"livros/" + resLivro.Titulo, aceiteRequisito);

                FirebaseResponse res3 = client.Get(@"requisicoes/" + cellValueID);
                RequisitarLivro resRequisitar = res3.ResultAs<RequisitarLivro>();

                RequisitarLivro aceitarRequisicao = new RequisitarLivro()
                {
                    IdRequisicao = resRequisitar.IdRequisicao,
                    ImgString = resRequisitar.ImgString,
                    Titulo = resRequisitar.Titulo,
                    Nome = resRequisitar.Nome,
                    DataLevantamento = resRequisitar.DataLevantamento,
                    DataEntrega = resRequisitar.DataEntrega,
                    EstadoRequisicao = "aceite"
                };

                FirebaseResponse res4 = await client.UpdateAsync(@"requisicoes/" + resRequisitar.IdRequisicao, aceitarRequisicao);

                FirebaseResponse res5 = await client.GetAsync(@"users/" + resRequisitar.Nome);
                Utilizador resUser = res5.ResultAs<Utilizador>();

                Utilizador recusaUser = new Utilizador()
                {
                    Nome = resRequisitar.Nome,
                    Password = resUser.Password,
                    LivroRequisitado = "sim"
                };

                FirebaseResponse res6 = await client.UpdateAsync(@"users/" + resRequisitar.Nome, recusaUser);

                MessageBox.Show("O pedido de requisição foi aceite!");

                selectedRow.DefaultCellStyle.BackColor = Color.Green;
            }
            else
            {
                MessageBox.Show("Selecione o pedido que deseja aceitar.");
            }
        }

        private async void btnRecusar_Click(object sender, EventArgs e)
        {
            if (dgvPendentes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvPendentes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvPendentes.Rows[selectedrowindex];
                string cellValueTitulo = Convert.ToString(selectedRow.Cells["Titulo"].Value);
                string cellValueID = Convert.ToString(selectedRow.Cells["ID"].Value);

                FirebaseResponse res1 = client.Get(@"livros/" + cellValueTitulo);
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

                FirebaseResponse res3 = client.Get(@"requisicoes/" + cellValueID);
                RequisitarLivro resRequisitar = res3.ResultAs<RequisitarLivro>();

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

                MessageBox.Show("O pedido de requisição foi recusado!");
            }
            else
            {
                MessageBox.Show("Selecione o pedido que deseja recusar.");
            }
        }

        private async void btnEntregue_Click(object sender, EventArgs e)
        {
            if (dgvEntregas.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvEntregas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEntregas.Rows[selectedrowindex];
                string cellValueTitulo = Convert.ToString(selectedRow.Cells["Titulo"].Value);
                string cellValueID = Convert.ToString(selectedRow.Cells["ID"].Value);

                FirebaseResponse res1 = client.Get(@"livros/" + cellValueTitulo);
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

                FirebaseResponse res3 = client.Get(@"requisicoes/" + cellValueID);
                RequisitarLivro resRequisitar = res3.ResultAs<RequisitarLivro>();

                RequisitarLivro recusarRequisicao = new RequisitarLivro()
                {
                    IdRequisicao = resRequisitar.IdRequisicao,
                    ImgString = resRequisitar.ImgString,
                    Titulo = resRequisitar.Titulo,
                    Nome = resRequisitar.Nome,
                    DataLevantamento = resRequisitar.DataLevantamento,
                    DataEntrega = resRequisitar.DataEntrega,
                    EstadoRequisicao = "entregue"
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

                MessageBox.Show("O pedido de requisição foi entregue!");
            }
            else
            {
                MessageBox.Show("Selecione o pedido que deseja entregar.");
            }
        }
    }
}
