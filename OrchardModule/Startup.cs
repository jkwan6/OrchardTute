using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.BackgroundTasks;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;
using OrchardModule.Drivers;
using OrchardModule.Filters;
using OrchardModule.Handlers;
using OrchardModule.Indexes;
using OrchardModule.Migrations;
using OrchardModule.Models;
using OrchardModule.Navigation;
using OrchardModule.Permissions;
using YesSql.Indexes;

namespace OrchardModule
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<PersonPart>()
                .UseDisplayDriver<ParsonPartDisplayDriver>()
                .AddHandler<PersonPartHandler>();
            services.AddSingleton<IIndexProvider, PersonPartIndexProvider>();
            services.AddScoped<IDataMigration, PersonMigrations>();
            services.AddScoped<IPermissionProvider, PersonPagePermissions>();
            services.AddScoped<INavigationProvider, AdminMenu>();

            services.Configure<MvcOptions>(options => options.Filters.Add(typeof(ShapeInjectingFilter)));
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "OrchardModule",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}