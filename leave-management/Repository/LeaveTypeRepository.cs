using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public bool Create(LeaveType entity)
        {
            this._db.LeaveTypes.Add(entity);

            return this.Save();
        }

        public bool Delete(LeaveType entity)
        {
            this._db.LeaveTypes.Remove(entity);

            return this.Save();
        }

        public bool Exists(int id)
        {
            var exists = this._db.LeaveTypes.Any(q => q.Id == id);
            return exists;
        }

        public IEnumerable<LeaveType> FindAll()
        {
            var LeaveTypes = this._db.LeaveTypes.ToList();
            return LeaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var LeaveType = this._db.LeaveTypes.Find(id);
            return LeaveType;
        }

        public IEnumerable<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = this._db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveType entity)
        {
            this._db.LeaveTypes.Update(entity);

            return this.Save();
        }
    }
}
