using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.EntityFrameworkCore.Entities;

namespace UsersApp.EntityFrameworkCore
{
    public class AppContext : DbContext
    {
        private readonly StreamWriter logStream = new StreamWriter("mylog.txt", true);

        DbSet<User> Users { get; set; }
        public AppContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=s-dev-01; Database=RegBD; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logStream.DisposeAsync();
        }
    }
}
