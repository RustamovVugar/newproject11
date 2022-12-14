using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        public void Add(Department entity)
        {
            if (entity is null) throw new ArgumentNullException();
           AppDbContext<Department>.datas.Add(entity);
        }

        public void Create(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Department entity)
        {
            if (entity is null) throw new ArgumentNullException();

            AppDbContext<Department>.datas.Remove(entity);
        }

        public Department Get(Predicate<Department> predicate)
        {
            return AppDbContext<Department>.datas.Find(predicate);
        }

        public List<Department> GetAll(Predicate<Department> predicate = null)
        {
            return predicate == null ? AppDbContext<Department>.datas : AppDbContext<Department>.datas.FindAll(predicate);
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
