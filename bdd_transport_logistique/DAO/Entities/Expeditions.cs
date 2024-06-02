namespace repository.Entities
{
    public class Expeditions
    {
        public int? Id { get; set; }
        public int? IdEntrepotSource { get; set; }
        public int? IdEntrepotDestination { get; set; }
        public DateTime? DateExpedition { get; set; }
        public DateTime? DateLivraisonPrevue { get; set; }
        public DateTime? DateLivraisonReelle { get; set; }
        public string? Poids { get; set; }
        public string? Statut { get; set; }

        public Expeditions(DateTime? dateExpedition, DateTime? dateLivraisonPrevue,  string? poids, string? statut,  int? idEntrepotSource, int? idEntrepotDestination, int? id = null, DateTime? dateLivraisonReelle = default)
        {
            DateExpedition = dateExpedition;
            DateLivraisonPrevue = dateLivraisonPrevue;
            Poids = poids;
            Statut = statut;
            IdEntrepotSource = idEntrepotSource;
            IdEntrepotDestination = idEntrepotDestination;
            Id = id;
            DateLivraisonReelle = dateLivraisonReelle;
        }

        public void DisplayAllExpeditions(Expeditions item)
        {
            Console.WriteLine($"Id expédition : {item.Id}");
            Console.WriteLine($"Date d'expédition : {item.DateExpedition}");
            Console.WriteLine($"Date de livraison prévue : {item.DateLivraisonPrevue}");
            Console.WriteLine($"Poids : {item.Poids}");
            Console.WriteLine($"Statut : {item.Statut}");
            Console.WriteLine($"Date de livraison réelle : {item.DateLivraisonReelle}");
            Console.WriteLine($"Id entrepot source : {item.IdEntrepotSource}");
            Console.WriteLine($"Id entrepot destination : {item.IdEntrepotDestination}\n");
        }


    }
}
