using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using User.Data.Models;

namespace User.Data.DTOs
{
    public class DTODashboard
    {
        public string idUser { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public decimal income { get; set; }
        public decimal expense { get; set; }
        public decimal balance  { get; set; }
        public List<DTOTransaction> LastTransac { get; set; }
        public List<DTOTransaction> timeFrameTransaction { get; set; }

    }


}
