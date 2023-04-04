﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace User.Data.Models
{

    // user model 
    public class Users
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public decimal Incomes { get; set; }
        public decimal Expense { get; set; }


    }
}