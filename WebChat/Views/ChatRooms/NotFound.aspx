<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebChat.Models.ChatRoom>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	NotFound
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>The chat room that you were looking for can not be found</h2>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>
