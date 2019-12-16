using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fremtidens_Bil_API
{
    public abstract class BaseEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
