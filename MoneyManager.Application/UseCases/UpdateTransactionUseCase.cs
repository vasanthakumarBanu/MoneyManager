using MoneyManager.Application.DTOs;
using MoneyManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Application.UseCases
{
    public class UpdateTransactionUseCase
    {
        private readonly ITransactionRepository _repository;

        public UpdateTransactionUseCase(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Guid id, UpdateTransactionRequest request)
        {
            var transaction = await _repository.GetByIdAsync(id);
            if (transaction == null)
                throw new Exception("Transaction not found");

            transaction.Amount = request.Amount;
            transaction.Category = request.Category;
            transaction.Date = request.Date;
            transaction.TransactionType = request.TransactionType;
            transaction.Notes = request.Notes;
            transaction.Description = request.Description;

            await _repository.UpdateAsync(transaction);
        }
    }

}
