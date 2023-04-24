using User.Data.DTOs;

namespace BancoAppWeb.Models.ViewModel
{
    public class ViewModelTrasaction
    {
        public List<DTOTransaction> Transactions { get; set; }
        public string UID { get; set; }
        public ViewModelTrasaction(List<DTOTransaction> transactions)
        {
            Transactions = transactions;
        }

        public ViewModelTrasaction(List<DTOTransaction> transactions, string uid)
        {
            Transactions = transactions;
            UID = uid;
        }
    }
}
