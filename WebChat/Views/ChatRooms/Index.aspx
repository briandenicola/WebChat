<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebChat.Helpers.PaginatedList<WebChat.Models.ChatRoom>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Web Chat Rooms . . .
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All ChatRooms Hosted on this Site</h2>

    <table>
        <tr>
            <th>
                Name
            </th>
            <th>
                Description
            </th>
            <th>
                Owner
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink( item.ChatRoomName, "Room", new { id=item.ChatRoomID })%>
            </td>
            <td>
                <%= Html.Encode(item.ChatRoomDescription) %>
            </td>
            <td>
                <%= Html.Encode(item.ChatRoomCreator) %>
            </td>
            
            <% if( item.IsOwner(Context.User.Identity.Name) ) { %>
                <td>
                    <%= Html.ActionLink("Manage", "Edit", new { id=item.ChatRoomID }) %> 
                </td>
            <% } %>
        </tr>
    
    <% } %>
    
    </table>

    <% if( Model.HasPreviousPage ) { %>
        <%= Html.RouteLink("<<<", "ChatRooms", new { page = (Model.PageIndex-1) } ) %>
    <% } %>
        
    <% if( Model.HasNextPage ) { %>
        <%= Html.RouteLink(">>>", "ChatRooms", new { page = (Model.PageIndex+1) } ) %>
    <% } %>

    <p>
        <%= Html.ActionLink("Create New Room", "Create") %>
    </p>

</asp:Content>

