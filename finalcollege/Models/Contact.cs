using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finalcollege.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string Fullname {  get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }

        public string Message { get; set; }
    }
}