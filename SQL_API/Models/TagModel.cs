using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class TagModel
    {
        public int TagId { get; set; }
        public string Tag { get; set; }
        public TagModel() { }
        public TagModel(string tag) { Tag = tag; }
    }
}
