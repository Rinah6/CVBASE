namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_LANGUAGE
    {
        [Key]
        public int IDLanguage { get; set; }

        [StringLength(50)]
        public string Language { get; set; }
    }
}
