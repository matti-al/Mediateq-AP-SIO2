using Mediateq_AP_SIO2.metier;
using Mediateq_AP_SIO2.modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Mediateq_AP_SIO2.modele.DAOAuthentification;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Formulaire d'authentification permettant aux utilisateurs de se connecter au système Mediateq.
    /// Gère la validation des identifiants et configure les autorisations d'accès selon le service de l'utilisateur.
    /// </summary>
    public partial class FormAuthentification : Form
    {
        /// <summary>
        /// Initialise une nouvelle instance du formulaire d'authentification.
        /// </summary>
        public FormAuthentification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton de connexion.
        /// Vérifie les identifiants saisis, authentifie l'utilisateur et configure les accès selon son service.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement</param>
        /// <param name="e">Les données de l'événement</param>
        private void BtnConnexion_Click(object sender, EventArgs e)
        {
            // Récupération des informations d'identification saisies
            string login = textBoxLogin.Text;
            string mdp = textBoxMotDePasse.Text;

            // Création d'une instance du gestionnaire d'authentification
            DAOAuthentification authentifier = new DAOAuthentification();

            // Tentative d'authentification de l'utilisateur
            AuthenticationResult result = authentifier.AuthenticateUser(login, mdp);
            Utilisateur utilisateur = result.User; // Accéder à l'utilisateur authentifié

            // Vérification de l'authentification réussie
            if (utilisateur != null && DAOAuthentification.VerifyPassword(utilisateur.getMotDePasse(), mdp))
            {
                MessageBox.Show("Connexion réussie", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Récupération du service de l'utilisateur pour déterminer ses autorisations
                Service service = utilisateur.getService();

                // Dictionnaire pour stocker l'état d'accès à chaque onglet
                var tabStates = new Dictionary<string, bool>();

                // Configuration des autorisations d'accès aux onglets selon le service de l'utilisateur
                switch (service.Libelle)
                {
                    case "Administratif":
                        // Le service administratif a accès à la gestion des parutions, titres, livres,
                        // la modification d'état, la gestion des détériorations, la consultation des documents
                        // inutilisables, et la gestion des revues, journaux et abonnements
                        tabStates["tabParutions"] = true;
                        tabStates["tabTitres"] = true;
                        tabStates["tabLivres"] = true;
                        tabStates["tabPageCangerEtat"] = true;
                        tabStates["tabPageDeterioration"] = true;
                        tabStates["tabPageAfficherDocumentsInutilisables"] = true;
                        tabStates["tabPageRevuesEtJournaux"] = true;
                        tabStates["tabPageLesNouveauxAbonnements"] = true;
                        break;

                    case "Prêts":
                        // Le service des prêts a accès à la gestion des parutions, titres, livres, DVD,
                        // la modification d'état, la gestion des détériorations, la consultation des documents
                        // inutilisables, et la gestion des nouveaux abonnements, mais pas des revues et journaux
                        tabStates["tabParutions"] = true;
                        tabStates["tabTitres"] = true;
                        tabStates["tabLivres"] = true;
                        tabStates["tabDVD"] = true;
                        tabStates["tabPageCangerEtat"] = true;
                        tabStates["tabPageDeterioration"] = true;
                        tabStates["tabPageAfficherDocumentsInutilisables"] = true;
                        tabStates["tabPageRevuesEtJournaux"] = false;
                        tabStates["tabPageLesNouveauxAbonnements"] = true;
                        break;

                    case "Culture":
                        // Le service culture a uniquement accès à la gestion des parutions
                        // et des nouveaux abonnements
                        tabStates["tabParutions"] = true;
                        tabStates["tabTitres"] = false;
                        tabStates["tabLivres"] = false;
                        tabStates["tabDVD"] = false;
                        tabStates["tabPageCangerEtat"] = false;
                        tabStates["tabPageDeterioration"] = false;
                        tabStates["tabPageAfficherDocumentsInutilisables"] = false;
                        tabStates["tabPageRevuesEtJournaux"] = false;
                        tabStates["tabPageLesNouveauxAbonnements"] = true;
                        break;

                    default:
                        // Si le service n'est pas reconnu, l'accès est refusé
                        MessageBox.Show("Rôle inconnu. Accès refusé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                // Transfert des autorisations d'accès au formulaire principal
                FrmMediateq.TabStates = tabStates;

                // Fermeture du formulaire d'authentification avec succès
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Affichage d'un message d'erreur si l'authentification échoue
                lblMessage.Text = "Nom d'utilisateur ou mot de passe incorrect!";
            }
        }
    }
}
