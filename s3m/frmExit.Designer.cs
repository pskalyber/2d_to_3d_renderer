namespace s3m
{
    partial class frmExit
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
            this.saveY = new System.Windows.Forms.Button();
            this.saveNo = new System.Windows.Forms.Button();
            this.saveCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveY
            // 
            this.saveY.Location = new System.Drawing.Point(47, 49);
            this.saveY.Name = "saveY";
            this.saveY.Size = new System.Drawing.Size(90, 30);
            this.saveY.TabIndex = 0;
            this.saveY.Text = "저장(&Y)";
            this.saveY.UseVisualStyleBackColor = true;
            this.saveY.Click += new System.EventHandler(this.saveY_Click);
            // 
            // saveNo
            // 
            this.saveNo.Location = new System.Drawing.Point(145, 49);
            this.saveNo.Name = "saveNo";
            this.saveNo.Size = new System.Drawing.Size(90, 30);
            this.saveNo.TabIndex = 1;
            this.saveNo.Text = "저장 안 함(&N)";
            this.saveNo.UseVisualStyleBackColor = true;
            this.saveNo.Click += new System.EventHandler(this.saveNo_Click);
            // 
            // saveCancel
            // 
            this.saveCancel.Location = new System.Drawing.Point(241, 49);
            this.saveCancel.Name = "saveCancel";
            this.saveCancel.Size = new System.Drawing.Size(90, 30);
            this.saveCancel.TabIndex = 2;
            this.saveCancel.Text = "취소(&C)";
            this.saveCancel.UseVisualStyleBackColor = true;
            this.saveCancel.Click += new System.EventHandler(this.saveCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(44, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "작업 내용을 저장하시겠습니까?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 91);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveCancel);
            this.Controls.Add(this.saveNo);
            this.Controls.Add(this.saveY);
            this.Name = "frmExit";
            this.Text = "Simple 3D Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveY;
        private System.Windows.Forms.Button saveNo;
        private System.Windows.Forms.Button saveCancel;
        private System.Windows.Forms.Label label1;
    }
}