using MonitorSwitcherGUI;
using MovablePython;
using System;
using System.Drawing;
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
                try
                {
                    AddToProfileList(DeserialiseProfile(s));
                }
                catch(FormatException)
                {
                    //Data is corrupted. Should not use any of it
                    Properties.Settings.Default.Reset();
                    Properties.Settings.Default.Save();

                    Properties.Settings.Default.Profiles = new System.Collections.Specialized.StringCollection();

                    return;
                }
            }
        }

        private void AddToProfileList(Profile profile)
        {
            profileBindingSource.Add(profile);

            //Something about the deseralisation process causes the hotkeys to not work
            //Have to do this to resolve it
            if (profile.Hotkey != null)
                profile.Hotkey = new Hotkey(profile.Hotkey.KeyCode, profile.Hotkey.Shift, 
                    profile.Hotkey.Control, profile.Hotkey.Alt, false);

            RegisterHotkey(profile);
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
                Properties.Settings.Default.Save();
            }
        }

        private void gvProfiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Profile selection = (Profile)profileBindingSource[e.RowIndex];

            selection = ChangeToProfile(selection);
        }

        private Profile ChangeToProfile(Profile selection)
        {
            if (File.Exists(selection.Path))
            {
                MonitorSwitcher.LoadDisplaySettings(selection.Path);
            }
            else
            {
                if (MessageBox.Show("Profile not found. Delete profile?", "Error", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    bDelete_Click(null, null);
                }
            }
            return selection;
        }

        //from http://stackoverflow.com/a/1718483
        private void gvProfiles_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int currentMouseOverRow = gvProfiles.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    profileBindingSource.Position = currentMouseOverRow;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Add Hotkey"));
                    m.MenuItems[0].Click += (s, eArgs) =>
                        {
                            GetHotkey getHotkey = new GetHotkey();
                            Profile selection = (Profile)profileBindingSource[currentMouseOverRow];

                            if(selection.Hotkey != null)
                            {
                                getHotkey.Key = selection.Hotkey.KeyCode;
                                getHotkey.Shift = selection.Hotkey.Shift;
                                getHotkey.Alt = selection.Hotkey.Alt;
                                getHotkey.Ctrl = selection.Hotkey.Control;
                            }

                            if (getHotkey.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                //Get the current position of this in the settings. We will have to save it there
                                int pos = Properties.Settings.Default.Profiles.IndexOf(SerialiseProfile(selection));

                                if (selection.Hotkey != null && selection.Hotkey.Registered)
                                {
                                    selection.Hotkey.Unregister();
                                }

                                selection.Hotkey = new Hotkey(getHotkey.Key, getHotkey.Shift, getHotkey.Ctrl, getHotkey.Alt, false);

                                //Save the profile in settings
                                Properties.Settings.Default.Profiles[pos] = SerialiseProfile(selection);                                

                                Properties.Settings.Default.Save();

                                RegisterHotkey(selection);
                            }
                        };

                    m.Show(gvProfiles, new Point(e.X, e.Y));
                }
            }
        }

        private void RegisterHotkey(Profile selection)
        {
            if (selection.Hotkey != null && !selection.Hotkey.Registered)
            {
                selection.Hotkey.Register(this);

                selection.Hotkey.Pressed += delegate { ChangeToProfile(selection); };
            }
        }

        private void SwitcherWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Unregister all the hotkeys
            foreach(Profile p in profileBindingSource)
            {
                if(p.Hotkey != null && p.Hotkey.Registered)
                {
                    p.Hotkey.Unregister();
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
