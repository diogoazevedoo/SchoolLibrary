using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    class Livro
    {
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string ISBN { get; set; }

        public string Editora { get; set; }

        public string Ano { get; set; }

        public string Idioma { get; set; }

        public string Paginas { get; set; }

        public string ImgString { get; set; }

        public string Requisitado { get; set; }

        public string RequisitadoPor { get; set; }

        private static string error = "Este livro não existe!";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool IsEqual(Livro livro1, Livro livro2)
        {
            if (livro1 == null || livro2 == null) { return false; }

            if (livro1.Titulo != livro2.Titulo)
            {
                error = "Este livro não existe!";
                return false;
            }

            return true;
        }

        public static bool IsEqualRequisitar(Livro livro1, Livro livro2)
        {
            if (livro1 == null || livro2 == null) { return false; }

            if (livro1.Titulo != livro2.Titulo)
            {
                error = "Este livro não existe!";
                return false;
            }

            if (livro1.Requisitado != livro2.Requisitado)
            {
                error = "Este livro já está requisitado";
                return false;
            }

            return true;
        }
    }
}
