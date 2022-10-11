<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="proyecto_curso.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="TxtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNumero" class="form-label">Numero: </label>
                <asp:TextBox runat="server" ID="TxtNumero" CssClass="form-control" />
            </div>



            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo: </label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad: </label>
                <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" runat="server" OnClick="btnAceptar_Click" />
                <a href="PokemonLista.aspx">Cancelar</a>
            </div>

        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtDescripcion" CssClass="form-control" />
            </div>
            
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="textImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://www.ceidra.org.py/img/imagennd.png" runat="server"
                        ID="imgPokemon" Width="60%" />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>
