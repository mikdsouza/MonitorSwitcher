namespace MonitorSwitcherApp
{
    partial class SwitcherWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pButtonPanel = new System.Windows.Forms.Panel();
            this.bSaveProfile = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.gvProfiles = new System.Windows.Forms.DataGridView();
            this.bDelete = new System.Windows.Forms.Button();
            this.sfdProfileXML = new System.Windows.Forms.SaveFileDialog();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pButtonPanel
            // 
            this.pButtonPanel.Controls.Add(this.bDelete);
            this.pButtonPanel.Controls.Add(this.bReset);
            this.pButtonPanel.Controls.Add(this.bSaveProfile);
            this.pButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonPanel.Location = new System.Drawing.Point(0, 232);
            this.pButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pButtonPanel.Name = "pButtonPanel";
            this.pButtonPanel.Size = new System.Drawing.Size(284, 29);
            this.pButtonPanel.TabIndex = 1;
            // 
            // bSaveProfile
            // 
            this.bSaveProfile.Location = new System.Drawing.Point(3, 3);
            this.bSaveProfile.Name = "bSaveProfile";
            this.bSaveProfile.Size = new System.Drawing.Size(75, 23);
            this.bSaveProfile.TabIndex = 0;
            this.bSaveProfile.Text = "Save Profile";
            this.bSaveProfile.UseVisualStyleBackColor = true;
            this.bSaveProfile.Click += new System.EventHandler(this.bSaveProfile_Click);
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(105, 3);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 1;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Visible = false;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // gvProfiles
            // 
            this.gvProfiles.AllowUserToAddRows = false;
            this.gvProfiles.AllowUserToDeleteRows = false;
            this.gvProfiles.AllowUserToResizeRows = false;
            this.gvProfiles.AutoGenerateColumns = false;
            this.gvProfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn});
            this.gvProfiles.DataSource = this.profileBindingSource;
            this.gvProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProfiles.Location = new System.Drawing.Point(0, 0);
            this.gvProfiles.MultiSelect = false;
            this.gvProfiles.Name = "gvProfiles";
            this.gvProfiles.ReadOnly = true;
            this.gvProfiles.RowHeadersVisible = false;
            this.gvProfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProfiles.ShowEditingIcon = false;
            this.gvProfiles.Size = new System.Drawing.Size(284, 232);
            this.gvProfiles.TabIndex = 2;
            this.gvProfiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProfiles_CellDoubleClick);
            // 
            // bDelete
            // 
            this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bDelete.Location = new System.Drawing.Point(206, 3);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 2;
            this.bDelete.Text = "Delete Profile";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // sfdProfileXML
            // 
            this.sfdProfileXML.DefaultExt = "xml";
            this.sfdProfileXML.Filter = "XML Files (*.xml) | *.xml";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.ReadOnly = true;
            this.pathDataGridViewTextBoxColumn.Visible = false;
            // 
            // profileBindingSource
            // 
            this.profileBindingSource.DataSource = typeof(MonitorSwitcherApp.Profile);
            // 
            // SwitcherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gvProfiles);
            this.Controls.Add(this.pButtonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SwitcherWindow";
            this.Text = "SwitcherWindow";
            this.Load += new System.EventHandler(this.SwitcherWindow_Load);
            this.pButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pButtonPanel;
        private System.Windows.Forms.Button bSaveProfile;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.DataGridView gvProfiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource profileBindingSource;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.SaveFileDialog sfdProfileXML;
    }
}