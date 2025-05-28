using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mediateq_AP_SIO2.metier;
using System.Windows.Forms;

namespace Mediateq_AP_SIO2.modele
{
    class DAORevue
    {

        // Récupération des revues dont la date de fin d'abonnement est inférieure à 60 jours
        public static List<Revue> GetIdRevueEcheance60j()
        {
            List<Revue> revues = new List<Revue>();
            try
            {
                string req = "SELECT id, titre, dateFinAbonnement  FROM revue WHERE dateFinAbonnement < DATE_SUB(CURDATE(), INTERVAL 60 DAY)";

                DAOFactory.connecter();
                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string titre = reader["titre"].ToString();
                    DateTime dateFinAbonnement = DateTime.Parse(reader["dateFinAbonnement"].ToString());

                    // On crée un objet Revue avec l'id et le titre
                    Revue uneRevue = new Revue(id, titre, dateFinAbonnement); 
                    revues.Add(uneRevue);
                }

                DAOFactory.deconnecter();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des états : " + ex.Message);
            }

            return revues;
        }


        // Mise à jour de l'état de la revue
        public static void UpdateEtatRevue(int idRevue, int nbMois)
        {
            try
            {
                string req = "UPDATE revue SET dateFinAbonnement = DATE_ADD(dateFinAbonnement, INTERVAL " + nbMois + " MONTH) WHERE id = " + idRevue;

                DAOFactory.connecter();
                DAOFactory.execSQLWrite(req);
                DAOFactory.deconnecter();

            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la mise à jour des états : " + ex.Message);
            }
        }

        // Correction in the GetPeriodicite method
        public static List<Revue> GetPeriodicite()
        {
            List<Revue> periodicites = new List<Revue>(); // Change the type of the list to string
            try
            {
                string req = "SELECT DISTINCT periodicite FROM revue";
                DAOFactory.connecter();
                MySqlDataReader reader = DAOFactory.execSQLRead(req);
                while (reader.Read())
                {
                    string uneperiodicite = reader["periodicite"].ToString();
                    Revue periodicite = new Revue(uneperiodicite);
                    periodicites.Add(periodicite); // This now matches the type of the list
                }
                DAOFactory.deconnecter();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des périodicités : " + ex.Message);
            }
            return periodicites;
        }

        // Insertion des nouvelles donnees 
        public static void InsertRevue(Revue uneRevue)
        {
            try
            {
                string req = $"INSERT INTO revue (id, titre, empruntable, periodicite, delai_miseadispo, dateFinAbonnement, idDescripteur) VALUES ('{uneRevue.Id}', '{uneRevue.Titre}', '{uneRevue.Empruntable}', '{uneRevue.Periodicite}', '{uneRevue.DelaiMiseADispo}', '{uneRevue.DateFinAbonnement:yyyy-MM-dd}', '{uneRevue.IdDescripteur.Id}')";
               
                if (!DAOFactory.EstConnecte()) // Vérifie si la connexion n'est pas déjà établie
                {
                    DAOFactory.connecter(); // Se connecte si ce n'est pas le cas
                }
                DAOFactory.execSQLWrite(req);
                DAOFactory.deconnecter();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'insertion de la revue : " + ex.Message);
            }
        }

        public static int GetNextRevueId()
        {
            try
            {
                // Récupérer toutes les revues  
                List<Revue> revues = DAOPresse.getAllRevues();

                // Trouver le dernier ID  
                int dernierId = revues.Max(revue => revue.Id);

                // Retourner le prochain ID  
                return dernierId + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération du dernier ID : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1; // Retourne 1 par défaut en cas d'erreur  
            }
        }

    }
}
