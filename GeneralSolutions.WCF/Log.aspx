<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="GeneralSolutions.WCF.Log" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Log</h2>
    <style>
        #txtLog {
            width: 100%;
        }
    </style>

    <asp:TextBox ID="txtLog" runat="server" ReadOnly="true" Rows="10" TextMode="MultiLine" ClientIDMode="Static">Log file is empty!</asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="btnFromCache" runat="server" Text="Reload" OnClick="btnFromCache_Click" />    

</asp:Content>
