namespace banking_api.Models
{
    public class Transaction
    {
        public int UserId { get; set; }
        public int Amount { get; set; }
        public string TransactionLocation { get; set; }
    }
}
