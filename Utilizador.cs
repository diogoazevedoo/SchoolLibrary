using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    class Utilizador
    {
        public string Nome { get; set; }

        public string Password { get; set; }

        public string LivroRequisitado { get; set; }

        private static string error = "Utilizador não existe";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool IsEqual(Utilizador user1, Utilizador user2)
        {
            if(user1 == null || user2 == null) { return false; }

            if(user1.Nome != user2.Nome)
            {
                error = "Este utilizador não existe!";
                return false;
            }
            else if(user1.Password != user2.Password) 
            {
                error = "Password inválida!";
                return false;
            }

            return true;
        }
    }
}
