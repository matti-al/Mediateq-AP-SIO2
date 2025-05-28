using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
        public class Revue
        {
            private int id;
            private string titre;
            private char empruntable;
            private string periodicite;
            private int delaiMiseADispo;
            private DateTime dateFinAbonnement;
            private Descripteur idDescripteur;

            // Constructeur complet
            public Revue(int id, string titre, char empruntable, string periodicite, DateTime dateFinAbonnement, int delaiMiseADispo, Descripteur idDescripteur)
            {
                Id = id;
                Titre = titre;
                Empruntable = empruntable;
                Periodicite = periodicite;
                DateFinAbonnement = dateFinAbonnement;
                DelaiMiseADispo = delaiMiseADispo;
                IdDescripteur = idDescripteur;
            }

        public Revue(int id, string titre, DateTime dateFinAbonnement)
        {
            Id = id;
            Titre = titre;
            DateFinAbonnement = dateFinAbonnement;
        }

        // Constructeur pour la periodicite
        public Revue(string periodicite)
        {
            Periodicite = periodicite;
        }
        // Propriétés publiques
        public int Id { get; set; }
            public string Titre { get; set; }
            public char Empruntable { get; set; }
            public string Periodicite { get; set; }
            public DateTime DateFinAbonnement { get; set; }
            public int DelaiMiseADispo { get; set; }
            public Descripteur IdDescripteur { get; set; }

            // ToString
            public override string ToString()
            {
                return $"{Id} - {Titre}";
            }
        }
    }
