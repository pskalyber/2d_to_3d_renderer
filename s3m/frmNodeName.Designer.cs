namespace s3m
{
    partial class frmNodeName
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
            this.tboxNodeName = new System.Windows.Forms.TextBox();
            this.lblNodeName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tboxNodeName
            // 
            this.tboxNodeName.Location = new System.Drawing.Point(12, 26);
            this.tboxNodeName.Name = "tboxNodeName";
            this.tboxNodeName.Size = new System.Drawing.Size(155, 21);
            this.tboxNodeName.TabIndex = 0;
            this.tboxNodeName.Text = "Node Name";
            this.tboxNodeName.TextChanged += new System.EventHandler(this.tboxNodeName_TextChanged);
            this.tboxNodeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxNodeName_KeyPress);
            // 
            // lblNodeName
            // 
            this.lblNodeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNodeName.Location = new System.Drawing.Point(0, 0);
            this.lblNodeName.Name = "lblNodeName";
            this.lblNodeName.Size = new System.Drawing.Size(179, 23);
            this.lblNodeName.TabIndex = 1;
            this.lblNodeName.Text = "Enter ths Node\'s Name";
            this.lblNodeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(12, 53);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(92, 53);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmNodeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 88);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblNodeName);
            this.Controls.Add(this.tboxNodeName);
            this.Name = "frmNodeName";
            this.Text = "frmNodeName";
            this.Load += new System.EventHandler(this.frmNodeName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNodeName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox tboxNodeName;
    }
}