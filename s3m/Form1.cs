using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Xml.Linq;

namespace ImageObjectExtration
{
    
    public partial class Form1 : Form
    {
        int ImgCount = 0;
        s3m.frmMain thisForm;
        int Sel_ToolNum = 1;
        enum Sel_Tool { Point = 1, Fill, Eraser, Ellipse };
        public U_ScrollPictureBox U_PicBox;
        Bitmap bmp1;
        PointF P1, P2;
        Bitmap bmp;
        Point[] Way_Point = new Point[4];
        ImageList image_list = new ImageList();
        
        Bitmap bmp_;
        Point point1,point2;
        Bitmap tempbmp;

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "LoadCursorFromFileW", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern System.IntPtr LoadCursorFromFile(string str);

        public Form1()
        {

            InitializeComponent();
            System.IntPtr hCursor = LoadCursorFromFile("Handwriting.cur");
            if (!System.IntPtr.Zero.Equals(hCursor))
                U_PicBox.Cursor = new System.Windows.Forms.Cursor(hCursor);

            this.U_PicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.U_PicBox_MouseMove);
            this.U_PicBox.MouseDown += new MouseEventHandler(U_PicBox_MouseDown);
            P1 = new PointF();
            P2 = new PointF();
            Way_Point[0] = new Point(1, 0);
            Way_Point[1] = new Point(0, 1);
            Way_Point[2] = new Point(-1, 0);
            Way_Point[3] = new Point(1, -1);
            bmp = this.U_PicBox.Image as Bitmap;
        }

