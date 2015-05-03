using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        string servidor = "windows\\sqlexpress";
        string banco = "Livraria";
        string usuario = "sa";
        string senha = "feevale";

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

        public List<Livro> ListaLivros()
        {
            List<Livro> lstLivros = new List<Livro>();

            // Cria uma instância da classe SqlConnection
            SqlConnection cnn = new SqlConnection();

            // Estabelece a string de conexão com o banco de dados
            // Consultar http://www.connectionstrings.com para obter mais tipos de string de conexão
            cnn.ConnectionString = "Data Source=" + servidor + ";" +
                "Initial Catalog=" + banco + ";" +
                "User ID=" + usuario + ";" +
                "Password=" + senha + ";" +
                "Current Language=us_english;Connection Timeout=10";

            try
            {
                // Abre a conexão com o banco de dados
                cnn.Open();

                // Informando dados basicos do comando a ser executado
                SqlCommand cmd = new SqlCommand("SELECT CodLivro, Titulo, NumPaginas, Ano, Editora, Preco, CodAutor FROM Livro");
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.Text;

                // Instancia o objeto SqlDataAdapter
                SqlDataReader rdLivro = cmd.ExecuteReader();

                if (rdLivro.HasRows)
                {
                    while (rdLivro.Read())
                    {
                        Livro l = new Livro
                        {
                            CodLivro = Convert.ToInt32(rdLivro["CodLivro"]),
                            Titulo = rdLivro["Titulo"].ToString(),
                            NumPaginas = Convert.ToInt32(rdLivro["NumPaginas"]),
                            Ano = Convert.ToInt32(rdLivro["Ano"]),
                            Editora = rdLivro["Editora"].ToString(),
                            Preco = Convert.ToDecimal(rdLivro["Preco"]),
                            Autorlivro = new Autor(Convert.ToInt32(rdLivro["CodAutor"]))
                        };

                        lstLivros.Add(l);
                    }
                }
                rdLivro.Close();
            }
            catch (Exception ex)
            {
                // Em caso de falha, informa ao usuário
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                cnn.Close();
            }

            return lstLivros;
        }
    }
}
