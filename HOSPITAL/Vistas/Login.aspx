<%@ Page Language="C#" AutoEventWireup="true" Inherits="Vistas.Login" Codebehind="Login.aspx.cs" ContentType="text/html; charset=utf-8" ResponseEncoding="UTF-8" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hospital April - Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            min-height: 100vh;
            display: flex;
            flex-direction: column;
        }

        .navbar {
            background-color: black;
            color: white;
            padding: 30px;
            width: 100%;
            display: flex;
            justify-content: space-around;
            align-items: center;
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

        .content-wrapper {
            flex: 1;
            display: flex;
            flex-direction: column;
            padding: 20px;
        }

        .hospital-info {
            text-align: left;
            margin: 20px 0 40px 20px;
        }

        .hospital-info h1 {
            font-size: 3em;
            margin: 0;
            font-weight: bold;
        }

        .login-container {
            display: flex;
            justify-content: center;
            align-items: center;
            flex: 1;
        }

        .login-box {
            background-color: black;
            color: white;
            width: 300px;
            padding: 20px;
            border-radius: 15px;
            text-align: center;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .login-box h2 {
            font-size: 1.5em;
            margin-bottom: 20px;
            font-weight: bold;
        }

        .input {
            width: 80%;
            padding: 10px;
            margin: 10px 0;
            border-radius: 5px;
            border: none;
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

        .error-message {
            color: red;
            margin: 10px 0;
            font-size: 14px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
        </div>

        <div class="content-wrapper">
            <div class="hospital-info">
                <h1>HOSPITAL<br />APRIL</h1>
            </div>

            <div class="login-container">
                <div class="login-box">
                    <h2>LOGIN</h2>
                    <asp:Label ID="lblUsername" runat="server" Text="Usuario" />
                    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Usuario" CssClass="input" />
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña" />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Contraseña" CssClass="input" />
                    <asp:Label ID="Label1" runat="server" CssClass="error-message"></asp:Label>
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="button" OnClick="btnLogin_Click1" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>