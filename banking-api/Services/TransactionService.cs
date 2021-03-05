using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using banking_api.Models;

namespace banking_api.Services
{
    // todo: address error handling e.g. global exception handler
    class TransactionService : ITransactionService
    {
        private readonly IList<Transaction> _transactions;
        private readonly IList<User> _users;

        public TransactionService()
        {
            _transactions = LoadTransactions();
            _users = LoadUsers();
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

        public IReadOnlyCollection<Transaction> GetValidOrSuspicious( bool valid = true )
        {
            var transactions = _transactions.Where( t =>
            {
                var any = _users.Any( u => u.Id == t.UserId && u.Country == t.TransactionLocation );

                return valid ? any : !any;
            } );

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
                    TransactionLocation = "Mexico"
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
                    TransactionLocation = "USA"
                },
                new Transaction
                {
                    UserId = 16,
                    Amount = 10,
                    TransactionLocation = "Mexico"
                }
            };
        }

        private static IList<User> LoadUsers()
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
                    Id = 3,
                    Country = "Mexico"
                }
            };
        }
    }
}
