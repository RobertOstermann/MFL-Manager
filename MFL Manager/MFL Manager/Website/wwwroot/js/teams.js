"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Retrieve team information from the server.
connection.start().then(function () {
    connection.invoke("GetTeams");
    connection.invoke("GetMessages");
    connection.invoke("GetBid");
})

connection.on("SelectTeam", function (team) {
    var card = document.getElementById(team);
    card.style.borderColor = "rgb(3, 235, 7)";
    // Set cookie to identify team.
    var TeamCookie = "TeamCookie=" + team;
    document.cookie = TeamCookie;
});

connection.on("ReceiveSetTeam", function (team) {
    var card = document.getElementById(team);
    card.style.borderColor = "rgb(226, 0, 0)";
});

connection.on("ReceiveRemoveTeam", function (team) {
    var card = document.getElementById(team);
    card.style.borderColor = "";
})

connection.on("RemoveCookie", function () {
    var TeamCookieDelete = "TeamCookie=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = TeamCookieDelete;
})

function selectTeam(team) {
    var card = document.getElementById(team);
    if (card.style.borderColor != "rgb(3, 235, 7)") {
        if (card.style.borderColor != "rgb(226, 0, 0)") {
            connection.invoke("SetTeam", team).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }
    else {
        connection.invoke("RemoveTeam", team).catch(function (err) {
            return console.error(err.toString());
        });
    }
}