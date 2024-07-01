namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_NOTECRITERIA
    {
        public int ID { get; set; }

        public int? N1 { get; set; }

        public int? N2 { get; set; }

        public int? N3 { get; set; }

        public int? N4 { get; set; }

        public int? N5 { get; set; }

        public int? IDCV { get; set; }
    }
}
