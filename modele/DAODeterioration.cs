using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Classe d'accès aux données concernant les détériorations de documents.
    /// </summary>
    internal class DAODeterioration
    {
        /// <summary>
        /// Ajoute une nouvelle détérioration dans la base de données.
        /// </summary>
        /// <param name="idDocument">Identifiant du document détérioré</param>
        /// <param name="numero">Numéro de l'exemplaire</param>
        /// <param name="nomUsager">Nom de l'usager qui a signalé la détérioration</param>
        /// <param name="dateDeterioration">Date à laquelle la détérioration a été constatée</param>
        /// <exception cref="Exception">Levée en cas d'erreur lors de l'enregistrement</exception>
        public static void AjouterDeterioration(int idDocument, int numero, string nomUsager, DateTime dateDeterioration)
        {
            try
            {
                string req = "INSERT INTO deterioration (idDocument, numero, nomUsager, dateDeterioration) " +
                             "VALUES (" + idDocument + ", " + numero + ", '" + nomUsager.Replace("'", "''") +
                             "', '" + dateDeterioration.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                DAOFactory.connecter();
                DAOFactory.execSQLWrite(req);
                DAOFactory.deconnecter();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'enregistrement de la détérioration : " + ex.Message);
            }
        }

        /// <summary>
        /// Récupère la liste de tous les documents détériorés.
        /// </summary>
        /// <returns>Une collection contenant les informations des documents détériorés</returns>
        /// <exception cref="Exception">Levée en cas d'erreur lors de la récupération des données</exception>
        public static ArrayList GetDocumentsDeteriores()
        {
            ArrayList documents = new ArrayList();

            try
            {
                string req = "SELECT deterioration.dateDeterioration, exemplaire.numero, exemplaire.idDocument, deterioration.nomUsager " +
                             "FROM deterioration " +
                             "JOIN exemplaire ON deterioration.idDocument = exemplaire.idDocument " +
                             "AND deterioration.numero = exemplaire.numero";


                DAOFactory.connecter();
                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    // Stocker chaque document comme un tableau d'objets
                    var document = new object[]
                    {
                    DateTime.Parse(reader["dateDeterioration"].ToString()),
                    int.Parse(reader["numero"].ToString()),
                    int.Parse(reader["idDocument"].ToString()),
                    reader["nomUsager"].ToString()
                    };

                    documents.Add(document);
                }

                DAOFactory.deconnecter();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des documents détériorés : " + ex.Message);
            }

            return documents;
        }
    }
}
