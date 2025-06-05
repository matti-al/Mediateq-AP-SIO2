using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.modele
{
    /// <summary>
    /// Classe d'accès aux données des services.
    /// Fournit des méthodes pour récupérer les services depuis la base de données.
    /// </summary>
    internal class DAOService
    {
        /// <summary>
        /// Récupère un service depuis la base de données à partir de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant unique du service à récupérer</param>
        /// <returns>L'objet Service correspondant ou null si aucun service n'est trouvé</returns>
        /// <exception cref="Exception">Exception levée en cas d'erreur lors de la récupération</exception>
        public static Service GetServiceById(int id)
        {
            try
            {
                using (MySqlConnection connexion = DAOFactory.GetConnection())
                {
                    string query = "SELECT * FROM service WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(query, connexion);
                    command.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Service(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Erreur lors de la récupération du service : " + exc.Message);
            }
            return null;
        }
    }
}
