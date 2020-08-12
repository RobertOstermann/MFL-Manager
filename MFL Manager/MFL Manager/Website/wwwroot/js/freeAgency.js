"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Retrieve bid, message, and free agency
// information from the server.
connection.start().then(function () {
    connection.invoke("SetUpServer");
    connection.invoke("GetCookie");
    connection.invoke("CheckPermissions");
    connection.invoke("CheckCommissionerPermissions");
    connection.invoke("GetPlayer");
    connection.invoke("GetMessages");
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
    // Display correct button - bid / match / years
    BuildBidButton();
    // Enable bid options until team is selected.
    document.getElementById("opt-out").disabled = false;
    document.getElementById("bid-input").disabled = false;
    document.getElementById("submit-bid").disabled = false;
    // Get the bid.
    connection.invoke("GetBid");
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
    cardBody.classList.add("card-body", "py-2");
    var cardText = document.createElement("p");
    cardText.classList.add("card-text");
    cardText.innerHTML = msg;
    // Footer of card.
    var cardFooter = document.createElement("div");
    cardFooter.classList.add("card-footer", "chat-message-footer", "py-2");
    var cardIdentifier = document.createElement("p");
    cardIdentifier.classList.add("chat-message-identifier", "my-0");
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
    cardBody.classList.add("card-body", "text-dark", "py-2");
    var cardText = document.createElement("p");
    cardText.classList.add("card-text");
    cardText.innerHTML = msg;
    // Footer of card.
    var cardFooter = document.createElement("div");
    cardFooter.classList.add("card-footer", "text-primary", "chat-message-footer", "py-2");
    var cardIdentifier = document.createElement("p");
    cardIdentifier.classList.add("chat-message-identifier", "my-0");
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
    cardBody.classList.add("card-body", "py-2");
    var cardText = document.createElement("p");
    cardText.classList.add("card-text");
    cardText.innerHTML = msg;
    // Footer of card.
    var cardFooter = document.createElement("div");
    cardFooter.classList.add("card-footer", "chat-message-footer", "py-2");
    var cardIdentifier = document.createElement("p");
    cardIdentifier.classList.add("chat-message-identifier", "my-0");
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
    cardBody.classList.add("card-body", "py-2");
    var cardText = document.createElement("p");
    cardText.classList.add("card-text");
    cardText.innerHTML = msg;
    // Footer of card.
    var cardFooter = document.createElement("div");
    cardFooter.classList.add("card-footer", "text-primary", "chat-message-footer", "py-2");
    var cardIdentifier = document.createElement("p");
    cardIdentifier.classList.add("chat-message-identifier", "my-0");
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

connection.on("OptIn", function () {
    // Disable bid options while team is opted out.
    document.getElementById("bid-input").disabled = false;
    document.getElementById("submit-bid").disabled = false;
    var optOut = document.getElementById("opt-out");
    optOut.classList.remove("btn-outline-success");
    optOut.classList.add("btn-outline-danger");
    optOut.innerHTML = "Opt Out";
    optOut.removeEventListener("click", optIn);
    optOut.addEventListener("click", optOut);
});

connection.on("OptOut", function () {
    // Disable bid options while team is opted out.
    document.getElementById("bid-input").disabled = true;
    document.getElementById("submit-bid").disabled = true;
    var optOut = document.getElementById("opt-out");
    optOut.classList.remove("btn-outline-danger");
    optOut.classList.add("btn-outline-success");
    optOut.innerHTML = "Opt In";
    optOut.removeEventListener("click", optOut);
    optOut.addEventListener("click", optIn);
});

connection.on("UpdateOptOut", function (teams) {
    var teamLabels = document.getElementById("opt-out-teams").children;
    for (var i = 0; i < teamLabels.length; i++) {
        teamLabels[i].style.color = "";
        for (var j = 0; j < teams.length; j++) {
            if (teamLabels[i].id == teams[j]) {
                teamLabels[i].style.color = "rgb(226, 0, 0)";
            }
        }
    }
});


function optOut() {
    connection.invoke("OptOut").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}

function optIn() {
    connection.invoke("OptIn").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}

/* Bid Control */

function BuildBidButton() {
    var buttonSection = document.getElementById("bid-button-section");
    if (document.contains(document.getElementById("bid-input-group"))) {
        document.getElementById("bid-input-group").remove();
    }
    // Build the input group.
    var inputGroup = document.createElement("div");
    inputGroup.classList.add("input-group", "mb-3");
    inputGroup.id = "bid-input-group";
    // Build the opt out button.
    var optOutSection = document.createElement("div");
    optOutSection.classList.add("input-group-prepend");
    var optOutButton = document.createElement("button");
    optOutButton.classList.add("btn", "btn-outline-danger", "bid-button");
    optOutButton.type = "button";
    optOutButton.id = "opt-out";
    optOutButton.innerHTML = "Opt Out";
    optOutButton.addEventListener("click", optOut);
    // Build the number input.
    var number = document.createElement("input");
    number.classList.add("form-control");
    number.type = "number";
    number.step = "0.50";
    number.min = "0.00";
    number.id = "bid-input";
    number.addEventListener("keyup", function (event) {
        if (event.keyCode == 13) {
            sendBid();
            event.preventDefault();
        }
    });
    // Build the bid button.
    var bidButtonSection = document.createElement("div");
    bidButtonSection.classList.add("input-group-append");
    var bidButton = document.createElement("button");
    bidButton.classList.add("btn", "btn-outline-primary", "bid-button");
    bidButton.type = "button";
    bidButton.id = "submit-bid";
    bidButton.innerHTML = "Submit Bid";
    bidButton.addEventListener("click", function (event) {
        sendBid();
        event.preventDefault();
    });
    // Combine the elements.
    optOutSection.appendChild(optOutButton);
    bidButtonSection.appendChild(bidButton);
    inputGroup.appendChild(optOutSection);
    inputGroup.appendChild(number);
    inputGroup.appendChild(bidButtonSection);
    buttonSection.appendChild(inputGroup);
}
/*
<div class="input-group mb-3" id="bid-input-group">
    <div class="input-group-prepend">
        <button class="btn btn-outline-danger bid-button" type="button" id="opt-out">Opt Out</button>
    </div>
    <input type="number" class="form-control" placeholder="0.00" step="0.50" min="0.00" id="bid-input">
        <div class="input-group-append">
            <button class="btn btn-outline-primary bid-button" type="button" id="submit-bid">Submit Bid</button>
        </div>
</div>
*/

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
    // Build the second row.
    var rowTwo;
    if (inProgress) {
        rowTwo = createInProgressFreeAgencySection();
    }
    else {
        rowTwo = createStartFreeAgencySection();
    }
    // Combine the elements of the commissioner section.
    colOne.appendChild(previousPlayer);
    colTwo.appendChild(nextPlayer);
    rowOne.appendChild(colOne);
    rowOne.appendChild(colTwo);
    commissionerSection.appendChild(rowOne);
    commissionerSection.appendChild(rowTwo);
    cardFooter.appendChild(commissionerSection);
});

