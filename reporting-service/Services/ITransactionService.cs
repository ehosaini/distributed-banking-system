using System.Collections.Generic;
using core_library.Models;

namespace reporting_service.Services
{
    public interface ITransactionService
    {
        // todo: make methods async
        public IReadOnlyCollection<Transaction> GetAllTransactions();
        public Transaction GetTransaction( int id );
        public Transaction AddTransaction( Transaction transaction );
        public IReadOnlyCollection<Transaction> FilterTransactions( bool valid = true );
    }
}
