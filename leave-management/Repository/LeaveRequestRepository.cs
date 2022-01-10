using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            this._db = db;

        }

        public bool Create(LeaveRequest entity)
        {
            this._db.LeaveRequests.Add(entity);

            return this.Save();
        }

        public bool Delete(LeaveRequest entity)
        {
            this._db.LeaveRequests.Remove(entity);

            return this.Save();
        }

        public bool Exists(int id)
        {
            var exists = this._db.LeaveRequests.Any(q => q.Id == id);
            return exists;
        }

        public IEnumerable<LeaveRequest> FindAll()
        {
            var LeaveHistories = this._db.LeaveRequests.Include(q => q.RequestingEmployee)
                                                        .Include(q => q.ApprovedBy)
                                                        .Include(q => q.LeaveType).ToList();

            return LeaveHistories;
        }

        public LeaveRequest FindById(int id)
        {
            var LeaveHistory = this._db.LeaveRequests.Include(q => q.RequestingEmployee)
                                                        .Include(q => q.ApprovedBy)
                                                        .Include(q => q.LeaveType).FirstOrDefault(q => q.Id == id);

            return LeaveHistory;
        }

        public bool Save()
        {
            var changes = this._db.SaveChanges();

            return changes > 0;
        }

        public bool Update(LeaveRequest entity)
        {
            this._db.LeaveRequests.Update(entity);

            return this.Save();
        }
    }
}
