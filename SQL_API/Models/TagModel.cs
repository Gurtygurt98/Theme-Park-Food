using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class TagModel
    {
        public string Name { set; get; }
        public int FoodID { set; get; }
        public TagModel() { }

        public TagModel(string tag,int id ) 
        { 
            this.Name = tag; 
            this.FoodID = id;
        }  

    }
}
