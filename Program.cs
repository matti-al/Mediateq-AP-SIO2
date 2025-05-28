using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mediateq_AP_SIO2
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Affichage du formulaire d'authentification
            
            FormAuthentification formAuth = new FormAuthentification();
            
            if (formAuth.ShowDialog() == DialogResult.OK)  // Si l'authentification réussit
            {
                // L'utilisateur est authentifié, afficher le formulaire principal
                Application.Run(new FrmMediateq());
            }
           else
            {
                //L'authentification a échoué, fermer l'application
                Application.Exit();
            }

        }
    }
}
