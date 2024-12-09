<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HorariosMedico.aspx.cs" Inherits="Vistas.HorariosMedico" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April - Mis Turnos</title>
    <style>
        /* Estilos generales */
        html, body, form {
            margin: 0;
            padding: 0;
            width: 100%;
        }

        body {
            font-family: Arial, sans-serif;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        #form1 {
            width: 100%;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .navbar {
            background-color: black;
            color: white;
            padding: 10px 50px;
            width: 100%;
            display: flex;
            justify-content: space-between;
            align-items: center;
            box-sizing: border-box;
        }

        .navbar .link {
            color: white;
            font-weight: bold;
            text-decoration: none;
            padding: 10px;
        }

        .navbar .link:hover {
            text-decoration: underline;
        }

        .hospital-info {
            text-align: left;
            margin: 30px 0;
            width: 100%;
            padding-left: 20px;
        }

        .hospital-info h1 {
            font-size: 3em;
            margin: 0;
            font-weight: bold;
        }

        /* Contenedor principal */
        .main-content {
            text-align: center;
            margin-top: 50px;
            width: 100%;
            max-width: 800px;
            padding: 0 20px;
        }

        .main-content h2 {
            font-size: 1.5em;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .main-content div {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            justify-content: center;
            align-items: center;
            margin-top: 20px;
        }

        select, .input {
            width: 150px;
            padding: 10px;
            margin: 10px 5px;
            border-radius: 5px;
            border: 1px solid #ccc;
            background-color: #f0f0f0;
            text-align: center;
            height: 40px;
            box-sizing: border-box;
        }

        .button {
            background-color: #84cbc4;
            color: black;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-weight: bold;
            cursor: pointer;
            margin: 10px 5px;
            height: 40px;
        }

        .button:hover {
            background-color: #6fb1a9;
        }

        .auto-style1 {
            font-size: medium;
            font-weight: normal;
        }

        .auto-style2 {
            text-align: center;
            margin-top: 20px;
        }

        #lblAviso {
            display: block;
            margin-top: 20px;
            color: #666;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Barra de navegación -->
        <div class="navbar">
            <asp:LinkButton ID="lnkMenuPrincipal" runat="server" Text="Menú Principal" CssClass="link" OnClick="lnkMenuPrincipal_Click" />
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="link" />
            <asp:LinkButton ID="lnkCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="link" OnClick="lnkCerrarSesion_Click" />
        </div>

        <!-- Información del Hospital -->
        <div class="hospital-info">
            <h1>HOSPITAL<br />APRIL</h1>
        </div>

        <div class="main-content">
            <h2>ASIGNAR HORARIOS</h2>
            <div>
                <strong>Legajo</strong>
                <asp:DropDownList ID="ddlLegajo" runat="server">
                </asp:DropDownList>
                
                <asp:DropDownList ID="ddlDia" runat="server">
                    <asp:ListItem>Lunes</asp:ListItem>
                    <asp:ListItem>Martes</asp:ListItem>
                    <asp:ListItem>Miercoles</asp:ListItem>
                    <asp:ListItem>Jueves</asp:ListItem>
                    <asp:ListItem>Viernes</asp:ListItem>
                    <asp:ListItem>Sabado</asp:ListItem>
                    <asp:ListItem>Domingo</asp:ListItem>
                </asp:DropDownList>
                
                <asp:DropDownList ID="ddlHorarios" runat="server">
                    <asp:ListItem>06:00</asp:ListItem>
                    <asp:ListItem>07:00</asp:ListItem>
                    <asp:ListItem>08:00</asp:ListItem>
                    <asp:ListItem>09:00</asp:ListItem>
                    <asp:ListItem>10:00</asp:ListItem>
                    <asp:ListItem>11:00</asp:ListItem>
                    <asp:ListItem>12:00</asp:ListItem>
                    <asp:ListItem>13:00</asp:ListItem>
                    <asp:ListItem>14:00</asp:ListItem>
                    <asp:ListItem>15:00</asp:ListItem>
                    <asp:ListItem>16:00</asp:ListItem>
                    <asp:ListItem>17:00</asp:ListItem>
                    <asp:ListItem>18:00</asp:ListItem>
                    <asp:ListItem>19:00</asp:ListItem>
                    <asp:ListItem>20:00</asp:ListItem>
                </asp:DropDownList>
                
                <asp:Button ID="btnFiltrar" runat="server" Text="Agregar" CssClass="button" OnClick="btnFiltrar_Click" />
            </div>
        </div>
        
        <h2 class="auto-style2">
            <asp:Label ID="lblAviso" runat="server" CssClass="auto-style1"></asp:Label>
        </h2>
    </form>
</body>
</html>