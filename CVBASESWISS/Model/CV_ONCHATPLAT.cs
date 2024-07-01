namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_ONCHATPLAT
    {
        [Key]
        public int IDChat { get; set; }

        [StringLength(50)]
        public string OnlineChat { get; set; }
    }
}
