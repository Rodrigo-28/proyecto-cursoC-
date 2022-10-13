<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="proyecto_curso.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>hola!</h1>
    <p>llegaste al pokedex web,tu lugar pokemon</p>
    <asp:GridView ID="dgvpokemon" runat="server" CssClass="table" AutoGenerateColumns="false"
        DataKeyNames="Id" OnSelectedIndexChanged="dgvpokemon_SelectedIndexChanged"
        OnPageIndexChanging="dgvpokemon_PageIndexChanging"
        AllowPaging="true" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Numero" DataField="Numero" />
            <%--<asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />--%>
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.descripcion" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" /> 
           <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="&#9997;"/>
            <%--<asp:BoundField HeaderText="Debilidad" DataField="Debilidad.descripcion" />--%>
        </Columns>
    </asp:GridView>
    <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
