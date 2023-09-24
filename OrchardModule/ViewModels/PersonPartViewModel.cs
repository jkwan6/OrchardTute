using OrchardCore.ContentFields.Fields;
using OrchardModule.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardModule.ViewModels
{
    public class PersonPartViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Handedness Handedness { get; set; }
        [Required]
        public DateTime? BirthDateUtc { get; set; }
    }
}
