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

namespace OrchardModule.Controllers
{
    public class PersonController : Controller
    {
        private readonly ISession _session;
        private readonly IContentManager _contentManager;

        public PersonController(ISession session, IContentManager contentManager)
        {
            _session = session;
            _contentManager = contentManager;
        }

        public async Task<String> List()
        {
            var personPages = await _session.Query<ContentItem, ContentItemIndex>(index => index.ContentType == "PersonPage")
                .ListAsync();
        
            foreach(var personPage in personPages)
            {
                await _contentManager.LoadAsync(personPage );
            }

            return string.Join(",", personPages.Select(personPage => personPage.As<PersonPart>().Name));
        
        }



    }
}
