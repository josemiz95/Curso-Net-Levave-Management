using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            this._db = db;

        }

        public bool CheckAllocation(int leavetypeId, string employeeId)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.EmployeeId == employeeId && q.LeaveTypeId == leavetypeId && q.Period == period).Any();
        }

        public bool Create(LeaveAllocation entity)
        {
            this._db.LeaveAllocations.Add(entity);
            return this.Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            this._db.LeaveAllocations.Remove(entity);
            return this.Save();
        }

        public bool Exists(int id)
        {
            var exists = this._db.LeaveAllocations.Any(q => q.Id == id);
            return exists;
        }

        public IEnumerable<LeaveAllocation> FindAll()
        {
            var LeaveAllocations = this._db.LeaveAllocations.ToList();

            return LeaveAllocations;
        }

        public LeaveAllocation FindById(int id)
        {
            var LeaveAllocation = this._db.LeaveAllocations.Find(id);

            return LeaveAllocation;
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id, int period)
        {
            var LeaveAllocation = this.FindAll().Where(x => x.EmployeeId == id && x.Period == period).ToList();
            return LeaveAllocation;
        }

        public bool Save()
        {
            var changes = this._db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            this._db.LeaveAllocations.Update(entity);
            return this.Save();
        }
    }
}
