"use strict";
const connection = new signalR.HubConnectionBuilder()
	.withUrl("/liverankingHub")
	.configureLogging(signalR.LogLevel.Information)
	.build();

window.onload = function () {
	console.log("connection started");
	connection.invoke("AddToGroup", eventid);
}

window.onclose = function () {
	console.log("closing");
	connection.invoke("RemoveFromGroup", eventid);
}

start();

connection.on("RecieveLeaderboard", function (rankings) {
	var table = document.getElementById("players");
	var rank = JSON.parse(rankings);

    for (var i in rank) {
		var string = `<tr>	<td> ${i.Username}</td> <td>${i.Points}</td> </tr >`;
		table.appendChild(string);
    }
});