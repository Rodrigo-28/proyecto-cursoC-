<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="proyecto_curso.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>hola!</h1>
    <p>llegaste al pokedex web,tu lugar pokemon</p>
    <asp:GridView ID="dgvpokemon" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Numero" DataField="Numero" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />


            <asp:BoundField HeaderText="Tipo" DataField="Tipo.descripcion" />
            <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.descripcion" />



        </Columns>
    </asp:GridView>
</asp:Content>
