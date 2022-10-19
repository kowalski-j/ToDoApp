using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Interfaces.Managers;
using ToDoApp.Core.Interfaces.Repositories;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Managers
{
    public class AgendaManager : IAgendaManager
    {
        private readonly IAgendaRepository _agendaRepo;
        public AgendaManager(IAgendaRepository agendaRepo)
        {
            _agendaRepo = agendaRepo;
        }

        public async Task<AgendaModel> CreateItem(AgendaModel model)
        {
            if (await _agendaRepo.IsDuplicateItem(model.Id, model.Name))
                throw new Exception("Item already exists");

            return await _agendaRepo.CreateItem(model);

        }

        public async Task<AgendaModel> DeleteItem(int agendaId)
        {
            return await _agendaRepo.DeleteItem(agendaId);
        }

        public async Task<AgendaModel> GetItemByName(string name)
        {
            return await _agendaRepo.GetItemByName(name);
        }

        public async Task<AgendaModel[]> GetItems()
        {
            return await _agendaRepo.GetItems();
        }

        public async Task<AgendaModel> UpdateItem(AgendaModel model)
        {
            if (!await _agendaRepo.ItemExists(model.Name))
                throw new Exception("Item does not exist");

            return await _agendaRepo.UpdateItem(model);
        }
    }

}
