using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime DateTransaction { get; set; }
        public string Attachment { get; set; }
        public string fkUserID { get; set; }
    }
}
