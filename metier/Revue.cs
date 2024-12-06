using System;

namespace Mediateq_AP_SIO2.metier

{
    public class Revue
    {
        private char empruntable;
        private string periodicite;
        private DateTime dateFinAbonnement;
        private int delaiMiseADispo;
        private Descripteur idDescripteur;
        private Categorie categorie;

        public Revue(int id, string titre, char empruntable, string periodicite, DateTime dateFinAbonnement, int delaiMiseADispo, Descripteur idDescripteur, Categorie pcategorie)
        {
            this.Id = id;
            this.Titre = titre;
            this.empruntable = empruntable;
            this.periodicite = periodicite;
            this.dateFinAbonnement = dateFinAbonnement;
            this.delaiMiseADispo = delaiMiseADispo;
            this.idDescripteur = idDescripteur;
            this.categorie = pcategorie;

        }

        public int Id { get; set; }
        public string Titre { get; set; }
        public char Empruntable { get; set; }
        public string Periodicite { get; set; }
        public DateTime DateFinAbonnement { get; set; }
        public int DelaiMiseADispo { get; set; }
        public Descripteur IdDescripteur { get; set; }
        public Categorie Categorie { get; set; }

    }
}
