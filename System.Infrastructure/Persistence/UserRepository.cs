using System.Application.Common.Interfaces.Persistence;
using System.Domain.Entities;

namespace System.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> users = new();

    public User AddUser(User user)
    {
        users.Add(user);
        return user;
    }

    public User? GetUserByUserName(string userName)
    {
        return users.SingleOrDefault(u => u.UserName.Equals(userName));
    }
}