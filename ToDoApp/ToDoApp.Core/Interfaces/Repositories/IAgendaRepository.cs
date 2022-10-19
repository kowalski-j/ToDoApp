using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Interfaces.Repositories
{
    public interface IAgendaRepository
    {
        Task<AgendaModel> GetItemByName(string name);
        Task<AgendaModel[]> GetItems();
        Task<AgendaModel> CreateItem(AgendaModel model);
        Task<AgendaModel> UpdateItem(AgendaModel model);
        Task<AgendaModel> DeleteItem(int agendaId);
        Task<bool> ItemExists(string agendaName);
        Task<bool> IsDuplicateItem(int agendaId, string name);
    }
}
