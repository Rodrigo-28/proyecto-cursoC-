<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="proyecto_curso.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <asp:ScriptManager runat="server" />

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
                <asp:Button Text="inactivar" ID="btnInactivar" OnClick="btnInactivar_Click" runat="server" CssClass="btn btn-warning" />
                <a href="PokemonLista.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtDescripcion" CssClass="form-control" />
            </div>

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




    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <asp:Button Text="Elimniar" ID="btnEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click" />
                    </div>
                    <%if (ConfirmaEliminacion)
                        {%>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar eliminacion" ID="chkConfirmarEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmarEliminar" CssClass="btn btn-outline-danger" runat="server" OnClick="btnConfirmarEliminar_Click"/>
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>
