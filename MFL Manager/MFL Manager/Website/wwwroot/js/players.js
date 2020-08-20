"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Retrieve player information from the server.
connection.start().then(function () {
    connection.invoke("SetUpServer");
    connection.invoke("GetCookie");
    connection.invoke("GetPlayers");
});

connection.on("RemoveCookie", function () {
    var teamCookieDelete = "TeamCookie=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = teamCookieDelete;
});

// Build Player Cards Test

connection.on("SetPlayers", function (players) {
    var divisions = Math.floor(players.length / 4);
    if (players.length % 4 !== 0) {
        divisions += 1;
    }
    var playerCards = document.getElementById("player-cards");
    for (var i = 0; i < divisions; i++) {
        var row = document.createElement("div");
        row.classList.add("row", "padding");
        // Add player cards to the row.
        for (var j = 0; j < 4; j++) {
            var playerNumber = j + i * 4;
            if (playerNumber >= players.length) {
                break;
            }
            // Build the column.
            var column = document.createElement("div");
            column.classList.add("col-sm-6", "col-md-3");
            // Build the player card.
            var card = document.createElement("div");
            card.classList.add("card");
            card.id = players[playerNumber].id;
            if (players[playerNumber].signed) {
                card.style.borderColor = "rgb(226, 0, 0)";
            }
            // Image of card.
            var image = document.createElement("img");
            image.classList.add("card-img-top");
            image.src = players[playerNumber].src;
            image.alt = players[playerNumber].name + " Image";
            // Body of card.
            var body = document.createElement("div");
            body.classList.add("card-body");
            // Title of body of card.
            var title = document.createElement("h4");
            title.classList.add("card-title");
            title.innerHTML = players[playerNumber].name;
            // Subtitle of body of card.
            var subtitle = document.createElement("h5");
            subtitle.classList.add("card-subtitle", "mb-2", "text-muted");
            subtitle.innerHTML = players[playerNumber].mflTeam;
            subtitle.id = players[playerNumber].id + "-mfl-team";
            var salary = document.createElement("h5");
            salary.classList.add("card-subtitle", "mb-2", "text-muted");
            if (players[playerNumber].contractYears === 0) {
                salary.innerHTML = "$" + players[playerNumber].salary.toFixed(2);
            } else {
                salary.innerHTML = "$" + players[playerNumber].salary.toFixed(2) + " for " + players[playerNumber].contractYears + " years.";
            }
            salary.id = players[playerNumber].id + "-salary";
            // Paragraph of body of card.
            var paragraph = document.createElement("p");
            paragraph.classList.add("card-text");
            paragraph.innerHTML = "NFL Team: " + players[playerNumber].nflTeam + "<br>Age: " + players[playerNumber].age + "<br>2019 Position Rank: "
                + players[playerNumber].previousRank + "<br>2019 Fantasy Average: " + players[playerNumber].previousAverage.toFixed(2);
            paragraph.id = players[playerNumber].id + "-information";
            // Combine the elements of the card.
            body.appendChild(title);
            body.appendChild(subtitle);
            body.appendChild(salary);
            body.appendChild(paragraph);
            card.appendChild(image);
            card.appendChild(body);
            column.appendChild(card);
            row.appendChild(column);
        }
        playerCards.appendChild(row);
    }
});

connection.on("UpdatePlayers", function (player) {
    document.getElementById(player.id + "-mfl-team").innerHTML = player.mflTeam;
    if (player.contractYears === 0) {
        document.getElementById(player.id + "-salary").innerHTML = "$" + player.salary.toFixed(2);
    } else {
        document.getElementById(player.id + "-salary").innerHTML = "$" + player.salary.toFixed(2) + " for " + player.contractYears + " years.";
    }
    document.getElementById(player.id + "-information").innerHTML = "NFL Team: " + player.nflTeam + "<br>Age: " + player.age + "<br>2019 Position Rank: "
        + player.previousRank + "<br>2019 Fantasy Average: " + player.previousAverage.toFixed(2);
    if (player.signed) {
        document.getElementById(player.id).style.borderColor = "rgb(226, 0, 0)";
    } else {
        document.getElementById(player.id).style.borderColor = "";
    }
});