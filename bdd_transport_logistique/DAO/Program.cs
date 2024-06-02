
using System.Net;
using System.Text;
using System.Text.Json;
using transport.Data.Entity;
using transport.Data.Repository;

//*ajouter une nouvel entrepot
//var repoEntrepots = new EntrepotsRepository();
//var entrepots = new Entrepots("ent_seo", "7892 Yeorumul-ro", "Seoul", "Coree du sud", "Asie");
//repoEntrepots.Save(entrepots);

//var entrepots = new Entrepots("ent_seo", "7800 Yeorumul-ro", "Seoul", "Coree du sud", "Asie");

//var listEntrepots = repoEntrepots.FindAll();

//foreach (var item in listEntrepots)
//{
//    Console.WriteLine(item.Id);
//    Console.WriteLine(item.NomEntrepot);
//    Console.WriteLine(item.Adresse);
//    Console.WriteLine(item.Ville);
//    Console.WriteLine(item.Pays);
//    Console.WriteLine(item.Continent);
//}

// *update entrepot id 5
//var repoEntrepots = new EntrepotsRepository();
//var entrepots = repoEntrepots.Find(5);
//entrepots.Adresse= "1238 Khaosan Road";
//repoEntrepots.Update(entrepots);

//*delete entrepot 6
//var repoEntrepots = new EntrepotsRepository();
//var entrepots = repoEntrepots.Find(6);
//repoEntrepots.Delete(new Entrepots("ent_seo", "7892 Yeorumul-ro", "Seoul", "Coree du sud", "Asie", 6));


//*ajouter une nouvel expedition
//var repoExpeditions = new ExpeditionsRepository();
//var expeditions = new Expeditions(new DateTime(2023, 03, 27), new DateTime(2023, 03, 30), new DateTime(2023, 03, 31), 1100.0, "livré", 5, 1);
//repoExpeditions.Save(expeditions);

//var listExpeditions = repoExpeditions.FindAll();
//foreach (var item in listExpeditions)
//{
//    Console.WriteLine(item.Id);
//    Console.WriteLine(item.DateExpedition);
//    Console.WriteLine(item.DateLivraisonPrevue);
//    Console.WriteLine(item.DateLivraisonReelle);
//    Console.WriteLine(item.IdEntrepotSource);
//    Console.WriteLine(item.IdEntrepotDestination);
//    Console.WriteLine(item.Pois);
//    Console.WriteLine(item.Statut);
//}

//*update expedition id 23 dans la table expeditions
//var repoExpeditions = new ExpeditionsRepository();
//var expeditions = repoExpeditions.Find(24);
//expeditions.DateLivraisonPrevue = new DateTime(2023, 03, 29);
//repoExpeditions.Update(expeditions);

//*delete expedition 22
//var repoExpeditions = new ExpeditionsRepository();
//var expeditions = repoExpeditions.Find(22);
//repoExpeditions.Delete(new Expeditions(new DateTime(2023, 03, 27), new DateTime(2023, 03, 29), new DateTime(2023, 03, 31), 1100.0, "livré", 5, 1));




