using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using banking_api.Models;

namespace banking_api.Services
{
    // todo: address error handling e.g. global exception handler
    class TransactionService : ITransactionService
    {
        private readonly IList<Transaction> _transactions;
        private readonly IList<User>_users;

        public TransactionService()
        {
            _transactions = LoadTransactions();
            _users = LoadUsers();
        }

        public IReadOnlyCollection<Transaction> GetAll()
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
                    TransactionLocation = "Mexico"
                },
                new Transaction
                {
                    UserId = 4,
                    Amount = 10,
                    TransactionLocation = "USA"
                }
            };
        }

        private IList<User> LoadUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Country = "USA"
                },
                new User
                {
                    Id = 2,
                    Country = "Canada"
                },
                new User
                {
                    Id = 1,
                    Country = "Mexico"
                },
                new User
                {
                    Id = 1,
                    Country = "USA"
                }
            };
        }
    }
}
