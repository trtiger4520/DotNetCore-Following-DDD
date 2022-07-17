using System.Domain.Entities;

namespace System.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByUserName(string userName);
    User AddUser(User user);
}