using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class ParkModel
    {
        public string ParkName { get; set; } = "";
        public int ID { get; set; }
        public string Description { get; set; }
        public ParkModel() { }
        public ParkModel(string ParkName, string description)
        {
            this.ParkName = ParkName;
            this.Description = description;
        }
        public ParkModel(string ParkName)
        {
            this.ParkName = ParkName;
        }
        // Constructor with all properties
        public ParkModel(int id, string ParkName, string Description)
        {
            ID = id;
            ParkName = ParkName;
            Description = Description;
        }

        // Equals method comparing only Name
        public override bool Equals(object obj)
        {
            if (obj is ParkModel other)
            {
                return string.Equals(ParkName, other.ParkName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        // GetHashCode method using Name's hash code
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(ParkName);
        }

        // ToString method displaying Nam
        public override string ToString()
        {
            return ParkName;
        }
    }
}

