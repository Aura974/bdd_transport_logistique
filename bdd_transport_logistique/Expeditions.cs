namespace transport.Data.Entity
{
    class Expeditions
    {
        public Expeditions(DateTime? dateExpedition, DateTime? dateLivraisonPrevue, DateTime? dateLivraisonReelle, double? pois, string? statut, int? idEntrepotSource = null, int? idEntrepotDestination = null, int? id = null)
        {
            Id = id;
            DateExpedition = dateExpedition;
            DateLivraisonPrevue = dateLivraisonPrevue;
            DateLivraisonReelle = dateLivraisonReelle;
            IdEntrepotSource = idEntrepotSource;
            IdEntrepotDestination= idEntrepotDestination;
            Pois = pois;
            Statut = statut;
            
        }
        public int? Id { get; set; }
        public  DateTime? DateExpedition { get; set; }
        public  DateTime? DateLivraisonPrevue { get; set; }
        public  DateTime? DateLivraisonReelle { get; set; }
        public int? IdEntrepotSource { get; set; }
        public int? IdEntrepotDestination { get; set;}
        public double? Pois { get; set;}
        public string? Statut { get; set;}
    }
}
