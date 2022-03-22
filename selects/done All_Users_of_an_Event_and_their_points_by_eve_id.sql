USE MyArchery;

-- all users in an event and their points (you have to set eve_id)
SELECT 
	e.eventname AS 'Event Name',
    u.username AS 'Username',
    SUM(p.value) AS 'Punkte'
FROM event_user_roles eur
LEFT JOIN event e ON eur.eve_id = e.eve_id
LEFT JOIN user u ON eur.use_id = u.use_id
LEFT JOIN arrow a ON eur.evusro_id = a.evusro_id
LEFT JOIN points p ON a.poi_id = p.poi_id
WHERE eur.eve_id = 1
GROUP BY e.eventname, u.username


