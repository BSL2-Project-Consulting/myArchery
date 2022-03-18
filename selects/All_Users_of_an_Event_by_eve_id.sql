USE MyArchery;

-- all Users in an event (you have to set eve_id)
SELECT 
	e.eve_id,
    e.eventname,
    u.username
FROM event_user_roles eur
LEFT JOIN user u ON eur.use_id = u.use_id
LEFT JOIN event e ON eur.eve_id = e.eve_id
WHERE e.eve_id = 1
ORDER BY e.eve_id