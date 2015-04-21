using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Livro
    {
        #region variaveis privadas

        private int codLivro;
        private string titulo;
        private int numPaginas;
        private int ano;
        private string editora;
        private decimal preco;
        private Autor autorlivro;

        #endregion

        #region Propriedades publicas

        public int CodLivro
        {
            get { return codLivro; }
            set { codLivro = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public int NumPaginas
        {
            get { return numPaginas; }
            set { numPaginas = value; }
        }

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        public string Editora
        {
            get { return editora; }
            set { editora = value; }
        }

        public decimal Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public Autor Autorlivro
        {
            get { return autorlivro; }
            set { autorlivro = value; }
        }

        #endregion

        public Livro()
        {

        }

        
    }
}
