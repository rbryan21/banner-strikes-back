using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Organization
    {
        [Key]
        public string Code { get; set; }
        public string DisplayName { get; set; }
    }
}
