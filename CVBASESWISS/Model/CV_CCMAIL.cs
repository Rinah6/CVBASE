namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_CCMAIL
    {
        public int ID { get; set; }

        public string CCMAIL { get; set; }

        public string MDLMAIL { get; set; }
        public string RETMAIL { get; set; }  //retention mail
        public string DSPF { get; set; } //docusign powerform
    }
}
