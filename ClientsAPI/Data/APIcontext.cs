using Microsoft.EntityFrameworkCore;
using ClientsAPI.Models;

namespace ClientsAPI.Data
{
    public class APIcontext:DbContext
    {
        public APIcontext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}
