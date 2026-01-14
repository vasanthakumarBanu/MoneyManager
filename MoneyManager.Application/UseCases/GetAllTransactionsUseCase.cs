using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Application.UseCases
{
    public class GetAllTransactionsUseCase
    {
        private readonly ITransactionRepository _repository;

        public GetAllTransactionsUseCase(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Transaction>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

}
