using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Data;
using ToDoApp.Core.Interfaces.Repositories;
using ToDoApp.Core.Models;
using ToDoApp.Infrastructure.Entities;

namespace ToDoApp.Infrastructure.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private DataEntities _dbContext;

        public AgendaRepository(DataEntities dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<AgendaModel> CreateItem(AgendaModel model)
        {
            var agenda = model.Map();

            _dbContext.Agendas.Add(agenda);
            await _dbContext.SaveChangesAsync();

            return model;

        }

        public async Task<AgendaModel> DeleteItem(int agendaId)
        {
            var agenda = await _dbContext.Agendas.Where(x => x.Id == agendaId).FirstOrDefaultAsync();
            if (agenda == null)
            {
                throw new Exception("Not found");
            }

            _dbContext.Remove(agenda);
            await _dbContext.SaveChangesAsync();

            return agenda.Map();
        }

        public async Task<AgendaModel> GetItemByName(string name)
        {
            var agenda = await _dbContext.Agendas.FirstOrDefaultAsync(x => x.Name == name);

            if (agenda == null)
            {
                throw new Exception("Not found");
            }

            return agenda.Map();
        }

        public async Task<AgendaModel[]> GetItems()
        {
            var agendas = await _dbContext.Agendas.ToListAsync();

            if(agendas == null)
            {
                throw new Exception("No agenda found");
            }

            return agendas.Select(x => x.Map()).ToArray();
        }

        public async Task<bool> IsDuplicateItem(int agendaId, string name)
        {
            var agenda = await _dbContext.Agendas.Where(x => x.Name.Trim().ToUpper() == name.Trim().ToUpper()
            && x.Id != agendaId).FirstOrDefaultAsync();

            return agenda != null;
        }

        public Task<bool> ItemExists(string agendaName)
        {
            return _dbContext.Agendas.AnyAsync(x => x.Name.Equals(agendaName));
        }

        public async Task<AgendaModel> UpdateItem(AgendaModel model)
        {
            var agenda = await _dbContext.Agendas.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (agenda == null)
            {
                throw new Exception("Not found");
            }

            agenda.Name = model.Name;
            agenda.Description = model.Description;

            await _dbContext.SaveChangesAsync();
            return agenda.Map();
        }
    }

}
