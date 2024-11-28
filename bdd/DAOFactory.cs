using System;
using System.Data.SqlClient;
using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;

namespace Mediateq_AP_SIO2
{
    class DAOFactory
    {
        private static MySqlConnection connexion;

        public static void creerConnection()
        {
            string serverIp = "127.0.0.1";
            string username = "mediateq-web";
            string password = "mediateq-web";
            string databaseName = "mediateq";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
           
            try
            {
                connexion = new MySqlConnection(dbConnectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur connexion BDD", e.Message);
            }
            
        }

        public static void connecter()
        {
            try
            {
                connexion.Open();
            }
            catch (Exception e)
            {
                throw new ExceptionSIO(2, "problème ouverture connexion BDD", e.Message);
            }
        }

        public static void deconnecter()
        {
            connexion.Close();
        }

 
        // Exécution d'une requête de lecture ; retourne un Datareader
        public static MySqlDataReader execSQLRead(string requete)
        {
            MySqlCommand command;
            MySqlDataAdapter adapter;
            command = new MySqlCommand();
            command.CommandText = requete;
            command.Connection = connexion;

            adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            MySqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            return dataReader;
        }

        // Exécution d'une requete d'écriture (Insert ou Update) ; ne retourne rien
        public static void execSQLWrite(string requete)
        {

            MySqlCommand command;
            command = new MySqlCommand();
            command.CommandText = requete;
            command.Connection = connexion;

            command.ExecuteNonQuery();
        }

        //Pour la page authentification

        private static string connectionString = "Votre_Chaine_De_Connexion";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
