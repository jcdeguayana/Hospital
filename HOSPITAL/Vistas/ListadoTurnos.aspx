<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.ListadoTurnos" Codebehind="ListadoTurnos.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April - Listado de Turnos</title>
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

        /* Caja de Filtro */
        .filter-box {
            background-color: white;
            text-align: center;
            padding: 20px;
            margin-top: 50px;
            border-radius: 10px;
            width: 300px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .filter-box h2 {
            font-size: 1.5em;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .input {
            width: 80%;
            padding: 10px;
            margin: 10px 0;
            border-radius: 5px;
            border: 1px solid #ccc;
            background-color: #f0f0f0;
        }

        .button {
            background-color: #84cbc4;
            color: black;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-weight: bold;
            cursor: pointer;
            margin: 5px;
        }

        .button:hover {
            background-color: #6fb1a9;
        }

        .reportes-box {
            margin-top: 20px;
            text-align: center;
            padding: 20px;
        }

        .auto-style1 {
            margin-top: 20px;
            width: 90%;
            max-width: 1200px;
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

        <!-- Caja de filtro de turnos -->
        <div class="filter-box">
            <h2>LISTADO DE TURNOS</h2>
            <asp:Label ID="lblDNI" runat="server" Text="Buscar por DNI"></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server" CssClass="input" Placeholder="Ingrese DNI"></asp:TextBox>
            <br />
            <asp:Label ID="lblUser" runat="server" Text="Buscar por Legajo"></asp:Label>
            <br />
            <asp:TextBox ID="txtLegajo" runat="server" CssClass="input" Placeholder="Ingrese Legajo"></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="button" OnClick="btnFiltrar_Click" />
        </div>

        <asp:GridView ID="grdTurnos" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="auto-style1" ForeColor="#333333" GridLines="None" AllowPaging="True" 
            OnPageIndexChanging="grdTurnos_PageIndexChanging" PageSize="5">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="CODIGO">
                    <ItemTemplate>
                        <asp:Label ID="lbl_cod" runat="server" Text='<%# Bind("COD_TURNO_TUR") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DNI">
                    <ItemTemplate>
                        <asp:Label ID="lbl_dni" runat="server" Text='<%# Bind("DNI_PACIENTE_TUR") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LEGAJO">
                    <ItemTemplate>
                        <asp:Label ID="lbl_legajo" runat="server" Text='<%# Bind("LEGAJO_MED_TUR") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DIA">
                    <ItemTemplate>
                        <asp:Label ID ="lbl_dia" runat="server" Text='<%# Bind("DIA_TURNOS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="HORA">
                    <ItemTemplate>
                        <asp:Label ID="lbl_hora" runat="server" Text='<%# Bind("HORA_TURNOS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ESPECIALIDAD">
                    <ItemTemplate>
                        <asp:Label ID="lbl_especialidad" runat="server" Text='<%# Bind("ESPECIALIDAD") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ESTADO">
                    <ItemTemplate>
                        <asp:Label ID="lbl_estado" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OBSERVACION">
                    <ItemTemplate>
                        <asp:Label ID="lbl_obs" runat="server" Text='<%# Bind("OBSERVACION") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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

        <!-- Caja de Reportes -->
        <div class="reportes-box">
            <h3>REPORTE</h3>
            <b>Promedios:</b> <br />
            <asp:Button ID="btnAusentes" runat="server" Text="Ausentes" CssClass="button" OnClick="btnAus_Click" />
            <asp:Button ID="btnPresentes" runat="server" Text="Presentes" CssClass="button" OnClick="btnPres_Click" />
            <br />
            <asp:Label ID="lblAusentes" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblPresentes" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>