using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
