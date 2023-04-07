-- Ajoutez 5 entrepôts dans différentes villes et pays.
insert into entrepots (nom_entrepot, adresse, ville, pays, continent)
	values
		("ent_lux", "234 route Arlon", "Strassen", "Luxembourg", "Europe"),
        ("ent_pto", "555 rua du Bacalau", "Porto", "Portugal", "Europe"),
        ("ent_ans", "346 rue de Charlemagne", "Angers", "France", "Europe"),
        ("ent_ven", "1174 Ca' Foscari", "Venise", "Italie", "Europe"),
        ("ent_bak", "4658 Nakhon Sawhan Rd", "Bangkok", "Thaïlande", "Asie");


-- Ajoutez plusieurs expéditions différentes 
INSERT INTO expeditions (date_expedition, date_livraison_prevue, date_livraison_reelle, id_entrepot_source, id_entrepot_destination, poids, statut)
	VALUES
		("2022-03-03", "2022-03-04", "2022-03-05", 1, 2,  300.5, "livré"),
        ("2022-01-14", "2022-01-20", "2022-01-24", 2, 5, 1572.8, "livré"),
        ("2023-02-24", "2023-03-01", null, 2, 4, 567, "expédié"),
        ("2022-04-03", "2022-04-07", null, 3, 4, 720, "expédié"),
        ("2022-09-12", "2022-09-16", null, 3, 5, 159, "expédié"),
        ("2019-04-12", "2019-04-16", "2019-04-16", 5, 5, 357, "livré"),
        ("2021-10-27", "2021-11-04", "2021-11-06", 4, 4, 732, "livré"),
        ("2020-06-08", "2020-06-15", "2020-07-01", 5, 1, 890,  "livré"),
        ("2023-04-03", "2023-04-07", null, 1, 5, 425, "expédié"),
        ("2022-10-28", "2022-10-31", "2022-10-31", 4, 3, 333, "livré"),
		("2023-02-03", "2023-02-06", "2023-02-07", 2, 1,  150.6, "livré"),
        ("2023-01-16", "2023-01-25", "2023-01-24", 2, 4, 222.7, "livré"),
        ("2023-01-03", "2023-10-01", null, 4, 3,  768.8, "expédié"),
        ("2022-02-15", "2022-02-22", "2022-02-24", 3, 5, 874.4, "livré"),
        ("2023-03-29", "2023-04-05", null, 3, 3,  674.9, "expédié"),
        ("2022-12-20", "2022-12-23", "2022-12-26", 5, 1, 957.4, "livré"),
        ("2023-03-02", "2023-03-09", "2023-03-17", 3, 4,  923.8, "livré"),
        ("2023-02-13", "2023-02-24", "2023-04-03", 5, 1, 356.7, "livré"),
        ("2023-03-07", "2023-03-14", null, 2, 2,  749.6, "expédié"),
        ("2023-04-04", "2023-04-07", "2023-04-07", 5, 1, 356.7, "livré"),
        ("2023-04-03", "2023-04-10", null, 5, 1, 356.7, "livré");