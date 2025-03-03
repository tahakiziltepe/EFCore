using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Common
{
    public static class StringConstants
    {
        public static string DbConnectionString { get; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=efcore;Integrated Security=True;";
    }
}
