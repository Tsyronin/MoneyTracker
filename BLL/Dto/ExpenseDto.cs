using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Dto
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public int UserBankAccountId { get; set; }
        public string BankExpenseId { get; set; }
        public DateTime Time { get; set; }
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
