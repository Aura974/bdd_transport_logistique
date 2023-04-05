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


-- Affichez les expéditions qui ont un poids supérieur à 100 kg et qui sont en transit.
select * from expeditions exp
where exp.poids > 100
and exp.statut = "expedie";


-- Affichez le nombre d'expéditions envoyées par chaque entrepôt.
select count(*) as total_envoi, nom_entrepot from expeditions exp
inner join entrepots ent on ent.id = exp.id_entrepot_source
group by nom_entrepot;


-- Affichez le nombre total d'expéditions en transit.
select count(*) as total_expedie from expeditions
where statut = "expedie";


-- Affichez le nombre total d'expéditions livrées.
select count(*) as total_livre from expeditions
where statut = "livre";


-- Affichez le nombre total d'expéditions pour chaque mois de l'année en cours.
SELECT month(date_expedition) as mois_exp,
case
	when month(date_expedition) = 1 then "janvier"
    WHEN month(date_expedition) = 2 THEN 'février'
	WHEN month(date_expedition) = 3 THEN 'mars'
	WHEN month(date_expedition) = 4 THEN 'avril'
	WHEN month(date_expedition) = 5 THEN 'mai'
	WHEN month(date_expedition) = 6 THEN 'juin'
	WHEN month(date_expedition) = 7 THEN 'juillet'
	WHEN month(date_expedition) = 8 THEN 'août'
	WHEN month(date_expedition) = 9 THEN 'septembre'
	WHEN month(date_expedition) = 10 THEN 'octobre'
	WHEN month(date_expedition) = 11 THEN 'novembre'
	ELSE 'décembre'
end as mois,
year(date_expedition),
count(*) AS total_expeditions
FROM expeditions
WHERE YEAR(date_expedition) = YEAR(now())
GROUP BY mois_exp
order by mois_exp asc;