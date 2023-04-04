using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.Models;
using User.Data.Interface;

namespace User.Data.Repository
{
    public class UsersRepository : IUser
    {

        List<Users> lisUsers = new List<Users>
        {
            new Users{UserId="bruno@",Balance=0.0m,FirstName ="Bruno",LastName="Silva",Incomes=0.0m,Expense=.0m}
        };


        //Func to search user in the list "lisUsers"
        public Users GetUserByID(string id)
        {
            return lisUsers.FirstOrDefault(x => x.UserId == id);
        }

        //public Users UpdateUserByID(string id, decimal balance, decimal income, decimal expense)
        //{
        //    var user = GetUserByID(id);


        //    return user;
        //}


    }
}
