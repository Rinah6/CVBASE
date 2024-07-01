namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_DATASET
    {
        public int ID { get; set; }

      
        public string DATASETCV { get; set; }

        public int? ID_USERS { get; set; }
    }
}
