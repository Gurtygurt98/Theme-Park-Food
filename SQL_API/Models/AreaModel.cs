/*
 * Table = Area 
 * Relates to the Food Table through LocationName-> Location Table -> AreaName 
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class AreaModel
    {
        // Variable Declaration  
        public int ID { get; set; }
        public string AreaName { get; set; } = "";
        public string ParkName { get; set; }
        public List<LocationModel> Locations { get; set; }
        public AreaModel(string AreaName, string ParkName)
        {
            this.ParkName = ParkName;
            this.AreaName = AreaName;
        }
        public AreaModel(string AreaName)
        {
            this.AreaName = AreaName;
        }
        public AreaModel(int id ,string AreaName, string ParkName)
        {
            this.ID = id;
            this.AreaName = AreaName;
            this.ParkName = ParkName;
        }
        // Default constructor 
        public AreaModel() { }
        // Equals method comparing only Name
        public override bool Equals(object obj)
        {
            if (obj is AreaModel other)
            {
                return string.Equals(AreaName, other.AreaName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        // GetHashCode method using Name's hash code
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(AreaName);
        }

        // ToString method displaying Name
        public override string ToString()
        {
            return AreaName;
        }
    }

}
