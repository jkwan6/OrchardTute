using YesSql;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using OrchardModule.Models;
using OrchardModule.Indexes;
using OrchardCore.Modules;

namespace OrchardModule.Controllers
{
    public class PersonController : Controller
    {
        private readonly ISession _session;
        private readonly IContentManager _contentManager;
        private readonly IClock _clock;

        public PersonController(ISession session, IContentManager contentManager, IClock clock)
        {
            _session = session;
            _contentManager = contentManager;
            _clock = clock;
        }

        public async Task<String> List()
        {
            var threshold = _clock.UtcNow.AddYears(-40);
            var personPages = await _session
                .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "PersonPage")
                .With<PersonPartIndex>(personPartIndex => personPartIndex.BirthDateUtc > threshold)
                .ListAsync();
        
            foreach(var personPage in personPages)
            {
                await _contentManager.LoadAsync(personPage );
            }

            return string.Join(",", personPages.Select(personPage => personPage.As<PersonPart>().Name));
        
        }



    }
}
