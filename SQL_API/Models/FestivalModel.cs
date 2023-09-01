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
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Location { get; set; } = "Epcot";
        public string Description { get; set; } = "This is a default festival for the Festival Model";
        public FestivalModel() { }

        public FestivalModel(string festivalName, string Location, string startDate, string endDate, string description)
        {
            this.Name = festivalName;
            this.Location = Location;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
        }
        public string ToString()
        {
            return "Name: " + this.Name  + " Start " + StartDate + " End " + EndDate;
        }
    }
}