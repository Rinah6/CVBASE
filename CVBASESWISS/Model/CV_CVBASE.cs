namespace CVBASESWISS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_CVBASE
    {
        [Key]
        public int IDCV { get; set; }

        public bool? Sleep { get; set; }

        public DateTime? DateCV { get; set; }

        public string LastName { get; set; }

 
        public string FirstName { get; set; }

        public int? IDGender { get; set; }

        public DateTime? BirthDay { get; set; }

   
        public string Adress1 { get; set; }

        public string Adress2 { get; set; }


        public string ZipCode { get; set; }

        public int? IDNationality { get; set; }

        public int? IDCat { get; set; }
        
        public int? IDCountry { get; set; }

    
        public string MobilPhone { get; set; }

    
        public string LandlinePhone { get; set; }

   
        public string Email1 { get; set; }


        public string Email2 { get; set; }

        public int? IDPersRef { get; set; }

        public string ExpDailyFees { get; set; }

        public DateTime? DateSPMU { get; set; }

        public bool? ShortListed { get; set; }

        public int? IDJunSenior { get; set; }

        public string Comments { get; set; }

        public int? GivenAge { get; set; }

        public DateTime? DateSave { get; set; }

        public bool? WEB { get; set; }

    
        public string RefRecProcess { get; set; }

     
        public string ExpectPosition { get; set; }

        public bool? Title { get; set; }

        public string SleepComments { get; set; }

    
        public string Adress3 { get; set; }

        public string MobilPhone2 { get; set; }

        public string WHY { get; set; }

        public string Skype { get; set; }

        public int? IDTOWN { get; set; }
    }
}
