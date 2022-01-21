﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.Entities
{
    public class Indirizzo
    {
        public int IndirizzoID { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Citta { get; set; }
        public int Cap { get; set; }
        public string Nazione { get; set; }

        public int ContattoID { get; set; }
        public Contatto Contatto { get; set; }

        public override string ToString()
        {
            return $"{IndirizzoID} - {Tipologia} : {Citta}, {Via}, {Cap}, {Nazione}";
        }

    }
}
