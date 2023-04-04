-- Ajoutez 5 entrepôts dans différentes villes et pays.
insert into entrepots (nom_entrepot, adresse, ville, pays)
	values
		("ent_lux", "234 route Arlon", "Strassen", "Luxembourg"),
        ("ent_pto", "555 rua du Bacalau", "Porto", "Portugal"),
        ("ent_ans", "346 rue de Charlemagne", "Angers", "France"),
        ("ent_ven", "1174 Ca' Foscari", "Venise", "Italie"),
        ("ent_bak", "4658 Nakhon Sawhan Rd", "Bangkok", "Thaïlande");


-- Ajoutez 10 expéditions différentes 
insert into expeditions (date_expedition, date_livraison, id_entrepot_source, id_entrepot_destination, poids, statut)
	values
		("2022-03-03", "2022-03-05", 1, 2,  3.5, "livré"),
        ("2022-01-15", "2022-01-24", 2, 5, 10.8, "livré"),
        ("2023-02-25", null, 2, 4, 0.5, "expédié"),
        ("2022-04-03", null, 3, 4, 0.2, "expédié"),
        ("2022-09-11", null, 3, 5, 1.5, "expédié"),
        ("2019-04-13", "2019-04-16", 5, 1, 3.5, "livré"),
        ("2021-10-27", "2021-11-06", 4, 1, 7.2, "livré"),
        ("2020-06-08", "2020-07-01", 5, 1, 8.6,  "livré"),
        ("2023-04-03", null, 1, 5, 4.2, "expédié"),
        ("2022-10-29", "2022-10-31", 4, 3, 3.3, "livré");