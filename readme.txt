# Mediateq_AP_SIO2

## Présentation

Mediateq_AP_SIO2 est une application de gestion de médiathèque développée en C# (.NET Framework 4.7.2).  
Elle permet la gestion des utilisateurs, des services et des revues, avec une authentification sécurisée.

---

## Architecture du projet

- **metier/** : contient les classes métier (ex : `Utilisateur`, `Service`, `Revue`).
- **modele/** : contient les classes d’accès aux données (DAO).
- **Formulaires** : gèrent l’interface utilisateur (ex : `FormAuthentification`, `FrmMediateq`).

---

## Principales classes

### Utilisateur

Représente un utilisateur de l’application.


### Service

Représente un service auquel un utilisateur peut appartenir.



---

## Accès aux données (DAO)

### DAOAuthentification

- `getUtilisateurByLogin(login, mdp)` : récupère un utilisateur par login et mot de passe (hashé).
- `HashPassword(password)` : hashage SHA256 du mot de passe.
- `VerifyPassword(hashedPassword, password)` : vérifie la correspondance entre un mot de passe et son hash.
- `AuthenticateUser(login, motDePasse)` : authentifie un utilisateur.

### DAOService

- Gère l’accès aux données des services.

---

## Processus d’authentification

1. L’utilisateur saisit son login et mot de passe.
2. Le mot de passe est hashé côté application.
3. La méthode DAO vérifie la présence de l’utilisateur dans la base.
4. Si l’utilisateur existe, il est authentifié et ses informations sont récupérées.

---

## Sécurité

- Les mots de passe sont stockés et comparés sous forme de hash SHA256.
- Les requêtes SQL utilisent des paramètres pour éviter les injections SQL.

---

## Technologies

- **Langage** : C# 7.3
- **Framework** : .NET Framework 4.7.2
- **Base de données** : MySQL

---

## Bonnes pratiques

- Séparation des responsabilités (métier, DAO, interface).
- Utilisation du hash pour les mots de passe.
- Gestion des exceptions lors des accès aux données.

---

## Auteur

*À compléter selon votre équipe/projet.*

