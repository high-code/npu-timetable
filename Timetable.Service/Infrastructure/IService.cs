using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;
namespace Timetable.Service.Infrastructure
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        int Count
        {
            get;
        }

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        void Save();
    }
}
