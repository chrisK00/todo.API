using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo.Data;
using todo.Logic.Services;

namespace todo.Logic.Helpers
{
    public static class Extensions
    {
        public static void ConfigureTodoServices(this IServiceCollection services)
        {
            services.AddScoped<ITodosRepository, TodosRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITodosService, TodosService>();
            services.AddSingleton(Log.Logger);
        }

    }
}
