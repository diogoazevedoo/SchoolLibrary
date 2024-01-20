using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    internal class RequisitarLivro
    {
        public string IdRequisicao { get; set; }
        public string ImgString { get; set; }

        public string Titulo { get; set; }

        public string Nome { get; set; }

        public string DataLevantamento { get; set; }

        public string DataEntrega { get; set; }

        public string EstadoRequisicao { get; set; }
    }
}
