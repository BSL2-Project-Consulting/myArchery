use myArchery;

-- all infos about an arrow (you have to set eve_id)
SELECT 
	e.name AS 'Event Name',
    u.username AS 'Username',
    CASE 
		WHEN p.value_id = 1 THEN 'Center Kill'
        WHEN p.value_id = 2 THEN 'Kill'
        WHEN p.value_id = 3 THEN 'Life'
        WHEN p.value_id = 4 THEN 'Body'
        WHEN p.value_id = 5 THEN 'No Hit'
	END AS 'Hit_Type',
    p.value AS 'Points',
    a.hitdatetime AS 'Hit Time',
    t.targetname AS 'Target'
FROM arrow a
LEFT JOIN event_user_roles eur ON a.evusro_id = eur.evusro_id
LEFT JOIN points p ON a.poi_id = p.poi_id
LEFT JOIN user u ON eur.use_id = u.use_id
LEFT JOIN event e ON eur.eve_id = e.eve_id
LEFT JOIN parcours_target pt ON a.pata_id = pt.pata_id
LEFT JOIN target t ON pt.tar_id = t.tar_id
WHERE eur.eve_id = 4
ORDER BY u.username, a.hitdatetime;


