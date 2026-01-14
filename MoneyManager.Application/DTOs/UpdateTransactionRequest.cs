using MoneyManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Application.DTOs
{
    public class UpdateTransactionRequest
    {
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? Notes { get; set; }
        public string? Description { get; set; }
    }
}
