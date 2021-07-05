using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaAssist2._0.Repository
{
    interface IRepository<T> where T : class
    {
        List<T> GetAll();

        T Get(int Id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(int Id);
    }
}
