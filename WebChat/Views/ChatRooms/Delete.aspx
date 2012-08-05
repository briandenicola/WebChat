<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebChat.Models.ChatRoom>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <strong>Please Confirm the Chat Room to Be Deleted</strong> : <%= Html.Encode(Model.ChatRoomName) %>
    
      <% using (Html.BeginForm()) {%>
        <input type="submit" value="Delete" name="confirmButton" />
      <% } %>        
      
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
    
</asp:Content>
