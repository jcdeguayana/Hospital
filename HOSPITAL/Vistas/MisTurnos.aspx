<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.MisTurnos" Codebehind="MisTurnos.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
   <meta charset="UTF-8">
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
    width: 90%;
    max-width: 1200px;
}

.main-content h2 {
    font-size: 1.5em;
    font-weight: bold;
    margin-bottom: 20px;
}

.input {
    width: 150px;
    padding: 10px;
    margin: 10px 5px;
    border-radius: 5px;
    border: 1px solid #ccc;
    background-color: #f0f0f0;
    text-align: center;
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
}

.button:hover {
    background-color: #6fb1a9;
}

/* Estilos del GridView */
#grdMisTurnos {
    width: 100%;
    margin: 20px 0;
    border-collapse: collapse;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

#grdMisTurnos th {
    padding: 12px;
    text-align: left;
}

#grdMisTurnos td {
    padding: 8px;
    text-align: left;
    vertical-align: middle;
}

/* Estilos para los botones de edición */
#grdMisTurnos td a {
    padding: 5px 10px;
    background-color: #84cbc4;
    color: black;
    text-decoration: none;
    border-radius: 4px;
    margin: 0 2px;
    display: inline-block;
    min-width: 60px;
    text-align: center;
    font-weight: bold;
}

#grdMisTurnos td a:hover {
    background-color: #6fb1a9;
}

/* Estilos para inputs y selects en el grid */
#grdMisTurnos input[type="text"], 
#grdMisTurnos select {
    width: 100%;
    padding: 8px;
    border: 1px solid #ddd;
    border-radius: 4px;
    box-sizing: border-box;
}

#grdMisTurnos textarea {
    width: 100%;
    min-height: 60px;
    padding: 8px;
    border: 1px solid #ddd;
    border-radius: 4px;
    box-sizing: border-box;
}

/* Estilos adicionales del GridView */
#grdMisTurnos tr:hover {
    background-color: #f8f9fa;
}

.EditRowStyle {
    background-color: #e9ecef;
}

/* Estilos para paginación */
#grdMisTurnos .PagerStyle td {
    padding: 10px;
    text-align: center;
}

#grdMisTurnos .PagerStyle a {
    padding: 5px 10px;
    margin: 0 2px;
    border: 1px solid #ddd;
    text-decoration: none;
    border-radius: 3px;
}

#grdMisTurnos .PagerStyle a:hover {
    background-color: #f0f0f0;
}

.search-section {
    margin-top: 30px;
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 10px;
    padding: 20px;
    background-color: #f5f5f5;
    border-radius: 10px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

/* Estilos responsive */
@media (max-width: 768px) {
    .main-content {
        width: 95%;
        margin: 10px auto;
    }

    #grdMisTurnos td,
    #grdMisTurnos th {
        padding: 6px;
    }

    #grdMisTurnos td a {
        padding: 4px 8px;
        min-width: 50px;
    }

    .input {
        width: 90%;
    }

    .search-section {
        width: 90%;
    }
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

       <!-- Contenedor principal de búsqueda de turnos -->
       <div class="main-content">
           <h2>MIS TURNOS</h2>
           <div>
               <asp:GridView ID="grdMisTurnos" runat="server" 
                   AutoGenerateColumns="False" 
                   AutoGenerateEditButton="True" 
                   CellPadding="4" 
                   ForeColor="#333333" 
                   GridLines="None"
                   OnRowCancelingEdit="grdMisTurnos_RowCancelingEdit" 
                   OnRowEditing="grdMisTurnos_RowEditing" 
                   OnRowUpdating="grdMisTurnos_RowUpdating"
                   AllowPaging="True"
                   OnPageIndexChanging="grdMisTurnos_PageIndexChanging">
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                   <Columns>
                       <asp:TemplateField HeaderText="Codigo">
                           <ItemTemplate>
                               <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("COD_TURNO_TUR") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Dni de paciente">
                           <EditItemTemplate>
                               <asp:Label ID="lblDni_eit" runat="server" Text='<%# Bind("DNI_PACIENTE_TUR") %>'></asp:Label>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="lblDni" runat="server" Text='<%# Bind("DNI_PACIENTE_TUR") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Mi legajo">
                           <EditItemTemplate>
                               <asp:Label ID="lblLegajo_eit" runat="server" Text='<%# Bind("LEGAJO_MED_TUR") %>'></asp:Label>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="lblLegajo" runat="server" Text='<%# Bind("LEGAJO_MED_TUR") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Dia del turno">
                           <EditItemTemplate>
                               <asp:Label ID="lblDia_eit" runat="server" Text='<%# Bind("DIA_TURNOS") %>'></asp:Label>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="lblDia" runat="server" Text='<%# Bind("DIA_TURNOS") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Hora del turno">
                           <EditItemTemplate>
                               <asp:Label ID="lblHora_eit" runat="server" Text='<%# Bind("HORA_TURNOS") %>'></asp:Label>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="lblHora" runat="server" Text='<%# Bind("HORA_TURNOS") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Estado">
                           <EditItemTemplate>
                               <asp:DropDownList ID="ddlPresencia" runat="server">
                                   <asp:ListItem>Pendiente</asp:ListItem>
                                   <asp:ListItem>Presente</asp:ListItem>
                                   <asp:ListItem>Ausente</asp:ListItem>
                               </asp:DropDownList>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Observacion">
                           <EditItemTemplate>
                               <asp:TextBox ID="txtObservacion" runat="server" Text='<%# Bind("OBSERVACION") %>' TextMode="MultiLine"></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="lblObservacion" runat="server" Text='<%# Bind("OBSERVACION") %>'></asp:Label>
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

               <div class="search-section">
                   <asp:Label ID="lblBuscarPorFecha" runat="server" Text="Buscar por dni"></asp:Label>
                   <asp:TextBox ID="txtFiltro" runat="server" CssClass="input" Placeholder="Ingrese DNI"></asp:TextBox>
                   <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="button" OnClick="btnFiltrar_Click" />
               </div>
           </div>
       </div>
   </form>
</body>
</html>