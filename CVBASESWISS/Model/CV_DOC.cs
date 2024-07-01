namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_DOC
    {
        public int ID { get; set; }

        public int? IDDoc { get; set; }

        public string Link { get; set; }

        public int? IDCV { get; set; }

        public int? NUM { get; set; }
    }
}
