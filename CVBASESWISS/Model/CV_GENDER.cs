namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_GENDER
    {
        [Key]
        public int IDGender { get; set; }

      
        public string Gender { get; set; }
    }
}
