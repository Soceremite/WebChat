<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebChat.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Content/css/dmaku.css"/>
    <link rel="stylesheet" href="Content/css/Cloud.css"/>
    <link rel="stylesheet" href="Content/css/my.css"/>
    <link rel="icon" href="1111.ico" type="image/vnd.microsoft.icon"/>
    <link rel="shortcut icon" href="/Resource/web/logo.ico" type="image/x-icon"/>
    <title>登录</title>
</head>
<body>
    <div class="cloud floating">
        <img src="/Resource/web/cloud.png" alt="Scoop Themes" />
    </div>

    <div class="cloud pos1 fliped floating">
        <img src="/Resource/web/cloud.png" alt="Scoop Themes" />
    </div>

    <div class="cloud pos2 floating">
        <img src="/Resource/web/cloud.png" alt="Scoop Themes" />
    </div>

    <div class="cloud pos3 fliped floating">
        <img src="/Resource/web/cloud.png" alt="Scoop Themes" />
    </div>
    <form id="Form2" runat="server">
        <div class="dowebok" id="dowebok2">
            <div class="form-container sign-in-container">
                <h1 align="center">登录</h1>
                <asp:TextBox ID="tbusername" runat="server" CssClass="input" placeholder="账号" ></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfvusername" runat ="server" CssClass="error" ControlToValidate="tbusername" ErrorMessage="账号不能为空" SetFocusOnError="true" Display="Dynamic" ValidationGroup="vg1"></asp:RequiredFieldValidator>
                <asp:TextBox ID="tbpassword" runat="server" CssClass="input" placeholder="密码" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="tfvpassword" runat ="server" CssClass="error" ControlToValidate="tbpassword" ErrorMessage="密码不能为空" SetFocusOnError="true" Display="Dynamic" ValidationGroup="vg1"></asp:RequiredFieldValidator>
                <asp:Button ID="BtnLogin" CssClass="btn" runat="server" Text="登录" OnClick="btnLogin_Click" ValidationGroup="vg1"/>
            </div>
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-panel overlay-right">
                        <h1>没有帐号？</h1>
                        <p>立即注册加入我们，和我们一起开始旅程吧</p>
                        <asp:Button ID="Button2" runat="server" CssClass="btn" background-color="#ff4b2b" Text="注册" OnClick="bt2_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

