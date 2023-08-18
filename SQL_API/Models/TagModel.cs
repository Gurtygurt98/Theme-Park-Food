using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class TagModel
    {
        public string Tag { set; get; }
        public TagModel() { }

        public TagModel(string tag) { this.Tag = tag;}  

    }
}