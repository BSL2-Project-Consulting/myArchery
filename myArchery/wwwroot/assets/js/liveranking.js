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
	console.log("Recieved Leaderboard");
	var table = document.getElementById("players");
	var rank = JSON.parse(rankings);
	table.innerHTML = '';
	var html = "";
	html += "<tr><th>Spieler</th><th>Punkte</th></tr >";
    for (var i in rank) {
		html += `<tr>	<td> ${i.Username}</td> <td>${i.Points}</td> </tr >`;
		table.appendChild(string);
	}

	table.innerHTML = html;
});