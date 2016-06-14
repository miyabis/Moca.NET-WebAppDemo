<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Views/Shared/Master/Base.Master" CodeBehind="Index.aspx.vb" Inherits="MocaDemo.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        Cookie : 
        <asp:Label runat="server" ID="lblCookieOld"></asp:Label>
        ⇒ 
        <asp:Label runat="server" ID="lblCookie"></asp:Label>
    </div>
    <div>
        ViewState : 
        <asp:Label runat="server" ID="lblVSOld"></asp:Label>
        ⇒ 
        <asp:Label runat="server" ID="lblVS"></asp:Label>
    </div>
    <div>
        Session : 
        <asp:Label runat="server" ID="lblCounter"></asp:Label>
    </div>

    <div style="margin: 20px 0;">
        ID:<asp:TextBox runat="server" ID="txtID"></asp:TextBox>
        Code:<asp:TextBox runat="server" ID="txtCode"></asp:TextBox>
        Name:<asp:TextBox runat="server" ID="txtName"></asp:TextBox>
        Note:<asp:TextBox runat="server" ID="txtNote"></asp:TextBox>
        <asp:Button runat="server" ID="btnInsert" Text="Add" />
    </div>

    <div>
        ID:<asp:TextBox runat="server" ID="txtSearchID"></asp:TextBox>
        <asp:Button runat="server" ID="btnUpdate" Text="Search" />
        <asp:GridView runat="server" ID="grdMain" Width="100%"></asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
