<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserUnfreeze.aspx.cs" Inherits="WebChat.Admin.UserUnfreeze" MasterPageFile="/Menu.Master" Title="账号解封" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 style="text-align:center">用户冻结</h3>
        <asp:GridView ID="gv1" runat="server" CssClass="gv_table" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="暂无数据" Font-Size="Medium" TabIndex="1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center" PageSize="20">
            <EditRowStyle Font-Size="Smaller" />
            <FooterStyle BackColor="#CCCC99" />
            <AlternatingRowStyle HorizontalAlign="Center" BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <HeaderStyle Width="5%" />
                    <HeaderTemplate>id</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbid" runat="server" Text='<%#Eval("id") %>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="=tb_class">
                    <HeaderStyle Width="20%" />
                    <HeaderTemplate>用户名</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbusername" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="=tb_class"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="=tb_class">
                    <HeaderStyle Width="20%" />
                    <HeaderTemplate>手机号</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbphone" runat="server" Text='<%#Eval("phone") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="=tb_class"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="=tb_class">
                    <HeaderStyle Width="20%" />
                    <HeaderTemplate>上次登录时间</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblogintime" runat="server" Text='<%#Eval("logintime") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="=tb_class"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="8%" />
                    <HeaderTemplate>解封</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btunban" runat="server" OnClick="UnBan_Click" CssClass="my_button" Text="解封" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle HorizontalAlign="Center" Height="26px" BackColor="white" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#3a3f51" Font-Bold="True" ForeColor="White" CssClass="shadow_text" HorizontalAlign="Center" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
</asp:Content>