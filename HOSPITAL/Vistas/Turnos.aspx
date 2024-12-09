<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.Turnos" Codebehind="Turnos.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April - Turnos</title>
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

        .main-content {
            display: flex;
            justify-content: center;
            gap: 50px;
            margin-top: 50px;
            width: 100%;
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

        <!-- Contenedor principal -->
        <div class="main-content">
            <asp:HyperLink NavigateUrl="ListadoTurnos.aspx" CssClass="link" runat="server">
                <asp:Panel CssClass="option" runat="server">
                    <asp:Image ID="imgVerTurnos" runat="server" ImageUrl="~/images/icono_informes.png" AlternateText="Ver Turnos" />
                    <span>Ver Turnos</span>
                </asp:Panel>
            </asp:HyperLink>
            <asp:HyperLink NavigateUrl="AsignarTurno.aspx" CssClass="link" runat="server">
                <asp:Panel CssClass="option" runat="server">
                    <asp:Image ID="imgAsignarTurnos" runat="server" ImageUrl="~/images/icono_turno.png" AlternateText="Asignar Turnos" />
                    <span>Asignar Turnos</span>
                </asp:Panel>
            </asp:HyperLink>
        </div>
    </form>
</body>
</html>