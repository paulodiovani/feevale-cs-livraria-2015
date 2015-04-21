using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Livraria;

namespace LivrariaWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Livro livros = new Livro();
            List<Livro> lstLivros = livros.ListaLivros();

            

            grdLivros.DataSource = lstLivros;
            grdLivros.DataBind();
        }
    }
}