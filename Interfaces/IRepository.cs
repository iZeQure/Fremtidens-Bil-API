using Fremtidens_Bil_API.Objects;
using System.Collections.Generic;

namespace Fremtidens_Bil_API.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        bool Create(T user);
        void Update(T updateEntity);
        void Delete(T deleteEntity);
        T GetById(string id);
    }
}
