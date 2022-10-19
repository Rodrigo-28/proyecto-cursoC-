<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EnviosEmail.aspx.cs" Inherits="proyecto_curso.EnviosEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>aqui es la pagina para enviar email</h1>
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
               <div class="mb-3">
                <label class="form-label">Asunto</label>
                <asp:TextBox runat="server" ID="TxtAsunto" CssClass="form-control" />
            </div>
               <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="TxtMensaje" CssClass="form-control" />
            </div>
            <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
        </div>
        <div class="col"></div>
    </div>
</asp:Content>
