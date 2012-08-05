<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebChat.Models.ChatRoom>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit this Chat Room</h2>

    <% Html.RenderPartial("ChatRoomForm"); %>

    <div>
        <%=Html.ActionLink("Delete this Room", "Delete", new { id = Model.ChatRoomID })%>
    </div>
</asp:Content>

