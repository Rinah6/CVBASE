using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBASESWISS.Model
{
    public partial class CV_DOCUSIGN
    {
        public int id { get; set; }
        public string IntegrationKey { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string UserId { get; set; }
        public string AccountId { get; set; }
        public string BaseUrl { get; set; }
        public string HostEnv { get; set; }
    }
}
