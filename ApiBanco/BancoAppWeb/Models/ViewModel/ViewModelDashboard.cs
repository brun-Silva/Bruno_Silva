using User.Data.DTOs;

namespace BancoAppWeb.Models.ViewModel
{
    public record ViewModelDashboard
    {
        public string idUser { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public decimal income { get; set; }
        public decimal expense { get; set; }
        public decimal balance { get; set; }
        public List<DTOTransaction> LastTransac { get; set; }
        public List<DTOTransaction> timeFrameTransaction { get; set; }

    }
}
