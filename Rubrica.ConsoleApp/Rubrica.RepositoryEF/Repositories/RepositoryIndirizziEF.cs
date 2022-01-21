using Microsoft.EntityFrameworkCore;
using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryEF.Repositories
{
    public class RepositoryIndirizziEF : IRepositoryIndirizzi
    {
        private readonly RubricaContext ctx;

        public RepositoryIndirizziEF()
        {
            ctx = new RubricaContext();
        }

        public Indirizzo Add(Indirizzo item)
        {
            ctx.Indirizzi.Add(item);
            ctx.SaveChanges();
            return item;
        }
       
         public IList<Indirizzo> GetAll()
        {
            return ctx.Indirizzi.Include(y=>y.Contatto).ToList();
        }

        public List<Indirizzo> GetIndirizzoByContattoID(int idContatto)
        {
            return ctx.Indirizzi.Include(y=>y.Contatto).Where(y=>y.ContattoID == idContatto).ToList();  
        }
    }
}
