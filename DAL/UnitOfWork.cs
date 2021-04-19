using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Context to use.
        /// </summary>
        private readonly AppDbContext _context;
        private IBankAccountRepository _bankAccountRepository;

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="context">Context to use.</param>
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IBankAccountRepository BankAccountRepository
        {
            get
            {
                if (_bankAccountRepository is null)
                    _bankAccountRepository = new BankAccountRepository(_context);
                return _bankAccountRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
