using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class LocationModel
    {
        int ID;
        public string LocationName { get; set; } = "";
        string ParkName;
        string FestivalName;
        string AreaName;

        public LocationModel() { } 
        public LocationModel(int id, string locationName, string parkName, string festivalName, string areaName)
        {
            this.ID = id;
            LocationName = locationName;
            ParkName = parkName;
            FestivalName = festivalName;
            AreaName = areaName;
        }
        public LocationModel(string locationName, string parkName, string festivalName, string areaName)
        {
            LocationName = locationName;
            ParkName = parkName;
            FestivalName = festivalName;
            AreaName = areaName;
        }
        // Equals method comparing only Name
        public override bool Equals(object obj)
        {
            if (obj is LocationModel other)
            {
                return string.Equals(LocationName, other.LocationName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        // GetHashCode method using Name's hash code
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(LocationName);
        }

        // ToString method displaying Name
        public override string ToString()
        {
            return LocationName;
        }
    }
}
