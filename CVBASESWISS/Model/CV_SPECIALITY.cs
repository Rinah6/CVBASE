namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_SPECIALITY
    {
        [Key]
        public int IDSpeciality { get; set; }

    
        public string Speciality { get; set; }
    }
}
