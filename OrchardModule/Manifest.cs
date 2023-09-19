using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "OrchardModule.Dojo",
    Author = "The Orchard Core Team",
    Website = "https://orchardcore.net",
    Version = "0.0.1",
    Description = "OrchardModule.Dojo",
    Category = "Content Management",
    Dependencies = new[] { "OrchardCore.ContentFields", "OrchardCore.Media" }
)]