        void U_PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (P1.X == 0 && P1.Y == 0 && P2.X == 0 && P2.Y == 0)
            {
                P1.X = (int)((e.Location.X / U_PicBox.MaxView) + U_PicBox.OffsetX);
                P1.Y = (int)((e.Location.Y / U_PicBox.MaxView) + U_PicBox.OffsetY);
                if (P2 == null)
                    P2 = P1;
                point2.X = (int)P2.X;
                point2.Y = (int)P2.Y;
            }
            switch (Sel_ToolNum)
            {
                case (int)Sel_Tool.Point:
                    point2.X = (int)((e.Location.X + U_PicBox.OffsetX) / U_PicBox.MaxView);
                    point2.Y = (int)((e.Location.Y + U_PicBox.OffsetY) / U_PicBox.MaxView);
                    if(P2 == null)
                        P2 = P1;
                    if (P1 == null)
                        P1 = point2;


                    break;


                case (int)Sel_Tool.Fill:
                    bmp = this.U_PicBox.Image as Bitmap;

                    Fun_Fill(point2.X, point2.Y);

                    break;
                case (int)Sel_Tool.Ellipse:
                    P1.X = (e.Location.X / U_PicBox.MaxView) + U_PicBox.OffsetX;
                    P1.Y = (e.Location.Y / U_PicBox.MaxView) + U_PicBox.OffsetY;
                    if (P2 == null)
                        P2 = P1;
                    point1.X = (int)P1.X;
                    point1.Y = (int)P1.Y;
                    bmp_ = this.U_PicBox.Image.Clone() as Bitmap;
                    
                    break;



            }
        }

        private void U_PicBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                
                switch (Sel_ToolNum)
                {
                    case (int)Sel_Tool.Point:
                        point1 = point2;
                        Point p = new Point(U_PicBox.OffsetX, U_PicBox.OffsetY);
                        point2 = e.Location;

                        point2.X += p.X;
                        point2.Y += p.Y;
                        point2.X = (int)(point2.X / U_PicBox.MaxView);
                        point2.Y = (int)(point2.Y / U_PicBox.MaxView);

                        U_PicBox.BackColor = Color.Transparent;
                        Pen pen = new Pen(Color.FromArgb(128, 255, 0, 0), 5);
                        pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        Graphics g = Graphics.FromImage(this.U_PicBox.Image);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        g.DrawLine(pen, point1, point2);
                        

                        if (point2.X < P1.X && point2.X > 0)
                        {
                            P1.X = point2.X - 10;
                        }
                        if (point2.Y < P1.Y && point2.Y > 0)
                        {
                            P1.Y = point2.Y - 10;
                        }
                        if (point2.X > P2.X && bmp1.Width > point2.X)
                        {
                            P2.X = point2.X + 10;
                        }
                        if (point2.Y > P2.Y && bmp1.Height > point2.Y)
                        {
                            P2.Y = point2.Y + 10;
                        }
                        
                        g.Dispose();
                        break;


                    case (int)Sel_Tool.Fill:

                        break;

                    case (int)Sel_Tool.Eraser:
                        point1 = point2;
                        Point ppp = new Point(U_PicBox.OffsetX, U_PicBox.OffsetY);
                        point2 = e.Location;

                        point2.X += ppp.X;
                        point2.Y += ppp.Y;
                        point2.X = (int)(point2.X / U_PicBox.MaxView);
                        point2.Y = (int)(point2.Y / U_PicBox.MaxView);
                        
                        
                        bmp.SetPixel(point2.X, point2.Y, bmp1.GetPixel(point2.X, point2.Y));
                        bmp.SetPixel(point2.X + 1, point2.Y + 1, bmp1.GetPixel(point2.X + 1, point2.Y + 1));
                        bmp.SetPixel(point2.X + 1, point2.Y - 1, bmp1.GetPixel(point2.X + 1, point2.Y - 1));
                        bmp.SetPixel(point2.X - 1, point2.Y + 1, bmp1.GetPixel(point2.X - 1, point2.Y + 1));
                        bmp.SetPixel(point2.X - 1, point2.Y - 1, bmp1.GetPixel(point2.X - 1, point2.Y - 1));
                        bmp.SetPixel(point2.X + 1, point2.Y, bmp1.GetPixel(point2.X + 1, point2.Y));
                        bmp.SetPixel(point2.X, point2.Y - 1, bmp1.GetPixel(point2.X, point2.Y - 1));
                        bmp.SetPixel(point2.X, point2.Y + 1, bmp1.GetPixel(point2.X, point2.Y + 1));
                        bmp.SetPixel(point2.X - 1, point2.Y, bmp1.GetPixel(point2.X - 1, point2.Y));

                        
                        break;

                    case (int)Sel_Tool.Ellipse:
                        if (e.Button == MouseButtons.Left)
                        {
                            
                            point2 = e.Location;
                            Point pp = new Point(U_PicBox.OffsetX, U_PicBox.OffsetY);
                            point2.X += pp.X;
                            point2.Y += pp.Y;
                            point2.X = (int)(point2.X / U_PicBox.MaxView);
                            point2.Y = (int)(point2.Y / U_PicBox.MaxView);

                            //U_PicBox.Image = bmp_;

                            Bitmap tempb = new Bitmap(bmp_);

                            Pen penn = new Pen(Color.FromArgb(128, 255, 0, 0), 5);
                            penn.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                            Graphics gg = Graphics.FromImage(tempb);
                            
                            gg.DrawEllipse(penn, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
                            gg.Dispose();

                            U_PicBox.Image = tempb;

                        }

                        
                        break;


                }


                //this.U_PicBox.Invalidate();
            }
            else
            {
                point2 = e.Location;
                Point p = new Point(U_PicBox.OffsetX, U_PicBox.OffsetY);
                point2.X += p.X;
                point2.Y += p.Y;
                point2.X = (int)(point2.X / U_PicBox.MaxView);
                point2.Y = (int)(point2.Y / U_PicBox.MaxView);
            }
        }

        
        private void DrawRedLine()
        {
            bmp = this.U_PicBox.Image as Bitmap;
            //progressBar1.Maximum = (P2.X - P1.X) * (P2.Y - P1.Y);


            tempbmp = new Bitmap((int)(P2.X - P1.X + 2), (int)(P2.Y - P1.Y + 2));
            //progressBar1.Value = 0;

            for (int i = (int)P1.X; i < P2.X; i++)
            {
                for (int j = (int)P1.Y; j < P2.Y; j++)
                {
                    if (bmp.GetPixel(i, j) != bmp1.GetPixel(i, j))
                    {
                        tempbmp.SetPixel(i - (int)P1.X, j - (int)P1.Y, bmp1.GetPixel(i, j));
                    }
                    //progressBar1.PerformStep();
                }
            }

            
            //U_PicBox.Image = tempbmp;


//             UserControl_Png U_Png = new UserControl_Png();
//             U_Png.Width = tempbmp.Width + 10;
//             U_Png.Height = tempbmp.Height + 30;
//             U_Png.pictureBox.Image = tempbmp;
//             U_Png.pictureBox.Width = tempbmp.Width + 1;
//             U_Png.pictureBox.Height = tempbmp.Height + 1;
//             U_Png.Show();
//             tempbmp.Save("./OutPng.png", ImageFormat.Png);
            //tempbmp.Save("./OutPng.png", ImageFormat.Png);
            pictureBox_View.Image = tempbmp;
            //tempbmp.Save("./OutPng.png", ImageFormat.Png);
            pictureBox_View.Update();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DrawRedLine();
        }

        private void userPictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            switch (Sel_ToolNum)
            {
                case (int)Sel_Tool.Point:

                   
                    break;


                case (int)Sel_Tool.Fill:

                    break;

                case (int)Sel_Tool.Eraser:

                    
                    break;
                case (int)Sel_Tool.Ellipse:
                    
                    break;


            }

            this.U_PicBox.Invalidate();
        }

        private void button_Fill_Click(object sender, EventArgs e)
        {
            Sel_ToolNum = (int)Sel_Tool.Fill;
        }

        private void button_Point_Click(object sender, EventArgs e)
        {
            Sel_ToolNum = (int)Sel_Tool.Point;
            System.IntPtr hCursor = LoadCursorFromFile("Handwriting.cur");
            if (!System.IntPtr.Zero.Equals(hCursor))
                U_PicBox.Cursor = new System.Windows.Forms.Cursor(hCursor);

        }

        private void Fun_Fill(int p1, int p2)
        {

            bmp = (Bitmap)this.U_PicBox.Image;
           
            ExtGraphics eg = new ExtGraphics(bmp, bmp1);

            eg.FloodFill(p1, p2);

            this.U_PicBox.Refresh();
            
// 
//             int Temp_index_x, Temp_index_y;
// 
//             //U_PicBox.BackColor = Color.Transparent;
//             //bmp.SetPixel(p1, p2, Color.FromArgb(128, 255, 0, 0));
//             for (int i = 0; i < 4; i++)
//             {
//                 Temp_index_x = p1 + Way_Point[i].X;
//                 Temp_index_y = p2 + Way_Point[i].Y;
// 
//                 if (bmp.Width > Temp_index_x && bmp.Height > Temp_index_y && Temp_index_x > 0 && Temp_index_y > 0)
//                 {
//                     if (bmp.GetPixel(Temp_index_x, Temp_index_y) == bmp1.GetPixel(Temp_index_x, Temp_index_y))
//                     {
//                         Fun_Fill(Temp_index_x, Temp_index_y);
//                     }
//                     else
//                     {
//                         bmp.SetPixel(Temp_index_x, Temp_index_y, Color.FromArgb(128, 255, 0, 0));
//                     }
//                 }
//             }

        }

       
        private void Search_Add()
        {
            if (textBox_Keyword == null)
            {
                MessageBox.Show("검색어를 입력 하십시오.");
                return;
            }


            const string SEARCH = "http://openapi.naver.com/search?key=4492272d32a2655454310605c0b23a50&query={0}&target=image&start=1&display=10&filter=large";
            var xraw = XElement.Load(String.Format(SEARCH, textBox_Keyword.Text));
            var xroot = XElement.Parse(xraw.ToString());
            var links = (from item in xroot.Element("channel").Descendants("item")
                         select new
                         {
                             Title = item.Element("title").Value,
                             LinkUrl = item.Element("link").Value,
                             Width = item.Element("sizewidth").Value,
                             Height = item.Element("sizeheight").Value

                         }).Take(int.Parse(numericUpDown1.Value.ToString()));


            flowLayoutPanel_Image.Controls.Clear();
            foreach (var searchResult in links)
            {
                Image_ListItem image_item = new Image_ListItem();
                image_item.Image.Click += new EventHandler(image_item_Click);
                image_item._Text = searchResult.Title;
                image_item.Image_Uri = searchResult.LinkUrl;
                flowLayoutPanel_Image.Controls.Add(image_item);
            }
            
        }

        float ImageLength;

        private void image_item_Click(object sender, EventArgs e)
        {
            if ((((PictureBox)sender).Image).Width > (((PictureBox)sender).Image).Height)
                ImageLength = (float)(580.0f / (((PictureBox)sender).Image).Width);
            else
                ImageLength = (float)(440.0f / (((PictureBox)sender).Image).Height);

            U_PicBox.MaxView = ImageLength;
            U_PicBox.Image = ((PictureBox)sender).Image;
            bmp1 = U_PicBox.Image.Clone() as Bitmap;
            bmp = U_PicBox.Image as Bitmap;


            U_PicBox.OffsetX = (int)(U_PicBox.OffsetX * U_PicBox.MaxView);
            U_PicBox.OffsetY = (int)(U_PicBox.OffsetY * U_PicBox.MaxView);



        }


        private void button_Eraser_Click(object sender, EventArgs e)
        {
            Sel_ToolNum = (int)Sel_Tool.Eraser;
        }

     

        private void button_ZoomIn_Click(object sender, EventArgs e)
        {
            
            switch (label_Size.Text)
            {
                case "x1":
                 U_PicBox.MaxView = ImageLength * 2.0f;
                label_Size.Text = "x2";
                U_PicBox.OffsetX = (int)(U_PicBox.OffsetX * U_PicBox.MaxView);
                U_PicBox.OffsetY = (int)(U_PicBox.OffsetY * U_PicBox.MaxView);
            	break;

                case "x2":
                U_PicBox.MaxView = ImageLength * 3.0f;
                label_Size.Text = "x3";
                U_PicBox.OffsetX = (int)(U_PicBox.OffsetX * U_PicBox.MaxView);
                U_PicBox.OffsetY = (int)(U_PicBox.OffsetY * U_PicBox.MaxView);
                break;

                case "x3":
                U_PicBox.MaxView = ImageLength * 4.0f;
                label_Size.Text = "x4";
                U_PicBox.OffsetX = (int)(U_PicBox.OffsetX * U_PicBox.MaxView);
                U_PicBox.OffsetY = (int)(U_PicBox.OffsetY * U_PicBox.MaxView);
                break;
            }

            
            U_PicBox.SizeScrollBars();
        }

        private void button_ZoomOut_Click(object sender, EventArgs e)
        {
            
                switch (label_Size.Text)
                {
                    case "x4":
                        U_PicBox.MaxView = ImageLength * 3.0f;
                        label_Size.Text = "x3";
                        U_PicBox.OffsetX = (int)(U_PicBox.OffsetX / U_PicBox.MaxView);
                        U_PicBox.OffsetY = (int)(U_PicBox.OffsetY / U_PicBox.MaxView);
                        break;

                    case "x3":
                        U_PicBox.MaxView = ImageLength * 2.0f;
                        label_Size.Text = "x2";
                        U_PicBox.OffsetX = (int)(U_PicBox.OffsetX / U_PicBox.MaxView);
                        U_PicBox.OffsetY = (int)(U_PicBox.OffsetY / U_PicBox.MaxView);
                        break;

                    case "x2":
                        U_PicBox.MaxView = ImageLength;
                        label_Size.Text = "x1";
                        U_PicBox.OffsetX = 0;
                        U_PicBox.OffsetY = 0;
                        break;
                }

            U_PicBox.SizeScrollBars();
        }

        private void button_Ellipse_Click(object sender, EventArgs e)
        {
            Sel_ToolNum = (int)Sel_Tool.Ellipse;
        }

        private void button_Internet_Click_1(object sender, EventArgs e)
        {
            Search_Add();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            U_PicBox.Image = bmp1;
            
            bmp1 = U_PicBox.Image.Clone() as Bitmap;
            bmp = U_PicBox.Image as Bitmap;
            U_PicBox.Update();
            pictureBox_View.Image.Dispose();

            DrawRedLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //progressBar1.Value = 0;
            DrawRedLine();
            tempbmp.MakeTransparent();   //지정된 칼라 투명 처리

           


            tempbmp.Save("./" + (ImgCount).ToString() + ".png", ImageFormat.Png);
            this.thisForm.ShowIamgePath("./" + (ImgCount++).ToString() + ".png");
        }

        public void Set3DForm(s3m.frmMain thisForm)
        {
            this.thisForm = thisForm;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawRedLine();
        }

        private void U_PicBox_MouseUp(object sender, MouseEventArgs e)
        {
            DrawRedLine();
        }

        private void textBox_Keyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_Add();
            }
        }

    }
}
