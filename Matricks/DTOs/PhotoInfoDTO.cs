using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matricks.DTOs
{
    public class PhotoInfoDTO
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Profile { get; set; }
    }
}
