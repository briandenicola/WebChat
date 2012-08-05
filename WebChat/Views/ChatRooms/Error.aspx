<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebChat.Models.ChatRoom>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Error
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>We apologize but an unexpected error has occured . . .</h2>
    <p>Please try again later.</p>
    
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>
