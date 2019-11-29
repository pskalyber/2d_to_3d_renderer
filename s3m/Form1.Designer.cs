using System.Drawing;
namespace ImageObjectExtration
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Size = new System.Windows.Forms.Label();
            this.flowLayoutPanel_Image = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox_Keyword = new System.Windows.Forms.TextBox();
            this.button_Internet = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox_View = new System.Windows.Forms.PictureBox();
            this.button_ZoomOut = new System.Windows.Forms.Button();
            this.button_Eraser = new System.Windows.Forms.Button();
            this.button_ZoomIn = new System.Windows.Forms.Button();
            this.button_Point = new System.Windows.Forms.Button();
            this.button_Fill = new System.Windows.Forms.Button();
            this.U_PicBox = new ImageObjectExtration.U_ScrollPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_View)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Size
            // 
            this.label_Size.AutoSize = true;
            this.label_Size.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Size.Location = new System.Drawing.Point(380, 474);
            this.label_Size.Name = "label_Size";
            this.label_Size.Size = new System.Drawing.Size(47, 29);
            this.label_Size.TabIndex = 9;
            this.label_Size.Text = "x1";
            this.label_Size.Visible = false;
            // 
            // flowLayoutPanel_Image
            // 
            this.flowLayoutPanel_Image.AutoScroll = true;
            this.flowLayoutPanel_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel_Image.Location = new System.Drawing.Point(598, 200);
            this.flowLayoutPanel_Image.Name = "flowLayoutPanel_Image";
            this.flowLayoutPanel_Image.Size = new System.Drawing.Size(202, 266);
            this.flowLayoutPanel_Image.TabIndex = 13;
            // 
            // textBox_Keyword
            // 
            this.textBox_Keyword.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Keyword.Location = new System.Drawing.Point(598, 472);
            this.textBox_Keyword.Name = "textBox_Keyword";
            this.textBox_Keyword.Size = new System.Drawing.Size(141, 22);
            this.textBox_Keyword.TabIndex = 12;
            this.textBox_Keyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Keyword_KeyDown);
            // 
            // button_Internet
            // 
            this.button_Internet.BackgroundImage = global::s3m.Properties.Resources.Untitled_4;
            this.button_Internet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Internet.Location = new System.Drawing.Point(745, 472);
            this.button_Internet.Name = "button_Internet";
            this.button_Internet.Size = new System.Drawing.Size(55, 22);
            this.button_Internet.TabIndex = 11;
            this.button_Internet.UseVisualStyleBackColor = true;
            this.button_Internet.Click += new System.EventHandler(this.button_Internet_Click_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.InterceptArrowKeys = false;
            this.numericUpDown1.Location = new System.Drawing.Point(558, 472);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(34, 21);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(316, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 27);
            this.label1.TabIndex = 19;
            this.label1.Text = "Size";
            this.label1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::s3m.Properties.Resources.Untitled_3;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(240, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 18;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::s3m.Properties.Resources.undo;
            this.button1.Location = new System.Drawing.Point(88, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox_View
            // 
            this.pictureBox_View.BackColor = System.Drawing.Color.White;
            this.pictureBox_View.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_View.Location = new System.Drawing.Point(598, 14);
            this.pictureBox_View.Name = "pictureBox_View";
            this.pictureBox_View.Size = new System.Drawing.Size(202, 180);
            this.pictureBox_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_View.TabIndex = 15;
            this.pictureBox_View.TabStop = false;
            // 
            // button_ZoomOut
            // 
            this.button_ZoomOut.Image = global::s3m.Properties.Resources.zoomout;
            this.button_ZoomOut.Location = new System.Drawing.Point(202, 472);
            this.button_ZoomOut.Name = "button_ZoomOut";
            this.button_ZoomOut.Size = new System.Drawing.Size(32, 32);
            this.button_ZoomOut.TabIndex = 8;
            this.button_ZoomOut.UseVisualStyleBackColor = true;
            this.button_ZoomOut.Click += new System.EventHandler(this.button_ZoomOut_Click);
            // 
            // button_Eraser
            // 
            this.button_Eraser.Image = global::s3m.Properties.Resources.Eraser_icon;
            this.button_Eraser.Location = new System.Drawing.Point(126, 472);
            this.button_Eraser.Name = "button_Eraser";
            this.button_Eraser.Size = new System.Drawing.Size(32, 32);
            this.button_Eraser.TabIndex = 7;
            this.button_Eraser.UseVisualStyleBackColor = true;
            this.button_Eraser.Click += new System.EventHandler(this.button_Eraser_Click);
            // 
            // button_ZoomIn
            // 
            this.button_ZoomIn.Image = global::s3m.Properties.Resources.zoomin;
            this.button_ZoomIn.Location = new System.Drawing.Point(164, 472);
            this.button_ZoomIn.Name = "button_ZoomIn";
            this.button_ZoomIn.Size = new System.Drawing.Size(32, 32);
            this.button_ZoomIn.TabIndex = 6;
            this.button_ZoomIn.UseVisualStyleBackColor = true;
            this.button_ZoomIn.Click += new System.EventHandler(this.button_ZoomIn_Click);
            // 
            // button_Point
            // 
            this.button_Point.Image = global::s3m.Properties.Resources.brush;
            this.button_Point.Location = new System.Drawing.Point(12, 472);
            this.button_Point.Name = "button_Point";
            this.button_Point.Size = new System.Drawing.Size(32, 32);
            this.button_Point.TabIndex = 5;
            this.button_Point.UseVisualStyleBackColor = true;
            this.button_Point.Click += new System.EventHandler(this.button_Point_Click);
            // 
            // button_Fill
            // 
            this.button_Fill.Image = global::s3m.Properties.Resources.Paint_icon;
            this.button_Fill.Location = new System.Drawing.Point(50, 472);
            this.button_Fill.Name = "button_Fill";
            this.button_Fill.Size = new System.Drawing.Size(32, 32);
            this.button_Fill.TabIndex = 4;
            this.button_Fill.UseVisualStyleBackColor = true;
            this.button_Fill.Click += new System.EventHandler(this.button_Fill_Click);
            // 
            // U_PicBox
            // 
            this.U_PicBox.AutoScroll = true;
            this.U_PicBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.U_PicBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.U_PicBox.Image = null;
            this.U_PicBox.Location = new System.Drawing.Point(12, 14);
            this.U_PicBox.Name = "U_PicBox";
            this.U_PicBox.OffsetX = 0;
            this.U_PicBox.OffsetY = 0;
            this.U_PicBox.Size = new System.Drawing.Size(580, 452);
            this.U_PicBox.TabIndex = 0;
            this.U_PicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.userPictureBox1_MouseUp);
            this.U_PicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.U_PicBox_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox_View);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.flowLayoutPanel_Image);
            this.Controls.Add(this.textBox_Keyword);
            this.Controls.Add(this.button_Internet);
            this.Controls.Add(this.label_Size);
            this.Controls.Add(this.button_ZoomOut);
            this.Controls.Add(this.button_Eraser);
            this.Controls.Add(this.button_ZoomIn);
            this.Controls.Add(this.button_Point);
            this.Controls.Add(this.button_Fill);
            this.Controls.Add(this.U_PicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "ImageObjectExtration";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Fill;
        private System.Windows.Forms.Button button_Point;
        private System.Windows.Forms.Button button_ZoomIn;
        private System.Windows.Forms.Button button_Eraser;
        private System.Windows.Forms.Button button_ZoomOut;
        private System.Windows.Forms.Label label_Size;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Image;
        private System.Windows.Forms.TextBox textBox_Keyword;
        private System.Windows.Forms.Button button_Internet;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pictureBox_View;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

