use myArchery;

-- all infos about an arrow (you have to set eve_id)
SELECT
	e.Eventname AS 'Event Name',
	u.username AS 'Username',
	CASE
		WHEN p.valueid = 1 THEN 'Center Kill'
		WHEN p.valueid = 2 THEN 'Kill'
		WHEN p.valueid = 3 THEN 'Life'
		WHEN p.valueid = 4 THEN 'Body'
		WHEN p.valueid = 5 THEN 'No Hit'
	END AS 'HitType',
	p.value AS 'Points',
	a.hitdatetime AS 'Hit Time',
	t.targetname AS 'Target'
FROM arrow a
LEFT JOIN eventuserrole eur ON a.evusroid = eur.evusroid
LEFT JOIN point p ON a.poiid = p.poiid
LEFT JOIN AspNetUsers u ON eur.useid = u.id
LEFT JOIN event e ON eur.eveid = e.eveid
LEFT JOIN parcourstarget pt ON a.pataid = pt.pataid
LEFT JOIN target t ON pt.tarid = t.tarid
WHERE eur.eveid = 3
ORDER BY u.username, a.hitdatetime;