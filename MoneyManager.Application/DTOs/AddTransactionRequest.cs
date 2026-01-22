using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Domain.Enum;

namespace MoneyManager.Application.DTOs
{
    public class AddTransactionRequest
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }

    }
}
