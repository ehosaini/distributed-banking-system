using System;
using System.Net.Http;
using System.Threading.Tasks;
using core_library.DTOs;

namespace banking_api.Services
{
    public interface ITransactionBroadcaster
    {
        // todo: make methods async
        public Task<HttpResponseMessage> BroadcastTransaction( TransactionDto transactionDto, Uri url );
    }
}
