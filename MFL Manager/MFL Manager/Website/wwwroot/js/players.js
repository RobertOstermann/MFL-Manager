"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Retrieve player information from the server.
connection.start().then(function () {
    connection.invoke("GetCookie");
})
