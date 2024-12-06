using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    class ExceptionSIO : Exception
    {
        private int niveauExc;
        private string libelleExc;
        public ExceptionSIO(int pNiveau, string pLibelle, string pMessage) : base(pMessage)
        {
            niveauExc = pNiveau;
            libelleExc = pLibelle;
        }


        public int NiveauExc { get; set; }
        public string LibelleExc { get; set; }

    }
}
