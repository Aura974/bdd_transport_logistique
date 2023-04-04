-- Affichez les entrepôts qui ont envoyé au moins une expédition en transit.
select ent.id, nom_entrepot, statut from entrepots ent
inner join expeditions exp on ent.id = exp.id_entrepot_source
where exp.statut = "expedie"
group by id;


-- Affichez les entrepôts qui ont reçu au moins une expédition en transit.
select ent.id, nom_entrepot, statut from entrepots ent
inner join expeditions exp on ent.id = exp.id_entrepot_destination
where exp.statut = "expedie"
group by id;


-- Affichez les expéditions qui ont un poids supérieur à 4 kg et qui sont en transit.
select * from expeditions exp
where exp.poids > 4
and exp.statut = "expedie";