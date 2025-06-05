using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente une parution spécifique d'une revue.
    /// Contient les informations sur un numéro particulier d'une revue périodique.
    /// </summary>
    public class Parution
    {
        private int numero;
        private DateTime dateParution;
        private string photo;
        private Revue laRevue;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Parution.
        /// </summary>
        /// <param name="numero">Le numéro de la parution</param>
        /// <param name="dateParution">La date de publication de la parution</param>
        /// <param name="photo">Le chemin vers l'image de couverture de la parution</param>
        /// <param name="uneRevue">La revue à laquelle appartient cette parution</param>
        public Parution(int numero, DateTime dateParution, string photo, Revue uneRevue)
        {
            this.numero = numero;
            this.dateParution = dateParution;
            this.photo = photo;
            this.laRevue = uneRevue;
        }

        /// <summary>
        /// Obtient ou définit le numéro de la parution.
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Obtient ou définit la date de publication de la parution.
        /// </summary>
        public DateTime DateParution { get; set; }

        /// <summary>
        /// Obtient ou définit le chemin vers l'image de couverture de la parution.
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Obtient ou définit la revue à laquelle appartient cette parution.
        /// </summary>
        public Revue LaRevue { get; set; }
    }
}
