using OrchardCore.ContentManagement.Handlers;
using OrchardModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardModule.Handlers
{
    public class PersonPartHandler: ContentPartHandler<PersonPart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, PersonPart part)
        {
            context.ContentItem.DisplayText = part.Name;
            return Task.CompletedTask;
        }
    }
}
