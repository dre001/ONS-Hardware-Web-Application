using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Contracts
{
    public interface IRepositoryBase <T> where T : class
    {
        ICollection<T> FindAll();
        T FindById(int Id);
        bool isExists(int Id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
