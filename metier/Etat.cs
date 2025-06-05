using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente l'état physique d'un exemplaire de document.
    /// Permet de qualifier la condition d'un exemplaire (neuf, bon, abîmé, etc.).
    /// </summary>
    internal class Etat
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de l'état.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le libellé descriptif de l'état.
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Etat.
        /// </summary>
        /// <param name="id">L'identifiant unique de l'état</param>
        /// <param name="libelle">Le libellé descriptif de l'état</param>
        public Etat(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }

        /// <summary>
        /// Renvoie une représentation textuelle de l'état.
        /// Cette méthode est utilisée pour l'affichage dans les contrôles comme ComboBox.
        /// </summary>
        /// <returns>Le libellé de l'état</returns>
        public override string ToString()
        {
            return Libelle; // Affiche le libellé dans le ComboBox
        }
    }
}
