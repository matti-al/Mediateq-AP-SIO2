using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Mediateq_AP_SIO2.modele
{
    internal class DAOAuthentification
    {
        public Utilisateur getUtilisateurByLogin(string Login, string mdp)
        {
            try
            {
                using (MySqlConnection connexion = DAOFactory.GetConnection())
                {
                    string query = "SELECT * FROM utilisateurs WHERE Login = @login && MotDePasse= @mdp";
                    MySqlCommand command = new MySqlCommand(query, connexion);

                    command.Parameters.AddWithValue("@login", Login);
                    command.Parameters.AddWithValue("@mdp", DAOAuthentification.HashPassword(mdp));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Service service = DAOService.GetServiceById(reader.GetInt32(5)); // Récupère l'objet Service

                            return new Utilisateur
                            (
                                reader.GetInt32(0),  // ID de l'utilisateur  
                                reader.GetString(1), // Login de l'utilisateur  
                                reader.GetString(2), // MDP de l'utilisateur  
                                reader.GetString(3), // Nom de l'utilisateur  
                                reader.GetString(4), // Prenom de l'utilisateur  
                                service
                            );
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Erreur lors de la récupération de l'utilisateur : " + exc.Message);
            }
            return null;
        }

        public static string HashPassword(string password)
        {
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                        builder.Append(b.ToString("x2"));
                    return builder.ToString();
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Erreur lors de la vérification de mot de passe : " + exc.Message);
            }
        }

        public static bool VerifyPassword(string hashedPassword, string password)
        {
            try
            {
                return hashedPassword == HashPassword(password);
            }
            catch (Exception exc)
            {
                throw new Exception("Erreur lors de la vérification de mot de passe : " + exc.Message);
            }
        }

        public class AuthenticationResult
        {
            public bool IsAuthenticated { get; set; }
            public Utilisateur User { get; set; }
        }

        public AuthenticationResult AuthenticateUser(string login, string motDePasse)
        {
            try
            {
                Utilisateur user = getUtilisateurByLogin(login, motDePasse);

                if (user != null)
                {
                    return new AuthenticationResult
                    {
                        IsAuthenticated = true,
                        User = user
                    };
                }

                return new AuthenticationResult
                {
                    IsAuthenticated = false,
                    User = null
                };
            }
            catch (Exception exc)
            {
                throw new Exception("Erreur lors de la vérification l'utilisateur : " + exc.Message);
            }
        }
    }
}
