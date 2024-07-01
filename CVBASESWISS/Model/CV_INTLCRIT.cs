namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_INTLCRIT
    {
        public int ID { get; set; }

        public int? IDCrit { get; set; }

        public int? IDCV { get; set; }

        public int? NbYear { get; set; }
    }
}
