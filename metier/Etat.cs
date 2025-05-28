using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    internal class Etat
    {

        public int Id { get; set; } 
        public string Libelle { get; set; }

        public Etat(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }

        public override string ToString()
        {
            return Libelle; // Affiche le libellé dans le ComboBox
        }


    }
}
