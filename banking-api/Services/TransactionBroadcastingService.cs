using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using core_library.DTOs;
using core_library.Models;

namespace banking_api.Services
{
    // todo: address error handling e.g. global exception handler
    class TransactionBroadcastingService : ITransactionBroadcaster
    {
        private readonly IList<User> _users;

        // Todo: if httpClient is needed in multiple services, wrap the functinality of the client 
        // into a service and use it and use it as a signleton to not exhaust socket pool. See Microsoft Doc
        // for more info
        private static readonly HttpClient _httpClient;

        static TransactionBroadcastingService()
        {
            _httpClient = new HttpClient();
        }
        public TransactionBroadcastingService()
        {
            _users = LoadUsers();
        }

        public async Task<HttpResponseMessage> BroadcastTransaction( TransactionDto transaction, Uri uri )
        {
            var tagged = TagTransaction( transaction );

            return await _httpClient.PostAsJsonAsync(uri, tagged );
        }

        public Transaction TagTransaction( TransactionDto transactionDto )
        {
            return new Transaction
            {
                UserId = transactionDto.UserId,
                Amount = transactionDto.Amount,
                TransactionLocation = transactionDto.TransactionLocation,
                Suspecious = !_users.Any( u => u.Id == transactionDto.UserId && u.Country == transactionDto.TransactionLocation )
            };
        }

        // Todo: make this a dictionary
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
