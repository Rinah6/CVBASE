namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_NATIONS
    {
        [Key]
        public int IDCountry { get; set; }

      
        public string Country { get; set; }
    }
}
