using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Mediateq_AP_SIO2.modele
{
    /// <summary>
    /// Classe responsable de la gestion de l'authentification des utilisateurs.
    /// Fournit des méthodes pour authentifier les utilisateurs et gérer les mots de passe.
    /// </summary>
    internal class DAOAuthentification
    {
        /// <summary>
        /// Récupère un utilisateur depuis la base de données à partir de son login et mot de passe.
        /// </summary>
        /// <param name="Login">Le login de l'utilisateur</param>
        /// <param name="mdp">Le mot de passe non haché de l'utilisateur</param>
        /// <returns>L'objet Utilisateur correspondant ou null si les identifiants sont incorrects</returns>
        /// <exception cref="Exception">Exception levée en cas d'erreur lors de la récupération</exception>
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

        /// <summary>
        /// Crée un hachage SHA-256 d'un mot de passe.
        /// </summary>
        /// <param name="password">Le mot de passe en clair à hacher</param>
        /// <returns>Le hachage SHA-256 du mot de passe sous forme de chaîne hexadécimale</returns>
        /// <exception cref="Exception">Exception levée en cas d'erreur lors du hachage</exception>
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

        /// <summary>
        /// Vérifie si un mot de passe correspond à un hachage existant.
        /// </summary>
        /// <param name="hashedPassword">Le hachage SHA-256 existant</param>
        /// <param name="password">Le mot de passe en clair à vérifier</param>
        /// <returns>True si le mot de passe correspond au hachage, sinon False</returns>
        /// <exception cref="Exception">Exception levée en cas d'erreur lors de la vérification</exception>
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

        /// <summary>
        /// Classe représentant le résultat d'une tentative d'authentification.
        /// </summary>
        public class AuthenticationResult
        {
            /// <summary>
            /// Indique si l'authentification a réussi.
            /// </summary>
            public bool IsAuthenticated { get; set; }

            /// <summary>
            /// L'utilisateur authentifié ou null si l'authentification a échoué.
            /// </summary>
            public Utilisateur User { get; set; }
        }

        /// <summary>
        /// Authentifie un utilisateur à partir de son login et mot de passe.
        /// </summary>
        /// <param name="login">Le login de l'utilisateur</param>
        /// <param name="motDePasse">Le mot de passe de l'utilisateur</param>
        /// <returns>Un objet AuthenticationResult contenant le résultat de l'authentification</returns>
        /// <exception cref="Exception">Exception levée en cas d'erreur lors de l'authentification</exception>
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
