namespace core_library.Models
{
    public class Transaction
    {
        public int UserId { get; set; }
        public int Amount { get; set; }
        public string TransactionLocation { get; set; }
        public bool Suspecious { get; set; }
    }
}
