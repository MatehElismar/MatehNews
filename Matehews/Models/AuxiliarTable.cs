using System;

namespace Matehews.Models
{
    public class AuxiliarTable
    {
        public int id {get; set;}
        public String description {get; set;}
        public AuxiliarTable()
        { 
        } 
        public AuxiliarTable(int id, string description)
        { 
            this.id = id;
            this.description = description;
        }
    }
}