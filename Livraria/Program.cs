using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    class Program
    {
        static void Main(string[] args)
        {
            Autor aut = new Autor();

            //Console.WriteLine("Consultando um Autor");
            //Console.WriteLine("--------------------");

            //Console.WriteLine("Digite o código do autor para pesquisar: ");
            //aut.CodAutor = int.Parse(Console.ReadLine());

            //aut.Consulta();

            //Console.WriteLine("O nome do autor pesquisado é " + aut.Nome + " e nasceu no dia " + aut.DtNascimento.ToString("dd/MM/yyyy"));
            
            //Console.WriteLine("Pressione Enter para continuar");
            //Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();
            /*
            Console.WriteLine("Inserindo um novo Autor");
            Console.WriteLine("-----------------------");

            aut = new Autor();

            Console.WriteLine("Digite o nome do autor: ");
            aut.Nome = Console.ReadLine();

            Console.WriteLine("Digite o cpf do autor: ");
            aut.Cpf = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento do autor: ");
            aut.DtNascimento = Convert.ToDateTime(Console.ReadLine());

            aut.Insere();
            */

            /*
            Console.WriteLine("Lista de autores");
            Console.WriteLine("----------------");

            List<Autor> lst = aut.ListaAutores();
            foreach (Autor a in lst)
            {
                Console.WriteLine(a.Nome);
            }

            Console.WriteLine();
            Console.WriteLine("Lista de autores ordenada");
            Console.WriteLine("-------------------------");

            var lstOrd = lst.OrderBy(au => au.Nome);

            foreach (Autor au in lstOrd)
            {
                Console.WriteLine(au.Nome);
            }

            Console.WriteLine();
            Console.WriteLine("Autores em um array invertido");
            Console.WriteLine("-----------------------------");

            Autor[] arrAut = lst.AsEnumerable().Reverse().ToArray();
            for (int i = 0; i < arrAut.Length; i++)
            {
                Console.WriteLine(arrAut[i].Nome);
            }

            Console.WriteLine();
            Console.WriteLine("Lista de autores ordenada decrescente");
            Console.WriteLine("-------------------------------------");

            var lstOrdDesc = from a in lst
                             orderby a.Nome descending
                             select a;

            foreach (Autor a in lstOrdDesc)
            {
                Console.WriteLine(a.Nome);
            }

            string[] cpfs = (from a in lst
                            select a.Cpf).ToArray();

            Console.WriteLine();
            Console.WriteLine("Lista de CPFs");
            Console.WriteLine("-------------");

            for (int i = 0; i < cpfs.Length; i++)
            {
                Console.WriteLine(cpfs[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Autores que tem a palavra coelho no nome");
            Console.WriteLine("-------------");

            var lstNomeContains = lst.Where(a => a.Nome.ToLower().Contains("coelho"));

            foreach (Autor au in lstNomeContains)
            {
                Console.WriteLine(au.Nome);
            }

            Console.WriteLine();
            Console.WriteLine("Autor mais velho");
            Console.WriteLine("-------------");

            var autorMaisVelho = lst.OrderBy(a => a.DtNascimento).First();
            Console.WriteLine(autorMaisVelho.Nome);

            Console.WriteLine();
            Console.WriteLine("Autor mais novo");
            Console.WriteLine("-------------");

            var autorMaisNovo = lst.OrderByDescending(a => a.DtNascimento).First();
            Console.WriteLine(autorMaisNovo.Nome);
            */

            Livro livros = new Livro();

            Console.WriteLine("Lista de livros");
            Console.WriteLine("----------------");

            List<Livro> lstLivros = livros.ListaLivros();

            foreach (Livro l in lstLivros)
            {
                Console.WriteLine("Titulo: " + l.Titulo + "\r\n\t" + l.Autorlivro.Nome + " (" + l.Ano.ToString() + ")");
            }

            Console.WriteLine();
            Console.WriteLine("Soma dos preços dos livros");
            Console.WriteLine("--------------------------");

            decimal vlrTotal = lstLivros.Sum(l => l.Preco);

            Console.WriteLine();
            Console.WriteLine("Menor preço");
            Console.WriteLine("--------------------------");

            decimal vlrMinimo = lstLivros.Min(l => l.Preco);

            Console.WriteLine(vlrMinimo);

            Console.WriteLine();
            Console.WriteLine("Maior preço");
            Console.WriteLine("--------------------------");

            decimal vlrMaximo = lstLivros.Max(l => l.Preco);

            Console.WriteLine(vlrMaximo);

            var lstGroup = lstLivros.GroupBy(l => l.Autorlivro.CodAutor)
                                    .Select(grp => new
                                    {
                                        ID = grp.Key,
                                        QtdLivros = grp.Count(l => l.Autorlivro.CodAutor == grp.Key),
                                        MaisBarato = grp.Min(l => l.Preco),
                                        MaisCaro = grp.Max(l => l.Preco)
                                    });

            foreach (var infos in lstGroup)
            {
                Console.WriteLine("Autor: " + infos.ID + "; Qtd. Livros: " + infos.QtdLivros.ToString() + "; Mais barato: " + infos.MaisBarato + "; Mais caro: " + infos.MaisCaro);
            }

            Console.Read();
        }
    }
}
