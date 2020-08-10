﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Retrieve bid, message, and free agency
// information from the server.
connection.start().then(function () {
    connection.invoke("SetUpServer");
    connection.invoke("GetCookie");
    connection.invoke("GetPlayer");
    connection.invoke("GetMessages");
    connection.invoke("GetBid");
    connection.invoke("CheckPermissions");
    connection.invoke("CheckCommissionerPermissions");
});

connection.on("RemoveCookie", function () {
    var TeamCookieDelete = "TeamCookie=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = TeamCookieDelete;
});

connection.on("GrantMessagePermissions", function () {
    // Enable message options until team is selected.
    document.getElementById("message-recipient").disabled = false;
    document.getElementById("message-input").disabled = false;
    document.getElementById("submit-message").disabled = false;
});

connection.on("GrantBidPermissions", function () {
    // Enable bid options until team is selected.
    document.getElementById("opt-out").disabled = false;
    document.getElementById("bid-input").disabled = false;
    document.getElementById("submit-bid").disabled = false;
});

connection.on("RevokeMessagePermissions", function () {
    // Disable message options until team is selected.
    document.getElementById("message-recipient").disabled = true;
    document.getElementById("message-input").disabled = true;
    document.getElementById("submit-message").disabled = true;
});

connection.on("RevokeBidPermissions", function () {
    // Disable bid options until team is selected.
    document.getElementById("opt-out").disabled = true;
    document.getElementById("bid-input").disabled = true;
    document.getElementById("submit-bid").disabled = true;
});

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
    cardText.innerHTML = msg;
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
    scrollToBottom("chat-box");
});

// Receive a direct message from the server.
connection.on("ReceiveMessageDirect", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var chatBox = document.getElementById("chat-box");
    // Build the message card.
    var card = document.createElement("div");
    card.classList.add("card", "border-primary", "chat-message");
    // Body of card.
    var cardBody = document.createElement("div");
    cardBody.classList.add("card-body", "text-dark");
    var cardText = document.createElement("p");
    cardText.classList.add("card-text");
    cardText.innerHTML = msg;
    // Footer of card.
    var cardFooter = document.createElement("div");
    cardFooter.classList.add("card-footer", "text-primary", "chat-message-footer");
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
    scrollToBottom("chat-box");
});

// Receive a sent message from the server.
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
    cardText.innerHTML = msg;
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
    scrollToBottom("chat-box");
});

// Receive a sent direct message from the server.
connection.on("SendMessageDirect", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var chatBox = document.getElementById("chat-box");
    // Build the message card.
    var card = document.createElement("div");
    card.classList.add("card", "border-primary", "chat-message-send");
    // Body of card.
    var cardBody = document.createElement("div");
    cardBody.classList.add("card-body");
    var cardText = document.createElement("p");
    cardText.classList.add("card-text");
    cardText.innerHTML = msg;
    // Footer of card.
    var cardFooter = document.createElement("div");
    cardFooter.classList.add("card-footer", "text-primary", "chat-message-footer");
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
    scrollToBottom("chat-box");
});

function scrollToBottom(id) {
    var div = document.getElementById(id);
    div.scrollTop = div.scrollHeight - div.clientHeight;
}

