using User.Data.DTOs;

namespace BancoAppWeb.Models.Shared
{
    public class ViewModelEditTransaction
    {
            public int Id { get; set; }
            public string userId { get; set; }
            public decimal Value { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Attachment { get; set; }
        
    }
}
