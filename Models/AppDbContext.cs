// File: AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ToDoApplication.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
