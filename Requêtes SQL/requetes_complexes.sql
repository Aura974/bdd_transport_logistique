-- Affichez les expéditions en transit qui ont été initiées par un entrepôt situé en Europe et à destination d'un entrepôt situé en Asie.
SELECT expeditions.id, date_expedition FROM expeditions
inner JOIN entrepots as entrepot_source
    ON entrepot_source.id = expeditions.id_entrepot_source
inner JOIN entrepots as entrepot_destination
    ON entrepot_destination.id = expeditions.id_entrepot_destination
Where statut = "expédié" 
AND entrepot_source.continent = "Europe"
AND entrepot_destination.continent = "Asie";


-- Affichez les entrepôts qui ont envoyé des expéditions à destination d'un entrepôt situé dans le même pays.
select exp.id_entrepot_source, ent.nom_entrepot, exp.id_entrepot_destination from entrepots ent
inner join expeditions exp on exp.id_entrepot_source = ent.id
where exp.id_entrepot_destination = exp.id_entrepot_source
group by exp.id_entrepot_source;


-- Affichez les entrepôts qui ont envoyé des expéditions à destination d'un entrepôt situé dans un pays différent.
select exp.id_entrepot_source, ent.nom_entrepot, exp.id_entrepot_destination from entrepots ent
inner join expeditions exp on exp.id_entrepot_source = ent.id
where exp.id_entrepot_destination != exp.id_entrepot_source
group by exp.id_entrepot_source;


-- Affichez les expéditions en transit qui ont été initiées par un entrepôt situé dans un pays dont le nom commence par la lettre "F" et qui pèsent plus de 500 kg.
select exp.id, exp.poids, ent.nom_entrepot, pays from expeditions exp
inner join entrepots ent on ent.id = exp.id_entrepot_source
where
	statut = "expédié"
    and ent.pays like "F%"
    and exp.poids > 500;


-- Affichez le nombre total d'expéditions pour chaque combinaison de pays d'origine et de destination.
select count(*) total_expeditions, ent_source.pays pays_origine, ent_destination.pays pays_destination from expeditions expe
inner join entrepots ent_source on expe.id_entrepot_source = ent_source.id
inner join entrepots ent_destination on expe.id_entrepot_destination = ent_destination.id
group by pays_origine, pays_destination;


-- Affichez les entrepôts qui ont envoyé des expéditions au cours des 30 derniers jours et dont le poids total des expéditions est supérieur à 500 kg.
select ent.nom_entrepot, expe.date_expedition, sum(expe.poids) poids_total from entrepots ent
inner join expeditions expe on expe.id_entrepot_source = ent.id
where
	date_expedition > now() - interval 30 day
group by ent.nom_entrepot
having poids_total > 500;


-- Affichez les expéditions qui ont été livrées avec un retard de plus de 2 jours ouvrables.
select expe.id, date_livraison_prevue, date_livraison_reelle, (datediff(date_livraison_reelle, date_livraison_prevue)) retard from expeditions expe
where
	datediff(date_livraison_reelle, date_livraison_prevue) > 2
    and dayofweek(date_livraison_reelle) != 2
    and dayofweek(date_livraison_reelle) != 3
    
or 
	datediff(date_livraison_reelle, date_livraison_prevue) > 4
    and dayofweek(date_livraison_reelle) = 2
    
or 
	datediff(date_livraison_reelle, date_livraison_prevue) > 4
	and dayofweek(date_livraison_reelle) = 3;


-- Affichez le nombre total d'expéditions pour chaque jour du mois en cours, trié par ordre décroissant.
select date_expedition, count(*) total from expeditions expe
where
	month(date_expedition) = month(now())
    and year(date_expedition) = year(now())
group by day(date_expedition)
order by total desc;



