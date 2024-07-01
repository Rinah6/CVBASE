namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_INTLCOMMENT
    {
        public int ID { get; set; }

        public string Comments { get; set; }

        public int? IDCV { get; set; }
    }
}
