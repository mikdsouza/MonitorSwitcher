using MonitorSwitcherGUI;
using MovablePython;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
                AddToProfileList(DeserialiseProfile(s));
            }
        }

        private void AddToProfileList(Profile profile)
        {
            profileBindingSource.Add(profile);
        }

        private void bSaveProfile_Click(object sender, EventArgs e)
        {
            if(sfdProfileXML.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MonitorSwitcher.SaveDisplaySettings(sfdProfileXML.FileName);

                //Seralise the information
                Profile profile = new Profile { Name = Path.GetFileNameWithoutExtension(sfdProfileXML.FileName), 
                    Path = sfdProfileXML.FileName };
                string serialisedProfile = SerialiseProfile(profile);

                AddToProfileList(profile);
                Properties.Settings.Default.Profiles.Add(serialisedProfile);
                Properties.Settings.Default.Save();
            }
        }

        private string SerialiseProfile(Profile profile)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            
            formatter.Serialize(stream, profile);

            stream.Position = 0;
            BinaryReader br = new BinaryReader(stream);
            byte[] bytes = br.ReadBytes((int)stream.Length);

            return Convert.ToBase64String(bytes);
        }

        private Profile DeserialiseProfile(string profile)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();

            byte[] bytes = Convert.FromBase64String(profile);
            stream.Write(bytes, 0, bytes.Length);
            stream.Position = 0;

            return (Profile)formatter.Deserialize(stream);
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
                
                if(File.Exists(selection.Path))
                {
                    File.Delete(selection.Path);
                }

                profileBindingSource.RemoveCurrent();
                Properties.Settings.Default.Profiles.Remove(selection.Path);
            }
        }

        private void gvProfiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Profile selection = (Profile)profileBindingSource[e.RowIndex];

            if (File.Exists(selection.Path))
            {
                MonitorSwitcher.LoadDisplaySettings(selection.Path);
            }
            else
            {
                if(MessageBox.Show("Profile not found. Delete profile?", "Error", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Error,MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    bDelete_Click(sender, null);
                }
            }
        }
    }

    [Serializable]
    public struct Profile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Hotkey Hotkey { get; set; }
    }
}
