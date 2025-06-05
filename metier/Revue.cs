using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente une revue dans le système de médiathèque.
    /// </summary>
    public class Revue
    {
        private int id;
        private string titre;
        private char empruntable;
        private string periodicite;
        private int delaiMiseADispo;
        private DateTime dateFinAbonnement;
        private Descripteur idDescripteur;

        /// <summary>
        /// Initialise une nouvelle instance complète de la classe Revue avec tous les paramètres.
        /// </summary>
        /// <param name="id">Identifiant unique de la revue</param>
        /// <param name="titre">Titre de la revue</param>
        /// <param name="empruntable">Indique si la revue est empruntable ('O' ou 'N')</param>
        /// <param name="periodicite">Périodicité de publication de la revue</param>
        /// <param name="dateFinAbonnement">Date de fin d'abonnement</param>
        /// <param name="delaiMiseADispo">Délai de mise à disposition en jours</param>
        /// <param name="idDescripteur">Descripteur associé à la revue</param>
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

        /// <summary>
        /// Initialise une nouvelle instance simplifiée de la classe Revue avec l'id, le titre et la date de fin d'abonnement.
        /// </summary>
        /// <param name="id">Identifiant unique de la revue</param>
        /// <param name="titre">Titre de la revue</param>
        /// <param name="dateFinAbonnement">Date de fin d'abonnement</param>
        public Revue(int id, string titre, DateTime dateFinAbonnement)
        {
            Id = id;
            Titre = titre;
            DateFinAbonnement = dateFinAbonnement;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Revue avec uniquement la périodicité.
        /// </summary>
        /// <param name="periodicite">Périodicité de publication de la revue</param>
        public Revue(string periodicite)
        {
            Periodicite = periodicite;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant unique de la revue.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le titre de la revue.
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Obtient ou définit si la revue est empruntable ('O' ou 'N').
        /// </summary>
        public char Empruntable { get; set; }

        /// <summary>
        /// Obtient ou définit la périodicité de publication de la revue.
        /// </summary>
        public string Periodicite { get; set; }

        /// <summary>
        /// Obtient ou définit la date de fin d'abonnement.
        /// </summary>
        public DateTime DateFinAbonnement { get; set; }

        /// <summary>
        /// Obtient ou définit le délai de mise à disposition en jours.
        /// </summary>
        public int DelaiMiseADispo { get; set; }

        /// <summary>
        /// Obtient ou définit le descripteur associé à la revue.
        /// </summary>
        public Descripteur IdDescripteur { get; set; }

        /// <summary>
        /// Retourne une représentation textuelle de la revue.
        /// </summary>
        /// <returns>Une chaîne contenant l'identifiant et le titre de la revue</returns>
        public override string ToString()
        {
            return $"{Id} - {Titre}";
        }
    }
    }
