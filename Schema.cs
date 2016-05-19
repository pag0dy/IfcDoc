// Name:        FormatSPF.cs
// Description: Base classes for schema support
// Author:      Tim Chipman
// Origination: This is based on prior work of Constructivity donated to BuildingSmart at no charge.
// Copyright:   (c) 2010 BuildingSmart International Ltd., (c) 2006-2010 Constructivity.com LLC.
// Note:        This specific file has dual copyright such that both organizations maintain all rights to its use.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace IfcDoc.Schema
{
    /// <summary>
    /// Base class for any record (including entities and commands)
    /// </summary>
    [DataContract]
    public abstract class SRecord
    {
        private long m_localID;
#if false
        private bool m_existing;
#endif
        public SRecord()
        {
        }

        [Browsable(false), XmlIgnore(), IgnoreDataMember]
        public long OID
        {
            get
            {
                return this.m_localID;
            }
            set
            {
                if (this.m_localID != 0)
                {
                    throw new InvalidOperationException("OID has already been set and cannot be changed.");
                }

                this.m_localID = value;
            }
        }

#if false
        [Browsable(false), XmlIgnore(), IgnoreDataMember]
        public bool Existing
        {
            get
            {
                return this.m_existing;
            }
            set
            {
                this.m_existing = value;
            }
        }
#endif

        public virtual void Delete()
        {
            this.m_localID = -1; // debug value indicated object was deleted
        }
    }

    /// <summary>
    /// Base class for header elements
    /// </summary>
    public abstract class SHeader : SRecord
    {
    }

    [Flags]
    public enum FieldScope
    {
        Direct = 1,
        Inverse = 2,
        All = 3,
    }

    /// <summary>
    /// A context-bound object that can query relationships or pull content dynamically from broker
    /// </summary>
    [DataContract]
    public abstract class SEntity : SRecord,
        ICloneable
    {
        static Dictionary<Type, IList<FieldInfo>> s_fieldmap = new Dictionary<Type, IList<FieldInfo>>(); // cached field lists in declaration order
        static Dictionary<Type, IList<FieldInfo>> s_inversemap = new Dictionary<Type, IList<FieldInfo>>();
        static Dictionary<Type, IList<FieldInfo>> s_fieldallmap = new Dictionary<Type, IList<FieldInfo>>();
        static Dictionary<Type, IList<PropertyInfo>> s_propertymapdeclared = new Dictionary<Type, IList<PropertyInfo>>(); // cached properties per type
        static Dictionary<Type, IList<PropertyInfo>> s_propertymapinverse = new Dictionary<Type, IList<PropertyInfo>>(); // cached properties per type

        public static event EventHandler EntityCreated;
        public static event EventHandler EntityDeleted;

        public static FieldInfo GetFieldByName(Type type, string name)
        {
            IList<FieldInfo> fields = SEntity.GetFieldsOrdered(type);
            foreach (FieldInfo field in fields)
            {
                if (field.Name.Equals(name))
                    return field;
            }

            return null;
        }

        public static IList<FieldInfo> GetFieldsAll(Type type)
        {
            IList<FieldInfo> fields = null;
            if (s_fieldallmap.TryGetValue(type, out fields))
            {
                return fields;
            }

            fields = new List<FieldInfo>();
            BuildFieldList(type, fields, FieldScope.All);
            s_fieldallmap.Add(type, fields);

            return fields;
        }

        public static IList<FieldInfo> GetFieldsOrdered(Type type)
        {
            IList<FieldInfo> fields = null;
            if (s_fieldmap.TryGetValue(type, out fields))
            {
                return fields;
            }

            fields = new List<FieldInfo>();
            BuildFieldList(type, fields, FieldScope.Direct);
            s_fieldmap.Add(type, fields);

            return fields;
        }

        public static IList<FieldInfo> GetFieldsInverse(Type type)
        {
            IList<FieldInfo> fields = null;
            if (s_inversemap.TryGetValue(type, out fields))
            {
                return fields;
            }

            fields = new List<FieldInfo>();
            BuildFieldList(type, fields, FieldScope.Inverse);
            s_inversemap.Add(type, fields);

            return fields;
        }

        private static void BuildFieldList(Type type, IList<FieldInfo> list, FieldScope scope)
        {
            if (type.IsValueType && ((scope & FieldScope.Direct)!=0))
            {
                FieldInfo fieldinfo = type.GetField("Value");
                if (fieldinfo != null)
                {
                    list.Add(fieldinfo);
                }
                return;
            }

            if (type.BaseType != null && type.BaseType != typeof(object) && type.BaseType != typeof(SEntity))
            {
                BuildFieldList(type.BaseType, list, scope);
            }

            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            FieldInfo[] sorted = new FieldInfo[fields.Length];

            if ((scope & FieldScope.Direct) != 0)
            {
                foreach (FieldInfo field in fields)
                {
                    if (field.IsDefined(typeof(DataMemberAttribute), false))
                    {
                        DataMemberAttribute attr = (DataMemberAttribute)field.GetCustomAttributes(typeof(DataMemberAttribute), false)[0];
                        sorted[attr.Order] = field;
                    }
                }

                foreach (FieldInfo sort in sorted)
                {
                    if (sort != null)
                    {
                        list.Add(sort);
                    }
                }
            }

            if ((scope & FieldScope.Inverse) != 0)
            {
                foreach (FieldInfo field in fields)
                {
                    if (field.IsDefined(typeof(DataLookupAttribute), false))
                    {
                        // sort order...
                        list.Add(field);
                    }
                }
            }
        }


        // INSTANCE methods

        public SEntity()
        {
            if (SEntity.EntityCreated != null)
            {
                SEntity.EntityCreated(this, EventArgs.Empty);
            }
        }

        public override void Delete()
        {
            if (SEntity.EntityDeleted != null)
            {
                SEntity.EntityDeleted(this, EventArgs.Empty);
            }

            // call base AFTER event notification such that OID remains while removing from list
            base.Delete();
        }

#if false
        /// <summary>
        /// Marks object as in-use (setting Exists to True) such that any unmarked objects may then be garbage collected.
        /// </summary>
        public void Mark()
        {
            if (this.Existing)
                return;

            this.Existing = true;

            Type t = this.GetType();
            IList<FieldInfo> listFields = SEntity.GetFieldsOrdered(t);
            foreach (FieldInfo field in listFields)
            {
                if (typeof(SEntity).IsAssignableFrom(field.FieldType))
                {
                    SEntity obj = field.GetValue(this) as SEntity;
                    if(obj != null)
                    {
                        obj.Mark();
                    }
                }
                else if(field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>) &&
                    typeof(SEntity).IsAssignableFrom(field.FieldType.GetGenericArguments()[0]))

                {
                    System.Collections.IList list = (System.Collections.IList)field.GetValue(this) as System.Collections.IList;
                    if(list != null)
                    {
                        foreach(object obj in list)
                        {
                            if(obj is SEntity)
                            {
                                SEntity ent = (SEntity)obj;
                                ent.Mark();
                            }
                        }
                    }
                }
            }
        }
#endif
        /// <summary>
        /// Gets user-friendly caption describing the type of object.
        /// </summary>
        /// <returns></returns>
        public virtual string GetTypeCaption()
        {
            // use display name if one exists
            if (this.GetType().IsDefined(typeof(DisplayNameAttribute), false))
            {
                DisplayNameAttribute attr = (DisplayNameAttribute)this.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), false)[0];
                return attr.DisplayName;
            }

            // try base class (i.e. BeamStandardCase -> Beam)
            if (this.GetType().BaseType.IsDefined(typeof(DisplayNameAttribute), false))
            {
                DisplayNameAttribute attr = (DisplayNameAttribute)this.GetType().BaseType.GetCustomAttributes(typeof(DisplayNameAttribute), false)[0];
                return attr.DisplayName;
            }


            // fall back on internal type
            return this.GetType().Name;
        }



        public virtual object Clone()
        {
            Type t = this.GetType();

            // make a copy, attached to broker
            SEntity clone = (SEntity)Activator.CreateInstance(t);

            // reference all registered fields
            IList<FieldInfo> fields = SEntity.GetFieldsOrdered(t);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsValueType || field.FieldType == typeof(string))
                {
                    // copy over value types
                    object val = field.GetValue(this);
                    field.SetValue(clone, val);
                }
                else if (field.FieldType.IsInterface || typeof(SEntity).IsAssignableFrom(field.FieldType))
                {
                    // make unique copy of referenced type except for owner history!!!
                    object val = field.GetValue(this);
                    if (val is SEntity)
                    {
                        SEntity sentity = (SEntity)val;

                        SEntity valclone = (SEntity)sentity.Clone();
                        field.SetValue(clone, valclone);
                    }
                    else
                    {
                        field.SetValue(clone, val);
                    }
                }
                else if (typeof(IList).IsAssignableFrom(field.FieldType))
                {
                    IList listSource = (IList)field.GetValue(this);
                    if (listSource != null)
                    {
                        // don't copy collections, but initialize new collection
                        System.Collections.IList listClone = (System.Collections.IList)Activator.CreateInstance(field.FieldType);
                        field.SetValue(clone, listClone);

                        Type[] genericargs = field.FieldType.GetGenericArguments();
                        if (genericargs.Length == 1)
                        {
                            foreach (object element in listSource)
                            {
                                object elemClone = null;

                                // clone resources -- don't carry over rooted objects
                                if (element is ICloneable)
                                {
                                    // clone resources, list of list, e.g. IfcBSplineSurface
                                    elemClone = ((ICloneable)element).Clone();
                                }
                                else
                                {
                                    // i.e. length coordinate
                                    elemClone = element;
                                }

                                // now add to list, INCLUDING IF NULL such as blank entries of table
                                listClone.Add(elemClone);
                            }
                        }
                    }
                }
            }

            return clone;
        }
    }

