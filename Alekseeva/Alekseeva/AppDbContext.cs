using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alekseeva.Models;
using Microsoft.EntityFrameworkCore;

namespace Alekseeva
{
    public class AppDbContext : DbContext
    {
        // Это свойство должно быть public
        public DbSet<User> User { get; set; }

        // Конфигурация подключения к базе данных через строку подключения
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AlekseevaKA;Trusted_Connection=True;");
        }
    }
}

