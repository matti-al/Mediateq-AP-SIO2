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

        public int Numero { get; set; }
        public DateTime DateParution { get; set; }
        public string Photo { get; set; }
        public Revue LaRevue { get; set; }
    }
}
