
var connection = new signalR.HubConnectionBuilder().withUrl("/messages").build();
connection.on("RecieveMessage", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var div = document.createElement("div");
    div.innerHTML = msg + "<hr/>";
    document.getElementById("messages").appendChild(div);

});

connection.on("UserConnected", function (connectionId) {
    var groupElement = document.getElementById("group");
    var option = document.createElement("option");
    option.text = connectionId;
    option.value = connectionId;
    groupElement.add(option);
});

connection.on("UserDisconnected", function (connectionId) {
    var groupElement = document.getElementsByTagName("group");
    for (var i = 0; i < groupElement.length; i++) {
        if (groupElement.option[i].value == connectionId) {
            groupElement.remove(i);
        }
    }
});

connection.start().catch(function (err) {
    return console.error(err.ToString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("message").value;
    var groupElement = document.getElementById("group");
    var groupValue = getElement.options[groupElement.selectedIndex].value;
    var method = "SendMessageToAll";
    if (groupValue === "All" || groupValue === "Myself") {
        var method = groupValue === "All" ? "SendMessageToCaller" : "SendMessageToCaller";
        connection.invoke(method, message).catch(function (err) {
            return console.error(err.ToString());
        });
    }
    else {
        connection.invoke("SendMessageToUser",groupValue, message).catch(function (err) {
            return console.error(err.ToString());
        });
    }
    event.preventDefault();
});