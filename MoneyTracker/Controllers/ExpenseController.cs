﻿using BLL.Dto;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoneyTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IExpenseService _expenseService;

        public ExpenseController(IUserService userService, IExpenseService expenseService)
        {
            _userService = userService;
            _expenseService = expenseService;
        }

        [HttpGet("/api/Expense/notChecked")]
        [Authorize]
        public async Task<IEnumerable<ExpenseDto>> GetNotCheckedExpenses()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var notCheckedExpenses = await _expenseService.GetNotChackedExpensesAsync(userId);

            return notCheckedExpenses;
        }
    }
}
