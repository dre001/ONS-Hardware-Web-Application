using ONS_Hardware_Web_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Contracts
{
  public interface ISupplierRepository : IRepositoryBase<Supplier>
    {
        ICollection<Supplier> GetSupplierType(int Id);
    }
}
