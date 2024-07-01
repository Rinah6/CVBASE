namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_PLACE
    {
        [Key]
        public int IDPlace { get; set; }

       
        public string Place { get; set; }
    }
}
