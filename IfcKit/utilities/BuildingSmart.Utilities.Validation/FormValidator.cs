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

using BuildingSmart.Exchange;
using BuildingSmart.Serialization.Step;

namespace BuildingSmart.Utilities.Validation
{
    public partial class FormValidator : Form
    {
        object m_project;
        Dictionary<string, Concept> m_targets;
        Dictionary<long, object> m_instances;

        Dictionary<Type, Dictionary<object, string[]>> m_results;
        Dictionary<Type, int[]> m_propstat;
        Dictionary<Type, int> m_counteach;
        Dictionary<Type, int> m_countpass;

        public FormValidator()
        {
            InitializeComponent();
        }

        public FormValidator(object project, Dictionary<string, Concept> targets)
            : this()
        {
            this.m_project = project;
            this.m_targets = targets;

            // get the underlying IfcProject
            if (this.m_project != null)
            {
                try
                {
                    // retrieve dictionary of all objects
                    Type typeProject = this.m_project.GetType();
                    StepSerializer format = new StepSerializer(typeProject);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        format.WriteObject(stream, this.m_project);
                        stream.Position = 0;
                        format.ReadObject(stream, out this.m_instances);
                    }
                }
                catch (Exception xx)
                {
                    MessageBox.Show(this, "There was an error serializing the data:\r\n\r\n" + xx.Message, "Validation Error");
                }
            }
        }

        private void FormValidator_Load(object sender, EventArgs e)
        {
            // populate the tree from top-level
            foreach (string modelview in this.m_targets.Keys)
            {
                Concept concept = this.m_targets[modelview];                

                TreeNode tnView = new TreeNode();
                tnView.Tag = concept;
                tnView.Text = modelview;
                this.treeView.Nodes.Add(tnView);

                SortedList<string, Type> listTypes = new SortedList<string, Type>();

                Type[] types = concept.GetType().Assembly.GetTypes();
                foreach (Type t in types)
                {
                    if (t.IsPublic && t.IsClass && !t.IsAbstract && t.Namespace.Equals(concept.GetType().Namespace))
                    {
                        string dispname = t.Name;
                        DisplayNameAttribute disp = (DisplayNameAttribute)t.GetCustomAttribute(typeof(DisplayNameAttribute));
                        if(disp != null)
                        {
                            dispname = disp.DisplayName;
                        }

                        listTypes.Add(dispname, t);
                    }
                }

                foreach(string sort in listTypes.Keys)
                {
                    Type t = listTypes[sort];

                    TreeNode tn = new TreeNode();
                    tn.Tag = t;
                    tn.Text = sort;
                    tnView.Nodes.Add(tn);

                    PropertyInfo[] props = t.GetProperties();
                    foreach (PropertyInfo prop in props)
                    {
                        if (prop.Name != "Target")
                        {
                            TreeNode tnProp = new TreeNode();
                            tnProp.Tag = prop;
                            tnProp.Text = prop.Name;
                            tn.Nodes.Add(tnProp);
                        }
                    }
                }
            }

            this.backgroundWorker.RunWorkerAsync();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.listView.Clear();

            this.textBoxHelp.Text = String.Empty;
            Type t = this.treeView.SelectedNode.Tag as Type;
            if (this.treeView.SelectedNode == this.treeView.Nodes[0])
            {
                this.textBoxHelp.Text = "Information exchange for building a bridge. [FHWA Design-to-Construction information change updated for IFC 4.1]";
            }
            else if (this.treeView.SelectedNode == this.treeView.Nodes[1])
            {
                this.textBoxHelp.Text = "Information exchange for structural analysis of a bridge. [For illustration purposes -- not implemented].";
            }
            else if (t != null)
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
                if (prop != null)
                {
                    t = this.treeView.SelectedNode.Parent.Tag as Type;

                    string mapval = String.Empty;
                    PropertyInfo fieldMap = t.GetProperty(prop.Name, BindingFlags.Static | BindingFlags.NonPublic);
                    if (fieldMap != null)
                    {
                        mapval = fieldMap.GetValue(null) as string;
                    }

                    string desval = String.Empty;
                    DescriptionAttribute attr = prop.GetCustomAttribute<DescriptionAttribute>();
                    if (attr != null)
                    {
                        desval = attr.Description;
                    }

                    this.textBoxHelp.Text = desval + "\r\n\r\n" + mapval;
                }
            }

