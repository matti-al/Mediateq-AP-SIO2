using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un utilisateur du système Mediateq.
    /// Contient les informations d'identification et les données personnelles de l'utilisateur.
    /// </summary>
    internal class Utilisateur
    {
        private int Id;
        private string Login;
        private string Nom;
        private string MotDePasse;
        private string Prenom;
        private Service Service;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Utilisateur.
        /// </summary>
        /// <param name="id">L'identifiant unique de l'utilisateur</param>
        /// <param name="login">Le login utilisé pour l'authentification</param>
        /// <param name="motDePasse">Le mot de passe haché de l'utilisateur</param>
        /// <param name="nom">Le nom de famille de l'utilisateur</param>
        /// <param name="prenom">Le prénom de l'utilisateur</param>
        /// <param name="service">Le service auquel l'utilisateur est rattaché</param>
        public Utilisateur(int id, string login, string motDePasse, string nom, string prenom, Service service)
        {
            Id = id;
            Login = login;
            MotDePasse = motDePasse;
            Nom = nom;
            Prenom = prenom;
            Service = service;
        }

        /// <summary>
        /// Obtient le login de l'utilisateur.
        /// </summary>
        /// <returns>Le login de l'utilisateur</returns>
        public string getLogin()
        {
            return Login;
        }

        /// <summary>
        /// Obtient le mot de passe haché de l'utilisateur.
        /// </summary>
        /// <returns>Le mot de passe haché de l'utilisateur</returns>
        public string getMotDePasse()
        {
            return MotDePasse;
        }

        /// <summary>
        /// Obtient le nom de famille de l'utilisateur.
        /// </summary>
        /// <returns>Le nom de famille de l'utilisateur</returns>
        public string getNom()
        {
            return Nom;
        }

        /// <summary>
        /// Obtient le prénom de l'utilisateur.
        /// </summary>
        /// <returns>Le prénom de l'utilisateur</returns>
        public string getPrenom()
        {
            return Prenom;
        }

        /// <summary>
        /// Obtient le service auquel l'utilisateur est rattaché.
        /// </summary>
        /// <returns>Le service de l'utilisateur</returns>
        public Service getService()
        {
            return Service;
        }

    }
}
