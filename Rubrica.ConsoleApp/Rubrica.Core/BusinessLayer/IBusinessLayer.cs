using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        public List<Contatto> GetAllContatti();
        public Esito AddNuovoContatto(Contatto newContatto);
        public Esito AggiungiIndirizzo(Indirizzo newIndirizzo);
        public Esito EliminaContatto(int idContatto);
    }
}
