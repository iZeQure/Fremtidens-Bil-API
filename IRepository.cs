using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fremtidens_Bil_API
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T t);
        void Update(T t);
        void Delete(T t);
        T GetById(int id);
        List<T> GetAll();
    }
}
