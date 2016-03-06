using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using SupinfoNote.Uni10.Core.JsonModels;
using SupinfoNote.Uni10.Core.JsonModels.Grade;

namespace SupinfoNote.Uni10.Core
{
    public class HttpHelper
    {
        public static HttpHelper Helper
        {
            get
            {
                if (_httpHelper == null)
                {
                    _httpHelper = new HttpHelper();
                }
                return _httpHelper;
            }
        }

        private static string _campusId;
        private static string _token;
        private static HttpHelper _httpHelper;

        public async Task<User> LoginRequest(string userName, string password)
        {
            _campusId = userName;
            _token = password;
            var result = await GetRequest(HttpRequestUrlLogin);
            if (result.IsSuccessStatusCode)
            {
                var usr = new User(await result.Content.ReadAsStringAsync());
                _token = usr.Token;
                return usr;
            }
            return null;
        }


        public async Task<List<News>> GetNews()
        {
            var result = await GetRequest(HttpRequestUrlNews);
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                return News.GetNews(json);
            }
            return null;
        }

        public async Task<List<Planning>> GetPlanning(string classId)
        {
            var result = await GetRequest(HttpRequestUrlPlanning, classId);
            if (result.IsSuccessStatusCode)
            {
                return Planning.GetPlanning(await result.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<List<GradePromo>> GetGrades()
        {
            var result = await GetRequest(HttpRequestUrlGrades);
            if (result.IsSuccessStatusCode)
            {
                return Grades.GetGrades(await result.Content.ReadAsStringAsync());
            }
            return null;
        }

        private async Task<HttpResponseMessage> GetRequest(string url, string classId = null)
        {
            try
            {
                var aHbpf = new HttpBaseProtocolFilter();
                aHbpf.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
                aHbpf.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
                HttpClient aTempClient = new HttpClient(aHbpf);
                aTempClient.DefaultRequestHeaders.Append("X-Appscho-Id", _campusId);
                aTempClient.DefaultRequestHeaders.Append("X-Appscho-Token", _token);
                aTempClient.DefaultRequestHeaders.Append("Accepte-Language", "fr");
                if (classId != null)
                {
                    aTempClient.DefaultRequestHeaders.Append("X-Appscho-CampusClassId", classId);
                }
                var result = await aTempClient.GetAsync(new Uri(url));
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Logout()
        {
            throw new NotImplementedException("a coder");
        }


        //requete info supinfo
        public const string HttpRequestUrlLogin = "https://api.appscho.com/supinfo/login";
        public const string HttpRequestUrlWhoami = "https://api.appscho.com/supinfo/whoami";
        public const string HttpRequestUrlPing = "https://api.appscho.com/supinfo/ping";
        public const string HttpRequestUrlGrades = "https://api.appscho.com/supinfo/grades";
        public const string HttpRequestUrlPlanning = "https://api.appscho.com/supinfo/planning";
        public const string HttpRequestUrlNews = "https://api.appscho.com/supinfo/news";
        public const string HttpRequestUrlLogout = "https://api.appscho.com/supinfo/logout";

        //info reseau sociaux
        public const string HttpRequestUrlAllSocial = "https://api.appscho.com/supinfo/social";
        public const string HttpRequestUrlFacebook = "https://api.appscho.com/supinfo/facebook";
        public const string HttpRequestUrlTwitter = "https://api.appscho.com/supinfo/twitter";
        public const string HttpRequestUrlInstagram = "https://api.appscho.com/supinfo/instagram";
        public const string HttpRequestUrlYoutube = "https://api.appscho.com/supinfo/youtube";
    }
}
