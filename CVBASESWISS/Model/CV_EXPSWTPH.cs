namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_EXPSWTPH
    {
        public int ID { get; set; }

        public DateTime? StartDate { get; set; }

        public int? Duration { get; set; }

        public int? IDSCIHUnit { get; set; }

        public int? IDRole { get; set; }

        public int? IDJunSenior { get; set; }

        public int? IDPersRef { get; set; }

        public string Appreciation { get; set; }

        public int? IDClient { get; set; }

        public int? IDExp { get; set; }

        public int? IDCountry { get; set; }

        public int? IDLanguage { get; set; }

        public bool? LFAWork { get; set; }

        public string DailyFees { get; set; }

        public string LinkReport { get; set; }

        public int? IDCV { get; set; }

        public int? NUM { get; set; }
    }
}
