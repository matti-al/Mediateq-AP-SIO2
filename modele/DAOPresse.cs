﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mediateq_AP_SIO2.metier;

namespace Mediateq_AP_SIO2
{
    class DAOPresse
    {

        public static List<Revue> getAllRevues()
        {
            List<Revue> lesRevues = new List<Revue>();
            try { 
            string req = "Select * from revue";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                Revue titre = new Revue(int.Parse(reader[0].ToString()), reader[1].ToString(), char.Parse(reader[2].ToString()), reader[3].ToString(),DateTime.Parse(reader[5].ToString()), int.Parse(reader[4].ToString()), int.Parse(reader[6].ToString()));
                lesRevues.Add(titre);
            }
            DAOFactory.deconnecter();

        }
            catch (Exception exc)
            {
                throw exc;
            }

            return lesRevues;
        }
        
        public static List<Parution> getParutionByTitre(Revue pTitre)
        {
            List<Parution> lesParutions = new List<Parution>();
            try { 
            string req = "Select * from parution where idRevue = " + pTitre.Id;
            //string req = "Select * from parution p join revue r on p.idRevue = r.idRevue where idRevue = " + pTitre.Id;
            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                Parution parution = new Parution(int.Parse(reader[1].ToString()), DateTime.Parse(reader[2].ToString()), reader[3].ToString(), pTitre);
                lesParutions.Add(parution);
            }
            DAOFactory.deconnecter();
        }
            catch (Exception exc)
            {
                throw exc;
            }
            return lesParutions;
        }

    }
}

