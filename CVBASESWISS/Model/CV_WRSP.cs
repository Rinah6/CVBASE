namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_WRSP
    {
        public int ID { get; set; }

        public int? IDLanguage { get; set; }

        public int? IDWr { get; set; }

        public int? IDSp { get; set; }

        public int? IDCV { get; set; }

        public int? NUM { get; set; }
    }
}
