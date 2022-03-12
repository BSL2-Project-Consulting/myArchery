USE MyArchery;

-- users current event's (you have to set username)
SELECT 
	u.username,
    e.eventname
FROM user u
LEFT JOIN event_user_roles eur ON u.use_id = eur.use_id
LEFT JOIN event e ON eur.eve_id = e.eve_id
WHERE u.username = 'User2'
ORDER BY u.username

