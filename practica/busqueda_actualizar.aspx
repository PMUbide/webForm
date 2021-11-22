<%@ Page Language="C#" AutoEventWireup="true" CodeFile="busqueda_actualizar.aspx.cs" Inherits="busqueda_actualizar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
          <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <div>
            <table class="table">
                <tr>
                    <th>Cod</th>
                    <th>Nombre</th>
                    <th>Mensaje</th>
                </tr>
                <tr>
                    
                    <td>
                        <asp:TextBox ID="CodPersona" runat="server"></asp:TextBox>
                        <asp:Button ID="botonBuscar2" runat="server" OnClick="botonBuscar" text="Buscar"/>
                        <asp:Button ID="botonActualizar2" runat="server" OnClick="botonActualizar" text="Actualizar"/>
                    </td>

                    <td>
                        <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
                    </td>
                     <td>
                        <asp:TextBox ID="mensaje" runat="server"></asp:TextBox>
                    </td>

                </tr>
            </table>

        </div>
    </form>
</body>
</html>
