using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BuildingSmart.Serialization.Spf;

namespace BuildingSmart.Utilities.Validation
{
    public partial class FormValidator : Form
    {
        object m_target;
        Dictionary<long, object> m_instances;

        public FormValidator()
        {
            InitializeComponent();
        }

        public FormValidator(object target) : this()
        {
            this.m_target = target;

            // get the underlying IfcProject
            FieldInfo fieldTarget = typeof(BuildingSmart.Exchange.Concept).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)[0];
            object ifcProject = fieldTarget.GetValue(target);

            // retrieve dictionary of all objects
            Type typeProject = ifcProject.GetType();
            StepSerializer format = new StepSerializer(typeProject);
            using (MemoryStream stream = new MemoryStream())
            {
                format.WriteObject(stream, ifcProject);
                stream.Position = 0;
                format.ReadObject(stream, out this.m_instances);
            }
        }

        private void FormValidator_Load(object sender, EventArgs e)
        {
            Type[] types = this.m_target.GetType().Assembly.GetTypes();
            foreach (Type t in types)
            {
                if(t.IsPublic && t.IsClass && !t.IsAbstract)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = t;
                    tn.Text = t.Name;
                    this.treeView.Nodes.Add(tn);

                    PropertyInfo[] props = t.GetProperties();
                    foreach(PropertyInfo prop in props)
                    {
                        TreeNode tnProp = new TreeNode();
                        tnProp.Tag = prop;
                        tnProp.Text = prop.Name;
                        tn.Nodes.Add(tnProp);
                    }
                }
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.listView.Clear();

            this.textBoxHelp.Text = String.Empty;
            Type t = this.treeView.SelectedNode.Tag as Type;
            if (t != null)
            {
                DescriptionAttribute attr = t.GetCustomAttribute<DescriptionAttribute>();
                if (attr != null)
                {
                    this.textBoxHelp.Text = attr.Description;
                }

            }
            else
            {
                PropertyInfo prop = this.treeView.SelectedNode.Tag as PropertyInfo;
                if(prop != null)
                {
                    DescriptionAttribute attr = prop.GetCustomAttribute<DescriptionAttribute>();
                    if(attr != null)
                    {
                        this.textBoxHelp.Text = attr.Description;
                    }

                    t = this.treeView.SelectedNode.Parent.Tag as Type;
                }
            }

            if (t != null)
            {
                ColumnHeader colheaderIndex = new ColumnHeader();
                colheaderIndex.Text = "#";
                colheaderIndex.Width = 60;
                this.listView.Columns.Add(colheaderIndex);

                // build columns
                foreach(PropertyInfo prop in t.GetProperties())
                {
                    ColumnHeader colheader = new ColumnHeader();
                    colheader.Tag = prop;
                    colheader.Text = prop.Name;
                    colheader.Width = 120;
                    this.listView.Columns.Add(colheader);
                }

                // get all instances of type...

                // get the target type
                ConstructorInfo[] ctors = t.GetConstructors();
                foreach(ConstructorInfo ctor in ctors)
                {
                    ParameterInfo[] parms = ctor.GetParameters();
                    if(parms.Length == 1)
                    {
                        Type typeTarget = parms[0].ParameterType;
                        
                        foreach(object o in this.m_instances.Values)
                        {
                            if (typeTarget.IsInstanceOfType(o))
                            {
                                // create a wrapper exchange object
                                object exchangeInstance = Activator.CreateInstance(t, new object[] { o });

                                ListViewItem lvi = new ListViewItem();
                                lvi.Tag = o;
                                lvi.Text = (this.listView.Items.Count + 1).ToString();

                                for (int iCol = 1; iCol < this.listView.Columns.Count; iCol++)
                                {
                                    PropertyInfo propinfo = (PropertyInfo)this.listView.Columns[iCol].Tag;

                                    string text = String.Empty;

                                    try
                                    {
                                        object value = propinfo.GetValue(exchangeInstance);
                                        if (value != null)
                                        {
                                            text = value.ToString();
                                            if(value is ValueType)
                                            {
                                                FieldInfo[] fields = value.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
                                                if(fields.Length == 1)
                                                {
                                                    object elem = fields[0].GetValue(value);
                                                    if(elem != null)
                                                    {
                                                        text = elem.ToString();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Type vt = value.GetType();
                                                text = vt.Name;
                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }

                                    lvi.SubItems.Add(text);
                                }

                                this.listView.Items.Add(lvi);
                            }
                        }
                    }
                }
            }
        }
    }
}
