using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

using System.Net;
using System.Web;

using IfcDoc.Format.XML;
using IfcDoc.Schema.DOC;
using IfcDoc.Schema.PSD;

namespace IfcDoc
{
    public class DataDictionary
    {
        public static void Download(DocProject project, System.ComponentModel.BackgroundWorker worker, string baseurl, string username, string password)
        {
            if (project.Sections[4].Schemas.Count == 0)
            {
                project.Sections[4].Schemas.Add(new DocSchema());
            }

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
            request = (HttpWebRequest)HttpWebRequest.Create(baseurl + "api/4.0/IfdLanguage/");
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

            request = (HttpWebRequest)HttpWebRequest.Create(baseurl + "api/4.0/IfdConcept/search/filter/language/1ASQw0qJqHuO00025QrE$V/type/NEST/Pset_*");
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("cookie", "peregrineapisessionid=" + sessionid);
            request.Accept = "application/json";
            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();
            reader = new System.IO.StreamReader(stream);
            body = reader.ReadToEnd();

            System.IO.Stream ms = new System.IO.MemoryStream();
            System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
            writer.Write(body);
            writer.Flush();
            ms.Position = 0;
            //System.IO.MemoryStream mstream = new System.IO.MemoryStream()

            ResponseSearch ifdRoot;
            try
            {
                DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                //settings.UseSimpleDictionaryFormat = true;
                System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(ResponseSearch));
                ifdRoot = (ResponseSearch)ser.ReadObject(ms);
            }
            catch
            {
                return;
            }

