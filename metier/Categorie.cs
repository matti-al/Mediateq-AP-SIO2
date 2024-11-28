

namespace Mediateq_AP_SIO2.metier
{
    public class Categorie
    {
        private int id;
        private string libelle;

        public Categorie(int id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        public int Id { get => id; set => id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
    }
}
