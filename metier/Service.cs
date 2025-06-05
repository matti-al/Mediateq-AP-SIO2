using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un service au sein de l'organisation.
    /// Chaque utilisateur est rattaché à un service spécifique.
    /// </summary>
    internal class Service
    {
        private int id;
        private string libelle;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Service.
        /// </summary>
        /// <param name="id">Identifiant unique du service</param>
        /// <param name="libelle">Libellé descriptif du service</param>
        public Service(int id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant unique du service.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Obtient ou définit le libellé descriptif du service.
        /// </summary>
        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }
    }
}
