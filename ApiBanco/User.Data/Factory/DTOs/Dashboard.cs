using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.Interface;
using User.Data.Repository;

namespace User.Data.Factory.DTOs
{
    public class Dashboard
    {
        private ITransaction transaction = (ITransaction)new TransactionRepository();
        private IUser users = (IUser)new UsersRepository();












    }
}
