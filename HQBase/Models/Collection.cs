using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HQBase.Models
{
    public class Collection
    {
        public int CollectionId { get; set; }
        public String Title { get; set; }
        public List<Comic> Comics { get; set; }

    }
}