namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_EDUC
    {
        public int ID { get; set; }

        public int? IDDiploma { get; set; }

        public int? IDSpeciality { get; set; }

        public int? IDCV { get; set; }

        public int? Years { get; set; }

        public int? IDPlace { get; set; }

        public int? NUM { get; set; }
    }
}
