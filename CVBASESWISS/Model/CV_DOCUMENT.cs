namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_DOCUMENT
    {
        [Key]
        public int IDDoc { get; set; }

       
        public string Docum { get; set; }
    }
}
