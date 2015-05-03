using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Livraria;
using System.Collections.Generic;

namespace LivrariaTest
{
    [TestClass]
    public class AutorTest
    {

        [TestMethod]
        public void TestProperties()
        {
            Autor autor = new Autor();

            autor.CodAutor = 999;
            autor.Nome = "George R. R. Martin";
            autor.Cpf = "012.345.678.90";
            autor.DtNascimento = new DateTime(1948, 9, 20);

            Assert.AreEqual(autor.CodAutor, 999);
            Assert.AreEqual(autor.Nome, "George R. R. Martin");
            Assert.AreEqual(autor.Cpf, "012.345.678.90");
            Assert.AreEqual<DateTime>(autor.DtNascimento, new DateTime(1948, 9, 20));
        }

        [TestMethod]
        public void TestListaAutores()
        {
            Autor autor = new Autor();
            List<Autor> lstAutores = autor.ListaAutores();

            foreach (var aut in lstAutores)
            {
                Assert.IsInstanceOfType(aut, typeof(Autor));
            }
        }

    }
}
