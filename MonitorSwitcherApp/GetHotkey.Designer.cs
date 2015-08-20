namespace MonitorSwitcherApp
{
    partial class GetHotkey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetHotkey));
            this.tbHotkey = new System.Windows.Forms.TextBox();
            this.lSetHotkey = new System.Windows.Forms.Label();
            this.cbCtrl = new System.Windows.Forms.CheckBox();
            this.cbAlt = new System.Windows.Forms.CheckBox();
            this.cbShift = new System.Windows.Forms.CheckBox();
            this.bOkay = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbHotkey
            // 
            this.tbHotkey.Location = new System.Drawing.Point(75, 12);
            this.tbHotkey.Name = "tbHotkey";
            this.tbHotkey.ReadOnly = true;
            this.tbHotkey.Size = new System.Drawing.Size(197, 20);
            this.tbHotkey.TabIndex = 0;
            this.tbHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbHotkey_KeyDown);
            // 
            // lSetHotkey
            // 
            this.lSetHotkey.AutoSize = true;
            this.lSetHotkey.Location = new System.Drawing.Point(9, 15);
            this.lSetHotkey.Name = "lSetHotkey";
            this.lSetHotkey.Size = new System.Drawing.Size(60, 13);
            this.lSetHotkey.TabIndex = 1;
            this.lSetHotkey.Text = "Set Hotkey";
            // 
            // cbCtrl
            // 
            this.cbCtrl.AutoSize = true;
            this.cbCtrl.Checked = true;
            this.cbCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCtrl.Location = new System.Drawing.Point(12, 40);
            this.cbCtrl.Name = "cbCtrl";
            this.cbCtrl.Size = new System.Drawing.Size(41, 17);
            this.cbCtrl.TabIndex = 2;
            this.cbCtrl.Text = "Ctrl";
            this.cbCtrl.UseVisualStyleBackColor = true;
            // 
            // cbAlt
            // 
            this.cbAlt.AutoSize = true;
            this.cbAlt.Checked = true;
            this.cbAlt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAlt.Location = new System.Drawing.Point(59, 40);
            this.cbAlt.Name = "cbAlt";
            this.cbAlt.Size = new System.Drawing.Size(38, 17);
            this.cbAlt.TabIndex = 3;
            this.cbAlt.Text = "Alt";
            this.cbAlt.UseVisualStyleBackColor = true;
            // 
            // cbShift
            // 
            this.cbShift.AutoSize = true;
            this.cbShift.Location = new System.Drawing.Point(103, 40);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(47, 17);
            this.cbShift.TabIndex = 4;
            this.cbShift.Text = "Shift";
            this.cbShift.UseVisualStyleBackColor = true;
            // 
            // bOkay
            // 
            this.bOkay.Location = new System.Drawing.Point(12, 63);
            this.bOkay.Name = "bOkay";
            this.bOkay.Size = new System.Drawing.Size(75, 23);
            this.bOkay.TabIndex = 5;
            this.bOkay.Text = "Ok";
            this.bOkay.UseVisualStyleBackColor = true;
            this.bOkay.Click += new System.EventHandler(this.bOkay_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(93, 63);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 6;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // GetHotkey
            // 
            this.AcceptButton = this.bOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(284, 93);
            this.ControlBox = false;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOkay);
            this.Controls.Add(this.cbShift);
            this.Controls.Add(this.cbAlt);
            this.Controls.Add(this.cbCtrl);
            this.Controls.Add(this.lSetHotkey);
            this.Controls.Add(this.tbHotkey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetHotkey";
            this.ShowInTaskbar = false;
            this.Text = "Get Hotkey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHotkey;
        private System.Windows.Forms.Label lSetHotkey;
        private System.Windows.Forms.CheckBox cbCtrl;
        private System.Windows.Forms.CheckBox cbAlt;
        private System.Windows.Forms.CheckBox cbShift;
        private System.Windows.Forms.Button bOkay;
        private System.Windows.Forms.Button bCancel;
    }
}