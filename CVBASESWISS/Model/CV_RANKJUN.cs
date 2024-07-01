namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_RANKJUN
    {
        public int ID { get; set; }

        public int? V1 { get; set; }

        public int? V2 { get; set; }

        public int? V3 { get; set; }
    }
}
