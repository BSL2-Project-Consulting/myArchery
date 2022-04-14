USE Archery;
-- -----------------------------------------------------
-- Data for table Archery.dboAspNetUser
-- -----------------------------------------------------

--USE Archery;
--SET IDENTITY_INSERT dbo.AspNetUsers ON;

INSERT INTO Archery.dbo.AspNetUsers (id, vname, nname, email, getnewsletter, username, normalizedusername, normalizedemail, emailconfirmed, passwordhash, securitystamp, concurrencystamp, phonenumber, phonenumberConfirmed, twofactorenabled, lockoutend, lockoutenabled, accessfailedcount) VALUES (1, 'Admin', 'Admin', 'admin@admin.at', 1, 'Admin', 'ADMIN', 'ADMIN@ADMIN.AT', 1, 'AQAAAAEAACcQAAAAEHFFvVuQKttjqfT9Q0cYzCpTXeLZ26slIbJ4NsmU2XXVadWC+bPB1uuJznt8OHALZQ==', 'AOIN6BP732EOTECM262HYF5WMKP3L3KK', 'f921a0b3-5423-43e3-8243-b106c09574a2', null, 1, 0, null, 0, 0);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (1, 'User1', 'lol', 'Usi', 'User', 'UsiAspNetUser@gmail.com', 1);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (2, 'User2', 'User2', 'Usr', 'Us', 'Usr.Us@gmail.com',  1);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (3, 'User3', 'User3', 'Ui', 'Usi', 'Ui.Usi@gmail.com', 0);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (4, '//del//User12', NULL, NULL, NULL, NULL, 0);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (5, 'User5', 'User5', 'Ui', 'User', 'UiAspNetUser@gmail.com', 1);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (6, 'User6', 'User6', 'Us', 'Ur', 'Us.Ur@gmail.com', 1);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (7, 'User7', 'User7', 'Ue', 'Ue', 'Ue.Ue@gmail.com', 0);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (8, 'User8', 'User8', 'User', 'Ur', 'User.Ur@gmail.com', 0);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (9, 'User9', 'User9', 'U', 'R', 'U.R@gmail.com', 0);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (10, 'User10', 'User10', 'Userr', 'Uss', 'Userr.Uss@gmail.com',0);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (11, '//del//User11', NULL, NULL, NULL, NULL, 0);
--INSERT INTO Archery.dbo.AspNetUsers (id, username, password, vname, nname, email, getnewsletter) VALUES (12, 'User4', 'User4', 'Usr', 'Us', 'Usr.Us1@gmail.com', 1);

--SET IDENTITY_INSERT dbo.AspNetUser OFF;
--COMMIT;

-- -----------------------------------------------------
-- Data for table Archery.dbo.parcours
-- -----------------------------------------------------
SET IDENTITY_INSERT dbo.parcour ON;

INSERT INTO Archery.dbo.parcour (parid, parcourname, town, postalcode, streethousenumber, counttargets) VALUES (1, 'BSV Perlstein', 'Perlstein', 4444, 'Perlweg 3', 11);
INSERT INTO Archery.dbo.parcour (parid, parcourname, town, postalcode, streethousenumber, counttargets) VALUES (2, 'Bogensportzentrum Roddorf', 'Roddorf', 2819, 'Wegweg 11', 23);
INSERT INTO Archery.dbo.parcour (parid, parcourname, town, postalcode, streethousenumber, counttargets) VALUES (3, 'BSV Zell Bad', 'Zell am Bad', 9029, 'Zellberg e', 14);
INSERT INTO Archery.dbo.parcour (parid, parcourname, town, postalcode, streethousenumber, counttargets) VALUES (4, 'dummypar', 'pra', 4343, 'dcd 4', 2);

SET IDENTITY_INSERT dbo.parcour OFF;

-- -----------------------------------------------------
-- Data for table Archery.dbo.event
-- -----------------------------------------------------

SET IDENTITY_INSERT dbo.event ON;