connection.on("StartFreeAgency", function () {
    document.getElementById("previous-player").disabled = false;
    document.getElementById("next-player").disabled = false;
    var commissionerSection = document.getElementById("commissioner-section")
    var previousControl = document.getElementById("control-row-two");
    var control = createInProgressFreeAgencySection();
    commissionerSection.removeChild(previousControl);
    commissionerSection.appendChild(control);
});

function startFreeAgency() {
    connection.invoke("StartFreeAgency").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}

function reset() {
    connection.invoke("PlayerReset").catch(function (err) {
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

function createStartFreeAgencySection() {
    // Build the row.
    var rowTwo = document.createElement("div");
    rowTwo.classList.add("row", "mb-3");
    rowTwo.id = "control-row-two";
    // Build the column.
    var colOne = document.createElement("div");
    colOne.classList.add("col");
    colOne.id = "control-column";
    // Build the button.
    var control = document.createElement("button");
    control.classList.add("btn", "btn-outline-success", "btn-block", "commissioner-button");
    control.type = "button";
    control.id = "control-start";
    control.innerHTML = "Start Free Agency";
    control.addEventListener("click", startFreeAgency);
    colOne.appendChild(control);
    rowTwo.appendChild(colOne);
    return rowTwo;
}

function createInProgressFreeAgencySection() {
    // Build the row.
    var rowTwo = document.createElement("div");
    rowTwo.classList.add("row", "mb-3");
    rowTwo.id = "control-row-two";
    // Build the columns.
    var colOne = document.createElement("div");
    colOne.classList.add("col");
    var colTwo = document.createElement("div");
    colTwo.classList.add("col");
    // Build the reset button.
    var controlReset = document.createElement("button");
    controlReset.classList.add("btn", "btn-warning", "btn-block", "commissioner-button");
    controlReset.type = "button";
    controlReset.id = "control-reset";
    controlReset.innerHTML = "Reset";
    controlReset.addEventListener("click", reset);
    colOne.appendChild(controlReset);
    // Build the sold button.
    var controlSold = document.createElement("button");
    controlSold.classList.add("btn", "btn-outline-danger", "btn-block", "commissioner-button");
    controlSold.type = "button";
    controlSold.id = "control-sold";
    controlSold.innerHTML = "Sold";
    controlSold.addEventListener("click", sold);
    colTwo.appendChild(controlSold);
    rowTwo.appendChild(colOne);
    rowTwo.appendChild(colTwo);
    return rowTwo;
}