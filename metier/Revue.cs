using System;

namespace Mediateq_AP_SIO2.metier

{
    public class Revue
    {
        private int id;
        private string titre;
        private char empruntable;
        private string periodicite;
        private DateTime dateFinAbonnement;
        private int delaiMiseADispo;
        private Descripteur idDescripteur;
        private Categorie categorie;

        public Revue(int id, string titre, char empruntable, string periodicite, DateTime dateFinAbonnement, int delaiMiseADispo, Descripteur idDescripteur, Categorie pcategorie)
        {
            this.id = id;
            this.titre = titre;
            this.empruntable = empruntable;
            this.periodicite = periodicite;
            this.dateFinAbonnement = dateFinAbonnement;
            this.delaiMiseADispo = delaiMiseADispo;
            this.idDescripteur = idDescripteur;
            this.categorie = pcategorie;

        }

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public char Empruntable { get => empruntable; set => empruntable = value; }
        public string Periodicite { get => periodicite; set => periodicite = value; }
        public DateTime DateFinAbonnement { get => dateFinAbonnement; set => dateFinAbonnement = value; }
        public int DelaiMiseADispo { get => delaiMiseADispo; set => delaiMiseADispo = value; }
        public Descripteur IdDescripteur { get => idDescripteur; set => idDescripteur = value; }
        public Categorie Categorie { get => categorie; set => categorie = value; }

    }
}
