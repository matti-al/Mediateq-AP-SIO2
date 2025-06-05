using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un DVD dans le système de médiathèque.
    /// Hérite de la classe Document et ajoute des propriétés spécifiques aux DVD.
    /// </summary>
    internal class DVD : Document
    {
        /// <summary>
        /// Obtient ou définit le synopsis du DVD.
        /// </summary>
        public string Synopsis { get; set; }

        /// <summary>
        /// Obtient ou définit le nom du réalisateur du DVD.
        /// </summary>
        public string Realisateur { get; set; }

        /// <summary>
        /// Obtient ou définit la durée du DVD en minutes.
        /// </summary>
        public int Duree { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe DVD.
        /// </summary>
        /// <param name="unId">L'identifiant unique du DVD</param>
        /// <param name="unTitre">Le titre du DVD</param>
        /// <param name="pRealisateur">Le réalisateur du DVD</param>
        /// <param name="pSynopsis">Le synopsis du DVD</param>
        /// <param name="pDuree">La durée du DVD en minutes</param>
        /// <param name="uneImage">Le chemin vers l'image de jaquette du DVD</param>
        public DVD(int unId, string unTitre, string pRealisateur, string pSynopsis, int pDuree, string uneImage) : base(unId, unTitre, uneImage)
        {
            Synopsis = pSynopsis;
            Realisateur = pRealisateur;
            Duree = pDuree;
        }
    }
}
