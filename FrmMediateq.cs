using Mediateq_AP_SIO2.metier;
using Mediateq_AP_SIO2.modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Mediateq_AP_SIO2.modele.DAOExemplaire;
using System.Xml.Linq;
using System.Collections;
using System.Linq;


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
        public static Dictionary<string, bool> TabStates { get; set; }

        public FrmMediateq()
        {
            InitializeComponent();
            if (TabStates != null)
            {
                ConfigureTabs(TabStates);
            }
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
                lesRevues = DAOPresse.getAllRevues();

                //initialiser les Tableaux
                ChargerExemplairesInutilisables();
                ChargerDocumentsDeteriores();
                ChargerRevue();
                ChargerTTRevue();




                // Pour afficher L'etat dans la liste deroulante
                List<Etat> etats = DAOEtat.GetEtats();
                comboBoxSelectionnerEtat.Items.Clear();
                foreach (Etat etat in etats)
                {
                    comboBoxSelectionnerEtat.Items.Add(etat); // Ajouter les objets "Etat"
                }

                //Affichage le id et le titre dans un comboBox dans l'onglet Revue
                List<Revue> Revues = DAORevue.GetIdRevueEcheance60j();
                comboBoxIdRevue.Items.Clear();
                foreach (Revue revue in Revues)
                {
                    comboBoxIdRevue.Items.Add(revue); // Ajouter les objets "Revue"
                }

                // Afficher le descripteur dans la liste déroulante
                List<Descripteur> descripteurs = DAODocuments.getAllDescripteurs();
                comboBoxDescipteurNvAbo.Items.Clear();

                 foreach (Descripteur descripteur in descripteurs)
                 {
                    comboBoxDescipteurNvAbo.Items.Add(descripteur.Libelle); // Ajouter les objets "Descripteur"
                 }           
                
                // Affiche Periodicite
                List<Revue> periodicites = DAORevue.GetPeriodicite();
                comboBoxPeriodiciteNvAbo.Items.Clear();
                foreach (Revue periodicite in periodicites)
                {
                    comboBoxPeriodiciteNvAbo.Items.Add(periodicite.Periodicite); // Ajouter les objets "Periodicite"
                }


            }
            catch (ExceptionSIO exc)
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




        public void ConfigureTabs(Dictionary<string, bool> tabStates)
        {
            foreach (var tabState in tabStates)
            {
                if (tabOngletsApplication.TabPages.ContainsKey(tabState.Key))
                {
                    tabOngletsApplication.TabPages[tabState.Key].Enabled = tabState.Value;
                }
            }
        }



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
            lblImageDvD.Text = "";
            lblSynopsisDvD.Text = "";

            // On recherche le livre correspondant au numéro de document saisi.
            // S'il n'existe pas: j'affiche un popup message d'erreur
            bool trouve = false;
            foreach (DVD dvd in lesDvD)
            {
                if (dvd.IdDoc == int.Parse(txbNumDvD.Text))
                {
                    lblNumeroDvD.Text = dvd.IdDoc.ToString();
                    lblTitreDvD.Text = dvd.Titre;
                    lblAuteurDvD.Text = dvd.Realisateur;
                    lblDureeDvD.Text = dvd.Duree.ToString();
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


        #region Changement d'état d'un document


        //Pour afficher les Etats dans la liste deroulante
        private void comboBoxSelectionnerEtat_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxSelectionnerEtat.SelectedItem != null)
            {
                Etat etatSelectionne = (Etat)comboBoxSelectionnerEtat.SelectedItem;
            }

        }

        private void buttonModifierEtat_Click(object sender, EventArgs e)
        {
            int idDocument = Convert.ToInt32(textBoxReferenceEtat.Text);
            int numero = Convert.ToInt32(textBoxNumeroDocumentTabChangerEtat.Text);
            Etat etatSelectionne = (Etat)comboBoxSelectionnerEtat.SelectedItem;


            DAOEtat.UpdateEtat(idDocument, numero, etatSelectionne.Id);
            MessageChangerEtat.Text = "L'état du document a été mis à jour avec succès.";
        }

        #endregion

        #region Deterioration
        private void buttonEnregistrerDeterioration_Click(object sender, EventArgs e)
        {
            int etatDeterioreId = 3;
            int idDocument = Convert.ToInt32(textBoxIdDocumentDeterioration.Text);
            int numero = Convert.ToInt32(textBoxNumeroDocumentDeteriorer.Text);
            string nomUsager = textBoxNomUsager.Text.Trim();


            try
            {
                // Mettre à jour l'état dans la table exemplaire
                DAOEtat.UpdateEtat(idDocument, numero, etatDeterioreId);

                // Enregistrer les informations dans la table deterioration
                DAODeterioration.AjouterDeterioration(idDocument, numero, nomUsager, DateTime.Now);

                // Afficher un message de confirmation
                labelMessageDeterioration.Text = "Détérioration enregistrée avec succès.";
            }
            catch (Exception ex)
            {
                labelMessageDeterioration.Text = $"Erreur lors de l'enregistrement : {ex.Message}";
            }
        }
        #endregion

        #region Affichage des documents


        private void ChargerExemplairesInutilisables()
        {
            try
            {
                // Récupérer les données des exemplaires inutilisables
                var exemplaires = ExemplaireDAO.GetExemplairesInutilisables();

                // Nettoyer le DataGridView
                dataGridViewAfficheDocumentInutilisable.Rows.Clear();

                // Ajouter les données au DataGridView
                foreach (object[] exemplaire in exemplaires)
                {
                    dataGridViewAfficheDocumentInutilisable.Rows.Add(exemplaire[0], exemplaire[1], exemplaire[2]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des exemplaires inutilisables : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerDocumentsDeteriores()
        {
            try
            {
                // Récupérer les données
                ArrayList documents = DAODeterioration.GetDocumentsDeteriores();

                // Nettoyer le DataGridView
                dataGridViewDocumentDeteriorer.Rows.Clear();

                // Ajouter les données au DataGridView
                foreach (object[] document in documents)
                {
                    dataGridViewDocumentDeteriorer.Rows.Add(document[0], document[1], document[2], document[3]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des documents détériorés : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Les abonnements aux revues et journaux 

        // Pour afficher les abonnements aux revues et journaux
        private void ChargerRevue()
        {
            try
            {
                List<Revue> revues = DAORevue.GetIdRevueEcheance60j();

                dataGridViewAfficheRevue.Rows.Clear();

                foreach (Revue revue in revues)
                {
                    dataGridViewAfficheRevue.Rows.Add(revue.Id, revue.Titre, revue.DateFinAbonnement.ToString("dd/MM/yyyy"));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur lors du chargement des Revues ");

            }
        }

        // Pour ajouter le nombre de mois à ajouter
        private void ValiderRevue_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer l'ID de la revue sélectionnée
                Revue revueSelectionnee = (Revue)comboBoxIdRevue.SelectedItem;
                int idRevue = revueSelectionnee.Id;

                // Récupérer le nombre de mois à ajouter
                int nbMois = int.Parse(textBoxNbMois.Text);


                // Mettre à jour l'état de la revue dans la base de données
                DAORevue.UpdateEtatRevue(idRevue,nbMois);


                // Recharger les revues
                ChargerRevue();
                MessageBox.Show("L'abonnement à la revue a été mis à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour de l'abonnement : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        #endregion

        #region Les nouveaux abonnements 

        public void ChargerTTRevue()
        {
            try
            {
                // Récupérer les données des revues
                List<Revue> revues = DAOPresse.getAllRevues();

                dataGridViewNvAbo.Rows.Clear();

                foreach (Revue revue in revues)
                {
                    // Recherche du descripteur associé à une revue
                    Descripteur descripteurAssocie = lesDescripteurs
                        // Utilisation de LINQ pour trouver le premier descripteur correspondant
                        .FirstOrDefault(d =>
                            // Vérifie que la revue a un descripteur associé (évite les erreurs null)
                            revue.IdDescripteur != null &&
                            // Compare l'ID du descripteur courant avec celui de la revue
                            d.Id == revue.IdDescripteur.Id
                        );

                    // On récupère le libellé s'il existe, sinon une chaîne vide
                    string libelle = descripteurAssocie != null ? descripteurAssocie.Libelle : "";

                    dataGridViewNvAbo.Rows.Add(
                        revue.Id,
                        revue.Titre,
                        revue.Empruntable,
                        revue.Periodicite,
                        revue.DelaiMiseADispo,
                        revue.DateFinAbonnement.ToString("dd/MM/yyyy") ?? "",
                        libelle
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des revues : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEnregistrerNvAbo_Click(object sender, EventArgs e)
        
        {
            try
            {
                // Récupérer les informations de la nouvelle revue  
                
                int id = DAORevue.GetNextRevueId();
                string titre = textBoxTitreNvAbo.Text.Trim();
                char empruntable = comboBoxEmpruntableNvAbo.SelectedItem.ToString()[0];
                string periodicite = comboBoxPeriodiciteNvAbo.SelectedItem.ToString();
                int delaiMiseADispo = int.Parse(textBoxDelaiNvAbo.Text);
                DateTime dateFinAbonnement = dateTimePickerFinAbo.Value; // Utilisation du DateTimePicker  
                Descripteur descripteurSelectionne = lesDescripteurs.FirstOrDefault(d => d.Libelle == comboBoxDescipteurNvAbo.SelectedItem.ToString());

                // Créer une nouvelle revue  
                Revue nouvelleRevue = new Revue(id, titre, empruntable, periodicite, dateFinAbonnement, delaiMiseADispo, descripteurSelectionne);

                // Enregistrer la nouvelle revue dans la base de données  
                DAORevue.InsertRevue(nouvelleRevue);

                // Recharger les revues  
                ChargerTTRevue();
                ChargerRevue();
                MessageBox.Show("L'abonnement à la revue a été enregistré avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement de l'abonnement : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        
    }
}
