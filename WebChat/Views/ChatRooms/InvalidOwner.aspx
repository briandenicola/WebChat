<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebChat.Models.ChatRoom>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	NotOwner
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Only the chat room owner is allowed to delete or edit a room</h2>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

