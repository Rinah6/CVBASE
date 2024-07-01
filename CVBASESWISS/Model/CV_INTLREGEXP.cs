namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_INTLREGEXP
    {
        public int ID { get; set; }

        public int? IDRegion { get; set; }

        public int? NbYear { get; set; }

        public int? IDCV { get; set; }

        public int? NUM { get; set; }
    }
}
