
using MoneyManager.Domain.Enum;

namespace MoneyManager.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

        public string Category { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public TransactionType TransactionType { get; set; }

        public string? Description { get; set; }

        public string? Note { get; set; }
    }
}
