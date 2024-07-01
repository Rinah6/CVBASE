namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_PRINTSEARCH
    {
        public int ID { get; set; }

        public string CAT { get; set; }

        public string TECHFIELD { get; set; }

        public string JUNSEN { get; set; }

        public string DIPL { get; set; }

        public string SPEC { get; set; }

        public string LANG { get; set; }

        public string REGION { get; set; }

        public string GENDER { get; set; }

        public string NATION { get; set; }

        public string CR1 { get; set; }

        public string CR2 { get; set; }

        public string CR3 { get; set; }

        public string V1 { get; set; }

        public string V2 { get; set; }

        public string V3 { get; set; }

        public string FOUND { get; set; }

        public string N_STAT { get; set; }

        public string N_LAST { get; set; }

        public string N_FIRST { get; set; }

        public string N_RANK { get; set; }

        //public string N_LANG2 { get; set; }

        //public string N_LANG3 { get; set; }

        //public string N_DIP2 { get; set; }

        //public string N_DIP3 { get; set; }

        //public string N_SP2 { get; set; }

        //public string N_SP3 { get; set; }

        //public string N_R2 { get; set; }

        //public string N_R3 { get; set; }

        public string N_CAT { get; set; }

        public string N_LEVEL { get; set; }

        public string N_NATIONAL { get; set; }
    }
}