#if false // use .net WCF attributes now

    /// <summary>
    /// This shadows the WCF definition, allowing for future forward compatibility
    /// </summary>
    public class DataContractAttribute : System.Attribute
    {
    }

    /// <summary>
    /// This shadows the WCF definition, allowing for future forward compatibility
    /// </summary>
    [
    AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false),
    ]
    public class DataMemberAttribute : System.Attribute
    {
        int m_order;
        string m_name;
        bool m_required;

        public DataMemberAttribute()
        {
            m_order = 0; // unordered; 1+ means ordered
            m_required = false;
        }

        public DataMemberAttribute(int order)
        {
            m_order = order;
            m_required = false;
        }

        public int Order
        {
            get
            {
                return m_order;
            }
            set
            {
                m_order = value;
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        public bool IsRequired
        {
            get
            {
                return m_required;
            }
            set
            {
                m_required = value;
            }
        }
    }
#endif

    /// <summary>
    /// Indicates that field is populated by looking up a field on a target object.
    /// </summary>
    [
    AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false),
    ]
    public class DataLookupAttribute : System.Attribute
    {
        string m_name;

        public DataLookupAttribute()
        {
            this.m_name = null;
        }

        public DataLookupAttribute(string name)
        {
            this.m_name = name;
        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }
    }

    [
    DisplayName("Description"),
    DataContract, Serializable,
    ]
    public class FILE_DESCRIPTION : SHeader
    {
        [DataMember(Order = 0)]
        public List<string> description;
        [DataMember(Order = 1)]
        public string implementation_level;

        public FILE_DESCRIPTION()
        {
            this.description = new List<string>();
            this.implementation_level = "2;1";
        }
    }

    [
    DisplayName("File"),
    DataContract, Serializable,
    ]
    public class FILE_NAME : SHeader
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
        {
            this.name = null;
            this.time_stamp = DateTime.UtcNow;
            this.author = new List<string>();
            this.organization = new List<string>();
            this.preprocessor_version = null;
            this.originating_system = null;
            this.authorization = null;
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

    [
    DisplayName("Schema"),
    DataContract, Serializable,
    ]
    public class FILE_SCHEMA : SHeader
    {
        [DataMember(Order = 0)]
        public List<string> schema;

        public FILE_SCHEMA()
        {
            this.schema = new List<string>();
        }
    }

    public struct SGuid
    {
        [DataMember(Order = 0)] string _Value; // holds string for persistence
        Guid _Guid; // holds GUID for optimal performance

        public SGuid(Guid value)
        {
            this._Guid = value;
            this._Value = Format(value);
        }

        public override string ToString()
        {
            return this._Value.ToString();
        }

        public Guid ToGuid()
        {
            return this._Guid;
        }

        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Guid = SGuid.Parse(value);
                this._Value = value;
            }
        }

        public static SGuid New()
        {
            return new SGuid(Guid.NewGuid());
        }

        private static string cConversionTable = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_$";

        public static Guid Parse(string format64)
        {
            if (format64 == null)
            {
                return Guid.Empty;
            }

            if (format64.Contains("-"))
            {
                return new Guid(format64);
            }

            int i, j, m;
            uint[] num = new uint[6];            

            format64 = format64.Trim('\'');

            if (format64.Length != 22)
            {
                throw new ArgumentException("Invalid Global ID Length: " + format64);
            }

            j = 0;
            m = 2;

            for (i = 0; i < 6; i++)
            {
                string temp = format64.Substring(j, m);
                j = j + m;
                m = 4;

                num[i] = cv_from_64(temp);
            }

            uint Data1 = (uint)(num[0] * 16777216 + num[1]);                 // 16-13. bytes
            ushort Data2 = (ushort)(num[2] / 256);                              // 12-11. bytes
            ushort Data3 = (ushort)((num[2] % 256) * 256 + num[3] / 65536);     // 10-09. bytes

            byte Data4_0 = (byte)((num[3] / 256) % 256);                   //    08. byte
            byte Data4_1 = (byte)(num[3] % 256);                           //    07. byte
            byte Data4_2 = (byte)(num[4] / 65536);                         //    06. byte
            byte Data4_3 = (byte)((num[4] / 256) % 256);                   //    05. byte
            byte Data4_4 = (byte)(num[4] % 256);                           //    04. byte
            byte Data4_5 = (byte)(num[5] / 65536);                         //    03. byte
            byte Data4_6 = (byte)((num[5] / 256) % 256);                   //    02. byte
            byte Data4_7 = (byte)(num[5] % 256);                           //    01. byte

            return new Guid(Data1, Data2, Data3, Data4_0, Data4_1, Data4_2, Data4_3, Data4_4, Data4_5, Data4_6, Data4_7);
        }

        public static string Format(Guid pGuid)
        {
            uint[] num = new uint[6];
            int i, n;

            byte[] comp = pGuid.ToByteArray();
            uint Data1 = BitConverter.ToUInt32(comp, 0);
            ushort Data2 = BitConverter.ToUInt16(comp, 4);
            ushort Data3 = BitConverter.ToUInt16(comp, 6);
            byte Data4_0 = comp[8];
            byte Data4_1 = comp[9];
            byte Data4_2 = comp[10];
            byte Data4_3 = comp[11];
            byte Data4_4 = comp[12];
            byte Data4_5 = comp[13];
            byte Data4_6 = comp[14];
            byte Data4_7 = comp[15];

            //
            // Creation of six 32 Bit integers from the components of the GUID structure
            //
            num[0] = (uint)(Data1 / 16777216);                                                 //    16. byte  (pGuid->Data1 / 16777216) is the same as (pGuid->Data1 >> 24)
            num[1] = (uint)(Data1 % 16777216);                                                 // 15-13. bytes (pGuid->Data1 % 16777216) is the same as (pGuid->Data1 & 0xFFFFFF)
            num[2] = (uint)(Data2 * 256 + Data3 / 256);                                 // 12-10. bytes
            num[3] = (uint)((Data3 % 256) * 65536 + Data4_0 * 256 + Data4_1);  // 09-07. bytes
            num[4] = (uint)(Data4_2 * 65536 + Data4_3 * 256 + Data4_4);       // 06-04. bytes
            num[5] = (uint)(Data4_5 * 65536 + Data4_6 * 256 + Data4_7);       // 03-01. bytes

            StringBuilder buf = new StringBuilder();

            //
            // Conversion of the numbers into a system using a base of 64
            //
            n = 2;
            for (i = 0; i < 6; i++)
            {
                string temp = cv_to_64(num[i], n);
                buf.Append(temp);
                n = 4;
            }

            return buf.ToString();
        }

        //
        // Conversion of an integer into a number with base 64
        // using the coside table cConveronTable
        //
        private static string cv_to_64(uint number, int nDigits)
        {
            uint act;
            int iDigit;
            char[] result = new char[nDigits];

            act = number;

            for (iDigit = 0; iDigit < nDigits; iDigit++)
            {
                result[nDigits - iDigit - 1] = cConversionTable[(int)(act % 64)];
                act /= 64;
            }

            if (act != 0)
            {
                throw new ArgumentException("Number out of range");
            }

            return new string(result);
        }

        //
        // The reverse function to calculate the number from the code
        //
        private static uint cv_from_64(string str)
        {
            int len, i, j, index;

            len = str.Length;
            if (len > 4)
            {
                throw new ArgumentException("Invalid Global ID Format");
            }

            uint pRes = 0;

            for (i = 0; i < len; i++)
            {
                index = -1;
                for (j = 0; j < 64; j++)
                {
                    if (cConversionTable[j] == str[i])
                    {
                        index = j;
                        break;
                    }
                }

                if (index == -1)
                {
                    throw new ArgumentException("Invalid Global ID Format");
                }

                pRes = (uint)(pRes * 64 + index);
            }

            return pRes;
        }
    }


}
