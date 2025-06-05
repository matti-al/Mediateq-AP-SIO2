using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mediateq_AP_SIO2.modele
{
    /// <summary>
    /// Classe d'accès aux données concernant les états des exemplaires.
    /// </summary>
    internal class DAOEtat
    {
        /// <summary>
        /// Récupère la liste de tous les états disponibles dans la base de données.
        /// </summary>
        /// <returns>Liste des états disponibles</returns>
        /// <exception cref="Exception">Exception levée en cas d'erreur lors de la récupération des données</exception>
        public static List<Etat> GetEtats()
        {
            List<Etat> etats = new List<Etat>();
            try
            {
                string req = "SELECT id, libelle FROM etat";

                DAOFactory.connecter();
                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string libelle = reader["libelle"].ToString();

                    Etat etat = new Etat(id, libelle);
                    etats.Add(etat);
                }

                DAOFactory.deconnecter();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des états : " + ex.Message);
            }

            return etats;
        }

        /// <summary>
        /// Met à jour l'état d'un exemplaire spécifique dans la base de données.
        /// </summary>
        /// <param name="idDocument">L'identifiant du document</param>
        /// <param name="numero">Le numéro de l'exemplaire</param>
        /// <param name="idEtat">L'identifiant du nouvel état à assigner</param>
        /// <exception cref="Exception">Exception levée en cas d'erreur lors de la mise à jour</exception>
        public static void UpdateEtat(int idDocument, int numero, int idEtat)
        {
            try
            {
                string req = "UPDATE exemplaire SET idEtat = " + idEtat +
                             " WHERE idDocument = " + idDocument + " AND numero = " + numero;

                DAOFactory.connecter();
                DAOFactory.execSQLWrite(req);
                DAOFactory.deconnecter();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la mise à jour de l'état : " + ex.Message);
            }
        }
    }

}
