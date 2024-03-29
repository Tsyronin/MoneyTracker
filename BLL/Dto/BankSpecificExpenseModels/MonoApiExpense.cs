﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Dto.BankSpecificExpenseModels
{
    public class MonoApiExpense
    {
        public string Id { get; set; }
        public long Time { get; set; }
        public string Description { get; set; }
        public int Mcc { get; set; }
        public bool Hold { get; set; }
        public int Amount { get; set; }
        public int OperationAmount { get; set; }
        public int CurrencyCode { get; set; }
        public int CommissionRate { get; set; }
        public int CashbackAmount { get; set; }
        public int Balance { get; set; }
        public string Comment { get; set; }
        public string ReceiptId { get; set; }
        public string CounterEdrpou { get; set; }
        public string CounterIban { get; set; }
    }
}
