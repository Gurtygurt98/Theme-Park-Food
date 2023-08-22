using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class FestivalModels
    {
        public string Name { get; set; }
        public int IDFestival { get; set; }
        public DateOnly start {get; set;}   
        public DateOnly end { get; set;}
        public string Location { get; set; }
        public string Description { get; set; }
        public FestivalModels() { }

    }
}
