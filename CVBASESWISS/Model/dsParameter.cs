using DocuSign.eSign.Client.Auth;
using DocuSign.eSign.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuSign.eSign.Api;
using static DocuSign.eSign.Client.Auth.OAuth.UserInfo;
using DocuSign.eSign.Model;
using System.IO;
using Org.BouncyCastle.Asn1.X509;
using static DocuSign.eSign.Client.Auth.OAuth;
using System.Windows.Forms;

namespace CVBASESWISS.Model
{
    public static class dsParameter
    {
        public static CV_DOCUSIGN dsOption = new CV_DOCUSIGN();
        public static string PowerForm = "";
        private static List<string> scopes = new List<string> { OAuth.Scope_SIGNATURE, OAuth.Scope_IMPERSONATION };

        public static OAuth.OAuthToken authToken = new OAuth.OAuthToken();
        private static ApiClient apiClient = new ApiClient();
        public static DateTime DateAuth;
        
        public static bool GetAuth()
        {
            try
            {
                DateAuth = DateTime.Now.AddMinutes(50);
                Cursor.Current = Cursors.WaitCursor;
                var hostEnv = OAuth.Demo_OAuth_BasePath;
                hostEnv = OAuth.Production_OAuth_BasePath;

                apiClient = new ApiClient(dsOption.BaseUrl + "/restapi");
                
                #region AccessTokenViaCode
                //var az = apiClient.GetAuthorizationUri(dsOption.IntegrationKey, scopes, "https://www.example.com/callback", "code");
                //var code = "";
                //var ze = apiClient.GenerateAccessToken(dsOption.IntegrationKey, "6bf9fe8a-7687-4cfc-b204-d5849bcd3534", code);
                #endregion
                authToken = apiClient.RequestJWTUserToken(
                    dsOption.IntegrationKey,
                    dsOption.UserId,
                    //hostEnv,
                    dsOption.HostEnv,
                    Encoding.UTF8.GetBytes(dsOption.PrivateKey),
                    24,
                    scopes
                );

                DbCVBASE soft = new DbCVBASE();
                var ds = soft.CV_CCMAIL.FirstOrDefault();
                if (ds!=null) PowerForm = GetPowerFormId(ds.DSPF);

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch(Exception e)
            {
                Cursor.Current = Cursors.Default;
                System.Windows.Forms.MessageBox.Show($"Please, verify your docusign identity!" + e.Message, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string GetPowerFormId(string s)
        {
            if(s.Contains("PowerFormId=")) s = s.Split(new string[] { "PowerFormId=" }, StringSplitOptions.None)[1];
            return s.Split('&')[0];
        }

        public static Envelope GetEnvelope(DateTime fromDate, string FullName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                EnvelopesApi envelopesApi = new EnvelopesApi(apiClient);
                
                var envs = envelopesApi.ListStatusChanges(dsOption.AccountId, new EnvelopesApi.ListStatusChangesOptions()
                {
                    fromDate = fromDate.AddDays(-1).ToString("yyyy-MM-dd"),
                    //toDate = fromDate.AddHours(5).ToString("yyyy-MM-dd"),
                    include = "recipients",//"recipients, documents, custom_fields",
                    order = "desc",
                    status = "Completed, Declined",
                    powerformids = PowerForm
                });

                if(envs.Envelopes != null)
                {
                    var list = envs.Envelopes.Where(x => x.Status.ToLower()=="completed" && x.Recipients.Signers.Where(y => y.Name == FullName).Any()).ToList();
                    foreach (var item in list)
                    {
                        var formData = envelopesApi.GetFormData(dsOption.AccountId, item.EnvelopeId);
                        var date = formData.FormData.Where(x => x.Name == "date").ToList().FirstOrDefault();
                        if (date.Value == fromDate.ToString("dd-MM-yyyy"))
                        {
                            Cursor.Current = Cursors.Default;
                            return item;
                        }
                    }
                }

                Cursor.Current = Cursors.Default;
                return null;
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                System.Windows.Forms.MessageBox.Show($"error! \n\n{e.Message}", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<EnvelopeTemplate> GetTemplates()
        {
            TemplatesApi templatesApi = new TemplatesApi(apiClient);
            return templatesApi.ListTemplates(dsOption.AccountId, new TemplatesApi.ListTemplatesOptions()
            {
                order = "desc"
            }).EnvelopeTemplates;
            
            return null;
        }
        public static void GetPowerForm()
        {
            PowerFormsApi powerFormsApi = new PowerFormsApi(apiClient);
            var a = powerFormsApi.ListPowerForms(dsOption.AccountId, new PowerFormsApi.ListPowerFormsOptions()
            {
                    
            }).PowerForms;
            
        }
        public static void GetDocumentPDF(string envId)
        {
            EnvelopesApi envelopesApi = new EnvelopesApi(apiClient);
            var env = envelopesApi.GetEnvelope(dsOption.AccountId, envId);
            System.IO.Stream results = envelopesApi.GetDocument(dsOption.AccountId, envId, "1");
            var filename = Path.Combine(P_Directory.appFolder, env.Recipients.Signers.FirstOrDefault().Name + DateTime.Parse(env.CreatedDateTime).ToString("ddmmyyyy") +".pdf");
                                
            var fileStream = File.OpenWrite(filename);
            results.CopyTo(fileStream);
            results.Close();
            fileStream.Close();
        }

        public static void GetDocumentPDFTo(string path, string envId)
        {
            EnvelopesApi envelopesApi = new EnvelopesApi(apiClient);
            var env = envelopesApi.GetEnvelope(dsOption.AccountId, envId, new EnvelopesApi.GetEnvelopeOptions()
            {
                include = "recipients"
            });
            System.IO.Stream results = envelopesApi.GetDocument(dsOption.AccountId, envId, "1");
            var filename = Path.Combine(path, env.Recipients.Signers.FirstOrDefault().Name + /*DateTime.Parse(env.CreatedDateTime).ToString("ddmmyyyy") + */ ".pdf");
                
            var fileStream = File.OpenWrite(filename);
            results.CopyTo(fileStream);
            results.Close();
            fileStream.Close();
        }
    }
}
