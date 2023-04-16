using transport_logistique.Entity;
using transport_logistique.Repository;

/******************************************** Ajouter des données dans la table ENTREPOT ********************************************/
var repo = new EntrepotRepository();

var entrepot = new Entrepot("ent_val", "208 calle de la Malvarosa", "Valencia", "Espagne", "Europe");
repo.Save(entrepot);


var list = repo.FindAll();

foreach (var item in list)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Nom_entrepot);
    Console.WriteLine(item.Adresse);
    Console.WriteLine(item.Ville);
    Console.WriteLine(item.Pays);
    Console.WriteLine(item.Continent);
}

/******************************************** Ajouter des données dans la table EXPEDITION ********************************************/
var expRepo = new ExpeditionRepository();

var expedition = new Expedition(new DateTime(2022, 10, 11), new DateTime(2022, 10, 15), new DateTime(2022, 10, 15), 3, 4, 67, "livré");

expRepo.Save(expedition);

var expList = expRepo.FindAll();

foreach (var item in expList)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Date_expedition);
    Console.WriteLine(item.Date_livraison_prevue);
    Console.WriteLine(item.Date_livraison_reelle);
    Console.WriteLine(item.Id_entrepot_source);
    Console.WriteLine(item.Id_entrepot_destination);
    Console.WriteLine(item.Poids);
    Console.WriteLine(item.Statut);
}