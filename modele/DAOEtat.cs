using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mediateq_AP_SIO2.modele
{
    internal class DAOEtat
    {

        // Récupère la liste des états
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

        // Met à jour l'état d'un exemplaire
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
