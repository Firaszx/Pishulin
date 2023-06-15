using System.Runtime.InteropServices;
using Organization.Models;
namespace Organization.Models.Data
{
    public static class DBInit
    {
        public static void Initialize(MySuperOrgContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
