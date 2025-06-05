namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe de base abstraite représentant un document dans le système de médiathèque.
    /// Sert de classe parente pour les types de documents spécifiques comme Livre et DVD.
    /// </summary>
    class Document
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe Document.
        /// </summary>
        /// <param name="unId">L'identifiant unique du document</param>
        /// <param name="unTitre">Le titre du document</param>
        /// <param name="uneImage">Le chemin vers l'image associée au document</param>
        public Document(int unId, string unTitre, string uneImage)
        {
            IdDoc = unId;
            Titre = unTitre;
            Image = uneImage;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant unique du document.
        /// </summary>
        public int IdDoc { get; set; }

        /// <summary>
        /// Obtient ou définit le titre du document.
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Obtient ou définit le chemin vers l'image associée au document.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Obtient ou définit la catégorie du document.
        /// </summary>
        public Categorie LaCategorie { get; set; }
    }
}
