namespace repository.Entities
{
    public class Entrepots
    {
        public int? Id { get; set; }
        public string? NomEntrepot { get; set; }
        public string? Adresse { get; set; }
        public string? Ville { get; set; }
        public string? Pays { get; set; }
        public string? Continent { get; set; }

        public Entrepots(string? nomEntrepot, string? adresse, string? ville, string? pays, string? continent, int? id = null)
        {
            NomEntrepot = nomEntrepot;
            Adresse = adresse;
            Ville = ville;
            Pays = pays;
            Continent = continent;
            Id = id;
        }

        public void DisplayAllEntrepots(Entrepots item)
        {
            Console.WriteLine($"Id entrepot : {item.Id}");
            Console.WriteLine($"Nom entrepot : {item.NomEntrepot}");
            Console.WriteLine($"Adresse : {item.Adresse}");
            Console.WriteLine($"Pays : {item.Pays}");
            Console.WriteLine($"Ville : {item.Ville}");
            Console.WriteLine($"Continent : {item.Continent}\n");
        }

    }
}
