<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.Opciones" Codebehind="Opciones.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April - Opciones</title>
    <style>
        /* Estilos generales */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
        }
        .navbar {
            background-color: black;
            color: white;
            padding: 10px;
            width: 100%;
            display: flex;
            justify-content: space-around;
            align-items: center;
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
        }
        .hospital-info h1 {
            font-size: 3em;
            margin: 0;
            font-weight: bold;
        }
        .hospital-info p {
            font-size: 1em;
            max-width: 400px;
        }
        /* Contenedor principal */
        .main-content {
            display: flex;
            justify-content: center;
            gap: 50px;
            margin-top: 50px;
        }
        .option {
            background-color: #84cbc4;
            border-radius: 10px;
            width: 150px;
            height: 150px;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            text-align: center;
            font-weight: bold;
            color: black;
        }
        .option img {
            width: 50px;
            height: 50px;
            margin-bottom: 10px;
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

        <!-- Contenedor principal de opciones -->
<div class="main-content">
    <asp:HyperLink NavigateUrl="Turnos.aspx" CssClass="link" runat="server">
        <asp:Panel CssClass="option" runat="server">
            <asp:Image ID="imgVerTurnos" runat="server" ImageUrl="~/images/icono_turno.png" AlternateText="Ver Turnos" />
            <span>Ver Turnos</span>
        </asp:Panel>
    </asp:HyperLink>

    <asp:HyperLink NavigateUrl="Opciones.aspx" CssClass="link" runat="server">
        <asp:Panel CssClass="option" runat="server">
            <asp:Image ID="imgMiPerfil" runat="server" ImageUrl="~/images/icono_medicos.png" AlternateText="Mi Perfil" />
            <span>Mi Perfil</span>
        </asp:Panel>
    </asp:HyperLink>
</div>

    </form>
</body>
</html>


