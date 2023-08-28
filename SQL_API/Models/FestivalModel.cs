using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class FestivalModel
    {
        public string FestivalName { get; set; }
        public string Park { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Description { get; set; }
        public FestivalModel() { }

        public FestivalModel(string festivalName, string park, DateOnly startDate, DateOnly endDate, string description)
        {
            this.FestivalName = festivalName;
            this.Park = park;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
        }
    }
}
