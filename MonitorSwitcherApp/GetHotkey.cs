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
        public Keys Key { get; private set; }
        public bool Ctrl { get { return cbCtrl.Checked; } }
        public bool Alt { get { return cbAlt.Checked; } }
        public bool Shift { get { return cbShift.Checked; } }

        public GetHotkey()
        {
            InitializeComponent();
        }

        private void tbHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Key = e.KeyCode;
            tbHotkey.Text = e.KeyCode.ToString();
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
