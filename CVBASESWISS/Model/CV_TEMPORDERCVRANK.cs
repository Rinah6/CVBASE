namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_TEMPORDERCVRANK
    {
        public int ID { get; set; }

        public int? IDCV { get; set; }

        public int? RANKS { get; set; }

        [StringLength(50)]
        public string LASTNAME { get; set; }

    }
}
