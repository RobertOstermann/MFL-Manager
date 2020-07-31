﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
document.getElementById("bidButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + ": " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.on("ReceiveBid", function (currentBid) {
    document.getElementById("currentBid").innerHTML = currentBid.toFixed(2);
})

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    document.getElementById("bidButton").disabled = false;
    document.getElementById("currentBid").innerHTML = connection.invoke("GetBid");
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("bidButton").addEventListener("click", function (event) {
    var bidAmount = parseFloat(document.getElementById("bidAmount").value);
    connection.invoke("SendBid", bidAmount).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});