
namespace transport.Data.Entity
{
    class Entrepots
    {
        public Entrepots(string? nomEntrepot, string? adresse, string? ville, string? pays, string? continent, int? id = null)
        {
            Id = id;
            NomEntrepot = nomEntrepot;
            Adresse = adresse;
            Ville = ville;
            Pays = pays;
            Continent = continent;
        }
        public int? Id { get; set; }
        public string? NomEntrepot { get; set; }
        public string? Adresse { get; set; }
        public string? Ville { get; set; }
        public string? Pays { get; set; }
        public string? Continent { get; set; }

    }
}