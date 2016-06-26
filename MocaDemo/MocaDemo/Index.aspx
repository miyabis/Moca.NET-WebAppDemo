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

    <div class="form-inline" style="margin: 20px 0;">
        <div class="form-group">
            <label class="sr-only" for="txtID">ID</label>
            <asp:TextBox runat="server" ID="txtID" CssClass="form-control" placeholder="ID"></asp:TextBox>
        </div>
        <div class="form-group">
            <label class="sr-only" for="txtName">Name</label>
            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Name"></asp:TextBox>
        </div>
        <div class="form-group">
            <label class="sr-only" for="txtNote">Note</label>
            <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" placeholder="Note"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="btnInsert" Text="Add" CssClass="btn btn-primary" />
    </div>

    <div>
        <div class="form-inline">
            <div class="form-group">
                <label class="sr-only" for="txtSearchID">ID</label>
                <asp:TextBox runat="server" ID="txtSearchID" CssClass="form-control" placeholder="ID"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" />
        </div>
        <div style="margin-top: 5px;">
            <asp:GridView runat="server" ID="grdMain" Width="100%" CssClass="table table-bordered table-striped table-hover"></asp:GridView>
        </div>
    </div>
    <asp:CustomValidator ID="valid" runat="server" Display="None" ValidationGroup="valid"></asp:CustomValidator>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
