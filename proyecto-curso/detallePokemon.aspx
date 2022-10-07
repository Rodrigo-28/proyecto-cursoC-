<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="detallePokemon.aspx.cs" Inherits="proyecto_curso.detallePokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex justify-content-center p-5">
        <div class="card" style="width: 18rem;">
            <img src="<%:Seleccionado.urlImagen %>" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Nombre Pokemon</h5>
                <p>Numero:<span><%:Seleccionado.Numero %></span></p>
                <p class="card-text"><%:Seleccionado.Descripcion %></p>
                <p>Debilidad:<span class="text-bg-info"><%:Seleccionado.Debilidad %></span></p>
                <p>Tipo:<span class="text-bg-info"><%:Seleccionado.Tipo %></span></p>
                <asp:Button Text="Volver" runat="server" CssClass="btn btn-primary" OnClick="Unnamed_Click" />



            </div>
        </div>
    </div>
</asp:Content>
