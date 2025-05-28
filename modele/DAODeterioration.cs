using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Mediateq_AP_SIO2
{
    internal class DAODeterioration
    {

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
