using AutoMapper;
using BLL.Dto;
using BLL.Helpers;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ExpenseService : IExpenseService
    {
        readonly IUnitOfWork _dataBase;
        private readonly UserManager<AppUser> _userManager;
        readonly MonoHelper _monoHelper;
        readonly IMapper _mapper;


        public ExpenseService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, MonoHelper monoHelper, IMapper mapper)
        {
            _dataBase = unitOfWork;
            _userManager = userManager;
            _monoHelper = monoHelper;
            _monoHelper.InitializeClient();
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExpenseDto>> GetNotChackedExpensesAsync(string userId)
        {
            var userBankAccounts = _dataBase.BankAccountRepository.GetUserBankAccounts(userId);
            var checkedExpenses = _dataBase.ExpenseRepository.GetRecentExpenses(userId).ToList();
            var expenses = new List<ExpenseDto>();
            if (userBankAccounts.SingleOrDefault(uba => uba.Bank == "Mono") != null)
            {
                var monoAccount = userBankAccounts.First(uba => uba.Bank == "Mono");
                var monoApiExpenses = await _monoHelper.GetRecentExpensesAsync(monoAccount.Token, null);
                var monoExpenses = _mapper.Map<IEnumerable<MonoApiExpense>, IEnumerable<ExpenseDto>>(monoApiExpenses);
                var chechedMonoExpensesIds = checkedExpenses.Where(ce => ce.UserBankAccountId == monoAccount.Id).Select(ce => ce.BankExpenseId).ToList();
                var notCkeckedMonoExpenses = monoExpenses.Where(me => !chechedMonoExpensesIds.Contains(me.BankExpenseId));
                expenses.AddRange(notCkeckedMonoExpenses);
            }
            //TODO: Add new bank logic here

            return expenses;
        }
    }
}
