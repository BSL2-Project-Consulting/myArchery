use myArchery;


-- all users from an events and their roles
SELECT 
	e.name AS 'Event',
    u.username AS 'Username',
    r.name AS 'Role'
FROM event_user_roles eur
LEFT JOIN event e ON eur.eve_id = e.eve_id
LEFT JOIN user u ON eur.use_id = u.use_id
LEFT JOIN roles r ON eur.rol_id = r.rol_id
ORDER BY e.name, r.name;







