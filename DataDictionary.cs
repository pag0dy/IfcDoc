using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Web;

using IfcDoc.Schema.DOC;
using No.Catenda.Peregrine.Model.Objects;

namespace IfcDoc
{
    public class DataDictionary
    {
        public static void Upload(DocProject project, string baseurl, string username, string password)
        {
            string url = baseurl + "api/4.0/session/login?email=" + HttpUtility.UrlEncode(username) + "&password=" + HttpUtility.UrlEncode(password);


            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = 0;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.Stream stream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            string body = reader.ReadToEnd();

            string cookie = response.Headers.Get("Set-Cookie");

            string[] parts = cookie.Split(new char[] { ';', ',' }); // bug? comma separates session ID
            string match = "peregrineapisessionid=";
            string sessionid = null;
            foreach(string part in parts)
            {
                if(part.StartsWith(match))
                {
                    sessionid = part.Substring(match.Length);
                    break;
                }
            }

            /*-Get all users:
var client = new RestClient("http://test.bsdd.buildingsmart.org/api/4.0/IfdUser/");
var request = new RestRequest(Method.GET);
request.AddHeader("cookie", "peregrineapisessionid=thesessionid");
request.AddHeader("accept", "application/json");
request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
IRestResponse response = client.Execute(request);*/

            /*- Get all languages:
var client = new RestClient("http://test.bsdd.buildingsmart.org/api/4.0/IfdLanguage/");
var request = new RestRequest(Method.GET);
request.AddHeader("cookie", "peregrineapisessionid={{sessionId}}");
request.AddHeader("accept", "application/json");
request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
IRestResponse response = client.Execute(request);*/
            request = (HttpWebRequest)HttpWebRequest.Create("http://test.bsdd.buildingsmart.org/api/4.0/IfdLanguage/");
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("cookie", "peregrineapisessionid=" + sessionid);
            request.Accept = "application/json";
            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();
            reader = new System.IO.StreamReader(stream);
            body = reader.ReadToEnd();

            body.ToString();

            request = (HttpWebRequest)HttpWebRequest.Create("http://test.bsdd.buildingsmart.org/api/4.0/IfdConcept/search/filter/language/1ASQw0qJqHuO00025QrE$V/type/NEST/Pset_*");
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("cookie", "peregrineapisessionid=" + sessionid);
            request.Accept = "application/json";
            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();
            reader = new System.IO.StreamReader(stream);
            body = reader.ReadToEnd();

            request = (HttpWebRequest)HttpWebRequest.Create("http://test.bsdd.buildingsmart.org/api/4.0/IfdConcept/search/filter/language/1ASQw0qJqHuO00025QrE$V/type/NEST/Pset_*");
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("cookie", "peregrineapisessionid=" + sessionid);
            request.Accept = "application/json";
            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();
            reader = new System.IO.StreamReader(stream);
            body = reader.ReadToEnd();

            body.ToString();

        }
    }
}
