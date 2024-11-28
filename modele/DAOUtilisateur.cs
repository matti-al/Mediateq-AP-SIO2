using Mediateq_AP_SIO2.metier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Mediateq_AP_SIO2.modele
{
    internal class DAOAuthentification
    {
        public Utilisateur getUtilisateurByLogin(string login)
        {
            using (SqlConnection connexion = DAOFactory.GetConnection())
            {
                string query = "SELECT * FROM Utilisateurs WHERE Login = @login";
                SqlCommand command = new SqlCommand(query, connexion);

                // Ajout du paramètre @login
                command.Parameters.AddWithValue("@login", login);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Utilisateur
                        (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5)
                        );
                    }

                }
            }
            return null;

        }
        public static class PasswordHasher
        {
            public static string HashPassword(string password)
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

            public static bool VerifyPassword(string hashedPassword, string password)
            {
                return hashedPassword == HashPassword(password);
            }
        }

        public bool AuthenticateUser(string login, string motDePasse)
        {

            Utilisateur utilisateur = getUtilisateurByLogin(login);

            if (utilisateur != null && PasswordHasher.VerifyPassword(utilisateur.MotDePasse, motDePasse))
            {
                return true; // Authentification réussie
            }

            return false; // Authentification échouée
        }
    }
}
