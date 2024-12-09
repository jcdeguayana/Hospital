<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.MainPage" Codebehind="MainPage.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April</title>
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

        .hospital-info p {
            font-size: 1em;
            color: #666;
            max-width: 400px;
        }

        .main-content {
            display: flex;
            flex-direction: column;
            align-items: center;
            width: 100%;
        }

        .options {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 20px;
            margin-top: 20px;
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

        <!-- Sección principal -->
        <div class="main-content">
            <div class="hospital-info">
                <h1>HOSPITAL<br />APRIL</h1>
            </div>
            <div class="options">
                <asp:HyperLink NavigateUrl="Pacientes.aspx" CssClass="link" runat="server">
                    <div class="option">
                        <asp:Image ID="imgPacientes" runat="server" ImageUrl="~/images/icono_pacientes.png" AlternateText="Pacientes" />
                        Pacientes
                    </div>
                </asp:HyperLink>

                <asp:HyperLink NavigateUrl="Turnos.aspx" CssClass="link" runat="server">
                    <div class="option">
                        <asp:Image ID="imgTurno" runat="server" ImageUrl="~/images/icono_turno.png" AlternateText="Turnos" />
                        Turnos
                    </div>
                </asp:HyperLink>

                <asp:HyperLink NavigateUrl="Medicos.aspx" CssClass="link" runat="server">
                    <div class="option">
                        <asp:Image ID="imgMedicos" runat="server" ImageUrl="~/images/icono_medicos.png" AlternateText="Médicos" />
                        Médicos
                    </div>
                </asp:HyperLink>

                <asp:HyperLink NavigateUrl="HorariosMedico.aspx" CssClass="link" runat="server">
                    <div class="option">
                        <asp:Image ID="imgInformes" runat="server" ImageUrl="~/images/icono_informes.png" AlternateText="Asignar carga horaria" />
                        Asignar horarios
                    </div>
                </asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>