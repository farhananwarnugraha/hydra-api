using System;
using HydraAPI.Interfaces;
using HydraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HydraAPI.Repository;

public class UserRepository : IUserRepository
{
    private readonly HydraContext _dbContext;

    public UserRepository(HydraContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<User> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public User GetByUsername(string username)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Username == username)?? throw new Exception("User Not Found");
    }

    public User GetRoleName(string username)
    {
        return _dbContext.Users
        .Include(u => u.Roles)
        .FirstOrDefault(u => u.Username == username)?? throw new Exception("User Not Found");
    }

    public void Register(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
        _dbContext.SaveChanges();
    }
}
