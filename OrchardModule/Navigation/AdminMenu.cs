using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using OrchardModule.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardModule.Navigation
{
    public class AdminMenu: INavigationProvider
    {
        private readonly IStringLocalizer T;

        public AdminMenu(IStringLocalizer<AdminMenu> localizer) => T = localizer;

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase)) return Task.CompletedTask;

            builder.Add(
                T["Person Page Admin"],
                "5",
                item => item.Action("CustomAuthorization", "Admin", new { Area = "OrchardModule" })
                .Permission(PersonPagePermissions.ManagePersonPages));

            return Task.CompletedTask;
        }
    }
}
