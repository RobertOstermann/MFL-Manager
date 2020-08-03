"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable bid options until team is selected.
document.getElementById("opt-out").disabled = true;
document.getElementById("bid-input").disabled = true;
document.getElementById("submit-bid").disabled = true;

// Enable buttons once team is selected.
function enableButtons() {
    document.getElementById("opt-out").disabled = true;
    document.getElementById("bid-input").disabled = true;
    document.getElementById("submit-bid").disabled = true;
}

// Retrieve bid, message, and free agency
// information from the server.
connection.start().then(function () {
    enableButtons();
})

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