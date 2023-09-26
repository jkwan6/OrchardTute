using OrchardCore.ContentManagement;
using OrchardModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql.Indexes;

namespace OrchardModule.Indexes
{
    // ORM Model
    public class PersonPartIndex: MapIndex
    {
        public string ContentItemId { get; set; }
        public DateTime? BirthDateUtc { get; set; }

    }


    public class PersonPartIndexProvider: IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context) =>
            context.For<PersonPartIndex>().Map(contentItem =>
            {
                var personPart = contentItem.As<PersonPart>();
                var x = (personPart == null) ? null : new PersonPartIndex{};
                return x;
            });
    }
}
