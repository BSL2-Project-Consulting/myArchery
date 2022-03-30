-- Create new Event

USE myarchery;

-- the create event user interface must request the following information:
-- 1) Event Name
-- 2) Amount of arrows a player has for each target 
-- 3) start- and enddate
-- 4) is event privat and if yes, a password
-- 5) a parcour (my personal idea is to give the user a list of all parcour names, he choose the name we insert the id of the chosen parcour)
-- 6) the points you get for Center Kill, Kill, Life, Body (if he dont hit, no hit, we always give 0 points the user cant change this fact)

-- You have to make three or more inserts (depends on how many player you wanna add). 


-- insert into event:
-- Change the values in the row VALUES, values which stands in between '' are strings 
-- or datetime all the other are integers. If an Event isn't privat insert NULL without '' into password
INSERT INTO event (eventname, arrowamount, startdate, enddate, isprivat, password, par_id)
VALUES ('eventname_here', arrowamount_here, 'startdate', 'enddate', is_privat_here, 'password_here', par_id_here);


-- insert into points:
-- we always make 5 inserts per event, one for Center Kill, Kill, Life, Body and no Hit (the insert for no hit never changes)
-- replace eve_id with the event id (integer) and the poitns with the amount of points the user choose
-- also replace the number of arrow with the arrow nubers (for arrow one you get 100 points for a CK and... for 
-- arrow two you get 80 points for CK)
-- insert for Center Kill:
INSERT INTO points (eve_id, value_id, value, ArrowNumber) VALUES (eve_id, 1, points, nuber of arrow);
-- insert for Kill:
INSERT INTO points (eve_id, value_id, value, ArrowNumber) VALUES (eve_id, 2, points, nuber of arrow);
-- insert for Life:
INSERT INTO points (eve_id, value_id, value, ArrowNumber) VALUES (eve_id, 3, points, nuber of arrow);
-- insert for Body:
INSERT INTO points (eve_id, value_id, value, ArrowNumber) VALUES (eve_id, 4, points, nuber of arrow);
-- insert for no Hit (always 0):
INSERT INTO points (eve_id, value_id, value, ArrowNumber) VALUES (eve_id, 5, 0, nuber of arrow);


-- insert into event_user_roles:
-- now we make one insert for the creater of the event, the rol_id 1 stands for the host, the
-- use_id stands for the user who created this event 
INSERT INTO event_user_roles (eve_id, use_id, rol_id)
VALUES (event_id_here, user_id_here, 1);


-- add users to an event
-- at the end one insert for all users who join an event
INSERT INTO event_user_roles (eve_id, use_id, rol_id)
VALUES (event_id_here, user_id_here, 2);


