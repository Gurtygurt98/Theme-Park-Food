using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class FestivalModel
    {
        public string Name { get; set; }
        public int IDFestival { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public FestivalModel() { }
        public FestivalModel(string name, int id, DateOnly start, DateOnly end, string location, string description)
        {
            this.Name = name;
            this.IDFestival = id;
            this.Start = start;
            this.End = end;
            this.Location = location;
            this.Description = description;
        }

    }
}
