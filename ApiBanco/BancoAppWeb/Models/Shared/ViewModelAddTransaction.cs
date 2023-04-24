using User.Data.Models;

namespace BancoAppWeb.Models.Shared
{
    public class ViewModelAddTransaction
    {
        public string? userId { get; set; }
        public decimal Value { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TransactionType? Type { get; set; }
        public string Attachment { get; set; }
    }



}
