"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
document.getElementById("bidButton").disabled = true;

connection.on("ReceiveMessage", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var li = document.createElement("li");
    li.textContent = msg;
    document.getElementById("messagesList").appendChild(li);
});

connection.on("ReceiveBid", function (currentBid) {
    document.getElementById("currentBid").innerHTML = currentBid.toFixed(2);
    document.getElementById("bidInput").value = currentBid.toFixed(2);
})

connection.start().then(function () {
    connection.invoke("GetMessages")
    connection.invoke("GetBid");
    document.getElementById("sendButton").disabled = false;
    document.getElementById("bidButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("messageInput").addEventListener("keyup", function (event) {
    if (event.keyCode == 13) {
        document.getElementById("sendButton").click();
        document.getElementById("messageInput").value = "";
        event.preventDefault();
    }
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("messageInput").value = "";
    event.preventDefault();
});

document.getElementById("bidInput").addEventListener("keyup", function (event) {
    if (event.keyCode == 13) {
        document.getElementById("bidButton").click();
        event.preventDefault();
    }
})

document.getElementById("bidButton").addEventListener("click", function (event) {
    var bidAmount = parseFloat(document.getElementById("bidInput").value);
    connection.invoke("SendBid", bidAmount).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});