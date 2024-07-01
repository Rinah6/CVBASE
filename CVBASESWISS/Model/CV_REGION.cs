namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_REGION
    {
        [Key]
        public int IDRegion { get; set; }

        [StringLength(100)]
        public string Region { get; set; }
    }
}
