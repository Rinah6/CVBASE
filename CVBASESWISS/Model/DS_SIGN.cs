using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBASESWISS.Model
{
    public partial class DS_SIGN
    {
        public int ID { get; set; }
        public DateTime REQUEST { get; set; }
        public int IDCV { get; set; }
        public string LINK { get; set; }
        public bool SIGNED{ get; set; }
    }
}
