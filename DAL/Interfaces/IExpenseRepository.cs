using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        /// <summary>
        /// Get Recorded user expenses of last 30 days.
        /// </summary>
        /// <param name="iserId"></param>
        /// <returns></returns>
        IQueryable<Expense> GetRecentExpenses(string userId);
    }
}
