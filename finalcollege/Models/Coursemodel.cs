using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finalcollege.Models
{
    public class Coursemodel
    {
        public int ID { get; set; }
        public string Program { get; set; }
        public string Courseid { get; set; }
        public string Coursename { get; set; }
        public string Description { get; set; }
        public String Duration { get; set; }
        public int Availablesheet { get; set; }

    }
}