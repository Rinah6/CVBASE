namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_JUNSENIOR
    {
        [Key]
        public int IDJunSenior { get; set; }

        [StringLength(20)]
        public string JunSenior { get; set; }
    }
}
