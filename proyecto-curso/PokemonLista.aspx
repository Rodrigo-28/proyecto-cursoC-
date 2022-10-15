<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="proyecto_curso.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de pokemon!</h1>
    <div class="row">

        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="Txtfiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro avanzado" runat="server"
                    CssClass="" ID="chkAvanzado"
                    AutoPostBack="true"
                    OnCheckedChanged="chkAvanzado_CheckedChanged" />

            </div>

        </div>


        <%if (FiltroAvanzado)
            {%>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCampo" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Tipo" />
                        <asp:ListItem Text="Numero" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Estado" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                        <asp:ListItem Text="Todos" />
                        <asp:ListItem Text="Activo" />
                        <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                    <asp:Button Text="Limpiar Filtro" runat="server" CssClass="btn btn-warning" ID="btnLimpiar" OnClick="btnLimpiar_Click" />

                </div>

            </div>
        </div>
        <% }  %>
    </div>












    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:ScriptManager runat="server" />

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
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="&#9997;" />
                    <%--<asp:BoundField HeaderText="Debilidad" DataField="Debilidad.descripcion" />--%>
                </Columns>
            </asp:GridView>
            <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>


        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

