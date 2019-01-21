"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveCountry", function (country) {
    var li = document.createElement("li");
    li.textContent = `${country.name}`;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById('sendButton').addEventListener("click", function (event) {
    var countryName = document.getElementById("countryName").value;
    var shortName = document.getElementById("shortName").value;
    var country = { name: countryName, shortName: shortName };
    connection.invoke("SendCountry", country).catch(function (err) { return console.error(err.toString()); });
    event.preventDefault();
});
