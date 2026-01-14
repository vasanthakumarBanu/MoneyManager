using MoneyManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Application.UseCases
{
    public class DeleteTransactionUseCase(ITransactionRepository repository)
    {
        public async Task ExecuteAsync(Guid id)
        {
            var transaction = await repository.GetByIdAsync(id);
            _ = transaction ?? throw new InvalidOperationException("Transaction not found.");

            await repository.DeleteAsync(transaction);
        }
    }
}