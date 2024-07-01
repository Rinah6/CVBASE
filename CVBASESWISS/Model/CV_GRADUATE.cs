namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_GRADUATE
    {
        [Key]
        public int IDGraduate { get; set; }

      
        public string Graduate { get; set; }
    }
}
