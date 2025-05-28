using Mediateq_AP_SIO2.metier;
using Mediateq_AP_SIO2.modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Mediateq_AP_SIO2.modele.DAOAuthentification;

namespace Mediateq_AP_SIO2
{
    public partial class FormAuthentification : Form
    {
        public FormAuthentification()
        {
            InitializeComponent();
        }

        private void BtnConnexion_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string mdp = textBoxMotDePasse.Text;

            DAOAuthentification authentifier = new DAOAuthentification();

            AuthenticationResult result = authentifier.AuthenticateUser(login, mdp);
            Utilisateur utilisateur = result.User; // Accéder à l'utilisateur authentifié

            

            
            if (utilisateur != null && DAOAuthentification.VerifyPassword(utilisateur.getMotDePasse(), mdp)) // Authentification réussie
            {
                MessageBox.Show("Connexion réussie", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Affichage de la fenêtre principale
                //FrmMediateq mainForm = new FrmMediateq();

                Service service = utilisateur.getService();
                var tabStates = new Dictionary<string, bool>();

                this.DialogResult = DialogResult.OK;
                this.Close();  // Fermer le formulaire d'authentification

                switch (service.Libelle)
                {
                    case "Administratif":
                        tabStates["tabParutions"] = true;
                        tabStates["tabTitres"] = true;
                        tabStates["tabLivres"] = true;
                        tabStates["tabPageCangerEtat"] = true;
                        tabStates["tabPageDeterioration"] = true;
                        tabStates["tabPageAfficherDocumentsInutilisables"] = true;

                        break;

                    case "Prêts": 
                        tabStates["tabParutions"] = true;
                        tabStates["tabTitres"] = true;
                        tabStates["tabLivres"] = true;
                        tabStates["tabDVD"] = true;
                        tabStates["tabPageCangerEtat"] = false;
                        tabStates["tabPageDeterioration"] = false;
                        tabStates["tabPageAfficherDocumentsInutilisables"] = false;
                        break;

                    case "Culture":
                        tabStates["tabParutions"] = true;
                        tabStates["tabTitres"] = false;
                        tabStates["tabLivres"] = false;
                        tabStates["tabDVD"] = false;
                        tabStates["tabPageCangerEtat"] = false;
                        tabStates["tabPageDeterioration"] = false;
                        tabStates["tabPageAfficherDocumentsInutilisables"] = false;
                        break;

                    

                    default:
                        MessageBox.Show("Rôle inconnu. Accès refusé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                /*
                mainForm.ConfigureTabs(tabStates);
                mainForm.Show();
                this.Hide(); // Fermer la fenêtre d'authentification*/

                FrmMediateq.TabStates = tabStates;

                this.DialogResult = DialogResult.OK; // Succès de l'authentification
                this.Close();
            }
            else
            {
                // Si l'authentification échoue
                lblMessage.Text = "Nom d'utilisateur ou mot de passe incorrect!";
            }
        }

    }
}
