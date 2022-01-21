using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.InterfaceRepositories
{
    public interface IRepositoryContatti: IRepository<Contatto>
    {
        public Contatto GetByID(int id);
        Contatto GetByNomeCognome(string nome, string cognome);
        public bool Delete(Contatto item);
    }
}
