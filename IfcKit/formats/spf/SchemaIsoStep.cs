using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

// schema known to ISO step files - includes headers only
// IFC-specific schema defined in Constructivity.Schema.IFC

namespace BuildingSmart.Serialization.Spf
{
    /// <summary>
    /// STEP file header for indicating file options.
    /// </summary>
    [
    DisplayName("Description"),
    DataContract, Serializable,
    ]
    public class FILE_DESCRIPTION
    {
        [DataMember(Order = 0)]
        List<string> description;
        [DataMember(Order = 1)]
        string implementation_level;

        public FILE_DESCRIPTION()
        {
            this.description = new List<string>();
            this.implementation_level = "2;1";
        }

        public List<string> Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string ImplementationLevel
        {
            get
            {
                return this.implementation_level;
            }
        }

        // extensions IFC-specific

        private string[] GetDescriptionValues(string keyword)
        {
            List<string> list = new List<string>();
            foreach (string s in this.description)
            {
                int head = s.IndexOf('[');
                int tail = s.LastIndexOf(']');

                if (head >= 0 && tail >= 0)
                {
                    string eachword = s.Substring(0, head).Trim();
                    if (eachword.Equals(keyword))
                    {
                        string args = s.Substring(head + 1, tail - head - 1);
                        string[] parts = args.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string p in parts)
                        {
                            list.Add(p);
                        }
                    }
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Returns a text field by concatenating multiple entries (limited to 246 characters each).
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private string GetDescriptionText(string keyword)
        {
            string[] parts = this.GetDescriptionValues(keyword);
            if (parts.Length == 0)
            {
                return null;
            }
            else if (parts.Length == 1)
            {
                return parts[0];
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string p in parts)
                {
                    sb.Append(p);
                }
                return sb.ToString();
            }
        }

        private void SetDescriptionValues(string keyword, string[] values)
        {
            // validate lengths
            if (values != null)
            {
                foreach (string v in values)
                {
                    if (keyword.Length + v.Length + 3 > 256)
                    {
                        throw new ArgumentException("Length of keyword followed by each value must be 256 characters or less.");
                    }
                }
            }

            // clear out existing
            for (int i = this.description.Count - 1; i >= 0; i--)
            {
                string s = this.description[i];
                int head = s.IndexOf('[');
                int tail = s.LastIndexOf(']');
                if (head >= 0 && tail >= 0)
                {
                    string eachword = s.Substring(0, head).Trim();
                    if (eachword.Equals(keyword))
                    {
                        this.description.RemoveAt(i);
                    }
                }
            }

            // append new values
            if (values != null)
            {
                foreach (string v in values)
                {
                    this.description.Add(keyword + " [" + v + "]");
                }
            }
        }

        /// <summary>
        /// Sets text field by splitting into segments (may exceed 256 characters per line).
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="text"></param>
        private void SetDescriptionText(string keyword, string text)
        {
            int maxlen = 256 - 3 - keyword.Length;

            if (text == null)
            {
                SetDescriptionValues(keyword, null);
            }
            else if (text.Length > maxlen)
            {
                int n = text.Length / maxlen + 1;
                string[] parts = new string[n];
                for (int i = 0; i < n; i++)
                {
                    if (i == n - 1)
                    {
                        parts[i] = text.Substring(i * maxlen);
                    }
                    else
                    {
                        parts[i] = text.Substring(i * maxlen, maxlen);
                    }
                }
                SetDescriptionValues(keyword, parts);
            }
            else
            {
                SetDescriptionValues(keyword, new string[] { text });
            }
        }

        public string[] GetIfcViewDefinitions()
        {
            return this.GetDescriptionValues("ViewDefinition");
        }

        public void SetIfcViewDefinitions(string[] vals)
        {
            this.SetDescriptionValues("ViewDefinition", vals);
        }

        public string[] GetIfcOptions()
        {
            return this.GetDescriptionValues("Option");
        }

        public string GetIfcComments()
        {
            return this.GetDescriptionText("Comment");
        }

        public void SetIfcComments(string comments)
        {
            this.SetDescriptionText("Comment", comments);
        }

  
    }

    /// <summary>
    /// STEP file header for name, date, application, and authoring information
    /// </summary>
    [
    DisplayName("File"),
    DataContract, Serializable,
    ]
    public class FILE_NAME
    {
        [DataMember(Order = 0)]
        string name;
        [DataMember(Order = 1)]
        DateTime time_stamp;
        [DataMember(Order = 2)]
        List<string> author;
        [DataMember(Order = 3)]
        List<string> organization;
        [DataMember(Order = 4)]
        string preprocessor_version;
        [DataMember(Order = 5)]
        string originating_system;
        [DataMember(Order = 6)]
        string authorization;

        public FILE_NAME()
            : this(null, null, null, null, null)
        {
        }

        public FILE_NAME(string thename, string theauthor, string theorganization, string preprocessor, string system)
        {
            this.name = thename;
            this.time_stamp = DateTime.UtcNow;
            this.author = new List<string>();
            this.author.Add(theauthor);
            this.organization = new List<string>();
            this.organization.Add(theorganization);
            this.preprocessor_version = preprocessor;
            this.originating_system = system;
            this.authorization = "";
        }

        [DataMember(Order = 0)]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        [DataMember(Order = 1)]
        public DateTime Timestamp
        {
            get
            {
                return this.time_stamp;
            }
            set
            {
                this.time_stamp = value;
            }
        }

        [DataMember(Order = 2)]
        public List<string> Author
        {
            get
            {
                return this.author;
            }
        }

        [DataMember(Order = 3)]
        public List<string> Organization
        {
            get
            {
                return this.organization;
            }
        }

        [DataMember(Order = 4)]
        public string PreprocessorVersion
        {
            get
            {
                return this.preprocessor_version;
            }
            set
            {
                this.preprocessor_version = value;
            }
        }

        [DataMember(Order = 5)]
        public string OriginatingSystem
        {
            get
            {
                return this.originating_system;
            }
            set
            {
                this.originating_system = value;
            }
        }

        [DataMember(Order = 6)]
        public string Authorization
        {
            get
            {
                return this.authorization;
            }
            set
            {
                this.authorization = value;
            }
        }
    }

    /// <summary>
    /// STEP file header for identifying the schema.
    /// </summary>
    [
    DisplayName("Schema"),
    DataContract, Serializable,
    ]
    public class FILE_SCHEMA
    {
        [DataMember(Order = 0)]
        public List<string> schema;

        public FILE_SCHEMA()
        {
            this.schema = new List<string>();
        }
    }
}