            if (t != null)
            {
                ColumnHeader colheaderIndex = new ColumnHeader();
                colheaderIndex.Text = "#";
                colheaderIndex.Width = 60;
                colheaderIndex.ImageIndex = 0;
                this.listView.Columns.Add(colheaderIndex);

                // build columns
                PropertyInfo[] props = t.GetProperties();
                Color[] colors = new Color[props.Length];
                int iColor = 0;
                foreach (PropertyInfo prop in props)
                {
                    if (prop.Name != "Target")
                    {
                        ColumnHeader colheader = new ColumnHeader();
                        colheader.Tag = prop;
                        colheader.Text = prop.Name;
                        colheader.Width = 120;
                        colheader.ImageIndex = 0;
                        this.listView.Columns.Add(colheader);
                    }

                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        colors[iColor] = Color.LimeGreen; // optional
                    }
                    else if(prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(ISet<>))
                    {
                        colors[iColor] = Color.Orange; // list reference
                    }
                    else if(prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                    {
                        colors[iColor] = Color.Orange; // reference
                    }
                    else
                    {
                        colors[iColor] = Color.Yellow; // required property
                    }

                    iColor++;
                }

                // get all instances of type...

                // get the target type
                Dictionary<object, string[]> results = null;
                if (!this.m_results.TryGetValue(t, out results))
                    return;

                int[] tracker = new int[this.listView.Columns.Count];


                Font fontUnderline = new Font(this.listView.Font, FontStyle.Underline);

                foreach (object o in results.Keys)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Tag = o;
                    lvi.Text = (this.listView.Items.Count + 1).ToString();
                    lvi.UseItemStyleForSubItems = false;

                    string[] vals = results[o];

                    bool pass = true;
                    for (int iCol = 1; iCol < this.listView.Columns.Count; iCol++)
                    {
                        string text = vals[iCol - 1];

                        Color colorBack = colors[iCol - 1];

                        ListViewItem.ListViewSubItem lviSub = new ListViewItem.ListViewSubItem();
                        lviSub.Text = text;
                        lviSub.BackColor = colorBack;
                        
                        PropertyInfo prop = props[iCol - 1];
                        if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                        {
                            //lviSub.Font = fontUnderline;
                        }

                        lvi.SubItems.Add(lviSub);//text, listView.ForeColor, colorBack, this.listView.Font);

                        if (!String.IsNullOrEmpty(text))
                        {
                            tracker[iCol]++;
                        }
                        else
                        {
                            pass = false;
                        }
                    }

                    lvi.ImageIndex = (pass ? 1 : 2);
                    this.listView.Items.Add(lvi);

                    if(pass)
                    {
                        tracker[0]++;
                    }
                }

