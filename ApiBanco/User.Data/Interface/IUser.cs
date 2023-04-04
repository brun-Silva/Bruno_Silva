using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.Models;

namespace User.Data.Interface
{
   public interface IUser
    {
        Users GetUserByID(string id);
        //Users UpdateUserByID(string id, decimal balance, decimal income, decimal expense);

    }
}
