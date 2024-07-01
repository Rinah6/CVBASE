namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_HISTOUR
    {
        public int ID { get; set; }

 
        public string LastName { get; set; }

     
        public string FirstName { get; set; }

        public DateTime? Date { get; set; }


        public string Mail { get; set; }

        public int? IDCV { get; set; }
    }
}
