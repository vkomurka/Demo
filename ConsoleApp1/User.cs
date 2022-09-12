using Demo.DAL;
using SQLite;

namespace ConsoleApp1
{
    public class User : IEntity
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
