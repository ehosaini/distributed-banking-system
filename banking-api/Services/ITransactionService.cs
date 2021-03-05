using System.Collections.Generic;
using banking_api.Models;

namespace banking_api.Services
{
    public interface ITransactionService
    {
        // todo: make methods async
        public IReadOnlyCollection<Transaction> GetAllTransactions();
        public Transaction GetTransaction( int id );
        public Transaction AddTransaction( Transaction transaction );
        public IReadOnlyCollection<Transaction> GetValidOrSuspicious( bool valid = true );
    }
}
