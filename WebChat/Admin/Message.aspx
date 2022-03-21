<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="WebChat.Admin.Message" MasterPageFile="/Menu.Master" Title="消息管理" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 style="text-align:center">消息管理</h3>
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
                    <HeaderStyle Width="10%" />
                    <HeaderTemplate>发送方</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbfromuser" runat="server" Text='<%#Eval("fromuser") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="=tb_class"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="=tb_class">
                    <HeaderStyle Width="10%" />
                    <HeaderTemplate>接收方</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbtouser" runat="server" Text='<%#Eval("touser") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="=tb_class"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="=tb_class">
                    <HeaderStyle Width="30%" />
                    <HeaderTemplate>内容</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbcontent" runat="server" Text='<%#Eval("content") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="=tb_class"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="=tb_class">
                    <HeaderStyle Width="20%" />
                    <HeaderTemplate>发送时间</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbmsgtime" runat="server" Text='<%#Eval("MsgTime") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="=tb_class"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="8%" />
                    <HeaderTemplate>删除</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btdelete" runat="server" OnClick="Delete_Click" CssClass="my_button" Text="删除" />
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
