using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC5_EF6.Models;

namespace MVC5_EF6.DAL
{
    public class AccountContext : DbContext
    {
        public AccountContext()
            : base("AccountContext") 
        {
        }

        


    }
}