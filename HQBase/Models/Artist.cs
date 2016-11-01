using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HQBase.Models
{
    public abstract class Artist{

        public String Name { get; set; }

        [DisplayName("Last Name")]
        public String LastName { get; set; }
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        public String Country { get; set; }
    }
}