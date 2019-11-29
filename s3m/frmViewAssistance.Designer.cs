namespace s3m
{
    partial class frmViewAssistance
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
            this.gboxGroundGrid = new System.Windows.Forms.GroupBox();
            this.tbarGridLocationY = new System.Windows.Forms.TrackBar();
            this.tbarGridStep = new System.Windows.Forms.TrackBar();
            this.pboxGridColor = new System.Windows.Forms.PictureBox();
            this.tboxGridLocationY = new System.Windows.Forms.TextBox();
            this.lblGridLocation = new System.Windows.Forms.Label();
            this.lblGridColor = new System.Windows.Forms.Label();
            this.tboxGridStep = new System.Windows.Forms.TextBox();
            this.lblGridStep = new System.Windows.Forms.Label();
            this.lblGridSize = new System.Windows.Forms.Label();
            this.tboxGridSize = new System.Windows.Forms.TextBox();
            this.tbarGridSize = new System.Windows.Forms.TrackBar();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.gboxAxises = new System.Windows.Forms.GroupBox();
            this.pboxZColor = new System.Windows.Forms.PictureBox();
            this.pboxYColor = new System.Windows.Forms.PictureBox();
            this.lblZColor = new System.Windows.Forms.Label();
            this.lblYColor = new System.Windows.Forms.Label();
            this.pboxXColor = new System.Windows.Forms.PictureBox();
            this.lblXColor = new System.Windows.Forms.Label();
            this.tboxAxisesSize = new System.Windows.Forms.TextBox();
            this.tbarAxisesSize = new System.Windows.Forms.TrackBar();
            this.lblAxisSize = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDefalut = new System.Windows.Forms.Button();
            this.gboxGroundGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarGridLocationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarGridStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGridColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarGridSize)).BeginInit();
            this.gboxAxises.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxZColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxYColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxXColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarAxisesSize)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxGroundGrid
            // 
            this.gboxGroundGrid.Controls.Add(this.tbarGridLocationY);
            this.gboxGroundGrid.Controls.Add(this.tbarGridStep);
            this.gboxGroundGrid.Controls.Add(this.pboxGridColor);
            this.gboxGroundGrid.Controls.Add(this.tboxGridLocationY);
            this.gboxGroundGrid.Controls.Add(this.lblGridLocation);
            this.gboxGroundGrid.Controls.Add(this.lblGridColor);
            this.gboxGroundGrid.Controls.Add(this.tboxGridStep);
            this.gboxGroundGrid.Controls.Add(this.lblGridStep);
            this.gboxGroundGrid.Controls.Add(this.lblGridSize);
            this.gboxGroundGrid.Controls.Add(this.tboxGridSize);
            this.gboxGroundGrid.Controls.Add(this.tbarGridSize);
            this.gboxGroundGrid.Location = new System.Drawing.Point(12, 12);
            this.gboxGroundGrid.Name = "gboxGroundGrid";
            this.gboxGroundGrid.Size = new System.Drawing.Size(416, 141);
            this.gboxGroundGrid.TabIndex = 0;
            this.gboxGroundGrid.TabStop = false;
            this.gboxGroundGrid.Text = "GroundGrid";
            // 
            // tbarGridLocationY
            // 
            this.tbarGridLocationY.Location = new System.Drawing.Point(87, 83);
            this.tbarGridLocationY.Name = "tbarGridLocationY";
            this.tbarGridLocationY.Size = new System.Drawing.Size(104, 45);
            this.tbarGridLocationY.TabIndex = 9;
            this.tbarGridLocationY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarGridLocationY.Value = 3;
            this.tbarGridLocationY.Scroll += new System.EventHandler(this.tbarGridLocationY_Scroll);
            // 
            // tbarGridStep
            // 
            this.tbarGridStep.Location = new System.Drawing.Point(87, 50);
            this.tbarGridStep.Name = "tbarGridStep";
            this.tbarGridStep.Size = new System.Drawing.Size(104, 45);
            this.tbarGridStep.TabIndex = 4;
            this.tbarGridStep.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarGridStep.Value = 10;
            this.tbarGridStep.Scroll += new System.EventHandler(this.tbarGridStep_Scroll);
            // 
            // pboxGridColor
            // 
            this.pboxGridColor.BackColor = System.Drawing.Color.White;
            this.pboxGridColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pboxGridColor.Location = new System.Drawing.Point(320, 20);
            this.pboxGridColor.Name = "pboxGridColor";
            this.pboxGridColor.Size = new System.Drawing.Size(50, 21);
            this.pboxGridColor.TabIndex = 7;
            this.pboxGridColor.TabStop = false;
            this.pboxGridColor.Click += new System.EventHandler(this.pboxGridColor_Click);
            // 
            // tboxGridLocationY
            // 
            this.tboxGridLocationY.Location = new System.Drawing.Point(188, 83);
            this.tboxGridLocationY.Name = "tboxGridLocationY";
            this.tboxGridLocationY.ReadOnly = true;
            this.tboxGridLocationY.Size = new System.Drawing.Size(30, 21);
            this.tboxGridLocationY.TabIndex = 10;
            this.tboxGridLocationY.Text = "-0.3";
            // 
            // lblGridLocation
            // 
            this.lblGridLocation.AutoSize = true;
            this.lblGridLocation.Location = new System.Drawing.Point(6, 83);
            this.lblGridLocation.Name = "lblGridLocation";
            this.lblGridLocation.Size = new System.Drawing.Size(65, 12);
            this.lblGridLocation.TabIndex = 8;
            this.lblGridLocation.Text = "Location Y";
            // 
            // lblGridColor
            // 
            this.lblGridColor.AutoSize = true;
            this.lblGridColor.Location = new System.Drawing.Point(271, 23);
            this.lblGridColor.Name = "lblGridColor";
            this.lblGridColor.Size = new System.Drawing.Size(35, 12);
            this.lblGridColor.TabIndex = 6;
            this.lblGridColor.Text = "Color";
            // 
            // tboxGridStep
            // 
            this.tboxGridStep.Location = new System.Drawing.Point(188, 50);
            this.tboxGridStep.Name = "tboxGridStep";
            this.tboxGridStep.ReadOnly = true;
            this.tboxGridStep.Size = new System.Drawing.Size(30, 21);
            this.tboxGridStep.TabIndex = 5;
            this.tboxGridStep.Text = "10";
            // 
            // lblGridStep
            // 
            this.lblGridStep.AutoSize = true;
            this.lblGridStep.Location = new System.Drawing.Point(6, 53);
            this.lblGridStep.Name = "lblGridStep";
            this.lblGridStep.Size = new System.Drawing.Size(30, 12);
            this.lblGridStep.TabIndex = 3;
            this.lblGridStep.Text = "Step";
            // 
            // lblGridSize
            // 
            this.lblGridSize.AutoSize = true;
            this.lblGridSize.Location = new System.Drawing.Point(6, 23);
            this.lblGridSize.Name = "lblGridSize";
            this.lblGridSize.Size = new System.Drawing.Size(30, 12);
            this.lblGridSize.TabIndex = 2;
            this.lblGridSize.Text = "Size";
            // 
            // tboxGridSize
            // 
            this.tboxGridSize.Location = new System.Drawing.Point(188, 20);
            this.tboxGridSize.Name = "tboxGridSize";
            this.tboxGridSize.ReadOnly = true;
            this.tboxGridSize.Size = new System.Drawing.Size(30, 21);
            this.tboxGridSize.TabIndex = 1;
            this.tboxGridSize.Text = "100";
            // 
            // tbarGridSize
            // 
            this.tbarGridSize.Location = new System.Drawing.Point(87, 20);
            this.tbarGridSize.Name = "tbarGridSize";
            this.tbarGridSize.Size = new System.Drawing.Size(104, 45);
            this.tbarGridSize.TabIndex = 0;
            this.tbarGridSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarGridSize.Value = 10;
            this.tbarGridSize.Scroll += new System.EventHandler(this.tbarGridSize_Scroll);
            // 
            // gboxAxises
            // 
            this.gboxAxises.Controls.Add(this.pboxZColor);
            this.gboxAxises.Controls.Add(this.pboxYColor);
            this.gboxAxises.Controls.Add(this.lblZColor);
            this.gboxAxises.Controls.Add(this.lblYColor);
            this.gboxAxises.Controls.Add(this.pboxXColor);
            this.gboxAxises.Controls.Add(this.lblXColor);
            this.gboxAxises.Controls.Add(this.tboxAxisesSize);
            this.gboxAxises.Controls.Add(this.tbarAxisesSize);
            this.gboxAxises.Controls.Add(this.lblAxisSize);
            this.gboxAxises.Location = new System.Drawing.Point(12, 159);
            this.gboxAxises.Name = "gboxAxises";
            this.gboxAxises.Size = new System.Drawing.Size(416, 111);
            this.gboxAxises.TabIndex = 1;
            this.gboxAxises.TabStop = false;
            this.gboxAxises.Text = "Axises";
            // 
            // pboxZColor
            // 
            this.pboxZColor.BackColor = System.Drawing.Color.Blue;
            this.pboxZColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pboxZColor.Location = new System.Drawing.Point(320, 71);
            this.pboxZColor.Name = "pboxZColor";
            this.pboxZColor.Size = new System.Drawing.Size(50, 21);
            this.pboxZColor.TabIndex = 8;
            this.pboxZColor.TabStop = false;
            this.pboxZColor.Click += new System.EventHandler(this.pboxZColor_Click);
            // 
            // pboxYColor
            // 
            this.pboxYColor.BackColor = System.Drawing.Color.Green;
            this.pboxYColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pboxYColor.Location = new System.Drawing.Point(320, 44);
            this.pboxYColor.Name = "pboxYColor";
            this.pboxYColor.Size = new System.Drawing.Size(50, 21);
            this.pboxYColor.TabIndex = 7;
            this.pboxYColor.TabStop = false;
            this.pboxYColor.Click += new System.EventHandler(this.pboxYColor_Click);
            // 
            // lblZColor
            // 
            this.lblZColor.AutoSize = true;
            this.lblZColor.Location = new System.Drawing.Point(259, 78);
            this.lblZColor.Name = "lblZColor";
            this.lblZColor.Size = new System.Drawing.Size(47, 12);
            this.lblZColor.TabIndex = 6;
            this.lblZColor.Text = "Z Color";
            // 
            // lblYColor
            // 
            this.lblYColor.AutoSize = true;
            this.lblYColor.Location = new System.Drawing.Point(259, 49);
            this.lblYColor.Name = "lblYColor";
            this.lblYColor.Size = new System.Drawing.Size(47, 12);
            this.lblYColor.TabIndex = 5;
            this.lblYColor.Text = "Y Color";
            // 
            // pboxXColor
            // 
            this.pboxXColor.BackColor = System.Drawing.Color.Red;
            this.pboxXColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pboxXColor.Location = new System.Drawing.Point(320, 17);
            this.pboxXColor.Name = "pboxXColor";
            this.pboxXColor.Size = new System.Drawing.Size(50, 21);
            this.pboxXColor.TabIndex = 4;
            this.pboxXColor.TabStop = false;
            this.pboxXColor.Click += new System.EventHandler(this.pboxXColor_Click);
            // 
            // lblXColor
            // 
            this.lblXColor.AutoSize = true;
            this.lblXColor.Location = new System.Drawing.Point(259, 20);
            this.lblXColor.Name = "lblXColor";
            this.lblXColor.Size = new System.Drawing.Size(47, 12);
            this.lblXColor.TabIndex = 3;
            this.lblXColor.Text = "X Color";
            // 
            // tboxAxisesSize
            // 
            this.tboxAxisesSize.Location = new System.Drawing.Point(188, 16);
            this.tboxAxisesSize.Name = "tboxAxisesSize";
            this.tboxAxisesSize.ReadOnly = true;
            this.tboxAxisesSize.Size = new System.Drawing.Size(30, 21);
            this.tboxAxisesSize.TabIndex = 2;
            this.tboxAxisesSize.Text = "100";
            // 
            // tbarAxisesSize
            // 
            this.tbarAxisesSize.Location = new System.Drawing.Point(87, 16);
            this.tbarAxisesSize.Name = "tbarAxisesSize";
            this.tbarAxisesSize.Size = new System.Drawing.Size(104, 45);
            this.tbarAxisesSize.TabIndex = 1;
            this.tbarAxisesSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarAxisesSize.Value = 10;
            this.tbarAxisesSize.Scroll += new System.EventHandler(this.tbarAxisesSize_Scroll);
            // 
            // lblAxisSize
            // 
            this.lblAxisSize.AutoSize = true;
            this.lblAxisSize.Location = new System.Drawing.Point(6, 20);
            this.lblAxisSize.Name = "lblAxisSize";
            this.lblAxisSize.Size = new System.Drawing.Size(30, 12);
            this.lblAxisSize.TabIndex = 0;
            this.lblAxisSize.Text = "Size";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(358, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 30);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDefalut
            // 
            this.btnDefalut.Location = new System.Drawing.Point(282, 275);
            this.btnDefalut.Name = "btnDefalut";
            this.btnDefalut.Size = new System.Drawing.Size(70, 30);
            this.btnDefalut.TabIndex = 11;
            this.btnDefalut.Text = "Defalut";
            this.btnDefalut.UseVisualStyleBackColor = true;
            this.btnDefalut.Click += new System.EventHandler(this.btnDefalut_Click);
            // 
            // frmViewAssistance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 312);
            this.Controls.Add(this.btnDefalut);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gboxGroundGrid);
            this.Controls.Add(this.gboxAxises);
            this.Name = "frmViewAssistance";
            this.Text = "View Assistance";
            this.gboxGroundGrid.ResumeLayout(false);
            this.gboxGroundGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarGridLocationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarGridStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGridColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarGridSize)).EndInit();
            this.gboxAxises.ResumeLayout(false);
            this.gboxAxises.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxZColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxYColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxXColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarAxisesSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxGroundGrid;
        private System.Windows.Forms.Label lblGridStep;
        private System.Windows.Forms.Label lblGridSize;
        private System.Windows.Forms.TrackBar tbarGridSize;
        private System.Windows.Forms.TextBox tboxGridStep;
        private System.Windows.Forms.TrackBar tbarGridStep;
        private System.Windows.Forms.Label lblGridColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox gboxAxises;
        private System.Windows.Forms.Label lblAxisSize;
        private System.Windows.Forms.Label lblXColor;
        private System.Windows.Forms.TextBox tboxAxisesSize;
        private System.Windows.Forms.TrackBar tbarAxisesSize;
        private System.Windows.Forms.TextBox tboxGridLocationY;
        private System.Windows.Forms.TrackBar tbarGridLocationY;
        private System.Windows.Forms.Label lblGridLocation;
        private System.Windows.Forms.PictureBox pboxGridColor;
        private System.Windows.Forms.PictureBox pboxXColor;
        private System.Windows.Forms.Label lblYColor;
        private System.Windows.Forms.Label lblZColor;
        private System.Windows.Forms.PictureBox pboxZColor;
        private System.Windows.Forms.PictureBox pboxYColor;
        private System.Windows.Forms.TextBox tboxGridSize;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDefalut;

    }
}