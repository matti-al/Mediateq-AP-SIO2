

namespace Mediateq_AP_SIO2.metier
{
    public class Categorie
    {
        /// <summary>
        /// Constructeur de la classe Categorie.
        /// Initialise une nouvelle instance avec un identifiant et un libellé.
        /// </summary>
        /// <param name="id">Identifiant de la catégorie</param>
        /// <param name="libelle">Libellé de la catégorie</param>
        public Categorie(int id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant de la catégorie.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le libellé de la catégorie.
        /// </summary>
        public string Libelle { get; set; }
    }
}
