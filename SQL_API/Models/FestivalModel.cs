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
        public DateOnly Start { get; set; } = new DateOnly(1995, 1, 1);
        public DateOnly End { get; set; } = new DateOnly(1995, 12, 31);
        public string Location { get; set; } = "Epcot";
        public string Description { get; set; } = "This is a default festival for the Festival Model";
        public FestivalModel() { }

        public FestivalModel(string festivalName, string park, DateOnly startDate, DateOnly endDate, string festivalLink, string description)
        {
            this.FestivalName = festivalName;
            this.Park = park;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.FestivalLink = festivalLink;
            this.Description = description;
        }

    }
}
