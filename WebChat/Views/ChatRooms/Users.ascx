<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebChat.Models.ChatRoom>" %>

    <h3>Users:</h3>
    <div id="users">
       <% if (Model.getUserCount() == 0) %>
       <% { %>
            <i>There are no users currently logged into this chat . . .</i>
       <% } %>
       <% else %>
       <% { %>
            <ul>
               <script type="text/javascript">
                   var room = "<%= Html.Encode(Model.ChatRoomID)%>";
                   getAllUsers(room);
               </script>
            </ul>
       <% } %>
    </div>
