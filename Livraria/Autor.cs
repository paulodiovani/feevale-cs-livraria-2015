using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Autor
    {
        #region variaveis privadas
        
        private int codAutor;
        private string nome;
        private string cpf;
        private DateTime dtNascimento;

        string servidor = "note-novo\\desenv";
        string banco = "Livraria";
        string usuario = "regis";
        string senha = "1234";

        #endregion

        #region Propriedades publicas

        public int CodAutor
        {
            get { return codAutor; }
            set { codAutor = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public DateTime DtNascimento
        {
            get { return dtNascimento; }
            set { dtNascimento = value; }
        }

        #endregion

        /// <summary>
        /// Cria um objeto da classe Autor
        /// </summary>
        public Autor()
        {

        }

        /// <summary>
        /// Cria um objeto da classe Autor e carrega suas informações
        /// </summary>
        /// <param name="parCodigo">Código do autor que deve ser carregado</param>
        public Autor(int parCodigo)
        {
            this.CodAutor = parCodigo;
            this.Consulta();
        }

        /// <summary>
        /// Consulta as informações de um autor
        /// </summary>
        public void Consulta()
        {
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Autor WHERE CodAutor = @Codigo");
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.Text;

                // Adicionar o parâmetro para filtrar as informações
                cmd.Parameters.AddWithValue("@Codigo", this.CodAutor);
                
                // Instancia o objeto SqlDataAdapter
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                // Cria e carrega uma tabela com os dados do Autor
                DataTable dtAutor = new DataTable();
                ad.Fill(dtAutor);

                // Verifica se foram retornadas limhas do banco de dados
                if (dtAutor.Rows.Count > 0)
                {
                    // Carrega as propriedades da classe
                    this.Cpf = dtAutor.Rows[0]["CPF"].ToString();
                    this.DtNascimento = Convert.ToDateTime(dtAutor.Rows[0]["DtNascimento"]);
                    this.Nome = dtAutor.Rows[0]["Nome"].ToString();
                }
                else
                {
                    // Informa que o código pesquisado não é valido
                    throw new Exception("Codigo informado inválido");
                }
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
        }

        /// <summary>
        /// Grava um novo autor no banco de dados
        /// </summary>
        /// <returns>Numero de registros inseridos</returns>
        public int Insere()
        {
            int NumInseridos = 0;

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
                SqlCommand cmd = new SqlCommand("INSERT INTO Autor(Nome, CPF, DtNascimento) VALUES(@Nome, @CPF, @DtNascimento)");
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.Text;

                // Adicionar os parâmetros necessários
                cmd.Parameters.AddWithValue("@Nome", this.Nome);
                cmd.Parameters.AddWithValue("@CPF", this.Cpf);
                cmd.Parameters.AddWithValue("@DtNascimento", this.DtNascimento);

                // Executa o comando informado
                NumInseridos = cmd.ExecuteNonQuery();

                return NumInseridos;
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

            return NumInseridos;
        }

        public List<Autor> ListaAutores()
        {
            List<Autor> lstAutores = new List<Autor>();

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
                SqlCommand cmd = new SqlCommand("SELECT CodAutor, Nome, CPF, DtNascimento FROM Autor");
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.Text;

                // Instancia o objeto SqlDataAdapter
                SqlDataReader rdAutor = cmd.ExecuteReader();

                if (rdAutor.HasRows)
                {
                    while (rdAutor.Read())
                    {
                        Autor au = new Autor
                        {
                            CodAutor = Convert.ToInt32(rdAutor["CodAutor"]),
                            Nome = rdAutor["Nome"].ToString(),
                            Cpf = rdAutor["CPF"].ToString(),
                            DtNascimento = Convert.ToDateTime(rdAutor["DtNascimento"])
                        };
                        
                        lstAutores.Add(au);
                    }
                }
                rdAutor.Close();
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

            return lstAutores;
        }
    }
}