                for(int i = 0; i < tracker.Length; i++)
                {
                    int count = tracker[i];
                    if (this.listView.Items.Count == 0)
                    {
                        this.listView.Columns[i].ImageIndex = 0; // no instances
                    }
                    else if(count == this.listView.Items.Count)
                    {
                        // all pass
                        this.listView.Columns[i].ImageIndex = 1;
                    }
                    else if(count == 0)
                    {
                        // all fail
                        this.listView.Columns[i].ImageIndex = 2;
                    }
                    else
                    {
                        // some pass
                        this.listView.Columns[i].ImageIndex = 3;
                    }
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.m_results = new Dictionary<Type, Dictionary<object, string[]>>();
            this.m_propstat = new Dictionary<Type, int[]>();
            this.m_counteach = new Dictionary<Type, int>();
            this.m_countpass = new Dictionary<Type, int>();

            foreach (Concept concept in this.m_targets.Values)
            {
                Type[] types = concept.GetType().Assembly.GetTypes();
                for (int iType = 0; iType < types.Length; iType++)
                {
                    Type t = types[iType];

                    if (t.IsPublic && t.IsClass && !t.IsAbstract && !this.m_results.ContainsKey(t))
                    {
                        PropertyInfo[] props = t.GetProperties();
                        int[] proppass = new int[props.Length];

                        Dictionary<object, string[]> map = new Dictionary<object, string[]>();
                        this.m_results.Add(t, map);
                        this.m_propstat.Add(t, proppass);

                        // find all instances. record
                        ConstructorInfo[] ctors = t.GetConstructors();
                        foreach (ConstructorInfo ctor in ctors)
                        {
                            ParameterInfo[] parms = ctor.GetParameters();
                            if (parms.Length == 1)
                            {
                                Type typeTarget = parms[0].ParameterType;

                                int countpass = 0;
                                int countobjs = 0;
                                foreach (object o in this.m_instances.Values)
                                {
                                    // also check for predefined type...
                                    if (typeTarget.IsInstanceOfType(o) && !map.ContainsKey(o))
                                    {
                                        // create a wrapper exchange object
                                        Concept exchangeInstance = (Concept)Activator.CreateInstance(t, new object[] { o });
                                        if (exchangeInstance.Target != null)
                                        {
                                            string[] vals = new string[props.Length];
                                            map.Add(o, vals);

                                            countobjs++;

                                            bool pass = true;
                                            for (int iCol = 0; iCol < props.Length; iCol++)
                                            {
                                                PropertyInfo propinfo = props[iCol];

                                                string text = String.Empty;

                                                try
                                                {
                                                    object value = propinfo.GetValue(exchangeInstance);
                                                    if (value is System.Collections.IList)
                                                    {
                                                        System.Collections.IList list = (System.Collections.IList)value;
                                                        if (list.Count > 0)
                                                        {
                                                            text = "(" + list.Count + ")";
                                                        }
                                                    }
                                                    else if (value != null)
                                                    {
                                                        text = value.ToString();
                                                        if (value is ValueType)
                                                        {
                                                            while(value is ValueType)
                                                            { 
                                                                PropertyInfo[] fields = value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                                                                if (fields.Length == 1)
                                                                {
                                                                    value = fields[0].GetValue(value);
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                            }

                                                            if (value != null)
                                                            {
                                                                text = value.ToString();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Type vt = value.GetType();
                                                            text = vt.Name;

                                                            // override with value if provided
                                                            PropertyInfo propName = vt.GetProperty("Name");
                                                            {
                                                                if (propName != null)
                                                                {
                                                                    object oname = propName.GetValue(value);
                                                                    if (oname != null)
                                                                    {
                                                                        PropertyInfo propValue = oname.GetType().GetProperty("Value");
                                                                        if (propValue != null)
                                                                        {
                                                                            object oval = propValue.GetValue(oname);
                                                                            if (oval is string)
                                                                            {
                                                                                text = (string)oval;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }
                                                }
                                                catch (Exception xx)
                                                {
                                                    xx.ToString();
                                                }

                                                vals[iCol] = text;

                                                if (String.IsNullOrEmpty(text))
                                                {
                                                    pass = false;
                                                }
                                                else
                                                {
                                                    proppass[iCol]++; 
                                                }
                                            }


                                            if (pass)
                                            {
                                                countpass++;
                                            }
                                        }
                                    }
                                }

                                lock (this.m_counteach)
                                {
                                    this.m_counteach.Add(t, countobjs);
                                    this.m_countpass.Add(t, countpass);
                                }
                            }
                        }
                    }

                    int prog = (int)(100.0 * (double)iType / (double)types.Length);
                    this.backgroundWorker.ReportProgress(prog, t);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar.Value = e.ProgressPercentage;
            if (e.UserState is Type)
            {
                Type t = (Type)e.UserState;
                lock (this.m_counteach)
                {
                    int counteach = 0;
                    int countpass = 0;
                    int[] proppass = null;
                    if (this.m_counteach.TryGetValue(t, out counteach) &&
                        this.m_countpass.TryGetValue(t, out countpass) &&
                        this.m_propstat.TryGetValue(t, out proppass))
                    {
                        // find the tree item
                        foreach(TreeNode tnView in this.treeView.Nodes)
                        {
                            foreach(TreeNode tnRoot in tnView.Nodes)
                            {
                                if (tnRoot.Tag == t)
                                {
                                    if (counteach == 0)
                                    {
                                        tnRoot.ImageIndex = 0;
                                    }
                                    else if(counteach == countpass)
                                    {
                                        tnRoot.ImageIndex = 1;
                                    }
                                    else if(countpass == 0)
                                    {
                                        tnRoot.ImageIndex = 2;
                                    }
                                    else 
                                    {
                                        tnRoot.ImageIndex = 3;
                                    }
                                    tnRoot.SelectedImageIndex = tnRoot.ImageIndex;

                                    int nProp = 0;
                                    foreach (TreeNode tnProp in tnRoot.Nodes)
                                    {
                                        if (counteach == 0)
                                        {
                                            tnProp.ImageIndex = 0;
                                        }
                                        else if(proppass[nProp] == counteach)
                                        {
                                            tnProp.ImageIndex = 1;
                                        }
                                        else if(proppass[nProp] == 0)
                                        {
                                            tnProp.ImageIndex = 2;
                                        }
                                        else
                                        {
                                            tnProp.ImageIndex = 3;
                                        }

                                        tnProp.SelectedImageIndex = tnProp.ImageIndex;
                                        nProp++;
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripStatusLabel1.Text = String.Empty;
            this.toolStripProgressBar.Visible = false;

            int[] stattotal = new int[4];

            foreach(TreeNode tnView in this.treeView.Nodes)
            {
                int[] stat = new int[4];

                foreach (TreeNode tnConc in tnView.Nodes)
                {
                    stat[tnConc.ImageIndex]++;
                    stattotal[tnConc.ImageIndex]++;
                }

                if(stat[0] == tnView.Nodes.Count)
                {
                    // no data
                    tnView.ImageIndex = 0;
                }
                else if (stat[2] == 0 && stat[3] == 0)
                {
                    // all pass
                    tnView.ImageIndex = 1;
                }
                else if (stat[1] == 0)
                {
                    // all fail
                    tnView.ImageIndex = 2;
                }
                else
                {
                    // some pass, some fail
                    tnView.ImageIndex = 3;
                }

                tnView.SelectedImageIndex = tnView.ImageIndex;
            }

            this.toolStripStatusLabelNone.Text = "No Data (" + stattotal[0] + ")";
            this.toolStripStatusLabelPass.Text = "Pass (" + stattotal[1] + ")";
            this.toolStripStatusLabelPartial.Text = "Partial (" + stattotal[3] + ")";
            this.toolStripStatusLabelFail.Text = "Fail (" + stattotal[2] + ")";

        }
    }
}
