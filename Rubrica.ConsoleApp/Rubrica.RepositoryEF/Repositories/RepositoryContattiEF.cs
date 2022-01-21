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
    public class RepositoryContattiEF : IRepositoryContatti
    {
        private readonly RubricaContext ctx;

        public RepositoryContattiEF()
        {
            ctx = new RubricaContext();
        }
        public Contatto Add(Contatto item)
        {
           ctx.Contatti.Add(item);
            ctx.SaveChanges();
            return item;
        }

        public bool Delete(Contatto item)
        {
          ctx.Contatti.Remove(item);
            ctx.SaveChanges();
            return true;    
        }

        public IList<Contatto> GetAll()
        {
          return ctx.Contatti.Include(y=>y.Indirizzi).ToList();
        }

        public Contatto GetByID(int id)
        {
            return ctx.Contatti.Include(y=>y.Indirizzi).FirstOrDefault(y=>y.ContattoID == id);
        }

        public Contatto GetByNomeCognome(string nome, string cognome)
        {
            return ctx.Contatti.Include(y => y.Indirizzi).FirstOrDefault(y => y.Nome==nome && y.Cognome==cognome);
        }
    }
}
