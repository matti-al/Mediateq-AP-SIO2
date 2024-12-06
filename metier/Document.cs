

namespace Mediateq_AP_SIO2.metier
{
    class Document
    {
        public Document(int unId, string unTitre, string uneImage)
        {
            IdDoc = unId;
            Titre = unTitre;
            Image = uneImage;
        }


        public int IdDoc { get; set; }
        public string Titre { get; set; }
        public string Image { get; set; }
        public Categorie LaCategorie { get; set; }
    }


}
