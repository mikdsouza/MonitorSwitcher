using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorSwitcherApp
{
    public partial class GetHotkey : Form
    {
        private Keys key;
        public Keys Key
        {
            get { return key; }
            set
            {
                key = value;
                tbHotkey.Text = value.ToString();
            }
        }

        public bool Ctrl { 
            get { return cbCtrl.Checked; }
            set { cbCtrl.Checked = value; }
        }

        public bool Alt { 
            get { return cbAlt.Checked; }
            set { cbAlt.Checked = value; }
        }

        public bool Shift { 
            get { return cbShift.Checked; }
            set { cbShift.Checked = value; }
        }

        public GetHotkey()
        {
            InitializeComponent();
        }

        private void tbHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Key = e.KeyCode;
        }

        private void bOkay_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
