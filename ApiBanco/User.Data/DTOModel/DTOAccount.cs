using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.DTOs;

namespace User.Data.DTOModel
{
    public class DTOAccount : DTOBase
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
    }
}
