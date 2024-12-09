<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.AsignarTurno" Codebehind="AsignarTurno.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April - Asignar Turno</title>
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

        /* Contenedor del formulario */
        .form-container {
            display: grid;
            grid-template-columns: auto auto;
            gap: 15px 30px;
            align-items: center;
            justify-content: center;
            margin-top: 30px;
            text-align: left;
            padding: 0 20px;
            max-width: 600px;
            width: 100%;
        }

        .form-container h2 {
            grid-column: span 2;
            font-size: 1.5em;
            font-weight: bold;
            text-align: center;
            margin-bottom: 20px;
        }

        .input {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            background-color: #f0f0f0;
            box-sizing: border-box;
        }

        .button {
            grid-column: span 2;
            background-color: #84cbc4;
            color: black;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-weight: bold;
            cursor: pointer;
            text-align: center;
            margin-top: 10px;
        }

        .button:hover {
            background-color: #6fb1a9;
        }

        #Label1 {
            text-align: center;
            margin-top: 20px;
            color: red;
        }

        #RequiredFieldValidator1 {
            grid-column: span 2;
            color: red;
            text-align: center;
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

        <!-- Formulario de asignar turno -->
        <div class="form-container">
            <h2>ASIGNAR TURNO</h2>
          
            <asp:Label ID="lblCodigo" runat="server" Text="Código del Turno"></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="input"></asp:TextBox>
            
            <asp:Label ID="lblDNI" runat="server" Text="DNI del Paciente"></asp:Label>
            <asp:DropDownList ID="ddlPacientes" runat="server" CssClass="input">
                <asp:ListItem Text="Seleccione un paciente" Value="" />
            </asp:DropDownList>

            <asp:Label ID="lblEspecialidad" runat="server" Text="Seleccionar Especialidad"></asp:Label>
            <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="input" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Text="Seleccione una especialidad" Value="" />
            </asp:DropDownList>

            <asp:Label ID="lblMedico" runat="server" Text="Seleccionar Médico"></asp:Label>
            <asp:DropDownList ID="ddlMedico" runat="server" CssClass="input" AutoPostBack="True" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:Label ID="lblDiaAtencion" runat="server" Text="Seleccionar Día de Atención"></asp:Label>
            <asp:DropDownList ID="ddlDiasAtencion" runat="server" CssClass="input" AutoPostBack="True" OnSelectedIndexChanged="ddlDiasAtencion_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:Label ID="lblHorario" runat="server" Text="Seleccionar Horario de Atención"></asp:Label>
            <asp:DropDownList ID="ddlHorario" runat="server" CssClass="input">
            </asp:DropDownList>

            <asp:Button ID="btnAsignar" runat="server" Text="Asignar" CssClass="button" OnClick="btnAsignar_Click" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodigo" ValidationGroup="1">Ingresar un codigo</asp:RequiredFieldValidator>
        </div>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>