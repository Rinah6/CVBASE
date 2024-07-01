namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_RANKDIPLOMA
    {
        public int ID { get; set; }

        public int? IDDiploma { get; set; }

        public int? Rank { get; set; }
    }
}
