<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebChat.Models.ChatRoom>" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <div id="CreateEditChatRoom">
        <fieldset>
            <p>
                <label for="ChatRoomName">Room Name:</label>
                <%= Html.TextBox("ChatRoomName") %>
                <%= Html.ValidationMessage("ChatRoomName", "*") %>
            </p>
            <p>
                <label for="ChatRoomDescription">Description:</label>
                <%= Html.TextBox("ChatRoomDescription") %>
                <%= Html.ValidationMessage("ChatRoomDescription", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
        </div>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
