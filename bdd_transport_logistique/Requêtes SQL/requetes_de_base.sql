-- Affichez tous les entrepôts.
select * from entrepots;


-- Affichez toutes les expéditions.
select * from expeditions;


-- Affichez toutes les expéditions en transit.
select * from expeditions
where statut = "expedie";


-- Affichez toutes les expéditions livrées.
select * from expeditions
where statut = "livre";