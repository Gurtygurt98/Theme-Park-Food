/*
    Project Developed by : Austin Phillips
    Page was Implemented using Dapper ORM 
    Page Description: This page provides a class outline for the TagData to map data to. 

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class TagModel
    {
        public int ID { get; set; }
        public string TagName { set; get; } = "";
        public string FoodName { set; get; } = "";
        public TagModel() { }

        public TagModel(string TagName, string FoodName) 
        { 
            this.TagName = TagName; 
            this.FoodName = FoodName;
        }
        public TagModel(int id, string TagName, string FoodName)
        { 
            this.ID = id;
            this.TagName = TagName;
            this.FoodName = FoodName;
        }
        public override bool Equals(object? obj)
        {
            if (obj is TagModel other)
            {
                return string.Equals(TagName, other.TagName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        // GetHashCode method using Name's hash code
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(TagName);
        }

        // ToString method displaying Name
        public override string ToString()
        {
            return TagName;
        }

    }
}
