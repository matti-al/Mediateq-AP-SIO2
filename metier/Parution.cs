using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
   public class Parution
    {
        private int numero;
        private DateTime dateParution;
        private string photo;
        private Revue laRevue;

        public Parution(int numero, DateTime dateParution, string photo, Revue uneRevue)
        {
            this.numero = numero;
            this.dateParution = dateParution;
            this.photo = photo;
            this.laRevue = uneRevue;
        }

        public int Numero { get => numero; set => numero = value; }
        public DateTime DateParution { get => dateParution; set => dateParution = value; }
        public string Photo { get => photo; set => photo = value; }
        public Revue LaRevue { get => laRevue; set => laRevue = value; }
    }
}
