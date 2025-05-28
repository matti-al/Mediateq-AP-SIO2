-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost:3306
-- Généré le : mer. 28 mai 2025 à 11:32
-- Version du serveur : 5.7.33
-- Version de PHP : 8.2.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `mediateq`
--

-- --------------------------------------------------------

--
-- Structure de la table `abonne`
--

CREATE TABLE `abonne` (
  `numabonne` int(11) NOT NULL,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `mail` varchar(200) NOT NULL,
  `motdepasse` text NOT NULL,
  `Service` varchar(50) NOT NULL,
  `adresse` varchar(200) NOT NULL,
  `telephone` varchar(10) NOT NULL,
  `type_abonnement_id` int(11) NOT NULL DEFAULT '3',
  `actif` tinyint(1) NOT NULL DEFAULT '1',
  `date_debut` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `date_fin` datetime DEFAULT NULL,
  `date_naissance` date DEFAULT NULL,
  `carte_perdue` tinyint(1) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `abonne`
--

INSERT INTO `abonne` (`numabonne`, `nom`, `prenom`, `mail`, `motdepasse`, `Service`, `adresse`, `telephone`, `type_abonnement_id`, `actif`, `date_debut`, `date_fin`, `date_naissance`, `carte_perdue`) VALUES
(1, 'PONCET', 'Tom', 'membre1@mediateq.com', '$2y$12$IVeTUvlETMsChSempeiZleT/0jnr3nE.HQmKzZa2GO291WODvAawK', 'Prêts', '123 Rue Exemple, Paris, France', '0102030405', 4, 1, '2024-01-01 10:00:00', NULL, '2004-06-14', 1),
(2, 'YAO LECOYER', 'Manu', 'membre2@mediateq.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Administratif', '456 Avenue Test, Lyon, France', '0607080910', 2, 0, '2024-02-01 11:00:00', '2024-03-01 11:00:00', '2005-08-18', 0),
(3, 'AL-HUSSAN', 'Matti', 'membre3@mediateq.com', '$2y$12$HtZcsbu4PkP0BR/vwooSJu47XVqzQfHQtS.XdxmPwZRZBhaxRWq1y', 'Culture', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-03-01 12:00:00', NULL, '2005-01-05', 1),
(4, 'ALHUSSAN', 'matti-tech', 'matti.al-hussan@clsi.fr', '$2y$10$icyQdbCJ/hstGuq7tui3kuSoblBZlOEsQGHU8vQpQsKTNrVClzIJe', 'Culture', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-11-30 00:00:00', '2025-11-30 00:00:00', '2000-02-05', 0),
(6, 'Test', 'bob', 'tomlebg@gmail.com', '$2y$10$B5Pv69v5oNDdrfJRnBpAcunPGrt6auQn0Iq6XewI98Q/0uD5Cjs4.', 'Administratif', '789 Boulevard Imaginaire, Lyon, France', '0602843644', 3, 1, '2024-11-30 00:00:00', '2025-11-30 00:00:00', '2004-12-05', 0),
(12, 'ALHUSSAN', 'knv', 'matti.al-hussan4@clsi.fr', '$2y$10$f/6I5mIgKKxT6vONR9KBGuvsGxrtdFXJc8YALnsBpBfCSmRBLwU9u', 'Administratif', '789 Boulevard Imaginaire, Lyon, France', '0602843644', 2, 1, '2024-12-01 00:00:00', '2025-12-01 00:00:00', '2005-01-05', 0),
(13, 'ALHUSSAN', 'knv', 'matti.al-hussa4n4@clsi.fr', '$2y$10$eZgVYYu9AdH5kMQkF0JSN.ZPv3mtqsK/1rKDYXnAkRq7yM2j0XfKG', 'Administratif', '789 Boulevard Imaginaire, Lyon, France', '0602843644', 2, 1, '2024-12-01 00:00:00', '2024-12-22 00:00:00', '2000-01-05', 0),
(15, 'ALHUSSAN', 'matti-tech', 'matti.al-huss14an@clsi.fr', '$2y$10$rCOmMBW/vywga5BcyygY7O7/VbSFVts/BuWy8.dbbR5Snv7zUjRBO', 'Administratif', '789 Boulevard Imaginaire, Lyon, France', '0602843644', 1, 1, '2024-12-01 00:00:00', '2024-12-22 00:00:00', '2019-12-12', 0),
(16, 'ALHUSSAN', 'knv', 'matti.al-hu4ssa4n4@clsi.fr', '$2y$10$9VKgnwdSwzroB7dRg0dbLOz/BD2PPw2GoJ/aJekUtjwsIe75p73wW', 'Administratif', '789 Boulevard Imaginaire, Lyon, France', '0602843644', 4, 1, '2024-12-01 00:00:00', '2025-01-12 00:00:00', '1965-01-05', 0),
(17, 'ALHUSSAN', 'matti-tech', 'matti.al-h6ussan@clsi.fr', '$2y$10$bmHACEcbp9MNRrdjOy1t2.nslt9dt0H8Cf4qWv0PEC6SuNz3ZvSTu', 'Prêts', '789 Boulevard Imaginaire, Lyon, France', '071234511', 2, 1, '2024-12-02 00:00:00', '2024-12-23 00:00:00', '2005-02-01', 0),
(1, 'PONCET', 'Tom', 'membre1@mediateq.com', '$2y$12$IVeTUvlETMsChSempeiZleT/0jnr3nE.HQmKzZa2GO291WODvAawK', '', '123 Rue Exemple, Paris, France', '0102030409', 4, 1, '2024-01-01 10:00:00', NULL, '2004-06-14', 1),
(2, 'YAO LECOYER', 'Manu', 'membre2@mediateq.com', '$2y$12$l41G41L92FvrNlK42hAznOOc3CsXPnjmYsHdcn3DahwSjlQ3ocoMS', '', '456 Avenue Test, Lyon, France', '0607080910', 2, 0, '2024-02-01 11:00:00', '2024-03-01 11:00:00', '2005-08-18', 0),
(3, 'AL-HUSSAN', 'Matti', 'membre3@mediateq.com', '$2y$12$HtZcsbu4PkP0BR/vwooSJu47XVqzQfHQtS.XdxmPwZRZBhaxRWq1y', '', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-03-01 12:00:00', NULL, '2005-01-05', 1),
(103, 'PONCET', 'Tom', 'membre4@gmail.com', '$2y$10$BZSU9VFjGitLk8ECUSJAD.GmCMimL081Qhxmna3pclgOAoQ0WR8Fa', '', '126 Rue Exemple, Paris, France', '102030405', 2, 1, '2024-12-10 00:00:00', '2024-12-31 00:00:00', '2000-05-14', 0),
(1, 'PONCET', 'Tom', 'membre1@mediateq.com', '$2y$12$IVeTUvlETMsChSempeiZleT/0jnr3nE.HQmKzZa2GO291WODvAawK', '', '123 Rue Exemple, Paris, France', '0102030409', 4, 1, '2024-01-01 10:00:00', NULL, '2004-06-14', 1),
(2, 'YAO LECOYER', 'Manu', 'membre2@mediateq.com', '$2y$12$l41G41L92FvrNlK42hAznOOc3CsXPnjmYsHdcn3DahwSjlQ3ocoMS', '', '456 Avenue Test, Lyon, France', '0607080910', 2, 0, '2024-02-01 11:00:00', '2024-03-01 11:00:00', '2005-08-18', 0),
(3, 'AL-HUSSAN', 'Matti', 'membre3@mediateq.com', '$2y$12$HtZcsbu4PkP0BR/vwooSJu47XVqzQfHQtS.XdxmPwZRZBhaxRWq1y', '', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-03-01 12:00:00', NULL, '2005-01-05', 1),
(103, 'PONCET', 'Tom', 'membre4@gmail.com', '$2y$10$BZSU9VFjGitLk8ECUSJAD.GmCMimL081Qhxmna3pclgOAoQ0WR8Fa', '', '126 Rue Exemple, Paris, France', '102030405', 2, 1, '2024-12-10 00:00:00', '2024-12-31 00:00:00', '2000-05-14', 0),
(1, 'PONCET', 'Tom', 'membre1@mediateq.com', '$2y$12$IVeTUvlETMsChSempeiZleT/0jnr3nE.HQmKzZa2GO291WODvAawK', '', '123 Rue Exemple, Paris, France', '0102030409', 4, 1, '2024-01-01 10:00:00', NULL, '2004-06-14', 1),
(2, 'YAO LECOYER', 'Manu', 'membre2@mediateq.com', '$2y$12$l41G41L92FvrNlK42hAznOOc3CsXPnjmYsHdcn3DahwSjlQ3ocoMS', '', '456 Avenue Test, Lyon, France', '0607080910', 2, 0, '2024-02-01 11:00:00', '2024-03-01 11:00:00', '2005-08-18', 0),
(3, 'AL-HUSSAN', 'Matti', 'membre3@mediateq.com', '$2y$12$HtZcsbu4PkP0BR/vwooSJu47XVqzQfHQtS.XdxmPwZRZBhaxRWq1y', '', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-03-01 12:00:00', NULL, '2005-01-05', 1),
(103, 'PONCET', 'Tom', 'membre4@gmail.com', '$2y$10$BZSU9VFjGitLk8ECUSJAD.GmCMimL081Qhxmna3pclgOAoQ0WR8Fa', '', '126 Rue Exemple, Paris, France', '102030405', 2, 1, '2024-12-10 00:00:00', '2024-12-31 00:00:00', '2000-05-14', 0),
(1, 'PONCET', 'Tom', 'membre1@mediateq.com', '$2y$12$IVeTUvlETMsChSempeiZleT/0jnr3nE.HQmKzZa2GO291WODvAawK', '', '123 Rue Exemple, Paris, France', '0102030409', 4, 1, '2024-01-01 10:00:00', NULL, '2004-06-14', 1),
(2, 'YAO LECOYER', 'Manu', 'membre2@mediateq.com', '$2y$12$l41G41L92FvrNlK42hAznOOc3CsXPnjmYsHdcn3DahwSjlQ3ocoMS', '', '456 Avenue Test, Lyon, France', '0607080910', 2, 0, '2024-02-01 11:00:00', '2024-03-01 11:00:00', '2005-08-18', 0),
(3, 'AL-HUSSAN', 'Matti', 'membre3@mediateq.com', '$2y$12$HtZcsbu4PkP0BR/vwooSJu47XVqzQfHQtS.XdxmPwZRZBhaxRWq1y', '', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-03-01 12:00:00', NULL, '2005-01-05', 1),
(103, 'PONCET', 'Tom', 'membre4@gmail.com', '$2y$10$BZSU9VFjGitLk8ECUSJAD.GmCMimL081Qhxmna3pclgOAoQ0WR8Fa', '', '126 Rue Exemple, Paris, France', '102030405', 2, 1, '2024-12-10 00:00:00', '2024-12-31 00:00:00', '2000-05-14', 0),
(1, 'PONCET', 'Tom', 'membre1@mediateq.com', '$2y$12$IVeTUvlETMsChSempeiZleT/0jnr3nE.HQmKzZa2GO291WODvAawK', '', '123 Rue Exemple, Paris, France', '0102030409', 4, 1, '2024-01-01 10:00:00', NULL, '2004-06-14', 1),
(2, 'YAO LECOYER', 'Manu', 'membre2@mediateq.com', '$2y$12$l41G41L92FvrNlK42hAznOOc3CsXPnjmYsHdcn3DahwSjlQ3ocoMS', '', '456 Avenue Test, Lyon, France', '0607080910', 2, 0, '2024-02-01 11:00:00', '2024-03-01 11:00:00', '2005-08-18', 0),
(3, 'AL-HUSSAN', 'Matti', 'membre3@mediateq.com', '$2y$12$HtZcsbu4PkP0BR/vwooSJu47XVqzQfHQtS.XdxmPwZRZBhaxRWq1y', '', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-03-01 12:00:00', NULL, '2005-01-05', 1),
(103, 'PONCET', 'Tom', 'membre4@gmail.com', '$2y$10$BZSU9VFjGitLk8ECUSJAD.GmCMimL081Qhxmna3pclgOAoQ0WR8Fa', '', '126 Rue Exemple, Paris, France', '102030405', 2, 1, '2024-12-10 00:00:00', '2024-12-31 00:00:00', '2000-05-14', 0),
(1, 'PONCET', 'Tom', 'membre1@mediateq.com', '$2y$12$IVeTUvlETMsChSempeiZleT/0jnr3nE.HQmKzZa2GO291WODvAawK', '', '123 Rue Exemple, Paris, France', '0102030409', 4, 1, '2024-01-01 10:00:00', NULL, '2004-06-14', 1),
(2, 'YAO LECOYER', 'Manu', 'membre2@mediateq.com', '$2y$12$l41G41L92FvrNlK42hAznOOc3CsXPnjmYsHdcn3DahwSjlQ3ocoMS', '', '456 Avenue Test, Lyon, France', '0607080910', 2, 0, '2024-02-01 11:00:00', '2024-03-01 11:00:00', '2005-08-18', 0),
(3, 'AL-HUSSAN', 'Matti', 'membre3@mediateq.com', '$2y$12$HtZcsbu4PkP0BR/vwooSJu47XVqzQfHQtS.XdxmPwZRZBhaxRWq1y', '', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-03-01 12:00:00', NULL, '2005-01-05', 1),
(103, 'PONCET', 'Tom', 'membre4@gmail.com', '$2y$10$BZSU9VFjGitLk8ECUSJAD.GmCMimL081Qhxmna3pclgOAoQ0WR8Fa', '', '126 Rue Exemple, Paris, France', '102030405', 2, 1, '2024-12-10 00:00:00', '2024-12-31 00:00:00', '2000-05-14', 0),
(1, 'PONCET', 'Tom', 'membre1@mediateq.com', '$2y$12$IVeTUvlETMsChSempeiZleT/0jnr3nE.HQmKzZa2GO291WODvAawK', '', '123 Rue Exemple, Paris, France', '0102030409', 4, 1, '2024-01-01 10:00:00', NULL, '2004-06-14', 1),
(2, 'YAO LECOYER', 'Manu', 'membre2@mediateq.com', '$2y$12$l41G41L92FvrNlK42hAznOOc3CsXPnjmYsHdcn3DahwSjlQ3ocoMS', '', '456 Avenue Test, Lyon, France', '0607080910', 2, 0, '2024-02-01 11:00:00', '2024-03-01 11:00:00', '2005-08-18', 0),
(3, 'AL-HUSSAN', 'Matti', 'membre3@mediateq.com', '$2y$12$HtZcsbu4PkP0BR/vwooSJu47XVqzQfHQtS.XdxmPwZRZBhaxRWq1y', '', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-03-01 12:00:00', NULL, '2005-01-05', 1),
(103, 'PONCET', 'Tom', 'membre4@gmail.com', '$2y$10$BZSU9VFjGitLk8ECUSJAD.GmCMimL081Qhxmna3pclgOAoQ0WR8Fa', '', '126 Rue Exemple, Paris, France', '102030405', 2, 1, '2024-12-10 00:00:00', '2024-12-31 00:00:00', '2000-05-14', 0),
(1, 'PONCET', 'Tom', 'membre1@mediateq.com', '$2y$12$IVeTUvlETMsChSempeiZleT/0jnr3nE.HQmKzZa2GO291WODvAawK', '', '123 Rue Exemple, Paris, France', '0102030409', 4, 1, '2024-01-01 10:00:00', NULL, '2004-06-14', 1),
(2, 'YAO LECOYER', 'Manu', 'membre2@mediateq.com', '$2y$12$l41G41L92FvrNlK42hAznOOc3CsXPnjmYsHdcn3DahwSjlQ3ocoMS', '', '456 Avenue Test, Lyon, France', '0607080910', 2, 0, '2024-02-01 11:00:00', '2024-03-01 11:00:00', '2005-08-18', 0),
(3, 'AL-HUSSAN', 'Matti', 'membre3@mediateq.com', '$2y$12$HtZcsbu4PkP0BR/vwooSJu47XVqzQfHQtS.XdxmPwZRZBhaxRWq1y', '', '789 Boulevard Imaginaire, Lyon, France', '071234511', 1, 1, '2024-03-01 12:00:00', NULL, '2005-01-05', 1),
(103, 'PONCET', 'Tom', 'membre4@gmail.com', '$2y$10$BZSU9VFjGitLk8ECUSJAD.GmCMimL081Qhxmna3pclgOAoQ0WR8Fa', '', '126 Rue Exemple, Paris, France', '102030405', 2, 1, '2024-12-10 00:00:00', '2024-12-31 00:00:00', '2000-05-14', 0);

-- --------------------------------------------------------

--
-- Structure de la table `commande`
--

CREATE TABLE `commande` (
  `id` int(11) NOT NULL,
  `nbExemplaire` int(11) DEFAULT NULL,
  `dateCommande` date DEFAULT NULL,
  `montant` double DEFAULT NULL,
  `idDocument` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `descripteur`
--

CREATE TABLE `descripteur` (
  `id` int(11) NOT NULL,
  `libelle` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `descripteur`
--

INSERT INTO `descripteur` (`id`, `libelle`) VALUES
(1, 'Presse économique'),
(2, 'Presse culturelle'),
(3, 'Presse sportive'),
(4, 'Presse loisir'),
(5, 'Presse Actualités'),
(10000, 'Humour'),
(10001, 'Bande dessinée'),
(10002, 'Science Fiction'),
(10003, 'Biographie'),
(10004, 'Historique'),
(10006, 'Roman'),
(10007, 'Aventures'),
(10008, 'Essai'),
(10009, 'Documentaire'),
(10010, 'Technique'),
(10011, 'Voyages'),
(10012, 'Drame'),
(10013, 'Comédie'),
(10014, 'Policier');

-- --------------------------------------------------------

--
-- Structure de la table `deterioration`
--

CREATE TABLE `deterioration` (
  `idDocument` int(11) NOT NULL,
  `numero` int(11) NOT NULL,
  `nomUsager` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `dateDeterioration` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `deterioration`
--

INSERT INTO `deterioration` (`idDocument`, `numero`, `nomUsager`, `dateDeterioration`) VALUES
(1, 2, 'Bob', '2024-12-13 10:43:48'),
(1, 2, 'jorge', '2024-12-13 10:45:21'),
(2, 1, 'Fred', '2024-12-13 11:52:14');

-- --------------------------------------------------------

--
-- Structure de la table `document`
--

CREATE TABLE `document` (
  `id` int(11) NOT NULL,
  `titre` varchar(50) DEFAULT NULL,
  `image` text,
  `commandeEnCours` int(11) DEFAULT NULL,
  `idPublic` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `document`
--

INSERT INTO `document` (`id`, `titre`, `image`, `commandeEnCours`, `idPublic`) VALUES
(1, 'Quand sort la recluse', 'https://static.fnac-static.com/multimedia/Images/FR/NR/31/b0/84/8695857/1507-1/tsp20230105062957/Quand-sort-la-recluse.jpg', NULL, 2),
(2, 'Un pays à l\'aube', 'https://focus.telerama.fr/274x369/100/2021/08/19/-multimedia-images_produits-ZoomPE-7-6-3-9782743619367-tsp20130903072409-Un-pays-a-l-aube.jpg', NULL, 2),
(3, 'Et je danse aussi', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/61WW6LGkopL.jpg', NULL, 3),
(4, 'L\'armée furieuse', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/414cv83qQUL._SX307_BO1,204,203,200_.jpg', NULL, 2),
(5, 'Les anonymes', 'https://www.livredepoche.com/sites/default/files/styles/manual_crop_269_435/public/images/livres/couv/9782253157113-001-T.jpeg?itok=YjJE2a5e', NULL, 2),
(6, 'La marque jaune', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/91xG9uGkBBL.jpg', NULL, 3),
(7, 'Dans les coulisses du musée', 'https://www.livredepoche.com/sites/default/files/styles/manual_crop_269_435/public/images/livres/couv/9782253144908-001-T.jpeg?itok=mVyZ5mV6', NULL, 3),
(8, 'Histoire du juif errant', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/91mNV9BiLrL.jpg', NULL, 2),
(9, 'Pars vite et reviens tard', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FfPsoF65L.jpg', 0, 2),
(10, 'Le vestibule des causes perdues', 'https://www.babelio.com/couv/CVT_Le-vestibule-des-causes-perdues_4311.jpeg', 0, 2),
(11, 'L\'ile des oublies', 'https://www.livredepoche.com/sites/default/files/images/livres/couv/9782253161677-001-T.jpeg', 0, 2),
(12, 'La souris bleue', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/41QCZD0X+HS._SX307_BO1,204,203,200_.jpg', 0, 2),
(13, 'Sacré Pêre Noël', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/817UlBu9XML.jpg', 0, 2),
(14, 'Mauvaise étoile', 'https://www.livredepoche.com/sites/default/files/styles/manual_crop_269_435/public/images/livres/couv/9782253176077-001-T.jpeg?itok=qP8a2k-X', 0, 2),
(15, 'La confrérie des téméraires', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/715vQyw5GFL.jpg', 0, 2),
(16, 'Le butin du requin', 'https://www.actes-sud.fr/sites/default/files/couvertures/9782330121877.jpg', 0, 2),
(17, 'Catastrophes au Brésil', 'https://static.fnac-static.com/multimedia/Images/FR/NR/dd/ea/6d/7203549/1507-1/tsp20230221075906/Les-39-cles-Cahill-contre-Vesper.jpg', 0, 2),
(18, 'Le Routard - Maroc', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/91j1+5tonlL.jpg', 0, 2),
(19, 'Guide Vert - Iles Canaries', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/81vH6kVUOML.jpg', 0, 2),
(20, 'Guide Vert - Irlande', 'https://static.fnac-static.com/multimedia/Images/FR/NR/c2/f7/ad/11401154/1507-1/tsp20220418082938/Guide-Vert-Irlande.jpg', 0, 2),
(21, 'Les déferlantes', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/41XbNQNHHEL._SX307_BO1,204,203,200_.jpg', 0, 2),
(22, 'Une part de Ciel', 'https://static.fnac-static.com/multimedia/Images/FR/NR/b8/0e/7c/8130232/1507-1/tsp20210114102306/Une-part-de-ciel.jpg', 0, 2),
(23, 'Le secret du janissaire', 'https://www.bedetheque.com/media/Couvertures/Couv_270396.jpg', 0, 2),
(24, 'Pavillon noir', 'https://images.epagine.fr/430/9782840551430_1_75.jpg', 0, 2),
(25, 'L\'archipel du danger', 'https://cdn.cultura.com/cdn-cgi/image/width=768/media/pim/TITELIVE/35_9782840552369_1_75.jpg', 0, 2),
(26, 'Agence tout risques', 'https://fr.web.img5.acsta.net/medias/nmedia/18/73/05/71/19447495.jpg', NULL, 3),
(27, 'jumanji', 'https://www.bing.com/ck/a?!&&p=b6b76ecfa6ee25d62acc153640c52a34ddb74cbf58c4c8052d51c67785ccf939JmltdHM9MTcyODk1MDQwMA&ptn=3&ver=2&hsh=4&fclid=031832c4-3983-6f2c-2f06-265c3d836d48&u=a1L2ltYWdlcy9zZWFyY2g_Rk9STT1JQVJSU00mcT1qdW1hbmppKyUzYStiaWVudmVudWUrZGFucytsYStqdW5nbGU&ntb=1', NULL, 3),
(28, 'CREED', 'https://www.bing.com/ck/a?!&&p=e1c7bed8a962af120873452f38d9406a9d66a5964f34dc4c48f5a0dcfd44651cJmltdHM9MTcyODk1MDQwMA&ptn=3&ver=2&hsh=4&fclid=031832c4-3983-6f2c-2f06-265c3d836d48&u=a1L2ltYWdlcy9zZWFyY2g_Rk9STT1JQVJSU00mcT1jcmVlZCslM2ErbCUyN2glYzMlYTlyaXRhZ2UrZGUrcm9ja3krYmFsYm9h&ntb=1', NULL, 3);

-- --------------------------------------------------------

--
-- Structure de la table `dvd`
--

CREATE TABLE `dvd` (
  `idDocument` int(11) NOT NULL,
  `synopsis` varchar(100) DEFAULT NULL,
  `réalisateur` varchar(50) DEFAULT NULL,
  `duree` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `dvd`
--

INSERT INTO `dvd` (`idDocument`, `synopsis`, `réalisateur`, `duree`) VALUES
(27, 'Jumanji : Bienvenue dans la jungle (Jumanji: Welcome to the Jungle)', 'Jake Kasdan', 119),
(28, 'Adonis Johnson, fils du champion Apollo Creed, demande à Rocky Balboa de l\'entraîner', 'Ryan Coogler', 133);

-- --------------------------------------------------------

--
-- Structure de la table `emprunt`
--

CREATE TABLE `emprunt` (
  `idAbonne` int(11) NOT NULL,
  `idDocument` int(11) NOT NULL,
  `numero` int(11) NOT NULL,
  `dateDebut` datetime NOT NULL,
  `dateFin` datetime NOT NULL,
  `rendu` tinyint(1) DEFAULT '0',
  `prolongeable` tinyint(1) DEFAULT '1',
  `prolonger` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `emprunt`
--

INSERT INTO `emprunt` (`idAbonne`, `idDocument`, `numero`, `dateDebut`, `dateFin`, `rendu`, `prolongeable`, `prolonger`) VALUES
(1, 1, 1, '2024-12-01 10:00:00', '2025-01-08 00:00:00', 0, 1, 1),
(1, 3, 2, '2024-11-28 14:00:00', '2024-01-08 00:00:00', 0, 0, 0),
(1, 20, 1, '2024-12-01 10:00:00', '2024-12-16 00:00:00', 0, 0, 0),
(2, 2, 1, '2024-11-25 09:30:00', '2024-12-05 09:30:00', 1, 0, 1),
(2, 8, 1, '2024-11-25 09:30:00', '2024-12-12 00:00:00', 0, 0, 0),
(2, 25, 1, '2024-12-01 10:00:00', '2024-12-22 00:00:00', 0, 0, 0),
(3, 6, 1, '2024-11-28 14:00:00', '2024-12-26 00:00:00', 0, 0, 0),
(3, 22, 1, '2024-11-28 14:00:00', '2024-12-12 14:00:00', 0, 0, 1),
(3, 24, 1, '2024-11-25 09:30:00', '2024-12-05 09:30:00', 1, 1, 1);

--
-- Déclencheurs `emprunt`
--
DELIMITER $$
CREATE TRIGGER `reset_prolongeable_prolonger` BEFORE UPDATE ON `emprunt` FOR EACH ROW BEGIN
    -- Vérification si la dateFin a été modifiée
    IF NEW.dateFin != OLD.dateFin THEN
        -- Si la dateFin a changé, mettre prolongeable et prolonger à 0
        SET NEW.prolongeable = 0;
        SET NEW.prolonger = 0;
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `est_decrit_par_2`
--

CREATE TABLE `est_decrit_par_2` (
  `idDocument` int(11) NOT NULL,
  `idDescripteur` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `est_decrit_par_2`
--

INSERT INTO `est_decrit_par_2` (`idDocument`, `idDescripteur`) VALUES
(3, 10006),
(1, 10008),
(3, 10011),
(1, 10014);

-- --------------------------------------------------------

--
-- Structure de la table `etat`
--

CREATE TABLE `etat` (
  `id` int(11) NOT NULL,
  `libelle` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `etat`
--

INSERT INTO `etat` (`id`, `libelle`) VALUES
(1, 'neuf'),
(2, 'usagé'),
(3, 'détérioré'),
(4, 'inutilisable');

-- --------------------------------------------------------

--
-- Structure de la table `exemplaire`
--

CREATE TABLE `exemplaire` (
  `idDocument` int(11) NOT NULL,
  `numero` int(11) NOT NULL,
  `dateAchat` date DEFAULT NULL,
  `idRayon` int(11) NOT NULL,
  `idEtat` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `exemplaire`
--

INSERT INTO `exemplaire` (`idDocument`, `numero`, `dateAchat`, `idRayon`, `idEtat`) VALUES
(1, 1, '2023-01-15', 1, 1),
(1, 2, '2023-02-20', 2, 3),
(1, 3, '2023-03-10', 3, 1),
(2, 1, '2023-07-02', 1, 3),
(3, 1, '2023-04-05', 2, 2),
(3, 2, '2023-05-12', 3, 2),
(3, 3, '2023-06-08', 1, 2),
(3, 4, '2023-11-10', 2, 2),
(4, 1, '2023-07-15', 2, 2),
(6, 1, '2023-07-20', 3, 3),
(8, 1, '2023-08-05', 1, 1),
(10, 1, '2023-08-10', 2, 2),
(12, 1, '2023-08-15', 3, 3),
(14, 1, '2023-09-02', 1, 1),
(16, 1, '2023-09-10', 2, 2),
(18, 1, '2023-09-15', 3, 3),
(20, 1, '2023-10-05', 1, 1),
(22, 1, '2023-10-10', 2, 2),
(24, 1, '2023-10-15', 3, 3),
(26, 1, '2023-11-02', 1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `livre`
--

CREATE TABLE `livre` (
  `idDocument` int(11) NOT NULL,
  `ISBN` char(13) DEFAULT NULL,
  `auteur` varchar(50) DEFAULT NULL,
  `collection` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `livre`
--

INSERT INTO `livre` (`idDocument`, `ISBN`, `auteur`, `collection`) VALUES
(1, '1234569877896', 'Fred Vargas', 'Commissaire Adamsberg'),
(2, '1236547896541', 'Dennis Lehanne', ''),
(3, '6541236987410', 'Anne-Laure Bondoux', ''),
(4, '3214569874123', 'Fred Vargas', 'Commissaire Adamsberg'),
(5, '3214563214563', 'RJ Ellory', ''),
(6, '3213213211232', 'Edgar P. Jacobs', 'Blake et Mortimer'),
(7, '6541236987541', 'Kate Atkinson', ''),
(8, '1236987456321', 'Jean d\'Ormesson', ''),
(9, '3,21E+12', 'Fred Vargas', 'Commissaire Adamsberg'),
(10, '3,21E+12', 'Manon Moreau', ''),
(11, '3,21E+12', 'Victoria Hislop', ''),
(12, '3,21E+12', 'Kate Atkinson', ''),
(13, '3,21E+12', 'Raymond Briggs', ''),
(14, '3,21E+12', 'RJ Ellory', ''),
(15, '3,21E+12', 'Floriane Turmeau', ''),
(16, '3,21E+12', 'Julian Press', ''),
(17, '3,21E+12', 'Philippe Masson', ''),
(18, '3,21E+12', '', 'Guide du Routard'),
(19, '3,21E+12', '', 'Guide Vert'),
(20, '3,21E+12', '', 'Guide Vert'),
(21, '3,21E+12', 'Claudie Gallay', ''),
(22, '3,21E+12', 'Claudie Gallay', ''),
(23, '3,21E+12', 'Ayrolles - Masbou', 'De cape et de crocs'),
(24, '3,21E+12', 'Ayrolles - Masbou', 'De cape et de crocs'),
(25, '3,21E+12', 'Ayrolles - Masbou', 'De cape et de crocs');

-- --------------------------------------------------------

--
-- Structure de la table `parution`
--

CREATE TABLE `parution` (
  `idRevue` int(11) NOT NULL,
  `numero` int(11) NOT NULL,
  `dateParution` date DEFAULT NULL,
  `photo` varchar(500) DEFAULT NULL,
  `idEtat` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `parution`
--

INSERT INTO `parution` (`idRevue`, `numero`, `dateParution`, `photo`, `idEtat`) VALUES
(10001, 154, '2021-07-01', NULL, 1),
(10001, 155, '2021-08-01', NULL, 1),
(10001, 156, '2021-09-01', NULL, 1),
(10001, 157, '2021-10-01', NULL, 1),
(10001, 158, '2021-11-01', NULL, 1),
(10001, 159, '2021-12-01', NULL, 1),
(10001, 160, '2023-01-01', 'lien vers la photo de janvier 2023', 1),
(10001, 161, '2023-02-01', 'lien vers la photo de février 2023', 1),
(10002, 2154, '2021-07-01', 'lien vers la photo de juillet 2021', 1),
(10002, 2155, '2021-08-01', NULL, 1),
(10002, 2156, '2021-09-01', NULL, 1),
(10002, 2157, '2021-10-01', NULL, 1),
(10002, 2158, '2021-11-01', NULL, 1),
(10002, 2159, '2021-12-01', NULL, 1),
(10002, 2160, '2023-01-01', 'lien vers la photo de janvier 2023', 1),
(10002, 2161, '2023-02-01', 'lien vers la photo de février 2023', 1),
(10003, 215, '2021-02-01', NULL, 1),
(10003, 216, '2021-03-01', NULL, 1),
(10003, 217, '2021-04-01', NULL, 1),
(10003, 218, '2021-05-01', NULL, 1),
(10003, 219, '2021-06-01', NULL, 1),
(10003, 220, '2021-07-01', NULL, 1),
(10003, 221, '2023-01-15', 'lien vers la photo de janvier 2023', 1),
(10003, 222, '2023-02-15', 'lien vers la photo de février 2023', 1),
(10004, 163, '2023-01-10', 'lien vers la photo de janvier 2023', 1),
(10004, 164, '2023-02-10', 'lien vers la photo de février 2023', 1),
(10005, 323, '2023-01-20', 'lien vers la photo de janvier 2023', 1),
(10005, 324, '2023-02-20', 'lien vers la photo de février 2023', 1),
(10005, 3215, '2021-11-20', NULL, 1),
(10005, 3216, '2021-11-21', NULL, 1),
(10005, 3217, '2021-11-22', NULL, 1),
(10005, 3218, '2021-11-23', NULL, 1),
(10005, 3219, '2021-11-24', NULL, 1),
(10005, 3220, '2021-11-25', NULL, 1),
(10006, 223, '2023-01-05', 'lien vers la photo de janvier 2023', 1),
(10006, 224, '2023-02-05', 'lien vers la photo de février 2023', 1),
(10007, 163, '2023-01-08', 'lien vers la photo de janvier 2023', 1),
(10007, 164, '2023-02-08', 'lien vers la photo de février 2023', 1),
(10008, 223, '2023-01-02', 'lien vers la photo de janvier 2023', 1),
(10008, 224, '2023-02-02', 'lien vers la photo de février 2023', 1),
(10009, 163, '2023-01-02', 'lien vers la photo de janvier 2023', 1),
(10009, 164, '2023-02-02', 'lien vers la photo de février 2023', 1),
(10010, 323, '2023-01-03', 'lien vers la photo de janvier 2023', 1),
(10010, 324, '2023-02-03', 'lien vers la photo de février 2023', 1),
(10011, 223, '2023-01-01', 'lien vers la photo de janvier 2023', 1),
(10011, 224, '2023-02-01', 'lien vers la photo de février 2023', 1);

-- --------------------------------------------------------

--
-- Structure de la table `public`
--

CREATE TABLE `public` (
  `id` int(11) NOT NULL,
  `libelle` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `public`
--

INSERT INTO `public` (`id`, `libelle`) VALUES
(1, 'Jeunesse'),
(2, 'Adultes'),
(3, 'Tous publics'),
(4, 'Ados');

-- --------------------------------------------------------

--
-- Structure de la table `rayon`
--

CREATE TABLE `rayon` (
  `id` int(11) NOT NULL,
  `libelle` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `rayon`
--

INSERT INTO `rayon` (`id`, `libelle`) VALUES
(1, 'Romans'),
(2, 'Science-fiction'),
(3, 'Policier'),
(4, 'Jeunesse'),
(5, 'Biographie');

-- --------------------------------------------------------

--
-- Structure de la table `reservation`
--

CREATE TABLE `reservation` (
  `idAbonne` int(11) NOT NULL,
  `idDocument` int(11) NOT NULL,
  `numero` int(11) NOT NULL,
  `dateReservation` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `idStatut` int(11) NOT NULL,
  `rang` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `reservation`
--

INSERT INTO `reservation` (`idAbonne`, `idDocument`, `numero`, `dateReservation`, `idStatut`, `rang`) VALUES
(1, 1, 3, '2024-12-05 00:00:00', 1, 1),
(1, 1, 4, '2024-12-07 00:00:00', 2, 2),
(1, 2, 3, '2024-12-05 00:00:00', 1, 1),
(1, 2, 4, '2024-12-06 00:00:00', 2, 2),
(1, 7, 2, '2024-12-06 00:00:00', 1, 1),
(1, 12, 4, '2024-12-07 00:00:00', 1, 1),
(1, 16, 1, '2024-11-28 00:00:00', 1, 1),
(1, 300, 4, '2024-12-05 00:00:00', 2, 2),
(2, 1, 1, '2024-12-06 00:00:00', 1, 1),
(2, 1, 2, '2024-12-06 00:00:00', 1, 1),
(2, 1, 3, '2024-11-28 00:00:00', 2, 2),
(2, 1, 4, '2024-12-06 00:00:00', 1, 1),
(2, 2, 4, '2024-12-05 00:00:00', 1, 1),
(2, 100, 4, '2024-12-06 00:00:00', 1, 1),
(3, 20, 1, '2024-11-25 00:00:00', 2, 1),
(3, 24, 1, '2024-11-28 00:00:00', 2, 1),
(3, 100, 3, '2024-12-06 00:00:00', 1, 1),
(3, 100, 4, '2024-12-06 00:00:00', 2, 2),
(3, 300, 4, '2024-12-05 00:00:00', 1, 1),
(1, 1, 3, '2024-12-05 00:00:00', 2, 3),
(1, 1, 4, '2024-12-07 00:00:00', 2, 3),
(1, 2, 3, '2024-12-05 00:00:00', 2, 2),
(1, 2, 4, '2024-12-06 00:00:00', 2, 3),
(1, 7, 2, '2024-12-06 00:00:00', 2, 2),
(1, 12, 4, '2024-12-07 00:00:00', 2, 2),
(1, 16, 1, '2024-11-28 00:00:00', 2, 2),
(1, 300, 4, '2024-12-05 00:00:00', 2, 3),
(2, 1, 1, '2024-12-06 00:00:00', 2, 2),
(2, 1, 2, '2024-12-06 00:00:00', 2, 2),
(2, 1, 3, '2024-11-28 00:00:00', 2, 4),
(2, 1, 4, '2024-12-06 00:00:00', 2, 4),
(2, 2, 4, '2024-12-05 00:00:00', 2, 4),
(2, 100, 4, '2024-12-06 00:00:00', 2, 3),
(3, 20, 1, '2024-11-25 00:00:00', 2, 2),
(3, 24, 1, '2024-11-28 00:00:00', 2, 2),
(3, 100, 3, '2024-12-06 00:00:00', 2, 2),
(3, 100, 4, '2024-12-06 00:00:00', 2, 4),
(3, 300, 4, '2024-12-05 00:00:00', 2, 4),
(1, 1, 3, '2024-12-05 00:00:00', 2, 5),
(1, 1, 4, '2024-12-07 00:00:00', 2, 5),
(1, 2, 3, '2024-12-05 00:00:00', 2, 3),
(1, 2, 4, '2024-12-06 00:00:00', 2, 5),
(1, 7, 2, '2024-12-06 00:00:00', 2, 3),
(1, 12, 4, '2024-12-07 00:00:00', 2, 3),
(1, 16, 1, '2024-11-28 00:00:00', 2, 3),
(1, 300, 4, '2024-12-05 00:00:00', 2, 5),
(2, 1, 1, '2024-12-06 00:00:00', 2, 3),
(2, 1, 2, '2024-12-06 00:00:00', 2, 3),
(2, 1, 3, '2024-11-28 00:00:00', 2, 6),
(2, 1, 4, '2024-12-06 00:00:00', 2, 6),
(2, 2, 4, '2024-12-05 00:00:00', 2, 6),
(2, 100, 4, '2024-12-06 00:00:00', 2, 5),
(3, 20, 1, '2024-11-25 00:00:00', 2, 3),
(3, 24, 1, '2024-11-28 00:00:00', 2, 3),
(3, 100, 3, '2024-12-06 00:00:00', 2, 3),
(3, 100, 4, '2024-12-06 00:00:00', 2, 6),
(3, 300, 4, '2024-12-05 00:00:00', 2, 6),
(1, 1, 3, '2024-12-05 00:00:00', 2, 7),
(1, 1, 4, '2024-12-07 00:00:00', 2, 7),
(1, 2, 3, '2024-12-05 00:00:00', 2, 4),
(1, 2, 4, '2024-12-06 00:00:00', 2, 7),
(1, 7, 2, '2024-12-06 00:00:00', 2, 4),
(1, 12, 4, '2024-12-07 00:00:00', 2, 4),
(1, 16, 1, '2024-11-28 00:00:00', 2, 4),
(1, 300, 4, '2024-12-05 00:00:00', 2, 7),
(2, 1, 1, '2024-12-06 00:00:00', 2, 4),
(2, 1, 2, '2024-12-06 00:00:00', 2, 4),
(2, 1, 3, '2024-11-28 00:00:00', 2, 8),
(2, 1, 4, '2024-12-06 00:00:00', 2, 8),
(2, 2, 4, '2024-12-05 00:00:00', 2, 8),
(2, 100, 4, '2024-12-06 00:00:00', 2, 7),
(3, 20, 1, '2024-11-25 00:00:00', 2, 4),
(3, 24, 1, '2024-11-28 00:00:00', 2, 4),
(3, 100, 3, '2024-12-06 00:00:00', 2, 4),
(3, 100, 4, '2024-12-06 00:00:00', 2, 8),
(3, 300, 4, '2024-12-05 00:00:00', 2, 8),
(1, 1, 3, '2024-12-05 00:00:00', 2, 9),
(1, 1, 4, '2024-12-07 00:00:00', 2, 9),
(1, 2, 3, '2024-12-05 00:00:00', 2, 5),
(1, 2, 4, '2024-12-06 00:00:00', 2, 9),
(1, 7, 2, '2024-12-06 00:00:00', 2, 5),
(1, 12, 4, '2024-12-07 00:00:00', 2, 5),
(1, 16, 1, '2024-11-28 00:00:00', 2, 5),
(1, 300, 4, '2024-12-05 00:00:00', 2, 9),
(2, 1, 1, '2024-12-06 00:00:00', 2, 5),
(2, 1, 2, '2024-12-06 00:00:00', 2, 5),
(2, 1, 3, '2024-11-28 00:00:00', 2, 10),
(2, 1, 4, '2024-12-06 00:00:00', 2, 10),
(2, 2, 4, '2024-12-05 00:00:00', 2, 10),
(2, 100, 4, '2024-12-06 00:00:00', 2, 9),
(3, 20, 1, '2024-11-25 00:00:00', 2, 5),
(3, 24, 1, '2024-11-28 00:00:00', 2, 5),
(3, 100, 3, '2024-12-06 00:00:00', 2, 5),
(3, 100, 4, '2024-12-06 00:00:00', 2, 10),
(3, 300, 4, '2024-12-05 00:00:00', 2, 10),
(1, 1, 3, '2024-12-05 00:00:00', 2, 11),
(1, 1, 4, '2024-12-07 00:00:00', 2, 11),
(1, 2, 3, '2024-12-05 00:00:00', 2, 6),
(1, 2, 4, '2024-12-06 00:00:00', 2, 11),
(1, 7, 2, '2024-12-06 00:00:00', 2, 6),
(1, 12, 4, '2024-12-07 00:00:00', 2, 6),
(1, 16, 1, '2024-11-28 00:00:00', 2, 6),
(1, 300, 4, '2024-12-05 00:00:00', 2, 11),
(2, 1, 1, '2024-12-06 00:00:00', 2, 6),
(2, 1, 2, '2024-12-06 00:00:00', 2, 6),
(2, 1, 3, '2024-11-28 00:00:00', 2, 12),
(2, 1, 4, '2024-12-06 00:00:00', 2, 12),
(2, 2, 4, '2024-12-05 00:00:00', 2, 12),
(2, 100, 4, '2024-12-06 00:00:00', 2, 11),
(3, 20, 1, '2024-11-25 00:00:00', 2, 6),
(3, 24, 1, '2024-11-28 00:00:00', 2, 6),
(3, 100, 3, '2024-12-06 00:00:00', 2, 6),
(3, 100, 4, '2024-12-06 00:00:00', 2, 12),
(3, 300, 4, '2024-12-05 00:00:00', 2, 12),
(1, 1, 3, '2024-12-05 00:00:00', 2, 13),
(1, 1, 4, '2024-12-07 00:00:00', 2, 13),
(1, 2, 3, '2024-12-05 00:00:00', 2, 7),
(1, 2, 4, '2024-12-06 00:00:00', 2, 13),
(1, 7, 2, '2024-12-06 00:00:00', 2, 7),
(1, 12, 4, '2024-12-07 00:00:00', 2, 7),
(1, 16, 1, '2024-11-28 00:00:00', 2, 7),
(1, 300, 4, '2024-12-05 00:00:00', 2, 13),
(2, 1, 1, '2024-12-06 00:00:00', 2, 7),
(2, 1, 2, '2024-12-06 00:00:00', 2, 7),
(2, 1, 3, '2024-11-28 00:00:00', 2, 14),
(2, 1, 4, '2024-12-06 00:00:00', 2, 14),
(2, 2, 4, '2024-12-05 00:00:00', 2, 14),
(2, 100, 4, '2024-12-06 00:00:00', 2, 13),
(3, 20, 1, '2024-11-25 00:00:00', 2, 7),
(3, 24, 1, '2024-11-28 00:00:00', 2, 7),
(3, 100, 3, '2024-12-06 00:00:00', 2, 7),
(3, 100, 4, '2024-12-06 00:00:00', 2, 14),
(3, 300, 4, '2024-12-05 00:00:00', 2, 14),
(1, 1, 3, '2024-12-05 00:00:00', 2, 15),
(1, 1, 4, '2024-12-07 00:00:00', 2, 15),
(1, 2, 3, '2024-12-05 00:00:00', 2, 8),
(1, 2, 4, '2024-12-06 00:00:00', 2, 15),
(1, 7, 2, '2024-12-06 00:00:00', 2, 8),
(1, 12, 4, '2024-12-07 00:00:00', 2, 8),
(1, 16, 1, '2024-11-28 00:00:00', 2, 8),
(1, 300, 4, '2024-12-05 00:00:00', 2, 15),
(2, 1, 1, '2024-12-06 00:00:00', 2, 8),
(2, 1, 2, '2024-12-06 00:00:00', 2, 8),
(2, 1, 3, '2024-11-28 00:00:00', 2, 16),
(2, 1, 4, '2024-12-06 00:00:00', 2, 16),
(2, 2, 4, '2024-12-05 00:00:00', 2, 16),
(2, 100, 4, '2024-12-06 00:00:00', 2, 15),
(3, 20, 1, '2024-11-25 00:00:00', 2, 8),
(3, 24, 1, '2024-11-28 00:00:00', 2, 8),
(3, 100, 3, '2024-12-06 00:00:00', 2, 8),
(3, 100, 4, '2024-12-06 00:00:00', 2, 16),
(3, 300, 4, '2024-12-05 00:00:00', 2, 16);

--
-- Déclencheurs `reservation`
--
DELIMITER $$
CREATE TRIGGER `Trig_BI_reservation_rang_statut` BEFORE INSERT ON `reservation` FOR EACH ROW BEGIN
    DECLARE nb_reservation INT DEFAULT 0;

    -- Vérifier le rang maximum existant pour ce document et exemplaire
    SELECT COUNT(*) INTO nb_reservation
    FROM reservation
    WHERE idDocument = NEW.idDocument AND numero = NEW.numero;

    -- Calculer le rang pour la nouvelle réservation
    SET NEW.rang = nb_reservation + 1;

    -- Définir le statut selon le rang
    IF NEW.rang = 1 THEN
        SET NEW.idStatut = 1; -- Disponible
    ELSE
        SET NEW.idStatut = 2; -- Indisponible
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `revue`
--

CREATE TABLE `revue` (
  `id` int(11) NOT NULL,
  `titre` varchar(50) NOT NULL,
  `empruntable` char(1) DEFAULT NULL,
  `periodicite` varchar(2) DEFAULT NULL,
  `delai_miseadispo` int(11) DEFAULT NULL,
  `dateFinAbonnement` date DEFAULT NULL,
  `idDescripteur` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `revue`
--

INSERT INTO `revue` (`id`, `titre`, `empruntable`, `periodicite`, `delai_miseadispo`, `dateFinAbonnement`, `idDescripteur`) VALUES
(10001, 'Arts Magazine', 'O', 'MS', 52, '2027-03-30', 2),
(10002, 'Alternatives Economiques', 'O', 'HB', 52, '2022-04-30', 1),
(10003, 'Challenges', 'O', 'HB', 26, '2022-02-28', 1),
(10004, 'Rock and Folk', 'O', 'MS', 52, '2022-10-31', 2),
(10005, 'Les Echos', 'N', 'QT', 5, '2049-03-31', 1),
(10006, 'L\'Equipe', 'N', 'QT', 5, '2022-01-31', 3),
(10007, 'Telerama', 'O', 'HB', 26, '2042-01-31', 2),
(10008, 'L\'Obs', 'O', 'HB', 26, '2022-01-31', 5),
(10009, 'Le Monde', 'N', 'QT', 5, '2022-01-31', 5),
(10010, 'L\'Equipe Magazine', 'O', 'HB', 12, '2036-11-30', 3),
(10011, 'Geo', 'O', 'MS', 52, '2035-04-30', 2),
(10012, 'Voltaire', 'O', 'MS', 6, '2025-05-08', 10008),
(10013, 'Voltaire', 'O', 'MS', 6, '2023-05-09', 10008);

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

CREATE TABLE `service` (
  `id` int(11) NOT NULL,
  `libelle` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`id`, `libelle`) VALUES
(1, 'Administratif'),
(2, 'Prêts'),
(3, 'Culture');

-- --------------------------------------------------------

--
-- Structure de la table `statut`
--

CREATE TABLE `statut` (
  `id` int(11) NOT NULL,
  `libelle` enum('bientôt disponible','disponible') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `statut`
--

INSERT INTO `statut` (`id`, `libelle`) VALUES
(1, 'disponible'),
(2, 'bientôt disponible');

-- --------------------------------------------------------

--
-- Structure de la table `type_abonnement`
--

CREATE TABLE `type_abonnement` (
  `id` int(11) NOT NULL,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `nb_documents` int(11) NOT NULL,
  `duree_pret_weeks` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `type_abonnement`
--

INSERT INTO `type_abonnement` (`id`, `nom`, `nb_documents`, `duree_pret_weeks`) VALUES
(1, 'Junior', 20, 3),
(2, 'Jeune', 20, 3),
(3, 'Adulte', 20, 3),
(4, 'Educateur', 30, 6),
(1, 'Junior', 20, 3),
(2, 'Jeune', 20, 3),
(3, 'Adulte', 20, 3),
(4, 'Educateur', 30, 6),
(1, 'Junior', 20, 3),
(2, 'Jeune', 20, 3),
(3, 'Adulte', 20, 3),
(4, 'Educateur', 30, 6),
(1, 'Junior', 20, 3),
(2, 'Jeune', 20, 3),
(3, 'Adulte', 20, 3),
(4, 'Educateur', 30, 6),
(1, 'Junior', 20, 3),
(2, 'Jeune', 20, 3),
(3, 'Adulte', 20, 3),
(4, 'Educateur', 30, 6),
(1, 'Junior', 20, 3),
(2, 'Jeune', 20, 3),
(3, 'Adulte', 20, 3),
(4, 'Educateur', 30, 6),
(1, 'Junior', 20, 3),
(2, 'Jeune', 20, 3),
(3, 'Adulte', 20, 3),
(4, 'Educateur', 30, 6),
(1, 'Junior', 20, 3),
(2, 'Jeune', 20, 3),
(3, 'Adulte', 20, 3),
(4, 'Educateur', 30, 6);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateurs`
--

CREATE TABLE `utilisateurs` (
  `Id` int(11) NOT NULL,
  `Login` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MotDePasse` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Nom` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Prenom` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Service` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `utilisateurs`
--

INSERT INTO `utilisateurs` (`Id`, `Login`, `MotDePasse`, `Nom`, `Prenom`, `Service`) VALUES
(1, 'admin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Al-hussan', 'Matti', '1'),
(2, 'Prêts.log', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Al-hussan', 'Matti', '2'),
(3, 'Culture.log', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Al-hussan', 'Matti', '3');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `commande`
--
ALTER TABLE `commande`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_1` (`idDocument`);

--
-- Index pour la table `descripteur`
--
ALTER TABLE `descripteur`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `deterioration`
--
ALTER TABLE `deterioration`
  ADD PRIMARY KEY (`idDocument`,`numero`,`dateDeterioration`);

--
-- Index pour la table `document`
--
ALTER TABLE `document`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_1` (`idPublic`);

--
-- Index pour la table `dvd`
--
ALTER TABLE `dvd`
  ADD PRIMARY KEY (`idDocument`);

--
-- Index pour la table `emprunt`
--
ALTER TABLE `emprunt`
  ADD UNIQUE KEY `idAbonne` (`idAbonne`,`idDocument`,`numero`);

--
-- Index pour la table `est_decrit_par_2`
--
ALTER TABLE `est_decrit_par_2`
  ADD PRIMARY KEY (`idDocument`,`idDescripteur`),
  ADD KEY `id_1` (`idDescripteur`);

--
-- Index pour la table `etat`
--
ALTER TABLE `etat`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `exemplaire`
--
ALTER TABLE `exemplaire`
  ADD PRIMARY KEY (`idDocument`,`numero`),
  ADD KEY `id` (`idRayon`),
  ADD KEY `id_1` (`idEtat`);

--
-- Index pour la table `livre`
--
ALTER TABLE `livre`
  ADD PRIMARY KEY (`idDocument`);

--
-- Index pour la table `parution`
--
ALTER TABLE `parution`
  ADD PRIMARY KEY (`idRevue`,`numero`),
  ADD KEY `id` (`idEtat`);

--
-- Index pour la table `public`
--
ALTER TABLE `public`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `rayon`
--
ALTER TABLE `rayon`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `revue`
--
ALTER TABLE `revue`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_1` (`idDescripteur`);

--
-- Index pour la table `service`
--
ALTER TABLE `service`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `utilisateurs`
--
ALTER TABLE `utilisateurs`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Login` (`Login`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `utilisateurs`
--
ALTER TABLE `utilisateurs`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `commande`
--
ALTER TABLE `commande`
  ADD CONSTRAINT `commande_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`);

--
-- Contraintes pour la table `deterioration`
--
ALTER TABLE `deterioration`
  ADD CONSTRAINT `deterioration_ibfk_1` FOREIGN KEY (`idDocument`,`numero`) REFERENCES `exemplaire` (`idDocument`, `numero`);

--
-- Contraintes pour la table `document`
--
ALTER TABLE `document`
  ADD CONSTRAINT `document_ibfk_1` FOREIGN KEY (`idPublic`) REFERENCES `public` (`id`);

--
-- Contraintes pour la table `dvd`
--
ALTER TABLE `dvd`
  ADD CONSTRAINT `dvd_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`);

--
-- Contraintes pour la table `est_decrit_par_2`
--
ALTER TABLE `est_decrit_par_2`
  ADD CONSTRAINT `est_decrit_par_2_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`),
  ADD CONSTRAINT `est_decrit_par_2_ibfk_2` FOREIGN KEY (`idDescripteur`) REFERENCES `descripteur` (`id`);

--
-- Contraintes pour la table `exemplaire`
--
ALTER TABLE `exemplaire`
  ADD CONSTRAINT `exemplaire_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`),
  ADD CONSTRAINT `exemplaire_ibfk_2` FOREIGN KEY (`idRayon`) REFERENCES `rayon` (`id`),
  ADD CONSTRAINT `exemplaire_ibfk_3` FOREIGN KEY (`idEtat`) REFERENCES `etat` (`id`);

--
-- Contraintes pour la table `livre`
--
ALTER TABLE `livre`
  ADD CONSTRAINT `livre_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`);

--
-- Contraintes pour la table `parution`
--
ALTER TABLE `parution`
  ADD CONSTRAINT `parution_ibfk_1` FOREIGN KEY (`idRevue`) REFERENCES `revue` (`id`),
  ADD CONSTRAINT `parution_ibfk_2` FOREIGN KEY (`idEtat`) REFERENCES `etat` (`id`);

--
-- Contraintes pour la table `revue`
--
ALTER TABLE `revue`
  ADD CONSTRAINT `revue_ibfk_2` FOREIGN KEY (`idDescripteur`) REFERENCES `descripteur` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
