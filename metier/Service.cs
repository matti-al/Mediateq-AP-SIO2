using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    internal class Service
    {
        private int id;
        private string libelle;

        public Service(int id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }
    }
}
