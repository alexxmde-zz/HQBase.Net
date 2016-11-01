using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HQBase.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public String Title { get; set; }
        public List<Comic> Comics { get; set; }
        public String Country { get; set; }
    }
}