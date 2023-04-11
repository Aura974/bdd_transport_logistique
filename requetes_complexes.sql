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


