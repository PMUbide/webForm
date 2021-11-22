<%@ Page Language="C#" AutoEventWireup="true" CodeFile="carga_volcado.aspx.cs" Inherits="carga_volcado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style>
        .textbox{
            width: 250px;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
              <asp:Button ID="botonXML" runat="server" OnClick="leeXML" text="LeerXML"/>
              
              <asp:Button ID="botonVolcar" runat="server" OnClick="convierteCSV" text="Vuelca XML"/>
           
              <asp:TextBox ID="mensaje" runat="server" CssClass="textbox"></asp:TextBox>

        </div>
    </form>
</body>
</html>
