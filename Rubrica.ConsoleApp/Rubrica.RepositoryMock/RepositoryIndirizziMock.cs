using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMock
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzi
    {
        public static List<Indirizzo> Indirizzi = new List<Indirizzo>()
        {
            new Indirizzo {IndirizzoID = 1, Tipologia="Residenza", Citta="Milano", Cap=00123, Via ="Roma 3",
            Nazione="Italia", ContattoID=1 }
        };
        public Indirizzo Add(Indirizzo item)
        {
            if (Indirizzi.Count() == 0)
            {
                item.IndirizzoID = 1;
            }
            else
            {
                item.IndirizzoID = Indirizzi.Max(c => c.ContattoID) + 1;
            }
           Indirizzi.Add(item);
            return item;
        }
            
        public IList<Indirizzo> GetAll()
        {
            return Indirizzi.ToList();
        }

        public List<Indirizzo> GetIndirizzoByContattoID(int idContatto)
        {
            return GetAll().Where(i => i.ContattoID == idContatto).ToList();
        }
    }
}
