using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CVBASESWISS
{
   public class connectionstring
    {
       public string DBConn = ConfigurationManager.ConnectionStrings["DbCVBASE"].ToString();
    }
}
