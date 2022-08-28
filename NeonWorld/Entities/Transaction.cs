using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Entities
{
    public class Transaction
    {
        public int TransactionID { set; get; }
        public DateTime TransactionDate { set; get; }
        public string ExternalTransactionID { set; get; }
        public decimal Amount { set; get; }
        public decimal Fee { set; get; }
        public string Result { set; get; }
        public string Message { set; get; }
        public TransactionStatus Status { set; get; }
        public string Provider { set; get; }
        public Guid UserID { get; set; }
        public User User { set; get; }
    }
}
