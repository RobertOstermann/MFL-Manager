"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Retrieve player information from the server.
connection.start().then(function () {
    connection.invoke("SetUpServer");
    connection.invoke("GetCookie");
    connection.invoke("GetPlayers");
})

connection.on("RemoveCookie", function () {
    var TeamCookieDelete = "TeamCookie=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = TeamCookieDelete;
});

// Build Player Cards Test

connection.on("SetPlayers", function (players) {
    var divisions = Math.floor(players.length / 4);
    if (players.length % 4 != 0) {
        divisions += 1;
    }
    
})

// Player Linked List Test

connection.on("TestPlayer", function (player) {
    document.getElementById("playerTest").innerHTML = player;
});

document.getElementById("previous").addEventListener("click", function (event) {
    connection.invoke("GetPreviousPlayer").catch(function (err) {
        return console.error(err.toString());
    })
    event.preventDefault();
});

document.getElementById("current").addEventListener("click", function (event) {
    connection.invoke("GetCurrentPlayer").catch(function (err) {
        return console.error(err.toString());
    })
    event.preventDefault();
});

document.getElementById("next").addEventListener("click", function (event) {
    connection.invoke("GetNextPlayer").catch(function (err) {
        return console.error(err.toString());
    })
    event.preventDefault();
});