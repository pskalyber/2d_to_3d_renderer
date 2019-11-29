using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageObjectExtration
{
    public class U_ScrollPictureBox : UserControl
    {
        private System.ComponentModel.Container components = null;

        public U_ScrollPictureBox()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 128);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(136, 16);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.vScrollBar1.Location = new System.Drawing.Point(136, 8);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(16, 112);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // U_ScrollPictureBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Name = "U_ScrollPictureBox";
            this.Size = new System.Drawing.Size(83, 83);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserPictureBox_Paint);
            this.SizeChanged += new System.EventHandler(this.UserPictureBox_SizeChanged);
            this.ResumeLayout(false);

        }

        public HScrollBar hScrollBar1;
        public VScrollBar vScrollBar1;

        private Image TheImage = null;
        public float MaxView = 1;

        private void UserPictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, this.ClientRectangle);

            if (TheImage != null)
            {
                g.DrawImage(TheImage, -OffsetX, -OffsetY, TheImage.Width * MaxView, TheImage.Height * MaxView);
                g.FillRectangle(Brushes.Gray, ClientRectangle.Width - vScrollBar1.Width, ClientRectangle.Height - hScrollBar1.Height, vScrollBar1.Width, hScrollBar1.Height);
            }
        }

        public Image Image
        {
            get
            {
                return TheImage;
            }
            set
            {
                TheImage = value;
                SizeScrollBars();
            }
        }

        
        private int iOffsetX = 0;
        public int OffsetX
        {
            get
            {
                return iOffsetX;
            }
            set
            {
                iOffsetX = value;
                Invalidate();
            }
        }

        private int iOffsetY = 0;

        private void hScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            int nVal = e.NewValue;
            OffsetX = nVal;

        }

        private void vScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            int nVal = e.NewValue;
            OffsetY = nVal;
        }

        public void SizeScrollBars()
        {
            hScrollBar1.Minimum = 0;
            vScrollBar1.Minimum = 0;
            hScrollBar1.SetBounds(0, ClientRectangle.Height - hScrollBar1.Height, ClientRectangle.Width - vScrollBar1.Width, hScrollBar1.Height);
            vScrollBar1.SetBounds(ClientRectangle.Right - vScrollBar1.Width, 0, vScrollBar1.Width, ClientRectangle.Height - hScrollBar1.Height);

            if (TheImage != null)
            {
                hScrollBar1.Maximum = (int)(TheImage.Width * MaxView) + vScrollBar1.Width * 2 + -ClientRectangle.Width;
                vScrollBar1.Maximum = (int)(TheImage.Height * MaxView) + hScrollBar1.Height * 2 - ClientRectangle.Height;
            }
            else
            {
                hScrollBar1.Maximum = 0;
                vScrollBar1.Maximum = 0;
            }

            Invalidate();
        }

        private void UserPictureBox_SizeChanged(object sender, System.EventArgs e)
        {
            SizeScrollBars();
        }

        public int OffsetY
        {
            get
            {
                return iOffsetY;
            }
            set
            {
                iOffsetY = value;
                Invalidate();
            }
        }
    }
}
