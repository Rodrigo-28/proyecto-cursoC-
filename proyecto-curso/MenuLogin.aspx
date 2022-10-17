<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="proyecto_curso.MenuLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <h3>te logueaste correctamente</h3>
            <hr />
        </div>
        <div class="col-4">
            <asp:Button Text="Pagina 1" ID="btnPagina1" CssClass="btn btn-primary" OnClick="btnPagina1_Click" runat="server" />

        </div>
        <div class="col-4">
            <asp:Button Text="pagina 2" ID="btnpagina2" OnClick="btnpagina2_Click" CssClass="btn btn-primary" runat="server" />
            <p>tenes q ser admin</p>
        </div>

    </div>
</asp:Content>
