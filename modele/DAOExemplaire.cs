using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mediateq_AP_SIO2.modele
{
    internal class DAOExemplaire
    {

        public class ExemplaireDAO
        {
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