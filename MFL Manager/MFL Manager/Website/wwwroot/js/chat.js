"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable bid options until team is selected.
document.getElementById("opt-out").disabled = true;
document.getElementById("bid-input").disabled = true;
document.getElementById("submit-bid").disabled = true;

// Enable buttons once team is selected.
function enableButtons() {
    document.getElementById("opt-out").disabled = false;
    document.getElementById("bid-input").disabled = false;
    document.getElementById("submit-bid").disabled = false;
}

// Retrieve bid, message, and free agency
// information from the server.
connection.start().then(function () {
    enableButtons();
})

/*  MESSAGE */

// Receive a message from the server.
connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var chatBox = document.getElementById("chat-box");
    // Build the message card.
    var card = document.createElement("div");
    card.classList.add("card", "chat-message");
    // Body of card.
    var cardBody = document.createElement("div");
    cardBody.classList.add("card-body");
    var cardText = document.createElement("p");
    cardText.classList.add("card-text");
    cardText.innerHTML = message;
    // Footer of card.
    var cardFooter = document.createElement("div");
    cardFooter.classList.add("card-footer", "chat-message-footer");
    var cardIdentifier = document.createElement("p");
    cardIdentifier.classList.add("chat-message-identifier");
    cardIdentifier.innerHTML = user;

    // Combine the elements of the card.
    cardBody.appendChild(cardText);
    cardFooter.appendChild(cardIdentifier);
    card.appendChild(cardBody);
    card.appendChild(cardFooter);
    // Add the card to the message box.
    chatBox.appendChild(card);
});

// Receive a sent a message from the server.
connection.on("SendMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var chatBox = document.getElementById("chat-box");
    // Build the message card.
    var card = document.createElement("div");
    card.classList.add("card", "chat-message-send");
    // Body of card.
    var cardBody = document.createElement("div");
    cardBody.classList.add("card-body");
    var cardText = document.createElement("p");
    cardText.classList.add("card-text");
    cardText.innerHTML = message;
    // Footer of card.
    var cardFooter = document.createElement("div");
    cardFooter.classList.add("card-footer", "chat-message-footer");
    var cardIdentifier = document.createElement("p");
    cardIdentifier.classList.add("chat-message-identifier");
    cardIdentifier.innerHTML = user;

    // Combine the elements of the card.
    cardBody.appendChild(cardText);
    cardFooter.appendChild(cardIdentifier);
    card.appendChild(cardBody);
    card.appendChild(cardFooter);
    // Add the card to the message box.
    chatBox.appendChild(card);
});

function sendMessage() {
    // Need to implement user by team selection.
    var user = "Power";
    var message = document.getElementById("message-input").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    })
    document.getElementById("message-input").value = "";
}

document.getElementById("message-input").addEventListener("keyup", function (event) {
    if (event.keyCode == 13) {
        sendMessage();
        event.preventDefault();
    }
});

document.getElementById("submit-message").addEventListener("click", function (event) {
    sendMessage();
    event.preventDefault();
});


/* BID */

// Receive a bid from the server.
connection.on("ReceiveBid", function (team, bid) {
    var message = team + ": " + bid.toFixed(2);
    document.getElementById("current-bid").innerHTML = message;
    document.getElementById("bid-input").value = bid.toFixed(2);
});

// Send bid to the server.
function sendBid() {
    var bid = parseFloat(document.getElementById("bid-input").value);
    connection.invoke("SendBid", bid).catch(function (err) {
        return console.error(err.toString());
    })
}

// Send bid with enter button.
document.getElementById("bid-input").addEventListener("keyup", function (event) {
    if (event.keyCode == 13) {
        sendBid();
        event.preventDefault();j
    }
})

// Send bid with submit button.
document.getElementById("submit-bid").addEventListener("click", function (event) {
    sendBid();
    event.preventDefault();
})