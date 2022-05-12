"use strict";

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/liverankingHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
		console.log("SignalR Connected.");
		connec.invoke("SendRanking", eventid);
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


connection.onclose(async () => {
    await start();
});

// Start the connection.
await start();

connection.on("RecieveLeaderboard", function (rankings) {
	 console.log("Recieved Leaderboard");
	 var table = document.getElementById("players");
	 var rank = JSON.parse(rankings);
	 var html = "";
	 html += "<tr><th>Spieler</th><th>Punkte</th></tr >";
	 for (var i in rank) {
		 html += `<tr>	<td> ${i.Username}</td> <td>${i.Points}</td> </tr >`;
		 table.appendChild(string);
	 }

	 table.innerHTML = html;
 });



/*
 * connection.on("RecieveLeaderboard", function (rankings) {
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
 */