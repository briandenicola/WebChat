<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebChat.Helpers.LogInformation>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	User IP Address Log
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <h2>Users</h2>
    <table>
        <tr>
            <th>User Name</th>
            <th>User ID</th>
            <th>User Last Login Date</th>
        </tr>

    <% foreach (var item in Model.Users) { %>
    
        <tr>
            <td><%= Html.Encode(item.UserName) %></td>
            <td><%= Html.Encode(item.UserId)%></td>
            <td><%= Html.Encode(item.LastActivityDate) %></td>
        </tr>
    
    <% } %>

    </table>
    
    <hr />
    
    <h2>Roles</h2>
    <table>
        <tr>
            <th>Role Name</th>
            <th>Role ID</th>
            <th>Role Description</th>
        </tr>

    <% foreach (var item in Model.Roles) { %>
    
        <tr>
            <td><%= Html.Encode(item.RoleName) %></td>
            <td><%= Html.Encode(item.RoleId)%></td>
            <td><%= Html.Encode(item.Description) %></td>
        </tr>
    
    <% } %>

    </table>
    
    <hr />
    
    <h2>Users in Roles</h2>
    <table>
        <tr>
            <th>User Name</th>
            <th>Role Name</th>
        </tr>

    <% foreach (var item in Model.UsersInRoles) { %>
    
        <tr>
            <td><%= Html.Encode(item.UserName) %></td>
            <td><%= Html.Encode(item.RoleName) %></td>
        </tr>
    
    <% } %>

    </table>

    <hr />
    
    <h2>User IP Address Log</h2>

    <table>
        <tr>
            <th>User Name</th>
            <th>User IP Address</th>
            <th>User Login Time</th>
        </tr>

    <% foreach (var item in Model.Logs) { %>
    
        <tr>
            <td><%= Html.Encode(item.UserName) %></td>
            <td><%= Html.Encode(item.UserIPAddress) %></td>
            <td><%= Html.Encode(item.UserTimeStamp) %></td>
        </tr>
    
    <% } %>

    </table>


    <hr />
</asp:Content>

