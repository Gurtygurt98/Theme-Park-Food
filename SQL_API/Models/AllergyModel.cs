using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class AllergyModel
    {
        public string Name { get; set; }
        public int FoodID { get;set; }
        public AllergyModel(string allergyName, int foodID)
        {
            this.Name = allergyName;
            this.FoodID = foodID;
        }
        public AllergyModel() { }   
    }
}
