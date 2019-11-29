namespace ImageObjectExtration
{
    partial class Image_ListItem
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_Text = new System.Windows.Forms.Label();
            this.Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Text
            // 
            this.Label_Text.AutoSize = true;
            this.Label_Text.Font = new System.Drawing.Font("휴먼편지체", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Text.Location = new System.Drawing.Point(3, 122);
            this.Label_Text.Name = "Label_Text";
            this.Label_Text.Size = new System.Drawing.Size(58, 22);
            this.Label_Text.TabIndex = 1;
            this.Label_Text.Text = "label1";
            this.Label_Text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Image
            // 
            this.Image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Image.Location = new System.Drawing.Point(0, 0);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(150, 119);
            this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image.TabIndex = 0;
            this.Image.TabStop = false;
            // 
            // Image_ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label_Text);
            this.Controls.Add(this.Image);
            this.Name = "Image_ListItem";
            this.Click += new System.EventHandler(this.Image_ListItem_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Text;
        public System.Windows.Forms.PictureBox Image;

    }
}
