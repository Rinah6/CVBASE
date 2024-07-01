namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_TECHNICFIELD
    {
        [Key]
        public int IDTechField { get; set; }

        public string TechnicField { get; set; }
    }
}
