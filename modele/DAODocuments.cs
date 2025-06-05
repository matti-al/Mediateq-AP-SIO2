using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Classe d'accès aux données concernant les documents de la médiathèque.
    /// </summary>
    class DAODocuments
    {
        /// <summary>
        /// Récupère toutes les catégories disponibles dans la base de données.
        /// </summary>
        /// <returns>Liste de toutes les catégories</returns>
        /// <exception cref="Exception">Levée en cas d'erreur lors de la récupération des données</exception>
        public static List<Categorie> getAllCategories()
        {
            List<Categorie> lesCategories = new List<Categorie>();
            try
            {
                string req = "Select * from public";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    Categorie categorie = new Categorie(int.Parse(reader[0].ToString()), reader[1].ToString());
                    lesCategories.Add(categorie);
                }
                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return lesCategories;
        }

        /// <summary>
        /// Récupère tous les descripteurs disponibles dans la base de données.
        /// </summary>
        /// <returns>Liste de tous les descripteurs</returns>
        /// <exception cref="Exception">Levée en cas d'erreur lors de la récupération des données</exception>
        public static List<Descripteur> getAllDescripteurs()
        {
            List<Descripteur> lesGenres = new List<Descripteur>();

            try
            {
                string req = "Select * from descripteur";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    Descripteur genre = new Descripteur(int.Parse(reader[0].ToString()), reader[1].ToString());
                    lesGenres.Add(genre);
                }
                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return lesGenres;
        }

        /// <summary>
        /// Récupère tous les livres disponibles dans la base de données.
        /// </summary>
        /// <returns>Liste de tous les livres</returns>
        /// <exception cref="Exception">Levée en cas d'erreur lors de la récupération des données</exception>
        public static List<Livre> getAllLivres()
        {
            List<Livre> lesLivres = new List<Livre>();
            try
            {
                string req = "Select l.idDocument, l.ISBN, l.auteur, d.titre, d.image, l.collection from livre l join document d on l.idDocument=d.id";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    Livre livre = new Livre(int.Parse(reader[0].ToString()), reader[3].ToString(), reader[1].ToString(),
                        reader[2].ToString(), reader[5].ToString(), reader[4].ToString());
                    lesLivres.Add(livre);
                }
                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return lesLivres;
        }

        /// <summary>
        /// Récupère tous les DVD disponibles dans la base de données.
        /// </summary>
        /// <returns>Liste de tous les DVD</returns>
        /// <exception cref="Exception">Levée en cas d'erreur lors de la récupération des données</exception>
        public static List<DVD> getAllDVD()
        {
            List<DVD> lesDVD = new List<DVD>();
            try
            {
                string req = "SELECT dvd.idDocument,document.titre, dvd.réalisateur, dvd.synopsis, dvd.duree, document.image FROM `dvd` JOIN document ON document.id = dvd.idDocument";

                DAOFactory.connecter();

                MySqlDataReader readerDvD = DAOFactory.execSQLRead(req);

                while (readerDvD.Read())
                {
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    DVD dvd = new DVD(int.Parse(readerDvD[0].ToString()), readerDvD[1].ToString(), readerDvD[2].ToString(), readerDvD[3].ToString(), int.Parse(readerDvD[4].ToString()), readerDvD[5].ToString());
                    lesDVD.Add(dvd);
                }
                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return lesDVD;
        }

        /// <summary>
        /// Récupère la catégorie associée à un DVD spécifique.
        /// </summary>
        /// <param name="pdvd">Le DVD dont on veut connaître la catégorie</param>
        /// <returns>La catégorie du DVD ou null si aucune catégorie n'est trouvée</returns>
        /// <exception cref="Exception">Levée en cas d'erreur lors de la récupération des données</exception>
        public static Categorie getCategorieByDvD(DVD pdvd)
        {
            Categorie categorie;
            try
            {
                string req = "Select p.id,p.libelle from public p,document d where p.id = d.idPublic and d.id='";
                req += pdvd.IdDoc + "'";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                if (reader.Read())
                {
                    categorie = new Categorie(int.Parse(reader[0].ToString()), reader[1].ToString());
                }
                else
                {
                    categorie = null;
                }
                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return categorie;
        }

        /// <summary>
        /// Récupère la catégorie associée à un livre spécifique.
        /// </summary>
        /// <param name="pLivre">Le livre dont on veut connaître la catégorie</param>
        /// <returns>La catégorie du livre ou null si aucune catégorie n'est trouvée</returns>
        /// <exception cref="Exception">Levée en cas d'erreur lors de la récupération des données</exception>
        public static Categorie getCategorieByLivre(Livre pLivre)
        {
            Categorie categorie;
            try
            {
                string req = "Select p.id,p.libelle from public p,document d where p.id = d.idPublic and d.id='";
                req += pLivre.IdDoc + "'";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                if (reader.Read())
                {
                    categorie = new Categorie(int.Parse(reader[0].ToString()), reader[1].ToString());
                }
                else
                {
                    categorie = null;
                }
                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return categorie;
        }
    }
}
