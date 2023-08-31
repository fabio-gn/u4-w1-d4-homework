using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_mattina
{
    internal class Prodotto : IMenuItem
    {
        public string nomeArticolo { get; set; }
        public double prezzo { get; set; }

        public Prodotto(string nome, double prezzo)
        {
            this.nomeArticolo = nome;
            this.prezzo = prezzo;
        }


    }
}
