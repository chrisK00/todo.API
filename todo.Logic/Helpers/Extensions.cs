using Microsoft.Extensions.DependencyInjection;
using Serilog;
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
