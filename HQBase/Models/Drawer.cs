using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HQBase.Models
{
    public class Drawer : Artist
    {
        [DisplayName("Drawer")]
        public int DrawerId { get; set; }

    }
}