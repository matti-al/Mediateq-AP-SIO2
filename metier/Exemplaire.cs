using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un exemplaire physique d'un document dans la médiathèque.
    /// Contient les informations sur un exemplaire spécifique comme sa date d'achat et son état.
    /// </summary>
    internal class Exemplaire
    {
        /// <summary>
        /// Obtient ou définit l'identifiant du document auquel appartient cet exemplaire.
        /// </summary>
        public int IdDocument { get; set; }

        /// <summary>
        /// Obtient ou définit le numéro de l'exemplaire.
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Obtient ou définit la date d'achat de l'exemplaire.
        /// </summary>
        public DateTime DateAchat { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant du rayon où est rangé l'exemplaire.
        /// </summary>
        public int IdRayon { get; set; }

        /// <summary>
        /// Obtient ou définit l'état physique de l'exemplaire.
        /// </summary>
        public Etat Etat { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Exemplaire.
        /// </summary>
        /// <param name="idDocument">L'identifiant du document auquel appartient cet exemplaire</param>
        /// <param name="numero">Le numéro de l'exemplaire</param>
        /// <param name="dateAchat">La date d'achat de l'exemplaire</param>
        /// <param name="idRayon">L'identifiant du rayon où est rangé l'exemplaire</param>
        /// <param name="etat">L'état physique de l'exemplaire</param>
        public Exemplaire(int idDocument, int numero, DateTime dateAchat, int idRayon, Etat etat)
        {
            IdDocument = idDocument;
            Numero = numero;
            DateAchat = dateAchat;
            IdRayon = idRayon;
            Etat = etat;
        }
    }
}

