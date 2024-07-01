namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_GAPPREC
    {
        [Key]
        public int IDGApprec { get; set; }

        public string GApprec { get; set; }
    }
}