INSERT INTO Archery.dbo.event (eveid, eventname, arrowamount, startdate, enddate, isprivat, password, parid) VALUES (1, 'Event 1', 1, '2024-02-16 13:00:00', '2024-02-16 19:00:00', 0, NULL, 1);
INSERT INTO Archery.dbo.event (eveid, eventname, arrowamount, startdate, enddate, isprivat, password, parid) VALUES (2, 'Event 2', 1, '2023-05-13 10:00:00', '2023-05-13 15:00:00', 1, 'Event 2', 1);
INSERT INTO Archery.dbo.event (eveid, eventname, arrowamount, startdate, enddate, isprivat, password, parid) VALUES (3, 'Event 3', 2, '2021-05-17 10:00:00', '2021-05-17 13:00:00', 0, NULL, 4);
INSERT INTO Archery.dbo.event (eveid, eventname, arrowamount, startdate, enddate, isprivat, password, parid) VALUES (4, 'Event 4', 2, '2021-07-07 10:00:00', '2021-07-08 10:00:00', 1, 'Event 4', 4);
INSERT INTO Archery.dbo.event (eveid, eventname, arrowamount, startdate, enddate, isprivat, password, parid) VALUES (5, 'Event 5', 3, '2022-03-10 14:00:00', '2023-03-10 14:00:00', 0, NULL, 1);

SET IDENTITY_INSERT dbo.event OFF;
-- -----------------------------------------------------
-- Data for table Archery.dbo.point
-- -----------------------------------------------------

SET IDENTITY_INSERT dbo.point ON;

INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (1, 1, 1, 20, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (2, 1, 2, 10, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (3, 1, 3, 5, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (4, 1, 4, 2, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (5, 1, 5, 0, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (6, 2, 1, 200, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (7, 2, 2, 100, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (8, 2, 3, 10, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (9, 2, 4, 0, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (10, 2, 5, 0, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (11, 3, 1, 100, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (12, 3, 2, 50, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (13, 3, 3, 25, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (14, 3, 4, 0, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (15, 3, 5, 0, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (16, 4, 1, 58, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (17, 4, 2, 50, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (18, 4, 3, 10, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (19, 4, 4, 5, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (20, 4, 5, 0, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (21, 5, 1, 60, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (22, 5, 2, 30, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (23, 5, 3, 10, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (24, 5, 4, 0, 1);
INSERT INTO Archery.dbo.point (poiid, eveid, valueid, value, ArrowNumber) VALUES (25, 5, 5, 0, 1);

SET IDENTITY_INSERT dbo.point OFF;

-- -----------------------------------------------------
-- Data for table Archery.dbo.target
-- -----------------------------------------------------

SET IDENTITY_INSERT dbo.target ON;

INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (1, 'Adler');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (2, 'Alpensteinbock');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (3, 'Bär');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (4, 'Biber');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (5, 'Büffel');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (6, 'Eichhörnchen');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (7, 'Elch');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (8, 'Ente');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (9, 'Falke');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (10, 'Feldhase');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (11, 'Ferkel');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (12, 'Fischotter');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (13, 'Flusspferd');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (14, 'Franz das Wiesel');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (15, 'Frischling');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (16, 'Frosch');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (17, 'Fuchs');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (18, 'Gams');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (19, 'Gepard');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (20, 'Giraffe');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (21, 'Gnu');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (22, 'Goldschakal');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (23, 'Hirsch');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (24, 'Hyäne');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (25, 'Kauz');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (26, 'Kormoran');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (27, 'Krokodil');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (28, 'Kuh');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (29, 'Leopard');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (30, 'Löwe');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (31, 'Luchs');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (32, 'Mader');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (33, 'Murmeltier');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (34, 'Nashorn');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (35, 'Otter');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (36, 'Panther');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (37, 'Papagei');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (38, 'Pavian');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (39, 'Pelikan');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (40, 'Reh');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (41, 'Rehricke');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (42, 'Robbe');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (43, 'Rothirsch');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (44, 'Schneehase');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (45, 'Schwan');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (46, 'Schwein');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (47, 'Spinne');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (48, 'Strauss');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (49, 'T-Rex');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (50, 'Uhu');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (51, 'Walross');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (52, 'Waschbär');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (53, 'Wiesel');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (54, 'Wildkaninchen');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (55, 'Wildschwein');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (56, 'Wolf');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (57, 'Wolpertinger');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (58, 'Zebra');
INSERT INTO Archery.dbo.target (tarid, targetname) VALUES (59, 'Zombie');

SET IDENTITY_INSERT dbo.target OFF;

-- -----------------------------------------------------
-- Data for table Archery.dbo.parcourstarget
-- -----------------------------------------------------

SET IDENTITY_INSERT dbo.parcourstarget ON;

INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (1, 1, 36);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (2, 1, 7);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (3, 1, 47);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (4, 1, 19);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (5, 1, 18);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (6, 1, 41);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (7, 1, 13);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (8, 1, 12);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (9, 1, 17);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (10, 1, 28);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (11, 1, 38);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (12, 2, 33);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (13, 2, 3);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (14, 2, 37);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (15, 2, 13);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (16, 2, 2);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (17, 2, 10);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (18, 2, 24);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (19, 2, 15);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (20, 2, 50);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (21, 2, 26);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (22, 2, 58);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (23, 2, 59);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (24, 2, 28);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (25, 2, 47);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (26, 2, 7);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (27, 2, 38);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (28, 2, 40);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (29, 2, 9);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (30, 2, 34);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (31, 2, 1);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (32, 2, 18);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (33, 2, 23);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (34, 2, 20);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (35, 3, 52);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (36, 3, 2);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (37, 3, 29);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (38, 3, 24);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (39, 3, 28);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (40, 3, 5);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (41, 3, 49);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (42, 3, 37);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (43, 3, 22);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (44, 3, 38);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (45, 3, 28);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (46, 3, 43);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (47, 3, 46);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (48, 3, 32);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (49, 4, 1);
INSERT INTO Archery.dbo.parcourstarget (pataid, parid, tarid) VALUES (50, 4, 3);

SET IDENTITY_INSERT dbo.parcourstarget OFF;

-- -----------------------------------------------------
-- Data for table Archery.dbo.roles
-- -----------------------------------------------------

SET IDENTITY_INSERT dbo.role ON;

INSERT INTO Archery.dbo.role (rolid, rolename) VALUES (1, 'Host');
INSERT INTO Archery.dbo.role (rolid, rolename) VALUES (2, 'Player');

SET IDENTITY_INSERT dbo.role OFF;
-- -----------------------------------------------------
-- Data for table Archery.dbo.eventuserrole
-- -----------------------------------------------------

SET IDENTITY_INSERT dbo.eventuserrole ON;

INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (1, 1, 1, 2);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (2, 1, 2, 1);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (3, 1, 3, 2);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (4, 1, 4, 2);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (5, 2, 4, 2);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (6, 2, 11, 1);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (7, 2, 12, 2);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (8, 3, 1, 1);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (9, 3, 2, 2);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (10, 4, 8, 2);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (11, 4, 9, 1);
INSERT INTO Archery.dbo.eventuserrole (evusroid, eveid, useid, rolid) VALUES (12, 5, 12, 1);

SET IDENTITY_INSERT dbo.eventuserrole OFF;

-- -----------------------------------------------------
-- Data for table Archery.dbo.arrow
-- -----------------------------------------------------

SET IDENTITY_INSERT dbo.arrow ON;

INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (1, 15, 49, 8, '2021-05-17 11:10:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (2, 11, 49, 8, '2021-05-17 11:15:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (3, 12, 50, 8, '2021-05-17 11:25:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (4, 15, 49, 9, '2021-05-17 10:10:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (5, 15, 49, 9, '2021-05-17 10:16:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (6, 15, 50, 9, '2021-05-17 10:21:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (7, 14, 50, 9, '2021-05-17 12:01:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (8, 17, 49, 10, '2021-07-07 16:00:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (9, 17, 50, 10, '2021-07-07 16:18:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (10, 20, 49, 11, '2021-07-07 16:11:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (11, 16, 49, 11, '2021-07-07 16:20:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (12, 19, 50, 11, '2021-07-07 16:25:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (13, 21, 1, 12, '2022-03-10 19:00:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (14, 25, 2, 12, '2022-03-10 19:20:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (15, 25, 2, 12, '2022-03-10 19:22:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (16, 25, 2, 12, '2022-03-10 19:34:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (17, 22, 3, 12, '2022-03-10 19:50:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (18, 22, 4, 12, '2022-03-11 10:01:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (19, 21, 5, 12, '2022-03-11 10:41:00');
INSERT INTO Archery.dbo.arrow (arrid, poiid, pataid, evusroid, hitdatetime) VALUES (20, 22, 6, 12, '2022-03-11 11:15:00');

SET IDENTITY_INSERT dbo.arrow OFF;