function sendMessage() {
    var recipient = $("#message-recipient").find("option:selected").text();
    var message = document.getElementById("message-input").value;
    connection.invoke("SendMessage", recipient, message).catch(function (err) {
        return console.error(err.toString());
    });
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

/* PLAYER CARD */

connection.on("SetPlayer", function (player) {
    var card = document.getElementById("bid-player-card");
    var image = document.getElementById("player-image");
    var name = document.getElementById("player-name");
    var team = document.getElementById("player-team");
    if (player.signed) {
        card.style.borderColor = "rgb(226, 0, 0)";
    }
    else {
        card.style.borderColor = "";
    }
    image.src = player.src;
    name.innerHTML = player.name;
    team.innerHTML = player.mflTeam;
    connection.invoke("CheckPermissions");
});

/* BID */

// Receive a bid from the server.
connection.on("ReceiveBid", function (team, bid) {
    var message = team + ": " + bid.toFixed(2);
    var betterBid = Math.round(parseFloat(bid));
    if (betterBid <= parseFloat(bid)) {
        betterBid += 0.50;
    }
    document.getElementById("current-bid").innerHTML = message;
    document.getElementById("bid-input").value = betterBid.toFixed(2);
});

// Send bid to the server.
function sendBid() {
    var bid = parseFloat(document.getElementById("bid-input").value);
    connection.invoke("SendBid", bid).catch(function (err) {
        return console.error(err.toString());
    });
}

// Send bid with enter button.
document.getElementById("bid-input").addEventListener("keyup", function (event) {
    if (event.keyCode == 13) {
        sendBid();
        event.preventDefault(); j
    }
});

// Send bid with submit button.
document.getElementById("submit-bid").addEventListener("click", function (event) {
    sendBid();
    event.preventDefault();
});

/* Commissioner Control */

connection.on("CommissionerPermissions", function (inProgress) {
    var cardFooter = document.getElementById("bid-card-footer");
    var commissionerSection = document.createElement("div");
    commissionerSection.id = "commissioner-section";
    // Build the first row.
    var rowOne = document.createElement("div");
    rowOne.classList.add("row", "mb-3");
    var colOne = document.createElement("div");
    colOne.classList.add("col");
    var colTwo = document.createElement("div");
    colTwo.classList.add("col");
    // Build the second row.
    var rowTwo = document.createElement("div");
    rowTwo.classList.add("row", "mb-3");
    var colThree = document.createElement("div");
    colThree.classList.add("col");
    colThree.id = "control-column";
    // Build the previous player button.
    var previousPlayer = document.createElement("button");
    previousPlayer.classList.add("btn", "btn-outline-dark", "btn-block", "commissioner-button");
    previousPlayer.type = "button";
    previousPlayer.id = "previous-player";
    previousPlayer.innerHTML = "Previous Player";
    if (!inProgress) previousPlayer.disabled = true;
    previousPlayer.addEventListener("click", function (event) {
        connection.invoke("GetPreviousPlayer").catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
    // Build the next player button.
    var nextPlayer = document.createElement("button");
    nextPlayer.classList.add("btn", "btn-outline-dark", "btn-block", "commissioner-button");
    nextPlayer.type = "button";
    nextPlayer.id = "next-player";
    nextPlayer.innerHTML = "Next Player";
    if (!inProgress) nextPlayer.disabled = true;
    nextPlayer.addEventListener("click", function (event) {
        connection.invoke("GetNextPlayer").catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
    // Build the control button.
    var control = document.createElement("button");
    if (inProgress) {
        control.classList.add("btn", "btn-outline-danger", "btn-block", "commissioner-button")
        control.type = "button";
        control.id = "control";
        control.innerHTML = "Sold";
        control.addEventListener("click", sold);
    }
    else {
        control.classList.add("btn", "btn-outline-success", "btn-block", "commissioner-button")
        control.type = "button";
        control.id = "control";
        control.innerHTML = "Start Free Agency";
        control.addEventListener("click", startFreeAgency);
    }
    // Combine the elements of the commissioner section.
    colOne.appendChild(previousPlayer);
    colTwo.appendChild(nextPlayer);
    rowOne.appendChild(colOne);
    rowOne.appendChild(colTwo);
    colThree.appendChild(control);
    rowTwo.appendChild(colThree);
    commissionerSection.appendChild(rowOne);
    commissionerSection.appendChild(rowTwo);
    cardFooter.appendChild(commissionerSection);
});

connection.on("StartFreeAgency", function () {
    document.getElementById("previous-player").disabled = false;
    document.getElementById("next-player").disabled = false;
    var control = document.getElementById("control");
    control.classList.remove("btn-outline-success");
    control.classList.add("btn-outline-danger");
    control.innerHTML = "Sold";
    control.removeEventListener("click", startFreeAgency);
    control.addEventListener("click", sold);
});

function startFreeAgency() {
    connection.invoke("StartFreeAgency").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}

function sold() {
    connection.invoke("PlayerSold").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}