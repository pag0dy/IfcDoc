using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IfcDoc
{
    public partial class FormCredentials : Form
    {
        public FormCredentials()
        {
            InitializeComponent();
        }

        public string Username
        {
            get
            {
                return this.textBox1.Text;
            }
        }

        // no sense in using SecureString as it will be sent in the clear anyways
        public string Password
        {
            get
            {
                return this.textBox2.Text;
            }
        }
    }
}
