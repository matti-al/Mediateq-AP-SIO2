using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    internal class DVD : Document
    {

        public string Synopsis { get; set; }
        public string Realisateur { get; set; }
        public int Duree { get; set; }


        public DVD(int unId, string unTitre, string pRealisateur, string pSynopsis,  int pDuree ,  string uneImage) : base(unId,unTitre,uneImage)
        {
            Synopsis = pSynopsis;
            Realisateur = pRealisateur;
            Duree = pDuree;
        }

       

    }
}
