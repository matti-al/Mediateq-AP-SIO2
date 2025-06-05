using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un descripteur de document dans le système Mediateq.
    /// Un descripteur est utilisé pour classifier les documents et revues.
    /// </summary>
    public class Descripteur
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe Descripteur.
        /// </summary>
        /// <param name="id">Identifiant unique du descripteur</param>
        /// <param name="libelle">Libellé décrivant le descripteur</param>
        public Descripteur(int id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant unique du descripteur.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le libellé du descripteur.
        /// </summary>
        public string Libelle { get; set; }
    }





}
