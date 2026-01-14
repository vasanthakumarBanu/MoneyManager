using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.DTOs;
using MoneyManager.Application.UseCases;

namespace MoneyManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly AddTransactionUseCase _addTransactionUseCase;
        private readonly GetAllTransactionsUseCase _getAllTransactionsUseCase;
        private readonly GetTransactionByIdUseCase _getTransactionByIdUseCase;
        private readonly UpdateTransactionUseCase _updateTransactionUseCase;
        private readonly DeleteTransactionUseCase _deleteTransactionUseCase;

        public TransactionController(
            AddTransactionUseCase addTransactionUseCase,
            GetAllTransactionsUseCase getAllTransactionsUseCase,
            GetTransactionByIdUseCase getTransactionByIdUseCase,
            UpdateTransactionUseCase updateTransactionUseCase,
            DeleteTransactionUseCase deleteTransactionUseCase)
        {
            _addTransactionUseCase = addTransactionUseCase;
            _getAllTransactionsUseCase = getAllTransactionsUseCase;
            _getTransactionByIdUseCase = getTransactionByIdUseCase;
            _updateTransactionUseCase = updateTransactionUseCase;
            _deleteTransactionUseCase = deleteTransactionUseCase;
        }

        // POST: api/transaction
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] AddTransactionRequest request)
        {
            if (request == null)
                return BadRequest("Invalid transaction data");

            await _addTransactionUseCase.ExecuteAsync(request);
            return Ok(new { message = "Transaction added successfully" });
        }

        // GET: api/transaction
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _getAllTransactionsUseCase.ExecuteAsync();
            return Ok(transactions);
        }

        // GET: api/transaction/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            var transaction = await _getTransactionByIdUseCase.ExecuteAsync(id);

            if (transaction == null)
                return NotFound("Transaction not found");

            return Ok(transaction);
        }

        // PUT: api/transaction/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(
            Guid id,
            [FromBody] UpdateTransactionRequest request)
        {
            if (request == null)
                return BadRequest("Invalid data");

            await _updateTransactionUseCase.ExecuteAsync(id, request);
            return Ok(new { message = "Transaction updated successfully" });
        }

        // DELETE: api/transaction/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            await _deleteTransactionUseCase.ExecuteAsync(id);
            return Ok(new { message = "Transaction deleted successfully" });
        }
    }
}
