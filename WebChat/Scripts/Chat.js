var msgId = 0;

function DateDeserialize(dateStr) {
    return eval('new' + dateStr.replace(/\//g, ' '));
}

function getLatestMessages(room, msg) {
    $.ajaxSetup({ cache: false });
    $.getJSON("../../JavaScript/GetMessagesAfter/" + room + "/" + msg, null, function (data) {
        $.each(data, function(index, msg) {
            msgId = msg.MessageId;
            $("#messages").append("<li><span id=\"msgTimeStamp\">[" + DateDeserialize(msg.MessageTimeStamp) + "]</span> <span id=\"msgOwner\">" + msg.MessageOwner + "</span>  " + msg.MessageText + "</li>");
        });
        $("#messages").attr({ scrollTop: $("#messages").attr("scrollHeight") });
    });
    
}

function getAllUsers(room) {
    $.ajaxSetup({ cache: false });
    $.getJSON("../../JavaScript/GetUsers/" + room, function (data) {
        $("#users").html("");
        $.each(data, function(index, user) {
            $("#users").append("<li>" + user.UserName + "</li>");
        });
    });
}

function updateChat(room) {
    getAllUsers(room);
    getLatestMessages(room, msgId);
}