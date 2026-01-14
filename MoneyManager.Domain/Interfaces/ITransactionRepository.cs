
using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<Transaction?> GetByIdAsync(Guid id);
        Task<List<Transaction>> GetAllAsync();
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(Transaction transaction);
    }
}