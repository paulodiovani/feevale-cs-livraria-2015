using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Livraria;

namespace LivrariaTest
{
    [TestClass]
    public class ConexaoTest
    {
        SqlConnection conexao = Conexao.Instance;

        [TestInitialize]
        public void SetUp()
        {
            conexao.ChangeDatabase("LivrariaTest");
        }

        [TestMethod]
        public void TestInstanceState()
        {
            Assert.AreEqual(conexao.State, ConnectionState.Open);
        }
    }
}
