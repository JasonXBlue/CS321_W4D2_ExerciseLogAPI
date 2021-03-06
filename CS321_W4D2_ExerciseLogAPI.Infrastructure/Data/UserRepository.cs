﻿using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User todo)
        {
            _dbContext.Users.Add(todo);
            _dbContext.SaveChanges();
            return todo;
        }

        public User Get(int id)
        {
            return _dbContext.Users
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public void Remove(User todo)
        {
            _dbContext.Users.Remove(todo);
            _dbContext.SaveChanges();
        }

        public User Update(User updatedUser)
        {
            var currentUser = _dbContext.Users.Find(updatedUser.Id);

            if (currentUser == null) return null;

            _dbContext.Entry(currentUser)
                .CurrentValues
                .SetValues(updatedUser);

            _dbContext.Users.Update(currentUser);
            _dbContext.SaveChanges();
            return currentUser;
                
        }
    }
}
