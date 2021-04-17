using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using core_library.Models;

namespace reporting_service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IList<Transaction> _transactions;

        public TransactionService()
        {
            _transactions = LoadTransactions();
        }

        public IReadOnlyCollection<Transaction> GetAllTransactions()
        {
            return new ReadOnlyCollection<Transaction>( _transactions );
        }

        public Transaction GetTransaction( int id )
        {
            throw new NotImplementedException();
        }

        public Transaction AddTransaction( Transaction transaction )
        {
            _transactions.Add( transaction );

            return transaction;
        }

        public IReadOnlyCollection<Transaction> FilterTransactions( bool valid = true )
        {
            IEnumerable<Transaction> transactions;

            if( valid )
            {
                transactions = _transactions.Where( t => !t.Suspecious );
            }
            else
            {
                transactions = _transactions.Where( t => t.Suspecious );
            }

            return new ReadOnlyCollection<Transaction>( transactions.ToList() );
        }

        private static IList<Transaction> LoadTransactions()
        {

            return new List<Transaction>
            {
                new Transaction
                {
                    UserId = 1,
                    Amount = 10,
                    TransactionLocation = "USA"
                },
                new Transaction
                {
                    UserId = 2,
                    Amount = 12,
                    TransactionLocation = "Canada"
                },
                new Transaction
                {
                    UserId = 3,
                    Amount = 12,
                    TransactionLocation = "Mexico",
                    Suspecious = true

                },
                new Transaction
                {
                    UserId = 4,
                    Amount = 10,
                    TransactionLocation = "USA"
                },
                new Transaction
                {
                    UserId = 6,
                    Amount = 10,
                    TransactionLocation = "USA",
                    Suspecious = true
                },
                new Transaction
                {
                    UserId = 16,
                    Amount = 10,
                    TransactionLocation = "Mexico",
                    Suspecious = true
                }
            };
        }
    }
}
