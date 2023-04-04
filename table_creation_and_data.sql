-- Créez une table "entrepots"
create table entrepots (
id int primary key auto_increment,
nom_entrepot varchar(30),
adresse varchar(255),
ville varchar(126),
pays varchar(50)
);


-- Créez une table "expeditions" 
create table expeditions (
id int primary key auto_increment,
date_expedition date,
date_livraison date,
id_entrepot_source int,
id_entrepot_destination int,
poids decimal,
statut varchar(7),

constraint fk_expeditions_id_entrepot_source_entrepots_id 
foreign key (id_entrepot_source)
references entrepots(id),

constraint fk_expeditions_id_entrepot_destination_entrepots_id 
foreign key (id_entrepot_destination)
references entrepots(id)
);