<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebChat.Models.ChatRoom>" %>

<% if (Request.IsAuthenticated) { %>

    <% if (Model.IsUserLoggedIn(Context.User.Identity.Name)) { %>
        <% using (Html.BeginForm()) {%>
            <div id="message_entry">   
                <p>
                    <h3>Messages:</h3>
                    <textarea id=MessageText" name="MessageText" rows="2" onkeypress="if (event.keyCode == 13) {this.form.submit();}" ></textarea> 
                </p>
            </div>
            <script type="text/javascript">
                $(function() { $("textarea:enabled:first").focus(); });
            </script>
        <% } %>
                
    <% } else { %> 
        <p><%=Html.ActionLink("Join Room", "Join", "ChatRooms", new { id = Model.ChatRoomID }, null)%> </p>
    <% } %>
<% } %>