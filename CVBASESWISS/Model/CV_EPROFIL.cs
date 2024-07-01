namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_EPROFIL
    {
        [Key]
        public int IDEProf { get; set; }

  
        public string EProfile { get; set; }
    }
}
