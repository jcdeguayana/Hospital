<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.ListadoMedicos" Codebehind="ListadoMedicos.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
   <meta charset="UTF-8" />
   <meta name="viewport" content="width=device-width, initial-scale=1.0" />
   <title>Hospital April - Listado de Médicos</title>
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

/* Caja de filtro */
.filter-box {
    background-color: white;
    text-align: center;
    padding: 20px;
    margin: 20px auto;
    border-radius: 10px;
    width: 300px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 10px;
}

.filter-box h2 {
    font-size: 1.5em;
    font-weight: bold;
    margin-bottom: 15px;
    width: 100%;
    text-align: center;
}

.filter-group {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    gap: 10px;
}

.input {
    width: 80%;
    padding: 10px;
    margin: 5px 0;
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
    margin-top: 10px;
}

.button:hover {
    background-color: #6fb1a9;
}

/* Grid styles */
.grid-container {
    width: 90%;
    margin: 20px auto;
    overflow-x: auto;
    max-width: 1200px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    display: flex;
    justify-content: center;
}

#grdMedicos {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
}

#grdMedicos th {
    padding: 12px;
    text-align: left;
}

#grdMedicos td {
    padding: 8px;
    text-align: left;
    vertical-align: middle;
}

#grdMedicos input[type="text"], 
#grdMedicos select {
    width: 100%;
    padding: 8px;
    border: 1px solid #ddd;
    border-radius: 4px;
    box-sizing: border-box;
}

/* Estilos para los botones de edición y eliminación */
#grdMedicos td a {
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

#grdMedicos td a:hover {
    background-color: #6fb1a9;
}

/* Estilos adicionales del GridView */
#grdMedicos tr:hover {
    background-color: #f8f9fa;
}

.EditRowStyle {
    background-color: #e9ecef;
}

/* Estilos para paginación */
#grdMedicos .PagerStyle td {
    padding: 10px;
    text-align: center;
}

#grdMedicos .PagerStyle a {
    padding: 5px 10px;
    margin: 0 2px;
    border: 1px solid #ddd;
    text-decoration: none;
    border-radius: 3px;
}

#grdMedicos .PagerStyle a:hover {
    background-color: #f0f0f0;
}

/* Estilos responsive */
@media (max-width: 768px) {
    .grid-container {
        width: 95%;
        margin: 10px auto;
    }

    #grdMedicos td,
    #grdMedicos th {
        padding: 6px;
    }

    #grdMedicos td a {
        padding: 4px 8px;
        min-width: 50px;
    }

    .input {
        width: 90%;
    }

    .filter-box {
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

       <div class="hospital-info">
           <h1>HOSPITAL<br />APRIL</h1>
       </div>

       <div class="filter-box">
           <h2>LISTADO DE MEDICOS</h2>
           <div class="filter-group">
               <asp:Label ID="lblDNI" runat="server" Text="Buscar por DNI"></asp:Label>
               <asp:TextBox ID="txtDNI" runat="server" CssClass="input" Placeholder="Ingrese DNI"></asp:TextBox>
               <asp:Label ID="Label1" runat="server" Text="Buscar por Usuario"></asp:Label>
               <asp:TextBox ID="txtUsuario" runat="server" CssClass="input" Placeholder="Ingrese Usuario"></asp:TextBox>
               <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="button" OnClick="btnFiltrar_Click1" />
           </div>
       </div>

       <div class="grid-container">
           <asp:GridView ID="grdMedicos" runat="server" AutoGenerateColumns="False" 
               AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" 
               CellPadding="4" ForeColor="#333333" GridLines="None" 
               OnRowCancelingEdit="grdMedicos_RowCancelingEdit" 
               OnRowDeleting="GridView1_RowDeleting" 
               OnRowEditing="GridView1_RowEditing" 
               OnRowUpdating="GridView1_RowUpdating" 
               OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
               <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
               <Columns>
                   <asp:TemplateField HeaderText="Legajo">
                       <EditItemTemplate>
                           <asp:Label ID="lblLegajo" runat="server" Text='<%# Bind("LEGAJO") %>'></asp:Label>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblLegajo" runat="server" Text='<%# Bind("LEGAJO") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Especialidad">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True">
                               <asp:ListItem Value="1">Cardiologia</asp:ListItem>
                               <asp:ListItem Value="2">Dermatologia</asp:ListItem>
                               <asp:ListItem Value="3">Neurologia</asp:ListItem>
                               <asp:ListItem Value="4">Pediatria</asp:ListItem>
                               <asp:ListItem Value="5">psiquiatria</asp:ListItem>
                           </asp:DropDownList>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblEspecialidad" runat="server" Text='<%# Bind("ESPECIALIDAD") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="DNI">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtDNIed" runat="server" Text='<%# Bind("DNI") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblDNi" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Id Usuario">
                       <ItemTemplate>
                           <asp:Label ID="lblId" runat="server" Text='<%# Bind("USUARIO") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Nombre">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtNombreEd" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Apellido">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtApe" runat="server" Text='<%# Bind("APELLIDO") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("APELLIDO") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Nacimiento">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtFecha" runat="server" Text='<%# Bind("NACIMIENTO") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblNacimiento" runat="server" Text='<%# Bind("NACIMIENTO") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Direccion">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtDireccion" runat="server" Text='<%# Bind("DIRECCION") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("DIRECCION") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Email">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtMail" runat="server" Text='<%# Bind("EMAIL") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblMail" runat="server" Text='<%# Bind("EMAIL") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Telefono">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtTelefono" runat="server" Text='<%# Bind("TELEFONO") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("TELEFONO") %>'></asp:Label>
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
       </div>
   </form>
</body>
</html>