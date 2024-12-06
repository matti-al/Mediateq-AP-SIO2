using Mediateq_AP_SIO2.metier;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Mediateq_AP_SIO2
{
    public partial class FrmMediateq : Form
    {
        #region Variables globales

        static List<Categorie> lesCategories;
        static List<Descripteur> lesDescripteurs;
        static List<Revue> lesRevues;
        static List<Livre> lesLivres;
        static List<DVD> lesDvD;


        #endregion


        #region Procédures évènementielles

        public FrmMediateq()
        {
            InitializeComponent();
        }

        private void FrmMediateq_Load(object sender, EventArgs e)
        {
            try
            {
                // Création de la connexion avec la base de données
                DAOFactory.creerConnection();

                // Chargement des objets communs en mémoire
                lesDescripteurs = DAODocuments.getAllDescripteurs();
                lesCategories = DAODocuments.getAllCategories();
                lesDvD = DAODocuments.getAllDVD();
                lesLivres = DAODocuments.getAllLivres();
            }
            catch(ExceptionSIO exc)
            { 
                MessageBox.Show(exc.NiveauExc + " - " + exc.LibelleExc + " - " + exc.Message);
            }
        }

        #endregion


        #region Parutions
        //-----------------------------------------------------------
        // ONGLET "PARUTIONS"
        //------------------------------------------------------------
        private void tabParutions_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesRevues = DAOPresse.getAllRevues();

            // initialisation liste déroulante
            cbxTitres.DataSource = lesRevues;
            cbxTitres.DisplayMember = "titre";
        }

        private void cbxTitres_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Parution> lesParutions;

            Revue titreSelectionne = (Revue)cbxTitres.SelectedItem;
            lesParutions = DAOPresse.getParutionByTitre(titreSelectionne);

            // ré-initialisation du dataGridView
            dgvParutions.Rows.Clear();

            // Parcours de la collection des titres et alimentation du datagridview
            foreach (Parution parution in lesParutions)
            {
                dgvParutions.Rows.Add(parution.Numero, parution.DateParution, parution.Photo);
            }

        }
        #endregion


        #region Revues
        //-----------------------------------------------------------
        // ONGLET "TITRES"
        //------------------------------------------------------------
        private void tabTitres_Enter(object sender, EventArgs e)
        {
            cbxDomaines.DataSource = lesDescripteurs;
            cbxDomaines.DisplayMember = "libelle";
        }

        private void cbxDomaines_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Objet Domaine sélectionné dans la comboBox
            Descripteur domaineSelectionne = (Descripteur)cbxDomaines.SelectedItem;

            // ré-initialisation du dataGridView
            dgvTitres.Rows.Clear();

            // Parcours de la collection des titres et alimentation du datagridview
            foreach (Revue revue in lesRevues)
            {
                if (revue.IdDescripteur != null && revue.IdDescripteur.Id == domaineSelectionne.Id)
                {
                    dgvTitres.Rows.Add(revue.Id, revue.Titre, revue.Empruntable, revue.DateFinAbonnement, revue.DelaiMiseADispo);
                }
            }
        }
        #endregion


        #region Livres
        //-----------------------------------------------------------
        // ONGLET "LIVRES"
        //-----------------------------------------------------------

        private void tabLivres_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesLivres = DAODocuments.getAllLivres();

            // il faut affecter la catégorie à chaque document
            // (on fait ça car le document a été instancié indirectement
            // depuis le constructeur de la classe Livre sans la catégorie).
            foreach (Livre livre in lesLivres)
            {
                Categorie categ = DAODocuments.getCategorieByLivre(livre);
                livre.LaCategorie = categ;
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            // On réinitialise les labels
            lblNumero.Text = "";
            lblTitre.Text = "";
            lblAuteur.Text = "";
            lblCollection.Text = "";
            lblISBN.Text = "";
            lblImage.Text = "";
            lblCategorie.Text = "";

            // On recherche le livre correspondant au numéro de document saisi.
            // S'il n'existe pas: on affiche un popup message d'erreur
            bool trouve = false;
            foreach (Livre livre in lesLivres)
            {
                if (livre.IdDoc == int.Parse(txbNumDoc.Text))
                {
                    lblNumero.Text = livre.IdDoc.ToString();
                    lblTitre.Text = livre.Titre;
                    lblAuteur.Text = livre.Auteur;
                    lblCollection.Text = livre.LaCollection;
                    lblISBN.Text = livre.ISBN1;
                    lblImage.Text = livre.Image;
                    lblCategorie.Text = livre.LaCategorie.Libelle;
                    trouve = true;
                }
            }
            if (!trouve)
                MessageBox.Show("Document non trouvé dans les livres");
        }

        private void txbTitre_TextChanged(object sender, EventArgs e)
        {
            dgvLivres.Rows.Clear();

            // On parcourt tous les livres. Si le titre matche avec la saisie, on l'affiche dans le datagrid.
            foreach (Livre livre in lesLivres)
            {
                // on passe le champ de saisie et le titre en minuscules car la méthode Contains
                // tient compte de la casse.
                string saisieMinuscules;
                saisieMinuscules = txbTitre.Text.ToLower();
                string titreMinuscules;
                titreMinuscules = livre.Titre.ToLower();

                //on teste si le titre du livre contient ce qui a été saisi
                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    dgvLivres.Rows.Add(livre.IdDoc, livre.Titre, livre.Auteur, livre.ISBN1, livre.LaCollection);
                }
            }
        }


        #endregion

        #region DVD
        //-----------------------------------------------------------
        // ONGLET "DVD"
        //-----------------------------------------------------------


        private void tabDVD_Click(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesDvD = DAODocuments.getAllDVD();

            // il faut affecter la catégorie à chaque document
            // (on fait ça car le document a été instancié indirectement
            // depuis le constructeur de la classe Livre sans la catégorie).
            foreach (DVD dvd in lesDvD)
            {
                Categorie categ = DAODocuments.getCategorieByDvD(dvd);
                dvd.LaCategorie = categ;
            }
        }


        private void btnDvD_Click(object sender, EventArgs e)
        {
            // On réinitialise les labels
            lblNumeroDvD.Text = "";
            lblTitreDvD.Text = "";
            lblAuteurDvD.Text = "";
            lblDureeDvD.Text = "";
            lblCategorieDvD.Text = "";
            lblImageDvD.Text = "";
            lblSynopsisDvD.Text = "";

            // On recherche le livre correspondant au numéro de document saisi.
            // S'il n'existe pas: on affiche un popup message d'erreur
            bool trouve = false;
            foreach (DVD dvd in lesDvD)
            {
                if (dvd.IdDoc == int.Parse(txbNumDvD.Text))
                {
                    lblNumeroDvD.Text = dvd.IdDoc.ToString();
                    lblTitreDvD.Text = dvd.Titre;
                    lblAuteurDvD.Text = dvd.Realisateur;
                    lblDureeDvD.Text = dvd.Duree.ToString();
                    //lblCategorieDvD.Text = dvd.LaCategorie.Libelle;
                    lblImageDvD.Text = dvd.Image;
                    lblSynopsisDvD.Text = dvd.Synopsis;
                    trouve = true;
                }
            }
            if (!trouve)
                MessageBox.Show("Document non trouvé dans les livres");

        }
        private void txbDvD_TextChanged(object sender, EventArgs e)
        {
            dgvDvD.Rows.Clear();

            // On parcourt tous les livres. Si le titre matche avec la saisie, on l'affiche dans le datagrid.
            foreach (DVD dvd in lesDvD)
            {
                // on passe le champ de saisie et le titre en minuscules car la méthode Contains
                // tient compte de la casse.
                string saisieMinuscules;
                saisieMinuscules = txbTitre.Text.ToLower();
                string titreMinuscules;
                titreMinuscules = dvd.Titre.ToLower();

                //on teste si le titre du livre contient ce qui a été saisi
                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    dgvDvD.Rows.Add(dvd.IdDoc, dvd.Titre, dvd.Realisateur, dvd.Synopsis, dvd.Duree, dvd.Image);
                }
            }
        }

        #endregion


    }
}
