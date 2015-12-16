<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="GeneralSolutions.WCF.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <p></p>
    <p></p>
    <p>To view the log file click: <asp:HyperLink ID="lnkLog" runat="server" NavigateUrl="~/Log.aspx">View Log</asp:HyperLink></p>
</asp:Content>
