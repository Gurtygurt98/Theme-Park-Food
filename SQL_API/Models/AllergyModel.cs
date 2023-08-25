using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class AllergyModel
    {
        public string AllergyName { get; set; } = "Test-Allergy";
        public int IDFood { get;set; }
        public AllergyModel(string allergyName, int foodID)
        {
            this.AllergyName = allergyName;
            this.IDFood = foodID;
        }
        public AllergyModel() { }   
    }
}
