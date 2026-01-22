using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Application.DTOs;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Interfaces;

namespace MoneyManager.Application.UseCases
{
    public class AddTransactionUseCase
    {
        private readonly ITransactionRepository _repository;

        public AddTransactionUseCase(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(AddTransactionRequest request)
        {
            if (request.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Amount = request.Amount,
                Category = request.Category,
                Date = request.Date,
                TransactionType = request.TransactionType,
                Note = request.Note,
                Description = request.Description
            };

            await _repository.AddAsync(transaction);
        }
    }
}
