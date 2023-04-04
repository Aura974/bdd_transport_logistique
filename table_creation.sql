-- Créez une table "entrepots"
create table entrepots (
id int primary key auto_increment,
nom_entrepot varchar(30) not null,
adresse varchar(255) not null,
ville varchar(126) not null,
pays varchar(50) not null
);


-- Créez une table "expeditions" 
create table expeditions (
id int primary key auto_increment,
date_expedition date not null,
date_livraison date,
id_entrepot_source int not null,
id_entrepot_destination int not null,
poids decimal(5,1) not null,
statut varchar(7) not null,

constraint fk_expeditions_id_entrepot_source_entrepots_id 
foreign key (id_entrepot_source)
references entrepots(id),

constraint fk_expeditions_id_entrepot_destination_entrepots_id 
foreign key (id_entrepot_destination)
references entrepots(id)
);