"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

var selectedTeam = false;

// Retrieve team information from the server.
connection.start().then(function () {
    connection.invoke("GetTeams");
    connection.invoke("GetMessages");
    connection.invoke("GetBid");
})

connection.on("SelectTeam", function (team) {
    var card = document.getElementById(team);
    card.style.borderColor = "#03eb07";
    // Set cookie to identify team.
    var TeamCookie = "TeamCookie=" + team;
    document.cookie = TeamCookie;
    selectedTeam = true;
});

connection.on("ReceiveSetTeam", function (team) {
    var card = document.getElementById(team);
    card.style.borderColor = "#e20000";
    card.disabled = true;
});

function selectTeam(team) {
    var card = document.getElementById(team);
    if (!selectedTeam) {
        if (!card.disabled) {
            connection.invoke("SetTeam", team).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }
}