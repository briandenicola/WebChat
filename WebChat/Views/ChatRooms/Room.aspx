<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebChat.Models.ChatRoom>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Chat Room:  <%= Html.Encode(Model.ChatRoomName) %> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../../Scripts/Chat.js" type="text/javascript"></script> 

    <h2>Chat Room:  <%= Html.Encode(Model.ChatRoomName) %> </h2>
     
    <div id="chat">   
        <% Html.RenderPartial("Users"); %>
        <% Html.RenderPartial("Messages"); %>
        <% Html.RenderPartial("MessageEntry"); %>
     </div>
     
    <% if (Model.IsUserLoggedIn(Context.User.Identity.Name)) { %>
        
        <p><%=Html.ActionLink("Leave Room", "Leave", "ChatRooms", new { id = Model.ChatRoomID }, null)%> </p>
    
    <% } %>
        
</asp:Content>

