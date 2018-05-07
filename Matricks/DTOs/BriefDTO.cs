using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricks.DTOs
{
    public class BriefDTO
    {
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Url { get; set; }
    }
}
