namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_SAVESEARCH
    {
        public int ID { get; set; }

        public string Cat { get; set; }

        public string Language { get; set; }

        public string TechField { get; set; }

        public string Diploma { get; set; }

        public string Speciality { get; set; }

        public string Region { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string JUNSEN { get; set; }

        [StringLength(50)]
        public string C1 { get; set; }

        [StringLength(50)]
        public string C2 { get; set; }

        [StringLength(50)]
        public string C3 { get; set; }

        public string V1 { get; set; }

        public string V2 { get; set; }

        public string V3 { get; set; }
    }
}
