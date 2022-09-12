using ConsoleApp1;
using Demo.SQLite;
using SQLite;

var connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Demo.db");
var connection = new SQLiteConnection(connectionString);

using (var uow = new UnitOfWork(connection))
{
    var userRepository = uow.Repository<User>();
    await userRepository.Init();

    var newUser = new User()
    {
        Id = Guid.NewGuid(),
        Name = "Adminstrator",
        Username = "admin",
        Password = "admin",
    };

    await userRepository.Add(newUser);

    var users = await userRepository.Get();
    foreach (var user in users)
    {
        Console.WriteLine(user.Id + " - " + user.Name);
    }

    await uow.Commit();
}
