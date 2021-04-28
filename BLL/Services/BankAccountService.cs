using AutoMapper;
using BLL.Dto;
using BLL.Exceptions;
using BLL.Helpers;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BankAccountService : IBankAccountService
    {
        readonly IUnitOfWork _dataBase;
        private readonly UserManager<AppUser> _userManager;
        readonly MonoHelper _monoHelper;
        readonly IMapper _mapper;


        public BankAccountService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, MonoHelper monoHelper, IMapper mapper)
        {
            _dataBase = unitOfWork;
            _userManager = userManager;
            _monoHelper = monoHelper;
            _monoHelper.InitializeClient();
            _mapper = mapper;
        }


        public async Task AddBankAccountAsync(BankAccountDto account)
        {
            switch (account.Bank)
            {
                case "Mono":
                    if (await _monoHelper.GetRecentExpensesAsync(account.Token, null) == null)
                        throw new ModelException("Invalid Bank Account");
                    break;
                default:
                    throw new ModelException("Invalid Bank Name");
            }
            await _dataBase.BankAccountRepository.AddAsync(_mapper.Map<BankAccountDto, UserBankAccount>(account));
            await _dataBase.SaveAsync();
        }
    }
}
