using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Interfaces.Managers;
using ToDoApp.Core.Models;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaController : Controller
    {
        private readonly IAgendaManager _agendaManager;

        public AgendaController(IAgendaManager agendaManager)
        {
            _agendaManager = agendaManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(AgendaModel[]), 200)]
        [ProducesResponseType(typeof(AgendaModel[]), 400)]
        [ProducesResponseType(typeof(AgendaModel[]), 500)]
        public async Task<IActionResult> GetItems()
        {
            var channels = await _agendaManager.GetItems();
            return Ok(channels);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(AgendaModel), 200)]
        [ProducesResponseType(typeof(AgendaModel), 400)]
        [ProducesResponseType(typeof(AgendaModel), 500)]
        public async Task<IActionResult> GetItem(string name)
        {
            var channels = await _agendaManager.GetItemByName(name);
            return Ok(channels);

        }

        [HttpPost("createList")]
        [ProducesResponseType(typeof(AgendaModel), 200)]
        [ProducesResponseType(typeof(AgendaModel), 400)]
        [ProducesResponseType(typeof(AgendaModel), 500)]
        public async Task<IActionResult> CreateList([FromBody] AgendaModel model)
        {
            var channels = await _agendaManager.CreateItem(model);
            return Ok(channels);

        }

        [HttpPost("updateList")]
        [ProducesResponseType(typeof(AgendaModel), 200)]
        [ProducesResponseType(typeof(AgendaModel), 400)]
        [ProducesResponseType(typeof(AgendaModel), 500)]
        public async Task<IActionResult> UpdateList([FromBody] AgendaModel model)
        {
            var channels = await _agendaManager.UpdateItem(model);
            return Ok(channels);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AgendaModel), 200)]
        [ProducesResponseType(typeof(AgendaModel), 400)]
        [ProducesResponseType(typeof(AgendaModel), 500)]
        public async Task<IActionResult> DeleteList(int id)
        {
            var channels = await _agendaManager.DeleteItem(id);
            return Ok(channels);

        }
    }
}