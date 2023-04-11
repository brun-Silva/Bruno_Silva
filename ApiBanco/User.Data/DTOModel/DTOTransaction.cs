using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.Models;

namespace User.Data.DTOs
{
    public class DTOTransaction
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TransactionType? Type { get; set; }
        public DateTime DateTransaction { get; set; }
        public string Attachment { get; set; }
        public string fkUserID { get; set; }
    }
}
