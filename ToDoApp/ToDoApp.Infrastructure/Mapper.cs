using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Models;
using ToDoApp.Infrastructure.Entities;

namespace ToDoApp.Infrastructure
{
    public static class Mapper
    {
        public static AgendaModel Map(this Agenda entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new AgendaModel
            {
                Id = entity.Id,
                CreatedOn = entity.CreatedOn,
                Description = entity.Description,
                Name = entity.Name
            };
        }

        public static Agenda Map(this AgendaModel entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Agenda
            {
                Id = entity.Id,
                CreatedOn = entity.CreatedOn,
                Description = entity.Description,
                Name = entity.Name
            };
        }
    }

}
