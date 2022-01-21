using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMock
{
    public class RepositoryContattiMock : IRepositoryContatti
    {
        public static List<Contatto> Contatti = new List<Contatto>()
        {
            new Contatto {ContattoID=1,Nome="Mario", Cognome="Rossi"},
            new Contatto {ContattoID=2,Nome="Giada", Cognome="Pantalone"}
        };
        public Contatto Add(Contatto item)
        {
            if (Contatti.Count() == 0)
            {
                item.ContattoID = 1;
            }
            else
            {
                item.ContattoID=Contatti.Max(c =>c.ContattoID)+1;
            }
            Contatti.Add(item);
            return item;
        }

        public bool Delete(Contatto item)
        {
            Contatti.Remove(item);
            return true;
        }

        public IList<Contatto> GetAll()
        {
           return Contatti.ToList();
        }

        public Contatto GetByID(int id)
        {
           return GetAll().FirstOrDefault(c =>c.ContattoID == id);  
        }

        public Contatto GetByNomeCognome(string nome, string cognome)
        {
            return GetAll().FirstOrDefault(c=>c.Nome==nome && c.Cognome==cognome);  
        }
    }
}
