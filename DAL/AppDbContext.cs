﻿using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {   }

        public virtual DbSet<UserBankAccount> UserBankAccounts { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
