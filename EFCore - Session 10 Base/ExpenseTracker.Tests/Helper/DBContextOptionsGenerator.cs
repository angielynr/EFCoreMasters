using ExpenseTracker.API.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Tests.Helper
{
    public static class DBContextOptionsGenerator
    {
        public static DbContextOptions<T> CreateUniqueClassOptions<T>(string callingClass) where T : DbContext
        {
            DbContextOptionsBuilder<T> dbContextOptionsBuilder = new DbContextOptionsBuilder<T>();
            dbContextOptionsBuilder.UseSqlServer(String.Format(GetTestCustomConnectionString(), callingClass));

            return dbContextOptionsBuilder.Options;
        }

        private static string GetTestCustomConnectionString()
        {
            var apiAssembly = typeof(CategoryController).Assembly;
            var directory = Path.GetDirectoryName(apiAssembly.Location);

            var config = new ConfigurationBuilder().SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();
            return config.GetConnectionString("ExpenseTrackerTestDB");

        }
    }
}
