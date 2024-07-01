namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_VISITSPMU
    {
        public int ID { get; set; }

        public DateTime? Date { get; set; }

        public int? IDEmplo1 { get; set; }

        public int? IDEmplo2 { get; set; }

        public int? IDEmplo3 { get; set; }

        public int? IDCategory { get; set; }

        public int? TestDone { get; set; }

        public int? IDGApprec { get; set; }

        public string Comments { get; set; }

        public int? IDCV { get; set; }
    }
}
