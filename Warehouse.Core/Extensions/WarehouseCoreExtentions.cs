using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Pipelines;
using Warehouse.Data;
using Warehouse.Database;

namespace Warehouse.Core.Extensions
{
    public static class WarehouseCoreExtentions
    {
        public static IServiceCollection AddWarehouseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(WarehouseCoreExtentions));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<WarehouseContext>(options => options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<WarehouseContext>();

            return services;
        }

        public static IApplicationBuilder UseWearhouseServices(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<WarehouseContext>();

            context.Database.Migrate();

            return app;
        }
    }
}
