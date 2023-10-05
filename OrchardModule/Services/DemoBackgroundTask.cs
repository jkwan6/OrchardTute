using Microsoft.Extensions.DependencyInjection;
using OrchardCore.BackgroundTasks;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardModule.Services
{
    [BackgroundTask(Schedule = "*/1 * * * *", Description = "just a demo background task")]

    public class DemoBackgroundTask : IBackgroundTask
    {
        public Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            var contentManager = serviceProvider.GetRequiredService<IContentManager>();
            //Debugger.Break();
            return Task.CompletedTask;
        }
    }
}
