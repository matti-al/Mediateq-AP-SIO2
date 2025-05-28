using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    internal class Exemplaire
    {
        public int IdDocument { get; set; } 
        public int Numero { get; set; } 
        public DateTime DateAchat { get; set; } 
        public int IdRayon { get; set; } 
        public Etat Etat { get; set; } 

        public Exemplaire(int idDocument, int numero, DateTime dateAchat, int idRayon, Etat etat)
        {
            IdDocument = idDocument;
            Numero = numero;
            DateAchat = dateAchat;
            IdRayon = idRayon;
            Etat = etat;
        }
    }
}

