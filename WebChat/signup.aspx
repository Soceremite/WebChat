<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="WebChat.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Content/css/dmaku.css"/>
    <link rel="stylesheet" href="Content/css/Cloud.css"/>
    <link rel="stylesheet" href="Content/css/my.css"/>
    <title>注册</title>
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
    <form id="Form1" runat="server">
        <div class="dowebok right-panel-active" id="dowebok1">
            <div class="form-container sign-up-container">
                <h1 align="center">注册</h1>
                <asp:TextBox ID="tbusername1" runat="server" CssClass="input" placeholder="用户名" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvusername1" runat ="server" CssClass="error" ControlToValidate="tbusername1" ErrorMessage="账号不能为空" SetFocusOnError="true" Display="Dynamic" ValidationGroup="vg1"></asp:RequiredFieldValidator>
                <asp:TextBox ID="tbpassword1" runat="server" CssClass="input" placeholder="密码" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvpassword1" runat ="server" CssClass="error" ControlToValidate="tbpassword1" ErrorMessage="密码不能为空" SetFocusOnError="true" Display="Dynamic" ValidationGroup="vg1"></asp:RequiredFieldValidator>
                <asp:TextBox ID="tbpassword2" runat="server" CssClass="input" placeholder="确认密码" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvpassword2" runat ="server" CssClass="error" ControlToValidate="tbpassword2" ErrorMessage="验证不能为空" SetFocusOnError="true" Display="Dynamic" ValidationGroup="vg1"></asp:RequiredFieldValidator>
                <asp:TextBox ID="tbphone" runat="server" CssClass="input" placeholder="手机" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" CssClass="error" ControlToValidate="tbphone" ErrorMessage="手机不能为空" SetFocusOnError="true" Display="Dynamic" ValidationGroup="vg1"></asp:RequiredFieldValidator>
                <asp:Button ID="BtnSignup" runat="server" CssClass="btn" background-color="#ff4b2b" Text="注册" OnClick="btSignup_Click" ValidationGroup="vg1"/>
            </div>
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-panel overlay-left">
                        <h1>已有帐号？</h1>
                        <p>请使用您的帐号进行登录</p>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" background-color="#ff4b2b" Text="登录" OnClick="bt1_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

