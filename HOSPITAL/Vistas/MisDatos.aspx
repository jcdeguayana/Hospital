<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.MisDatos" Codebehind="MisDatos.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April - Mis Datos</title>
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

        .container {
            width: 90%;
            max-width: 1200px;
            margin: 0 auto;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .main-content {
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 30px;
            margin-top: 50px;
            width: 100%;
        }

        .main-content h2 {
            font-size: 1.5em;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .user-data {
            width: 100%;
            margin-bottom: 40px;
        }

        #GridView1 {
            width: 100%;
            border-collapse: collapse;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }

        #GridView1 th {
            background-color: #5D7B9D !important;
            color: white;
            padding: 12px;
            text-align: left;
        }

        #GridView1 td {
            padding: 12px;
            text-align: left;
        }

        .modify-section {
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 15px;
            padding: 20px;
            background-color: #f5f5f5;
            border-radius: 10px;
            width: 100%;
            max-width: 400px;
            margin: 20px 0;
        }

        .input {
            width: 100%;
            padding: 10px;
            margin: 5px 0;
            border-radius: 5px;
            border: 1px solid #ccc;
            background-color: #fff;
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
            width: 100%;
            margin-top: 10px;
        }

        .button:hover {
            background-color: #6fb1a9;
        }

        .validators {
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 10px;
            margin-top: 20px;
            color: red;
            text-align: center;
        }

        .validators p {
            margin: 5px 0;
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

        <div class="container">
            <div class="hospital-info">
                <h1>HOSPITAL<br />APRIL</h1>
            </div>

            <div class="main-content">
                <h2>MIS DATOS</h2>
                <div class="user-data">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="LEGAJO" HeaderText="LEGAJO" />
                            <asp:BoundField DataField="DNI" HeaderText="DNI" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                            <asp:BoundField DataField="APELLIDO" HeaderText="APELLIDO" />
                            <asp:BoundField DataField="FECHA" HeaderText="FECHA" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="DIRECCION" HeaderText="DIRECCIÓN" />
                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>

                <div class="modify-section">
                    <h2>MODIFICAR DATOS</h2>
                    <asp:TextBox ID="txtNuevoUsuario" runat="server" CssClass="input" Placeholder="Ingrese nuevo usuario" ValidationGroup="1"></asp:TextBox>
                    <asp:TextBox ID="txtNuevaContrasena" runat="server" CssClass="input" Placeholder="Ingrese contraseña" TextMode="Password" ValidationGroup="1"></asp:TextBox>
                    <asp:TextBox ID="txtConfirmarContrasena" runat="server" CssClass="input" Placeholder="Repita contraseña" TextMode="Password" ValidationGroup="1"></asp:TextBox>
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="button" ValidationGroup="1" OnClick="btnModificar_Click2" />
                </div>

                <div class="validators">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNuevoUsuario" ForeColor="Red" ValidationGroup="1">Ingresar un usuario</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNuevaContrasena" ForeColor="Red" ValidationGroup="1">Ingresar una contraseña</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmarContrasena" ForeColor="Red" ValidationGroup="1">Ingresar una contraseña</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNuevaContrasena" ControlToValidate="txtConfirmarContrasena" ForeColor="Red" ValidationGroup="1">Repetir contraseña</asp:CompareValidator>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>