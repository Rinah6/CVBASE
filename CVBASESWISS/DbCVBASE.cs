namespace CVBASESWISS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CVBASESWISS.Model;

    public partial class DbCVBASE : DbContext
    {
        public DbCVBASE()
            : base("name=DbCVBASE")
        {
        }

        public virtual DbSet<CV_CATEGORY> CV_CATEGORY { get; set; }
        public virtual DbSet<CV_CLIENT> CV_CLIENT { get; set; }
        //public virtual DbSet<CV_CRITERIA> CV_CRITERIA { get; set; }
        public virtual DbSet<CV_CVBASE> CV_CVBASE { get; set; }
        public virtual DbSet<CV_DIPLOMA> CV_DIPLOMA { get; set; }
        public virtual DbSet<CV_DOC> CV_DOC { get; set; }
        public virtual DbSet<CV_DOCDATECOMM> CV_DOCDATECOMM { get; set; }
        public virtual DbSet<CV_DOCUMENT> CV_DOCUMENT { get; set; }
        public virtual DbSet<CV_DOCUSIGN> CV_DOCUSIGN { get; set; }
        public virtual DbSet<CV_EDUC> CV_EDUC { get; set; }
        public virtual DbSet<CV_EMPLOYEE> CV_EMPLOYEE { get; set; }
        public virtual DbSet<CV_EXPCOMMENT> CV_EXPCOMMENT { get; set; }
        public virtual DbSet<CV_EXPSWTPH> CV_EXPSWTPH { get; set; }
        public virtual DbSet<CV_GAPPREC> CV_GAPPREC { get; set; }
        public virtual DbSet<CV_GENDER> CV_GENDER { get; set; }
        public virtual DbSet<CV_GRAD> CV_GRAD { get; set; }
        public virtual DbSet<CV_GRADUATE> CV_GRADUATE { get; set; }
        public virtual DbSet<CV_INTLCOMMENT> CV_INTLCOMMENT { get; set; }
        public virtual DbSet<CV_INTLEXPTECH> CV_INTLEXPTECH { get; set; }
        public virtual DbSet<CV_INTLREGEXP> CV_INTLREGEXP { get; set; }
        public virtual DbSet<CV_JUNSENIOR> CV_JUNSENIOR { get; set; }
        public virtual DbSet<CV_LANGUAGE> CV_LANGUAGE { get; set; }
        public virtual DbSet<CV_NATIONS> CV_NATIONS { get; set; }
        public virtual DbSet<CV_NOTECRITERIA> CV_NOTECRITERIA { get; set; }
        public virtual DbSet<CV_REGION> CV_REGION { get; set; }
        public virtual DbSet<CV_ROLE> CV_ROLE { get; set; }
        public virtual DbSet<CV_SPECIALITY> CV_SPECIALITY { get; set; }
        //public virtual DbSet<CV_TABLES> CV_TABLES { get; set; }
        public virtual DbSet<CV_TECHNICFIELD> CV_TECHNICFIELD { get; set; }
        public virtual DbSet<CV_UNIT> CV_UNIT { get; set; }
        public virtual DbSet<CV_USERS> CV_USERS { get; set; }
        public virtual DbSet<CV_VISITSPMU> CV_VISITSPMU { get; set; }
        public virtual DbSet<CV_WRSP> CV_WRSP { get; set; }
        public virtual DbSet<CV_WRSPLEVEL> CV_WRSPLEVEL { get; set; }

        public virtual DbSet<CV_SAVESEARCH> CV_SAVESEARCH { get; set; }
        public virtual DbSet<CV_PRINTDASH> CV_PRINTDASH { get; set; }
        public virtual DbSet<CV_PRINTSEARCH> CV_PRINTSEARCH { get; set; }
        public virtual DbSet<CV_DATAWH> CV_DATAWH { get; set; }
        public virtual DbSet<CV_DATASET> CV_DATASET { get; set; }
        public virtual DbSet<CV_RANKJUN> CV_RANKJUN { get; set; }
        public virtual DbSet<CV_RANKSEN> CV_RANKSEN { get; set; }
        public virtual DbSet<CV_RANKDIPLOMA> CV_RANKDIPLOMA { get; set; }
        public virtual DbSet<CV_CCMAIL> CV_CCMAIL { get; set; }
        public virtual DbSet<CV_AUTHORMDP> CV_AUTHORMDP { get; set; }

        public virtual DbSet<CV_EPRO> CV_EPRO { get; set; }
        public virtual DbSet<CV_EPROFIL> CV_EPROFIL { get; set; }
        public virtual DbSet<CV_EPROWL> CV_EPROWL { get; set; }
        public virtual DbSet<CV_ONCHAT> CV_ONCHAT { get; set; }
        public virtual DbSet<CV_ONCHATAVA> CV_ONCHATAVA { get; set; }
        public virtual DbSet<CV_ONCHATPLAT> CV_ONCHATPLAT { get; set; }
        public virtual DbSet<CV_PLACE> CV_PLACE { get; set; }

        public virtual DbSet<CV_TEST> CV_TEST { get; set; }
        public virtual DbSet<CV_TEMPORDERCVRANK> CV_TEMPORDERCVRANK { get; set; }

        public virtual DbSet<CV_HISTOUR> CV_HISTOUR { get; set; }

        public virtual DbSet<CV_BATCH> CV_BATCH { get; set; }
        public virtual DbSet<DS_SIGN> DS_SIGN { get; set; }

        public virtual DbSet<CV_TOWNS> CV_TOWNS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
