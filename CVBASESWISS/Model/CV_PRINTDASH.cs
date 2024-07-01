namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_PRINTDASH
    {
        public int ID { get; set; }

        public string CAT { get; set; }

        [StringLength(10)]
        public string ALIVE { get; set; }

        [StringLength(10)]
        public string SLEEP { get; set; }

        [StringLength(10)]
        public string MALE { get; set; }

        [StringLength(10)]
        public string FEMALE { get; set; }

        [StringLength(10)]
        public string OTHER { get; set; }

        [StringLength(10)]
        public string JUNIOR { get; set; }

        [StringLength(10)]
        public string JUNIOLFA { get; set; }

        [StringLength(10)]
        public string SENIOR { get; set; }

        [StringLength(10)]
        public string SENIORLFA { get; set; }

        [StringLength(10)]
        public string TBD { get; set; }

        [StringLength(10)]
        public string CATNB { get; set; }

        [StringLength(10)]
        public string CATNOTSETUP { get; set; }

        [StringLength(10)]
        public string CVNB { get; set; }

        [StringLength(10)]
        public string CVALIVE { get; set; }

        [StringLength(10)]
        public string CVSLEEP { get; set; }

        [StringLength(10)]
        public string CVMALE { get; set; }

        [StringLength(10)]
        public string CVFEMALE { get; set; }

        [StringLength(10)]
        public string CVOTHER { get; set; }

        [StringLength(10)]
        public string CVJUN { get; set; }

        [StringLength(10)]
        public string CVJUNLFA { get; set; }

        [StringLength(10)]
        public string CVSEN { get; set; }

        [StringLength(10)]
        public string CVSENLFA { get; set; }

        [StringLength(10)]
        public string CVTBD { get; set; }
    }
}
