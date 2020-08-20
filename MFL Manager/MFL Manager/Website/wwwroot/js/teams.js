"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Retrieve team information from the server.
connection.start().then(function () {
    connection.invoke("SetUpServer");
    connection.invoke("GetCookie");
    connection.invoke("GetTeams");
});

connection.on("SetCookie", function (team) {
    var teamCookie = "TeamCookie=" + team;
    document.cookie = teamCookie;
});

connection.on("RemoveCookie", function () {
    var teamCookieDelete = "TeamCookie=; expires=Thu, 01 Jan 1970 00:00:00 UTC;";
    document.cookie = teamCookieDelete;
});

connection.on("UpdateTeams", function () {
    connection.invoke("GetTeams");
});

connection.on("ServerSelectTeam", function (team) {
    var card = document.getElementById(team);
    card.style.borderColor = "rgb(3, 235, 7)";
});

connection.on("SelectTeam", function (team) {
    var card = document.getElementById(team);
    card.style.borderColor = "rgb(3, 235, 7)";
    window.location.href = "/FreeAgency";
});

connection.on("ReceiveSetTeam", function (team) {
    var card = document.getElementById(team);
    card.style.borderColor = "rgb(226, 0, 0)";
});

connection.on("ReceiveRemoveTeam", function (team) {
    var card = document.getElementById(team);
    card.style.borderColor = "";
});

function selectTeam(team) {
    var card = document.getElementById(team);
    if (card.style.borderColor !== "rgb(3, 235, 7)") {
        if (card.style.borderColor !== "rgb(226, 0, 0)") {
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