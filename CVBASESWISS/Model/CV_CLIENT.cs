namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_CLIENT
    {
        [Key]
        public int IDClient { get; set; }

    
        public string Client { get; set; }
    }
}
