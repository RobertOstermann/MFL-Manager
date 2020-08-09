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
    var i, j;
    var divisions = Math.floor(players.length / 4);
    if (players.length % 4 != 0) {
        divisions += 1;
    }
    var playerCards = document.getElementById("player-cards");
    for (i = 0; i < divisions; i++) {
        var row = document.createElement("div");
        row.classList.add("row", "padding");
        // Add player cards to the row.
        for (j = 0; j < 4; j++) {
            var playerNumber = j + i * 1;
            if (playerNumber >= players.length);
            // Build the column.
            var column = document.createElement("div");
            column.classList.add("col-sm-6", "col-md-3");
            // Build the player card.
            var card = document.createElement("div");
            card.classList.add("card");
            card.id = i.toString();
            // Image of card.
            var image = document.createElement("img");
            image.classList.add("card-img-top");
            image.src = players[playerNumber].src;
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
            // Paragraph of body of card.
            var paragraph = document.createElement("p");
            paragraph.classList.add("card-text");
            paragraph.innerHTML = "NFL Team: " +  players[playerNumber].nflTeam + "<br>Age: " + players[playerNumber].age + "<br>Salary: $" +  players[playerNumber].salary.toFixed(2) +
                "<br>2019 Position Rank: " + players[playerNumber].previousRank + "<br>2019 Fantasy Average: " + players[playerNumber].previousAverage.toFixed(2);
            // Combine the elements of the card.
            body.appendChild(title);
            body.appendChild(subtitle);
            body.appendChild(paragraph);
            card.appendChild(image);
            card.appendChild(body);
            column.appendChild(card);
            row.appendChild(column);
        }
        playerCards.appendChild(row);
    }
})

// Player Linked List Test

connection.on("TestPlayer", function (player) {
    document.getElementById("playerTest").innerHTML = JSON.stringify(player);
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