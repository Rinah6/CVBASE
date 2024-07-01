namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_TEST
    {
        [Key]
        public int IDTest { get; set; }

    
        public string Test { get; set; }
    }
}
