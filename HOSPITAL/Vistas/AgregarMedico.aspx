<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.AgregarMedico" Codebehind="AgregarMedico.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April - Agregar Médico</title>
    <style>
        :root {
            --primary-color: #84cbc4;
            --primary-hover: #6fb1a9;
            --text-color: #333;
            --border-color: #ccc;
            --error-color: #ff0000;
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
            font-weight: bold;
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

        .form-control:focus {
            outline: none;
            border-color: var(--primary-color);
            box-shadow: 0 0 0 2px rgba(132, 203, 196, 0.2);
        }

        .validation-message {
            color: var(--error-color);
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

        .mensaje-resultado {
            text-align: center;
            margin-top: 1rem;
            font-family: Verdana;
            font-size: x-large;
        }

        @media (max-width: 600px) {
            .form-container {
                padding: 1rem;
            }

            .hospital-info h1 {
                font-size: 2rem;
            }

            .form-title {
                font-size: 1.5rem;
            }

            .btn-primary {
                width: 100%;
            }
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
            <h2 class="form-title">AGREGAR MÉDICO</h2>

            <!-- ID del Médico -->
            <div class="form-group">
                <asp:Label ID="lblID" runat="server" Text="ID del Médico"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" placeholder="Ingrese ID" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvID" runat="server" ControlToValidate="txtID" ValidationGroup="1">Debe completar el campo</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Usuario -->
            <div class="form-group">
                <asp:Label ID="lblUsername" runat="server" Text="Nombre de usuario"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Ingrese nombre de usuario" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsername" ValidationGroup="1">Ingresar nombre de usuario</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Contraseña -->
            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese contraseña" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="1">Ingresar una contraseña</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Confirmar Contraseña -->
            <div class="form-group">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirmar Contraseña"></asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Repita la contraseña" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ValidationGroup="1">Las contraseñas no coinciden</asp:CompareValidator>
                </div>
            </div>

            <!-- Tipo de Usuario -->
            <div class="form-group">
                <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo de Usuario"></asp:Label>
                <asp:TextBox ID="txtTipoUsuario" runat="server" CssClass="form-control" placeholder="Ingrese tipo de usuario" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvTipoUsuario" runat="server" ControlToValidate="txtTipoUsuario" ValidationGroup="1">Ingresar tipo de Usuario</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Legajo -->
            <div class="form-group">
                <asp:Label ID="lblLegajo" runat="server" Text="Legajo"></asp:Label>
                <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control" placeholder="Ingrese legajo" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ValidationGroup="1">Ingresar un Legajo</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- DNI -->
            <div class="form-group">
                <asp:Label ID="lblDNI" runat="server" Text="DNI"></asp:Label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ValidationGroup="1">Ingresar un DNI</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Nombre -->
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese nombre" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ValidationGroup="1">Ingresar un Nombre</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Apellido -->
            <div class="form-group">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese apellido" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ValidationGroup="1">Ingresar un Apellido</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Sexo -->
            <div class="form-group">
                <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>
                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <!-- Nacionalidad -->
            <div class="form-group">
                <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad"></asp:Label>
                <asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Otro" Value="OT"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Fecha de Nacimiento -->
            <div class="form-group">
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" placeholder="DD/MM/AAAA" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFechaNacimiento" ValidationGroup="1">Ingresar una Fecha</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Dirección -->
            <div class="form-group">
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Ingrese dirección" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ValidationGroup="1">Ingresar una Dirección</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Provincia -->
            <div class="form-group">
                <asp:Label ID="lblProvincia" runat="server" Text="Provincia"></asp:Label>
                <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <!-- Localidad -->
            <div class="form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="Localidad"></asp:Label>
                <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <!-- Email -->
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="ejemplo@correo.com" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="1">Ingresar un Email</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="1">Ingresar un correo válido</asp:RegularExpressionValidator>
                </div>
            </div>

            <!-- Teléfono -->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese teléfono" ValidationGroup="1"></asp:TextBox>
                <div class="validation-message">
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ValidationGroup="1">Ingresar un Teléfono</asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Especialidad -->
            <div class="form-group">
                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad"></asp:Label>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>

            <!-- Botón y Mensaje -->
            <div class="form-actions">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn-primary" OnClick="btnAgregar_Click1" ValidationGroup="1" />
                <div class="mensaje-resultado">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>