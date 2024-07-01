namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_EMPLOYEE
    {
        [Key]
        public int IDPersRef { get; set; }

        public string PersRef { get; set; }
    }
}
