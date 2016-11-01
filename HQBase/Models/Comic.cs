using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HQBase.Models
{
    public class Comic
    {
        public int ComicId { get; set; }

        [StringLength(125)]
        public String Title { get; set; }

        [DisplayName("Publisher")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        [DisplayName("Drawer")]
        public int DrawerId { get; set; }
        [DisplayName("Drawer")]
        public Drawer Drawer { get; set; }

        [DisplayName("Writer")]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        [DisplayName("Collection")]
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }

        [DisplayName("Edition Number")]
        [Range(0, 1000)]
        public int EditionNum { get; set; }


    }
}