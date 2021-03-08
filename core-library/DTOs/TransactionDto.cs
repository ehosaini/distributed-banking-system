namespace core_library.DTOs
{
    public class TransactionDto
    {
        public int UserId { get; set; }
        public int Amount { get; set; }
        public string TransactionLocation { get; set; }
        public bool Suspecious { get; set; }
    }
}
