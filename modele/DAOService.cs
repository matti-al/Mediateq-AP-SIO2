using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.modele
{
    internal class DAOService
    {
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
