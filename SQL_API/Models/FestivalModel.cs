using System;

namespace SQL_API.Models
{
    public class FestivalModel
    {
        public string FestivalName { get; set; } = "";
        public int ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ParkName { get; set; }
        public string Description { get; set; }

        public FestivalModel() { }
        public FestivalModel(string festivalName, string Location, string startDate, string endDate, string description)
        {
            this.FestivalName = festivalName;
            this.ParkName = Location;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
        }
        // Constructor with all properties
        public FestivalModel(int id, string festivalName, string location, string startDate, string endDate, string description)
        {
            ID = id;
            FestivalName = festivalName;
            ParkName = location;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

        // Equals method comparing only Name
        public override bool Equals(object obj)
        {
            if (obj is FestivalModel other)
            {
                return string.Equals(FestivalName, other.FestivalName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        // GetHashCode method using Name's hash code
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(FestivalName);
        }

        // ToString method displaying Name
        public override string ToString()
        {
            return FestivalName;
        }
    }
}
