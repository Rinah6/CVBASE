namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_CATEGORY
    {
        [Key]
        public int IDCat { get; set; }

       
        public string Category { get; set; }

        public string CR1 { get; set; }

        public string CR2 { get; set; }

        public string CR3 { get; set; }

        public string CR4 { get; set; }

        public string CR5 { get; set; }

        public bool? ISOK { get; set; }
    }
}
