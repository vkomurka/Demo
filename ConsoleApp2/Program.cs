using ConsoleApp2;
using Demo.EntityFramework;
using Microsoft.EntityFrameworkCore;

var connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Demo2.db");

var context = new Context();
context.Database.SetConnectionString(connectionString);

using (var uow = new UnitOfWork(context))
{
    var users = await uow.Repository<User>().Get();
}
