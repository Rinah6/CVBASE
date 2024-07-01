namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_DIPLOMA
    {
        [Key]
        public int IDDiploma { get; set; }

     
        public string Diploma { get; set; }
    }
}
