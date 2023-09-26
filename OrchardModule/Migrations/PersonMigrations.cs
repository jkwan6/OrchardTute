﻿using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardModule.Indexes;
using OrchardModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql.Sql;

namespace OrchardModule.Migrations
{
    public class PersonMigrations: DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public PersonMigrations(IContentDefinitionManager contentDefinitionManager) => 
            _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(PersonPart), part => part
                .Attachable()
                .WithField(nameof(PersonPart.Biography), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Biography")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "The person's biography."
                    })
                    .WithEditor("TextArea"))
            );

            _contentDefinitionManager.AlterTypeDefinition("PersonPage", type => type
                .Creatable()
                .Listable()
                .WithPart(nameof(PersonPart))
            );



            return 1;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(PersonPart), part => part
                .Attachable()
                .WithField(nameof(PersonPart.Biography), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Biography")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "The person's biography."
                    })
                    .WithEditor("TextArea"))
            );

            _contentDefinitionManager.AlterTypeDefinition("PersonPage", type => type
                .Creatable()
                .Listable()
                .WithPart(nameof(PersonPart))
            );



            return 2;
        }

        public int UpdateFrom2()
        {
            _contentDefinitionManager.AlterTypeDefinition("PersonPage", type => type
                .WithPart(nameof(PersonPart))
                .Stereotype("Widget"));
            return 3;
        }

        public int UpdateFrom3()
        {

            SchemaBuilder.CreateMapIndexTable(nameof(PersonPartIndex),
                table => table
                .Column<string>(nameof(PersonPartIndex.ContentItemId), column => column.WithLength(26))
                .Column<DateTime>(nameof(PersonPartIndex.BirthDateUtc)));


            return 4;
        }
    }
}
