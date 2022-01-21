using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.InterfaceRepositories
{
    public interface IRepository<T>
    {
        public IList<T> GetAll();
        public T Add(T item);
       

    }
}
