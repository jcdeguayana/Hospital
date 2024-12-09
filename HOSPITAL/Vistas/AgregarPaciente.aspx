<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.AgregarPaciente" Codebehind="AgregarPaciente.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April - Agregar Paciente</title>
    <style>
        :root {
            --primary-color: #84cbc4;
            --primary-hover: #6fb1a9;
            --text-color: #333;
            --border-color: #ccc;
            --success-color: #00CC00;
        }

        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            color: var(--text-color);
            line-height: 1.6;
        }

        .navbar {
            background-color: black;
            padding: 1rem;
            display: flex;
            justify-content: space-around;
            align-items: center;
        }

        .navbar .link {
            color: white;
            text-decoration: none;
            padding: 0.5rem 1rem;
            font-weight: bold;
            transition: opacity 0.3s;
        }

        .navbar .link:hover {
            opacity: 0.8;
        }

        .hospital-info {
            text-align: center;
            padding: 2rem;
            background-color: #f5f5f5;
            margin-bottom: 2rem;
        }

        .hospital-info h1 {
            font-size: 2.5rem;
            margin: 0;
            line-height: 1.2;
        }

        .form-container {
            max-width: 500px;
            margin: 0 auto;
            padding: 2rem;
        }

        .form-title {
            text-align: center;
            margin-bottom: 2rem;
            font-size: 1.8rem;
        }

        .form-group {
            margin-bottom: 1.5rem;
        }

        .form-group label {
            display: block;
            margin-bottom: 0.5rem;
            font-weight: bold;
        }

        .form-control {
            width: 100%;
            padding: 0.8rem;
            border: 1px solid var(--border-color);
            border-radius: 4px;
            font-size: 1rem;
            background-color: #f8f8f8;
            box-sizing: border-box;
        }

        .validation-message {
            color: var(--success-color);
            font-size: 0.9rem;
            margin-top: 0.3rem;
        }

        .form-actions {
            text-align: center;
            margin-top: 2rem;
        }

        .btn-primary {
            background-color: var(--primary-color);
            color: black;
            padding: 1rem 2rem;
            border: none;
            border-radius: 4px;
            font-weight: bold;
            cursor: pointer;
            transition: background-color 0.3s;
            width: 100%;
            max-width: 200px;
        }

        .btn-primary:hover {
            background-color: var(--primary-hover);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <asp:LinkButton ID="lnkMenuPrincipal" runat="server" Text="Menú Principal" CssClass="link" OnClick="lnkMenuPrincipal_Click" />
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="link" />
            <asp:LinkButton ID="lnkCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="link" OnClick="lnkCerrarSesion_Click" />
        </div>

        <div class="hospital-info">
            <h1>HOSPITAL APRIL</h1>
        </div>

        <div class="form-container">
            <h2 class="form-title">AGREGAR PACIENTE</h2>
            
            <!-- DNI -->
            <div class="form-group">
                <asp:Label ID="lblDNI" runat="server" Text="DNI"></asp:Label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ValidationGroup="1">Ingresar DNI</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ValidationExpression="^\d+$" ValidationGroup="1">Solo valores numéricos</asp:RegularExpressionValidator>
                </div>
            </div>

            <!-- Nombre -->
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese nombre" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ValidationGroup="1">Ingresar nombre</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Apellido -->
            <div class="form-group">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese apellido" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ValidationGroup="1">Ingresar apellido</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Sexo -->
            <div class="form-group">
                <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>
                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <!-- Fecha de Nacimiento -->
            <div class="form-group">
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" placeholder="DD/MM/AAAA" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFechaNacimiento" ValidationGroup="1">Ingresar fecha</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revFecha" runat="server" ControlToValidate="txtFechaNacimiento" ValidationExpression="^([0-2][0-9]|3[0-1])/(0[1-9]|1[0-2])/\d{4}$" ValidationGroup="1">Formato de fecha válido (DD/MM/AAAA)</asp:RegularExpressionValidator>
                </div>
            </div>

            <!-- Dirección -->
            <div class="form-group">
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Ingrese dirección" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ValidationGroup="1">Ingresar dirección</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Provincia -->
            <div class="form-group">
                <asp:Label ID="lblProvincia" runat="server" Text="Provincia"></asp:Label>
                <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged1"></asp:DropDownList>
            </div>

            <!-- Localidad -->
            <div class="form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="Localidad"></asp:Label>
                <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <!-- Correo Electrónico -->
            <div class="form-group">
                <asp:Label ID="lblCorreoElectronico" runat="server" Text="Correo Electrónico"></asp:Label>
                <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control" placeholder="ejemplo@correo.com" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreoElectronico" ValidationGroup="1">Ingresar correo</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreoElectronico" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ValidationGroup="1">Ingrese correo válido</asp:RegularExpressionValidator>
                </div>
            </div>

            <!-- Teléfono -->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese teléfono" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ValidationGroup="1">Ingresar teléfono</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Mensaje y Botón -->
            <div class="form-actions">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <asp:Button ID="btnAgregar" runat="server" CssClass="btn-primary" OnClick="btnAgregar_Click2" Text="Agregar" ValidationGroup="1" />
            </div>
        </div>
    </form>
</body>
</html>