using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public static class Conexao
    {
        private static string strConexao = @"Data Source=localhost\sqlexpress;Initial Catalog=Livraria;User Id=sa;Password=feevale";
        private static readonly SqlConnection instance = new SqlConnection(strConexao);

        /// <summary>
        /// Retorna um objeto do tipo SqlConnection contendo a conexão com o banco de dados
        /// </summary>
        public static SqlConnection Instance
        {
            get
            {
                if (instance.State == ConnectionState.Closed)
                {
                    instance.Open();
                }

                return instance;
            }
        }

    }
}
