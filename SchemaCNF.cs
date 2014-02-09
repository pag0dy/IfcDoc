// Name:        SchemaCNF.cs
// Description: Schema for ISO-10303-28 configuraiton
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2013 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IfcDoc.Schema.CNF
{
    public static class SchemaCNF
    {
        static Dictionary<string, Type> s_types;

        public static Dictionary<string, Type> Types
        {
            get
            {
                if (s_types == null)
                {
                    s_types = new Dictionary<string, Type>();

                    Type[] types = typeof(SchemaCNF).Assembly.GetTypes();
                    foreach (Type t in types)
                    {
                        if (typeof(SEntity).IsAssignableFrom(t) && !t.IsAbstract && t.Namespace.Equals("IfcDoc.Schema.CNF"))
                        {
                            string name = t.Name.ToUpper();
                            s_types.Add(name, t);
                        }
                    }
                }

                return s_types;
            }
        }

        public const string DefaultNamespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language";
    }

    public class configuration
    {
        [XmlElement]
        public entity[] entity;
    }

    public class entity
    {
        [XmlAttribute]
        public string select;

        [XmlElement]
        public attribute[] attribute;

        [XmlElement]
        public inverse[] inverse;
    }

    public class attribute
    {
        [XmlAttribute]
        public string select;

        [XmlAttribute("exp-attribute")]
        public string exp_attribute;

        [XmlAttribute]
        public bool keep = true;

        [XmlAttribute]
        public bool tagless = false;
    }

    public class inverse
    {
        [XmlAttribute]
        public string select;

        [XmlAttribute("exp-attribute")]
        public string exp_attribute;
    }
}
