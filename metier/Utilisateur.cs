using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    internal class Utilisateur
    {
        private int Id;
        private string Login;
        private string Nom;
        private string MotDePasse;
        private string Prenom;
        private Service Service;


        public Utilisateur(int id, string login, string motDePasse, string nom, string prenom, Service service)
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
        public Service getService()
        {
            return Service;
        }
        
    }
}
