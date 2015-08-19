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
    public partial class SwitcherWindow : Form
    {
        public SwitcherWindow()
        {
            InitializeComponent();
        }

        private void SwitcherWindow_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Profiles == null)
                Properties.Settings.Default.Profiles = new System.Collections.Specialized.StringCollection();

            //Get profiles from the settings
            AddStringsToProfileList(Properties.Settings.Default.Profiles.Cast<string>().ToArray());

            //Hide the reset button if need be
            #if DEBUG
                bReset.Visible = true;
                pathDataGridViewTextBoxColumn.Visible = true;
            #endif
        }

        private void AddStringsToProfileList(params string[] profiles)
        {
            foreach(string s in profiles)
            {
                profileBindingSource.Add(new Profile { Name = s, Path = s });
            }
        }

        private void bSaveProfile_Click(object sender, EventArgs e)
        {
            AddStringsToProfileList("lol");
            Properties.Settings.Default.Profiles.Add("lol");
            Properties.Settings.Default.Save();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            profileBindingSource.Clear();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (profileBindingSource.Current != null)
            {
                Profile selection = (Profile)profileBindingSource.Current;
                MessageBox.Show(selection.Path);
            }
        }
    }

    public struct Profile
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
