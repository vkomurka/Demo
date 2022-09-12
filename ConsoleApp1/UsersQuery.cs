using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.SQLite;

namespace ConsoleApp1
{
    //public class UsersQuery : QueryBase<UserDto>
    //{
    //    public Guid? Id { get; set; }

    //    protected override IQueryable<UserDto> GetRecords()
    //    {
    //        return
    //            from user in Connection.Table<User>()
    //            where Id == null || user.Id == Id
    //            select new UserDto()
    //            {
    //                Id = user.Id,
    //                Name = user.Name,
    //                Username = user.Username,
    //            };
    //    }
    //}
}
