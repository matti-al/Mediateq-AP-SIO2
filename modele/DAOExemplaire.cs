using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mediateq_AP_SIO2.modele
{
    /// <summary>
    /// Classe d'accès aux données concernant les exemplaires de documents.
    /// </summary>
    internal class DAOExemplaire
    {
        /// <summary>
        /// Classe interne fournissant des méthodes d'accès aux données pour les exemplaires.
        /// </summary>
        public class ExemplaireDAO
        {
            /// <summary>
            /// Récupère la liste des exemplaires qui sont dans un état inutilisable (état id = 4).
            /// </summary>
            /// <returns>Une ArrayList contenant les exemplaires inutilisables, chaque exemplaire étant représenté par un tableau d'objets</returns>
            /// <exception cref="Exception">Exception levée en cas d'erreur lors de la récupération des données</exception>
            public static ArrayList GetExemplairesInutilisables()
            {
                ArrayList exemplaires = new ArrayList();

                try
                {
                    string req = "SELECT exemplaire.idDocument, exemplaire.numero, etat.libelle " +
                                 "FROM exemplaire " +
                                 "JOIN etat ON etat.id = exemplaire.idEtat " +
                                 "WHERE etat.id = 4";

                    DAOFactory.connecter();
                    MySqlDataReader reader = DAOFactory.execSQLRead(req);

                    while (reader.Read())
                    {
                        // Stocker chaque exemplaire comme un tableau d'objets
                        var exemplaire = new object[]
                        {
                                int.Parse(reader["idDocument"].ToString()),
                                int.Parse(reader["numero"].ToString()),
                                reader["libelle"].ToString()
                        };

                        exemplaires.Add(exemplaire);
                    }

                    DAOFactory.deconnecter();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erreur lors de la récupération des exemplaires inutilisables : " + ex.Message);
                }

                return exemplaires;
            }
        }
    }
}