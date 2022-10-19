using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Interfaces.Managers
{
    public interface IAgendaManager
    {
        Task<AgendaModel> GetItemByName(string name);
        Task<AgendaModel[]> GetItems();
        Task<AgendaModel> CreateItem(AgendaModel model);
        Task<AgendaModel> UpdateItem(AgendaModel model);
        Task<AgendaModel> DeleteItem(int agendaId);
    }
}
