namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_UNIT
    {
        [Key]
        public int IDSCIHUnit { get; set; }

      
        public string Unit { get; set; }
    }
}
