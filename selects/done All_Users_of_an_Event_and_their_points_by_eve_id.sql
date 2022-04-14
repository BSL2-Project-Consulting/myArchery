USE MyArchery;

-- all users in an event and their points (you have to set eve_id)
SELECT
	e.eventname AS 'Event Name',
	u.username AS 'Username',
	SUM(p.value) AS 'Punkte'
FROM EventUserRole eur
LEFT JOIN event e ON eur.eveid = e.eveid
LEFT JOIN AspNetUsers u ON eur.useid = u.id
LEFT JOIN arrow a ON eur.evusroid = a.Evusroid
LEFT JOIN point p ON a.PoiId = p.poiid
WHERE eur.eveid = 3
GROUP BY e.eventname, u.username

