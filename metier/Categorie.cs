

namespace Mediateq_AP_SIO2.metier
{
    public class Categorie
    {
        public Categorie(int id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
    }
}
