namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_USERS
    {
        [Key]
        public int ID_USERS { get; set; }

   
        public string LOGIN { get; set; }

        public string PASSWORD { get; set; }

        public int? AUTH { get; set; }

        public int? ISADMIN { get; set; }
    }
}
