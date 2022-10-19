using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Interfaces.Managers;
using ToDoApp.Core.Interfaces.Repositories;
using ToDoApp.Core.Managers;
using ToDoApp.Infrastructure.Repositories;

namespace ToDoApp.Api.Extensions
{
    public static class ServicesExtension
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IAgendaManager, AgendaManager>();
        }
    }
}
