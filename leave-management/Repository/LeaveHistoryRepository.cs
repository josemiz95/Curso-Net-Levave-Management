using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            this._db = db;

        }

        public bool Create(LeaveHistory entity)
        {
            this._db.LeaveHistories.Add(entity);

            return this.Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            this._db.LeaveHistories.Remove(entity);

            return this.Save();
        }

        public bool Exists(int id)
        {
            var exists = this._db.LeaveHistories.Any(q => q.Id == id);
            return exists;
        }

        public IEnumerable<LeaveHistory> FindAll()
        {
            var LeaveHistories = this._db.LeaveHistories.ToList();

            return LeaveHistories;
        }

        public LeaveHistory FindById(int id)
        {
            var LeaveHistory = this._db.LeaveHistories.Find(id);

            return LeaveHistory;
        }

        public bool Save()
        {
            var changes = this._db.SaveChanges();

            return changes > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            this._db.LeaveHistories.Update(entity);

            return this.Save();
        }
    }
}