            // PERF: consider API on server that would return all information at once (currently 150+ round trips)
            for (int iConc = 0; iConc < ifdRoot.IfdConcept.Length; iConc++ )
            {
                IfdConcept concept = ifdRoot.IfdConcept[iConc];
                worker.ReportProgress((int)(100.0 * (double)iConc / (double)ifdRoot.IfdConcept.Length));

                // api/4.0/IfdPSet/{guid}/ifcVersion/{ifcVersion}/XML

#if true//figure out version info // language code starting at 5th character then lowercase -- e.g. "IFC-2X4" -> "2x4"
                string ifcversion = "2x4";// "IFC4";// "ifc-2X4"; //???? what should this be ???? -- code "ifc-2X4" appears in headers; "IFC-2x4" appears in UI; "IFC4" is official schema name
                request = (HttpWebRequest)HttpWebRequest.Create(baseurl + "api/4.0/IfdPSet/" + concept.guid + "/ifcVersion/" + ifcversion + "/XML");
                request.Method = "GET";
                request.ContentLength = 0;
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Headers.Add("cookie", "peregrineapisessionid=" + sessionid);
                request.Accept = "application/xml";
#endif
#if false // worked April 1, but no longer works as of 2017-06-13 (http body returns "null" -- as in 4 character string) -- issue with test server -- CoBuilder merge wiped out content??
               
                request = (HttpWebRequest)HttpWebRequest.Create(baseurl + "api/4.0/IfdConcept/" + concept.guid + "/children");
                request.Method = "GET";
                request.ContentLength = 0;
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Headers.Add("cookie", "peregrineapisessionid=" + sessionid);
                request.Accept = "application/json";
                //request.Accept = "application/xml";

#endif
                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    stream = response.GetResponseStream();


                    reader = new System.IO.StreamReader(stream);
                    body = reader.ReadToEnd();
                    if (body != null && body != "null") // !!!!
                    {
                        ms = new MemoryStream();
                        writer = new StreamWriter(ms, Encoding.Unicode);
                        writer.Write(body);
                        writer.Flush();
                        ms.Position = 0;

                        try
                        {
                            using (FormatXML format = new FormatXML(ms, typeof(PropertySetDef), null, null))
                            {
                                format.Load();
                                PropertySetDef psd = (PropertySetDef)format.Instance;
                                Program.ImportPsd(psd, project);
                            }
                        }
                        catch
                        {
                            System.Diagnostics.Debug.WriteLine("Error downloading property set: " + concept.guid.ToString());
                        }


#if false
                        ResponsePset ifdResponse;
                        DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                        //settings.UseSimpleDictionaryFormat = true;
                        System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(ResponsePset));

                        try
                        {
                            System.IO.Stream xs = new System.IO.MemoryStream();
                            System.IO.StreamWriter xwriter = new System.IO.StreamWriter(xs);
                            xwriter.Write(body);
                            xwriter.Flush();
                            xs.Position = 0;

                            ifdResponse = (ResponsePset)ser.ReadObject(xs);

                            ifdResponse.ToString();


                            DocPropertySet docPset = new DocPropertySet();
                            docPset.Uuid = new Guid();// concept.guid;
                            foreach (IfdName ifdName in concept.fullNames)
                            {
                                // if english
                                if (ifdName.languageFamily == "IFC")
                                {
                                    docPset.Name = ifdName.name;
                                }
                                else
                                {
                                    DocLocalization docLoc = new DocLocalization();
                                    docLoc.Locale = ifdName.language.languageCode;
                                    docLoc.Name = ifdName.name;
                                    docPset.Localization.Add(docLoc);
                                }
                            }
                            docPset.Documentation = concept.definitions.description;
                            project.Sections[4].Schemas[0].PropertySets.Add(docPset);

                            foreach (IfdConceptInRelationship ifdProp in ifdResponse.IfdConceptInRelationship)
                            {
                                //ifdProp.fullNames[0].
                                DocProperty docProp = new DocProperty();
                                if (ifdProp.definitions != null)
                                {
                                    docProp.Documentation = ifdProp.definitions.description;
                                }
                                docPset.Properties.Add(docProp);

                                foreach (IfdName ifdName in ifdProp.fullNames)
                                {
                                    // if english
                                    if (ifdName.languageFamily == "IFC")
                                    {
                                        //docProp.Name = ifdName.name;
                                        string[] nameparts = ifdName.name.Split('.');
                                        if (nameparts.Length == 2)
                                        {
                                            docPset.Name = nameparts[0];
                                            docProp.Name = nameparts[1];
                                        }
                                    }
                                    else
                                    {
                                        DocLocalization docLoc = new DocLocalization();
                                        docLoc.Locale = ifdName.language.languageCode;
                                        docLoc.Name = ifdName.name;
                                        docProp.Localization.Add(docLoc);
                                    }
                                }
                            }
                        }
#endif
                    }
                }
                catch
                {
                    //...
                    return;
                }
            }
        }
    }

    [DataContract]
    public class ResponseSearch
    {
        [DataMember] public IfdConcept[] IfdConcept;
    }

    [DataContract]
    public class ResponsePset
    {
        [DataMember] public IfdConceptInRelationship[] IfdConceptInRelationship;
    }

    [DataContract]
    public class IfdConceptInRelationship : IfdConcept
    {
    }

    [DataContract]
    public class IfdConcept
    {
        [DataMember(Order = 0)] public string guid;
        [DataMember(Order = 1)] public string versionId;
        [DataMember(Order = 2)] public string versionDate;
        [DataMember(Order = 3)] public string status;
        [DataMember(Order = 4)] public IfdName[] fullNames;
        [DataMember(Order = 5)] public IfdDescription definitions;
        [DataMember(Order = 6)] public IfdDescription comments;
        [DataMember(Order = 7)] public string conceptType;
        [DataMember(Order = 8)] public IfdName[] shortNames;
        [DataMember(Order = 9)] public IfdName[] lexemes;
        [DataMember(Order = 10)] public IfdIllustration[] illustrations;
        [DataMember(Order = 11)] public IfdOrganization owner;
    }

    [DataContract]
    public class IfdIllustration : IfdLanguageRepresentationBase
    {
        [DataMember(Order = 0)] public string blobstoreKey;
        [DataMember(Order = 1)] public string illustrationUrl;
    }

    [DataContract]
    public class IfdOrganization
    {
        [DataMember(Order = 0)] public string guid;
        [DataMember(Order = 1)] public string name;
        [DataMember(Order = 2)] public string url;
    }

    public enum IfdConceptTypeEnum
    {
        NULL = 0,
        ACTOR = 1,
        ACTIVITY = 2,
        DOCUMENT = 3,
        PROPERTY = 4,
        SUBJECT = 5,
        UNIT = 6,
        MEASURE = 7,
        VALUE = 8,
        NEST = 9,
        BAG = 10,
        CLASSIFICATION = 11,
        UNDEFINED = -1,
    }

    [DataContract]
    public abstract class IfdLanguageRepresentationBase
    {
        [DataMember(Order = 0)] public string guid;
        [DataMember(Order = 1)] public IfdLanguage language;
        [DataMember(Order = 2)] public string languageFamily;

    }

    [DataContract]
    public class IfdName : IfdLanguageRepresentationBase
    {
        [DataMember(Order = 3)] public string name;
        [DataMember(Order = 4)] public string nameType;
    }

    [DataContract]
    public class IfdDescription : IfdLanguageRepresentationBase
    {
        [DataMember(Order = 3)] public string description;
        [DataMember(Order = 4)] public string descriptionType; // enum...
    }

    public enum IfdDescriptionTypeEnum
    {
        NULL = 0,
        DEFINITION = 1,
        COMMENT = 2,
        UNDEFINED = -1,
    }

    [DataContract]
    public class IfdLanguage
    {
        [DataMember(Order = 0)] public string guid;
        [DataMember(Order = 1)] public string nameInEnglish;
        [DataMember(Order = 2)] public string nameInSelf;
        [DataMember(Order = 3)] public string languageCode;
    }
}
