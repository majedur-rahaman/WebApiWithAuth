using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApiWithAuth.Models
{
    public class AuthContext: IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            :base("AuthContext")
        {
            
        }

        //public DbSet<Client> Clients { get; set; }
        //public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}