namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un livre dans le système de médiathèque.
    /// Hérite de la classe Document et ajoute des propriétés spécifiques aux livres.
    /// </summary>
    class Livre : Document
    {
        private string ISBN;
        private string auteur;
        private string laCollection;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Livre.
        /// </summary>
        /// <param name="unId">L'identifiant unique du livre</param>
        /// <param name="unTitre">Le titre du livre</param>
        /// <param name="unISBN">Le numéro ISBN du livre</param>
        /// <param name="unAuteur">L'auteur du livre</param>
        /// <param name="uneCollection">La collection à laquelle appartient le livre</param>
        /// <param name="uneImage">Le chemin vers l'image de couverture du livre</param>
        public Livre(int unId, string unTitre, string unISBN, string unAuteur, string uneCollection, string uneImage) : base(unId, unTitre, uneImage)
        {
            ISBN1 = unISBN;
            Auteur = unAuteur;
            LaCollection = uneCollection;
        }

        /// <summary>
        /// Obtient ou définit le numéro ISBN du livre.
        /// </summary>
        public string ISBN1 { get; set; }

        /// <summary>
        /// Obtient ou définit l'auteur du livre.
        /// </summary>
        public string Auteur { get; set; }

        /// <summary>
        /// Obtient ou définit la collection à laquelle appartient le livre.
        /// </summary>
        public string LaCollection { get; set; }
    }
}
