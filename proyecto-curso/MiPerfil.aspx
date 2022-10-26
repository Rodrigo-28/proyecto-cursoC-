<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="proyecto_curso.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
             <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"  />
            </div>
              <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido"  />
            </div>
             <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class ="form-label">Imagen Perfil</label>
                <input type="file" id="txtImage" runat="server"  class="form-control"/>
            </div>
            <asp:Image ImageUrl="https://plantillasdememes.com/img/plantillas/imagen-no-disponible01601774755.jpg" ID="imgNuevoPerfil" CssClass="img-fluid mb-3" runat="server" />
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" />
                <a href="/">Regresar</a>
            </div>
        </div>

    </div>
</asp:Content>
