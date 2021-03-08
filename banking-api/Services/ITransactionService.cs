using System.Collections.Generic;
using core_library.DTOs;
using core_library.Models;

namespace banking_api.Services
{
    public interface ITransactionService
    {
        // todo: make methods async
        public IReadOnlyCollection<Transaction> GetAllTransactions();
        public Transaction GetTransaction( int id );
        public Transaction AddTransaction( Transaction transaction );
        public IReadOnlyCollection<TransactionDto> GetValidOrSuspicious( bool valid = true );
    }
}
