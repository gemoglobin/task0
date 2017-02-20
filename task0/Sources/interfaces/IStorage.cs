using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task0.Sources.interfaces
{
    public interface IStorage<T> where T : class
    {
        IEnumerable<T> GetAll();
        
        void Save();
    }
}
