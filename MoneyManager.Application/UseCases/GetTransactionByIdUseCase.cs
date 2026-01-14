using MoneyManager.Domain.Interfaces;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Application.UseCases
{
    public class GetTransactionByIdUseCase
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionByIdUseCase(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Transaction> ExecuteAsync(Guid id)
        {
            var transaction = await _repository.GetByIdAsync(id);
            if (transaction == null)
                throw new Exception("Transaction not found");

            return transaction;
        }


    }
}
