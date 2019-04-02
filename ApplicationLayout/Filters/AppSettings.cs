using System.Configuration;

namespace ApplicationLayout.Filters
{
    //This class is used to get the variables defined in web.config appSettings
    public class AppSettings
    {
        public string BypassLDAP
        {
            get { return ConfigurationManager.AppSettings["bypassLDAP"]; }
        }

        public string UploadPath
        {
            get { return ConfigurationManager.AppSettings["FolderPath"]; }
        }

        public string BaseURL
        {
            get { return ConfigurationManager.AppSettings["baseURL"]; }
        }

        public string EnableEmail
        {
            get { return ConfigurationManager.AppSettings["enable_email"]; }
        }

    }
}