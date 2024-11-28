using Mediateq_AP_SIO2.modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            DAOAuthentification autentifier = new DAOAuthentification();

            //on verifie si il existe dans la base de donnée
            bool isAuthenticated = autentifier.AuthenticateUser(login, mdp);


            // Si l'authentification est réussie
            if (isAuthenticated)
            {
                MessageBox.Show("Connexion réussie", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Rediriger vers une autre page (par exemple : formulaire principal)
                this.Hide();  // Masquer le formulaire de connexion
                FrmMediateq mainForm = new FrmMediateq();  // Formulaire principal
                mainForm.Show();
            }
            else
            {
                // Si l'authentification échoue
                lblMessage.Text = "Nom d'utilisateur ou mot de passe incorrect!";
            }
        }
    }
}
