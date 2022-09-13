using Demo.Desktop.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Desktop.Model
{
    public class Context : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
    }
}
