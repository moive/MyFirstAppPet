using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstApp.Models
{
    public class Pet
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public bool IsAdopted { get; set; }
    }
}