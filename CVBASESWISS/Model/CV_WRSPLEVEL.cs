namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_WRSPLEVEL
    {
        [Key]
        public int IDWrSp { get; set; }

      
        public string WrSp { get; set; }
    }
}
