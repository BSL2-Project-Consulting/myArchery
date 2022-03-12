use myArchery;

-- all points of a user in an event (you have to set eve_id)
SELECT 
	e.eventname AS 'Event Name',
    u.username AS 'Username',
    SUM(p.value) AS 'Points'
FROM arrow a
LEFT JOIN event_user_roles eur ON a.evusro_id = eur.evusro_id
LEFT JOIN points p ON a.poi_id = p.poi_id
LEFT JOIN user u ON eur.use_id = u.use_id
LEFT JOIN event e ON eur.eve_id = e.eve_id
WHERE eur.eve_id = 3
GROUP BY e.eventname, u.username;
