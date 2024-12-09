<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.ListadoPacientes" Codebehind="ListadoPacientes.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
   <meta charset="UTF-8" />
   <meta name="viewport" content="width=device-width, initial-scale=1.0" />
   <title>Hospital April - Listado de Pacientes</title>
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

#grdPacientes {
    width: 100%;
    border-collapse: collapse;
}

#grdPacientes th {
    padding: 12px;
    text-align: left;
}

#grdPacientes td {
    padding: 8px;
    text-align: left;
    vertical-align: middle;
}

#grdPacientes input[type="text"] {
    width: 100%;
    padding: 8px;
    border: 1px solid #ddd;
    border-radius: 4px;
    box-sizing: border-box;
}

#grdPacientes select {
    width: 100%;
    padding: 8px;
    border: 1px solid #ddd;
    border-radius: 4px;
    box-sizing: border-box;
}

/* Estilos para los botones de edición y eliminación */
#grdPacientes td a {
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

#grdPacientes td a:hover {
    background-color: #6fb1a9;
}

/* Estilos del GridView */
#grdPacientes {
    margin-top: 20px;
    width: 100%;
}

.EditRowStyle {
    background-color: #e9ecef;
}

#grdPacientes tr:hover {
    background-color: #f8f9fa;
}

/* Estilos para paginación */
#grdPacientes .PagerStyle td {
    padding: 10px;
    text-align: center;
}

#grdPacientes .PagerStyle a {
    padding: 5px 10px;
    margin: 0 2px;
    border: 1px solid #ddd;
    text-decoration: none;
    border-radius: 3px;
}

#grdPacientes .PagerStyle a:hover {
    background-color: #f0f0f0;
}

/* Estilos responsive */
@media (max-width: 768px) {
    .grid-container {
        width: 95%;
        margin: 10px auto;
    }

    #grdPacientes td,
    #grdPacientes th {
        padding: 6px;
    }

    #grdPacientes td a {
        padding: 4px 8px;
        min-width: 50px;
    }
}
   </style>
</head>
<body>
   <form id="form1" runat="server" class="auto-style3">
  <div class="navbar">
    <asp:LinkButton ID="lnkMenuPrincipal" runat="server" Text="Menú Principal" CssClass="link" OnClick="lnkMenuPrincipal_Click" />
    <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="link" />
    <asp:LinkButton ID="lnkCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="link" OnClick="lnkCerrarSesion_Click" />
</div>

       <div class="hospital-info">
           <h1>HOSPITAL<br />APRIL</h1>
       </div>

       <div class="filter-box">
           <h2>LISTADO DE PACIENTES</h2>
           <div class="filter-group">
               <asp:Label ID="lblDNI" runat="server" Text="Buscar por DNI"></asp:Label>
               <asp:TextBox ID="txtDNI" runat="server" CssClass="input" Placeholder="Ingrese DNI"></asp:TextBox>
               <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="button" OnClick="btnFiltrar_Click" />
           </div>
       </div>

       <div class="grid-container">
           <asp:GridView ID="grdPacientes" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grdPacientes_RowDeleting" AutoGenerateEditButton="True" OnRowCancelingEdit="grdPacientes_RowCancelingEdit" OnRowEditing="grdPacientes_RowEditing" OnRowUpdating="grdPacientes_RowUpdating" AllowPaging="True" OnPageIndexChanging="grdPacientes_PageIndexChanging">
               <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
               <Columns>
                   <asp:TemplateField HeaderText="DNI">
                       <EditItemTemplate>
                           <asp:TextBox ID="txt_ed_dni" runat="server" text='<%#Bind("dni") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Bind("dni") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="LOCALIDAD">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlLocalidad" runat="server" AutoPostBack="True">
                               <asp:ListItem Value="1">La Plata</asp:ListItem>
                               <asp:ListItem Value="2">Mar del Plata</asp:ListItem>
                               <asp:ListItem Value="3">Bahía Blanca</asp:ListItem>
                               <asp:ListItem Value="4">Córdoba Capital</asp:ListItem>
                               <asp:ListItem Value="5">Villa Carlos Paz</asp:ListItem>
                               <asp:ListItem Value="6">Río Cuarto</asp:ListItem>
                               <asp:ListItem Value="7">Rosario</asp:ListItem>
                               <asp:ListItem Value="8">Santa Fe Capital</asp:ListItem>
                               <asp:ListItem Value="9">Rafaela</asp:ListItem>
                               <asp:ListItem Value="10">Mendoza Capital</asp:ListItem>
                               <asp:ListItem Value="11">San Rafael</asp:ListItem>
                               <asp:ListItem Value="12">Godoy Cruz</asp:ListItem>
                               <asp:ListItem Value="13">San Miguel de Tucumán</asp:ListItem>
                               <asp:ListItem Value="14">Tafí Viejo</asp:ListItem>
                               <asp:ListItem Value="15">Concepción</asp:ListItem>
                           </asp:DropDownList>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lbl_it_loc" runat="server" Text='<%# Bind("id_localidad") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="NOMBRE">
                       <EditItemTemplate>
                           <asp:TextBox ID="txt_ed_nom" runat="server" text='<%#Bind("nombre") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lbl_it_nom" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="APELLIDO">
                       <EditItemTemplate>
                           <asp:TextBox ID="txt_ed_ape" runat="server" text='<%#Bind("apellido") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lbl_it_Ape" runat="server" Text='<%# Bind("apellido") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="SEXO">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlsexo" runat="server" AutoPostBack="True">
                               <asp:ListItem value="1">Mujer</asp:ListItem>
                               <asp:ListItem Value="2">Hombre</asp:ListItem>
                           </asp:DropDownList>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lbl_it_sexo" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="NACIONALIDAD">
                       <EditItemTemplate>
                           <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True">
                               <asp:ListItem Value="1">Buenos Aires</asp:ListItem>
                               <asp:ListItem Value="2">Cordoba</asp:ListItem>
                               <asp:ListItem Value="3">Santa Fe</asp:ListItem>
                               <asp:ListItem Value="4">Mendoza</asp:ListItem>
                               <asp:ListItem Value="5">Tucuman</asp:ListItem>
                           </asp:DropDownList>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblNacionalidad" runat="server" Text='<%# Bind("nacionalidad") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="FECHA NACIMIENTO">
                       <EditItemTemplate>
                           <asp:TextBox ID="txt_ed_fecha" runat="server" text='<%#Bind("fecha_nacimiento") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblNaci" runat="server" Text='<%# Bind("fecha_nacimiento") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="DIRECCION">
                       <EditItemTemplate>
                           <asp:TextBox ID="txt_ed_dire" runat="server" text='<%#Bind("direccion") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("direccion") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="EMAIL">
                       <EditItemTemplate>
                           <asp:TextBox ID="txt_ed_correo" runat="server" text='<%#Bind("correo") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="TELEFONO">
                       <EditItemTemplate>
                           <asp:TextBox ID="txt_ed_Tel" runat="server" text='<%#Bind("telefono") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblTel" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
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