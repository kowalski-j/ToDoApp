using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Infrastructure.Entities;

namespace ToDoApp.Api.Data
{
    public class DataEntities : DbContext
    {
        public DataEntities(DbContextOptions<DataEntities> options) : base(options)
        {

        }

        public DbSet<Agenda> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
