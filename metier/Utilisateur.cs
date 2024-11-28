using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    internal class Utilisateur
    {
        public int Id;
        public string Login;
        public string MotDePasse;
        public string Nom;
        public string Prenom;
        public string Service;


        public Utilisateur(int id, string login, string motDePasse, string nom, string prenom, string service)
        {
            Id = id;
            Login = login;
            MotDePasse = motDePasse;
            Nom = nom;
            Prenom = prenom;
            Service = service;
        }

        public string getLogin() { 
            return Login; 
        }
        public string getMotDePasse() {
            return MotDePasse; 
        }
        public string getNom()
        {
            return Nom;
        }
        public string getPrenom()
        {
            return Prenom;
        }
        public string getService()
        {
            return Service;
        }
        
    }
}
