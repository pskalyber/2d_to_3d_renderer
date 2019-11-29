namespace s3m
{
    partial class tools
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
            this.components = new System.ComponentModel.Container();
            this.lblObject = new System.Windows.Forms.Label();
            this.lblControl = new System.Windows.Forms.Label();
            this.lblDrawing = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnEyes = new System.Windows.Forms.Button();
            this.btnRotateAxis = new System.Windows.Forms.Button();
            this.btnTranslateAxis = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.pBoxZ = new System.Windows.Forms.PictureBox();
            this.pBoxY = new System.Windows.Forms.PictureBox();
            this.pBoxX = new System.Windows.Forms.PictureBox();
            this.btnGlrotation = new System.Windows.Forms.Button();
            this.btnGlScale = new System.Windows.Forms.Button();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnChoice = new System.Windows.Forms.Button();
            this.btnZminus = new System.Windows.Forms.Button();
            this.btnYminus = new System.Windows.Forms.Button();
            this.btnZplus = new System.Windows.Forms.Button();
            this.btnYplus = new System.Windows.Forms.Button();
            this.btnXminus = new System.Windows.Forms.Button();
            this.btnXplus = new System.Windows.Forms.Button();
            this.btnPen = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnRect = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.lblView = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxX)).BeginInit();
            this.SuspendLayout();
            // 
            // lblObject
            // 
            this.lblObject.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblObject.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblObject.Location = new System.Drawing.Point(2, 112);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(29, 15);
            this.lblObject.TabIndex = 8;
            this.lblObject.Text = "Object";
            this.lblObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblControl
            // 
            this.lblControl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblControl.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblControl.Location = new System.Drawing.Point(0, 223);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(61, 15);
            this.lblControl.TabIndex = 8;
            this.lblControl.Text = "Control";
            this.lblControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDrawing
            // 
            this.lblDrawing.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblDrawing.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDrawing.Location = new System.Drawing.Point(2, 0);
            this.lblDrawing.Name = "lblDrawing";
            this.lblDrawing.Size = new System.Drawing.Size(59, 15);
            this.lblDrawing.TabIndex = 8;
            this.lblDrawing.Text = "Tool";
            this.lblDrawing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnEyes
            // 
            this.btnEyes.FlatAppearance.BorderSize = 0;
            this.btnEyes.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnEyes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnEyes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEyes.Image = global::s3m.Properties.Resources.camera;
            this.btnEyes.Location = new System.Drawing.Point(32, 191);
            this.btnEyes.Name = "btnEyes";
            this.btnEyes.Size = new System.Drawing.Size(30, 30);
            this.btnEyes.TabIndex = 18;
            this.btnEyes.UseVisualStyleBackColor = true;
            this.btnEyes.Click += new System.EventHandler(this.btnEyes_Click);
            // 
            // btnRotateAxis
            // 
            this.btnRotateAxis.FlatAppearance.BorderSize = 0;
            this.btnRotateAxis.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnRotateAxis.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnRotateAxis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRotateAxis.Image = global::s3m.Properties.Resources.rotateAxis;
            this.btnRotateAxis.Location = new System.Drawing.Point(32, 160);
            this.btnRotateAxis.Name = "btnRotateAxis";
            this.btnRotateAxis.Size = new System.Drawing.Size(30, 30);
            this.btnRotateAxis.TabIndex = 17;
            this.btnRotateAxis.UseVisualStyleBackColor = true;
            this.btnRotateAxis.Click += new System.EventHandler(this.btnRotateAxis_Click);
            // 
            // btnTranslateAxis
            // 
            this.btnTranslateAxis.FlatAppearance.BorderSize = 0;
            this.btnTranslateAxis.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnTranslateAxis.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnTranslateAxis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTranslateAxis.Image = global::s3m.Properties.Resources.translateAxis;
            this.btnTranslateAxis.Location = new System.Drawing.Point(32, 129);
            this.btnTranslateAxis.Name = "btnTranslateAxis";
            this.btnTranslateAxis.Size = new System.Drawing.Size(30, 30);
            this.btnTranslateAxis.TabIndex = 16;
            this.btnTranslateAxis.UseVisualStyleBackColor = true;
            this.btnTranslateAxis.Click += new System.EventHandler(this.btnTranslateAxis_Click);
            // 
            // btnApply
            // 
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApply.Image = global::s3m.Properties.Resources._3d;
            this.btnApply.Location = new System.Drawing.Point(32, 80);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(30, 30);
            this.btnApply.TabIndex = 15;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pBoxZ
            // 
            this.pBoxZ.BackgroundImage = global::s3m.Properties.Resources.z;
            this.pBoxZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBoxZ.Location = new System.Drawing.Point(23, 305);
            this.pBoxZ.Name = "pBoxZ";
            this.pBoxZ.Size = new System.Drawing.Size(15, 30);
            this.pBoxZ.TabIndex = 14;
            this.pBoxZ.TabStop = false;
            // 
            // pBoxY
            // 
            this.pBoxY.BackgroundImage = global::s3m.Properties.Resources.y;
            this.pBoxY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBoxY.Location = new System.Drawing.Point(23, 273);
            this.pBoxY.Name = "pBoxY";
            this.pBoxY.Size = new System.Drawing.Size(15, 30);
            this.pBoxY.TabIndex = 14;
            this.pBoxY.TabStop = false;
            // 
            // pBoxX
            // 
            this.pBoxX.BackgroundImage = global::s3m.Properties.Resources.x;
            this.pBoxX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBoxX.Location = new System.Drawing.Point(23, 241);
            this.pBoxX.Name = "pBoxX";
            this.pBoxX.Size = new System.Drawing.Size(15, 30);
            this.pBoxX.TabIndex = 14;
            this.pBoxX.TabStop = false;
            // 
            // btnGlrotation
            // 
            this.btnGlrotation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGlrotation.FlatAppearance.BorderSize = 0;
            this.btnGlrotation.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnGlrotation.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnGlrotation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGlrotation.Image = global::s3m.Properties.Resources.rotation;
            this.btnGlrotation.Location = new System.Drawing.Point(1, 160);
            this.btnGlrotation.Name = "btnGlrotation";
            this.btnGlrotation.Size = new System.Drawing.Size(30, 30);
            this.btnGlrotation.TabIndex = 13;
            this.btnGlrotation.UseVisualStyleBackColor = true;
            this.btnGlrotation.Click += new System.EventHandler(this.btnGlrotation_Click);
            // 
            // btnGlScale
            // 
            this.btnGlScale.FlatAppearance.BorderSize = 0;
            this.btnGlScale.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnGlScale.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnGlScale.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGlScale.Image = global::s3m.Properties.Resources.scale;
            this.btnGlScale.Location = new System.Drawing.Point(1, 129);
            this.btnGlScale.Name = "btnGlScale";
            this.btnGlScale.Size = new System.Drawing.Size(30, 30);
            this.btnGlScale.TabIndex = 13;
            this.btnGlScale.UseVisualStyleBackColor = true;
            this.btnGlScale.Click += new System.EventHandler(this.btnGlScale_Click);
            // 
            // btnTranslate
            // 
            this.btnTranslate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTranslate.FlatAppearance.BorderSize = 0;
            this.btnTranslate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnTranslate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTranslate.Image = global::s3m.Properties.Resources.translate;
            this.btnTranslate.Location = new System.Drawing.Point(1, 191);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(30, 30);
            this.btnTranslate.TabIndex = 13;
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // btnChoice
            // 
            this.btnChoice.FlatAppearance.BorderSize = 0;
            this.btnChoice.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnChoice.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnChoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoice.Image = global::s3m.Properties.Resources.hand;
            this.btnChoice.Location = new System.Drawing.Point(1, 80);
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Size = new System.Drawing.Size(30, 30);
            this.btnChoice.TabIndex = 10;
            this.btnChoice.UseVisualStyleBackColor = true;
            this.btnChoice.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // btnZminus
            // 
            this.btnZminus.FlatAppearance.BorderSize = 0;
            this.btnZminus.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnZminus.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnZminus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnZminus.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZminus.Image = global::s3m.Properties.Resources._509;
            this.btnZminus.Location = new System.Drawing.Point(0, 305);
            this.btnZminus.Name = "btnZminus";
            this.btnZminus.Size = new System.Drawing.Size(22, 30);
            this.btnZminus.TabIndex = 7;
            this.btnZminus.UseVisualStyleBackColor = true;
            this.btnZminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZminus_MouseDown);
            this.btnZminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZminus_MouseUp);
            // 
            // btnYminus
            // 
            this.btnYminus.FlatAppearance.BorderSize = 0;
            this.btnYminus.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnYminus.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnYminus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYminus.Font = new System.Drawing.Font("굴림", 9F);
            this.btnYminus.Image = global::s3m.Properties.Resources._509;
            this.btnYminus.Location = new System.Drawing.Point(0, 273);
            this.btnYminus.Name = "btnYminus";
            this.btnYminus.Size = new System.Drawing.Size(22, 30);
            this.btnYminus.TabIndex = 7;
            this.btnYminus.UseVisualStyleBackColor = true;
            this.btnYminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYminus_MouseDown);
            this.btnYminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYminus_MouseUp);
            // 
            // btnZplus
            // 
            this.btnZplus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZplus.FlatAppearance.BorderSize = 0;
            this.btnZplus.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnZplus.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnZplus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnZplus.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZplus.Image = global::s3m.Properties.Resources.plus;
            this.btnZplus.Location = new System.Drawing.Point(39, 305);
            this.btnZplus.Name = "btnZplus";
            this.btnZplus.Size = new System.Drawing.Size(22, 30);
            this.btnZplus.TabIndex = 6;
            this.btnZplus.UseVisualStyleBackColor = true;
            this.btnZplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZplus_MouseDown);
            this.btnZplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZplus_MouseUp);
            // 
            // btnYplus
            // 
            this.btnYplus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYplus.FlatAppearance.BorderSize = 0;
            this.btnYplus.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnYplus.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnYplus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYplus.Font = new System.Drawing.Font("굴림", 9F);
            this.btnYplus.Image = global::s3m.Properties.Resources.plus;
            this.btnYplus.Location = new System.Drawing.Point(39, 273);
            this.btnYplus.Name = "btnYplus";
            this.btnYplus.Size = new System.Drawing.Size(22, 30);
            this.btnYplus.TabIndex = 6;
            this.btnYplus.UseVisualStyleBackColor = true;
            this.btnYplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYplus_MouseDown);
            this.btnYplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYplus_MouseUp);
            // 
            // btnXminus
            // 
            this.btnXminus.FlatAppearance.BorderSize = 0;
            this.btnXminus.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnXminus.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnXminus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXminus.Font = new System.Drawing.Font("굴림", 9F);
            this.btnXminus.Image = global::s3m.Properties.Resources._509;
            this.btnXminus.Location = new System.Drawing.Point(0, 241);
            this.btnXminus.Name = "btnXminus";
            this.btnXminus.Size = new System.Drawing.Size(22, 30);
            this.btnXminus.TabIndex = 5;
            this.btnXminus.UseVisualStyleBackColor = true;
            this.btnXminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXminus_MouseDown);
            this.btnXminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXminus_MouseUp);
            // 
            // btnXplus
            // 
            this.btnXplus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXplus.FlatAppearance.BorderSize = 0;
            this.btnXplus.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnXplus.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnXplus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXplus.Font = new System.Drawing.Font("굴림", 9F);
            this.btnXplus.Image = global::s3m.Properties.Resources.plus;
            this.btnXplus.Location = new System.Drawing.Point(39, 241);
            this.btnXplus.Name = "btnXplus";
            this.btnXplus.Size = new System.Drawing.Size(22, 30);
            this.btnXplus.TabIndex = 4;
            this.btnXplus.UseVisualStyleBackColor = true;
            this.btnXplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXplus_MouseDown);
            this.btnXplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXplus_MouseUp);
            // 
            // btnPen
            // 
            this.btnPen.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPen.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPen.FlatAppearance.BorderSize = 0;
            this.btnPen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnPen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnPen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPen.Image = global::s3m.Properties.Resources.Pencil;
            this.btnPen.Location = new System.Drawing.Point(1, 18);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(30, 30);
            this.btnPen.TabIndex = 1;
            this.btnPen.UseVisualStyleBackColor = false;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.FlatAppearance.BorderSize = 0;
            this.btnCircle.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnCircle.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnCircle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCircle.Image = global::s3m.Properties.Resources.sphere;
            this.btnCircle.Location = new System.Drawing.Point(32, 49);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(30, 30);
            this.btnCircle.TabIndex = 3;
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnRect
            // 
            this.btnRect.FlatAppearance.BorderSize = 0;
            this.btnRect.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnRect.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnRect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRect.Image = global::s3m.Properties.Resources.cube;
            this.btnRect.Location = new System.Drawing.Point(1, 49);
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(30, 30);
            this.btnRect.TabIndex = 2;
            this.btnRect.UseVisualStyleBackColor = true;
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            // 
            // btnLine
            // 
            this.btnLine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLine.FlatAppearance.BorderSize = 0;
            this.btnLine.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnLine.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLine.Image = global::s3m.Properties.Resources.lines;
            this.btnLine.Location = new System.Drawing.Point(32, 18);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(30, 30);
            this.btnLine.TabIndex = 1;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // lblView
            // 
            this.lblView.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblView.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblView.Location = new System.Drawing.Point(33, 112);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(29, 15);
            this.lblView.TabIndex = 19;
            this.lblView.Text = "Axis";
            this.lblView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.btnEyes);
            this.Controls.Add(this.btnRotateAxis);
            this.Controls.Add(this.btnTranslateAxis);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.pBoxZ);
            this.Controls.Add(this.pBoxY);
            this.Controls.Add(this.pBoxX);
            this.Controls.Add(this.btnGlrotation);
            this.Controls.Add(this.btnGlScale);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.btnChoice);
            this.Controls.Add(this.lblControl);
            this.Controls.Add(this.lblDrawing);
            this.Controls.Add(this.lblObject);
            this.Controls.Add(this.btnZminus);
            this.Controls.Add(this.btnYminus);
            this.Controls.Add(this.btnZplus);
            this.Controls.Add(this.btnYplus);
            this.Controls.Add(this.btnXminus);
            this.Controls.Add(this.btnXplus);
            this.Controls.Add(this.btnPen);
            this.Controls.Add(this.btnCircle);
            this.Controls.Add(this.btnRect);
            this.Controls.Add(this.btnLine);
            this.Name = "tools";
            this.Size = new System.Drawing.Size(65, 370);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPen;
        public System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnRect;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnXplus;
        private System.Windows.Forms.Button btnXminus;
        private System.Windows.Forms.Button btnYminus;
        private System.Windows.Forms.Button btnYplus;
        private System.Windows.Forms.Button btnZplus;
        private System.Windows.Forms.Button btnZminus;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.Button btnChoice;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnGlScale;
        private System.Windows.Forms.Button btnGlrotation;
        private System.Windows.Forms.Label lblDrawing;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pBoxX;
        private System.Windows.Forms.PictureBox pBoxY;
        private System.Windows.Forms.PictureBox pBoxZ;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnTranslateAxis;
        private System.Windows.Forms.Button btnRotateAxis;
        private System.Windows.Forms.Button btnEyes;
        private System.Windows.Forms.Label lblView;
    }
}
