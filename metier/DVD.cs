using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    internal class DVD : Document
    {

        private string synopsis;
        private string realisateur;
        private int duree;


        public DVD(int unId, string unTitre, string pRealisateur, string pSynopsis,  int pDuree ,  string uneImage) : base(unId,unTitre,uneImage)
        {
            synopsis = pSynopsis;
            realisateur = pRealisateur;
            duree = pDuree;
        }

        public string Synopsis { get => synopsis; set => synopsis = value; }
        public string Realisateur { get => realisateur; set => realisateur = value; }
        public int Duree { get => duree; set => duree = value; }
    }
}
