use archery

SELECT 
	u.username,
    e.eventname
FROM aspnetusers u
LEFT JOIN eventuserrole eur ON u.id = eur.useid
LEFT JOIN event e ON eur.eveid = e.eveid
WHERE u.username = 'AdminBasti'
ORDER BY u.username;

select * from eventuserrole;
select * from aspnetusers;