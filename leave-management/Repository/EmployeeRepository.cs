using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            this._db = db;

        }

        public bool Create(Employee entity)
        {
            this._db.Employees.Add(entity);
            return this.Save();
        }

        public bool Delete(Employee entity)
        {
            this._db.Employees.Remove(entity);
            return this.Save();
        }

        public IEnumerable<Employee> FindAll()
        {
            var Employees = this._db.Employees.ToList();

            return Employees;
        }

        public Employee FindById(string id)
        {
            var Employee = this._db.Employees.Find(id);

            return Employee;
        }

        public bool Save()
        {
            var changes = this._db.SaveChanges();

            return changes > 0;
        }

        public bool Update(Employee entity)
        {
            this._db.Employees.Update(entity);
            return this.Save();
        }
    }
}
