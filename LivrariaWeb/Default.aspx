<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LivrariaWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Livraria Web</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grdLivros" runat="server" autogeneratecolumns="false">
            <Columns>
                <asp:BoundField DataField="Titulo" HeaderText="Título" SortExpression="Titulo" />
                <asp:BoundField DataField="NumPaginas" HeaderText="Páginas" />
                <asp:BoundField DataField="Ano" HeaderText="Lançamento" />
                <asp:BoundField DataField="Editora" HeaderText="Editora" />
                <asp:BoundField DataField="Preco" HeaderText="Valor" SortExpression="Preco" DataFormatString="{0:C}" />
                <asp:HyperLinkField HeaderText="Ações" DataNavigateUrlFields="CodLivro" DataNavigateUrlFormatString="CadLivro.aspx?CodLivro={0}" Text="Editar" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
