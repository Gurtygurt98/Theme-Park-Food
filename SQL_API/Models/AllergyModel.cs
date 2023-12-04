/*
 * Table = Allergy 
 * Relates to the Food Table through FoodName variable
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
    public class AllergyModel
    {
        // Variable decleration 
        public int ID { get; set; }
        public string AllergyName { get; set; }
        public string FoodName { get;set; }
        // Constructor 
        public AllergyModel(string allergyName, string FoodName)
        {
            this.AllergyName = allergyName;
            this.FoodName = FoodName;
        }
        public AllergyModel(int id, string allergyName, string FoodName)
        {
            this.ID = id;
            this.AllergyName = allergyName;
            this.FoodName = FoodName;
        }
        // Default Constructor 
        public AllergyModel() { }

        // Equals method comparing only Name
        public override bool Equals(object obj)
        {
            if (obj is AllergyModel other)
            {
                return string.Equals(AllergyName, other.AllergyName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        // GetHashCode method using Name's hash code
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(AllergyName);
        }

        // ToString method displaying Name
        public override string ToString()
        {
            return AllergyName;
        }
    }
}
