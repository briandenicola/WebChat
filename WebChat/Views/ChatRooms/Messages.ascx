<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebChat.Models.ChatRoom>" %>

    <h3>Chat Window:</h3>
    <div id="messages">
       <% if (Model.getMessageCount() == 0) %>
       <% { %>
            <i>There are no messages currently in this chat . . .</i>
       <% } %>
       <% else %>
       <% { %>
            <ul>
               <script type="text/javascript">
                   var room = "<%= Html.Encode(Model.ChatRoomID)%>";
                   getLatestMessages(room,0);
                   setInterval("updateChat(room)", 3000);
               </script>
            </ul>
       <% } %>
    </div>
   