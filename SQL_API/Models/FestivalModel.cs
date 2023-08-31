using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class FestivalModel
    {
        public string Name { get; set; } = "Food and Wine 1955";
        public int IDFestival { get; set; }
        public string Start { get; set; } = new DateOnly(1995, 1, 1).ToString();
        public string End { get; set; } = new DateOnly(1995, 12, 31).ToString();
        public string Location { get; set; } = "Epcot";
        public string Description { get; set; } = "This is a default festival for the Festival Model";
        public FestivalModel() { }

        public FestivalModel(string festivalName, string Location, string startDate, string endDate, string description)
        {
            this.Name = festivalName;
            this.Location = Location;
            this.Start = startDate;
            this.End = endDate;
            this.Description = description;
        }
        public string ToString()
        {
            return "Name: " + this.Name ;
        }
    }
}