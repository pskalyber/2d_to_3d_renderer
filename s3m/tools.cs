using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace s3m
{
    public partial class tools : UserControl
    {
        const int PEN = 0;
        const int LINE = 1;
        const int RECT = 2;
        const int CIRCLE = 3;

        const int SELECT = 11;
        const int SCALE = 12;
        const int ROTATION = 13;
        const int TRANSLATE = 14;
        const int AXIS_TRANSLATE = 15;
        const int AXIS_ROTATE = 16;
        const int CAMERA = 17;

        const int XPLUS = 21;
        const int XMINUS = 22;
        const int YPLUS = 23;
        const int YMINUS = 24;
        const int ZPLUS = 25;
        const int ZMINUS = 26;

        const int ZOOMIN = 31;
        const int ZOOMOUT = 32;

        opengl openglcs;
        Property property;

        int value=0;

        public tools()
        {
            InitializeComponent();
        }

        public tools(ref opengl openglcs, ref Property property)
        {
            InitializeComponent();
            this.openglcs = openglcs;
            this.property = property;
        }

        #region 버튼 - 클릭 이벤트

        private void btnPen_Click(object sender, EventArgs e)
        {
            openglcs.MODE = PEN;
            property.Mode = "PEN";
            showClickedBtn(1);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            openglcs.MODE = LINE;
            property.Mode = "LINE";
            showClickedBtn(2);
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            openglcs.vertexList.Clear();
            openglcs.MODE = RECT;
            property.Mode = "RECTANGLE";
            showClickedBtn(3);
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            openglcs.vertexList.Clear();
            openglcs.MODE = CIRCLE;
            property.Mode = "CIRCLE";
            showClickedBtn(4);
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            openglcs.MODE = SELECT;
            property.Mode = "SELECT";
        }

        private void btnGlScale_Click(object sender, EventArgs e)
        {
            openglcs.MODE = SCALE;
            property.Mode = "OBJECT SCALE";
            showClickedBtn(5);
        }

        private void btnGlrotation_Click(object sender, EventArgs e)
        {
            openglcs.MODE = ROTATION;
            property.Mode = "OBJECT ROTATION";
            showClickedBtn(6);
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            openglcs.MODE = TRANSLATE;
            property.Mode = "OBJECT TRANSLATE";
            showClickedBtn(7);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (openglcs.vertexList.Count > 3)
            {
                openglcs.CreateKObj();
                openglcs.addTreeView("Object" + openglcs.objectCount);
                ++openglcs.objectCount;
            }
        }

        private void btnTranslateAxis_Click(object sender, EventArgs e)
        {
            openglcs.MODE = AXIS_TRANSLATE;
            property.Mode = "AXIS_TRANSLATE";
            showClickedBtn(8);
        }

        private void btnRotateAxis_Click(object sender, EventArgs e)
        {
            openglcs.MODE = AXIS_ROTATE;
            property.Mode = "AXIS_ROTATE";
            showClickedBtn(9);
        }

        private void btnEyes_Click(object sender, EventArgs e)
        {
            openglcs.MODE = CAMERA;
            property.Mode = "CAMERA";
            showClickedBtn(10);
        }
        #endregion

        #region 버튼 - 마우스 다운 이벤트

        private void btnXplus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                value = XPLUS;
                timer.Start();
            }
        }
        private void btnXminus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                value = XMINUS;
                timer.Start();
            }
        }
        private void btnYplus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                value = YPLUS;
                timer.Start();
            }
        }
        private void btnYminus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                value = YMINUS;
                timer.Start();
            }
        }

        private void btnZplus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                value = ZPLUS;
                timer.Start();
            }
        }
        private void btnZminus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                value = ZMINUS;
                timer.Start();
            }
        }
        #endregion

        #region 버튼 - 마우스 업 이벤트
        private void btnXplus_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer.Stop();
            }
        }
        private void btnXminus_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer.Stop();
            }
        }
        private void btnYplus_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer.Stop();
            }
        }
        private void btnYminus_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer.Stop();
            }
        }
        private void btnZplus_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer.Stop();
            }
        }
        private void btnZminus_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer.Stop();
            }
        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            switch (value)
            {
                case XPLUS:
                    switch (openglcs.MODE)
                    {
                        case SCALE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].xScale += 0.1f;
                            break;
                        case ROTATION:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].xRotation += 2f;
                            break;
                        case TRANSLATE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].xTranslate += 1f;
                            break;
                        case AXIS_TRANSLATE:
                            openglcs.axisX += 2f;
                            break;
                        case AXIS_ROTATE:
                            openglcs.rotX += 2f;
                            break;
                        case CAMERA:
                            openglcs.rotLx += 2f;
                            Gl.glMatrixMode(Gl.GL_MODELVIEW);
                            Gl.glLoadIdentity();
                            Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                            break;
                        default:
                            break;
                    }
                    break;
                case XMINUS:
                    switch (openglcs.MODE)
                    {
                        case SCALE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].xScale -= 0.1f;
                            break;
                        case ROTATION:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].xRotation -= 2f;
                            break;
                        case TRANSLATE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].xTranslate -= 1f;
                            break;
                        case AXIS_TRANSLATE:
                            openglcs.axisX -= 2f;
                            break;
                        case AXIS_ROTATE:
                            openglcs.rotX -= 2f;
                            break;
                        case CAMERA:
                            openglcs.rotLx -= 2f;
                            Gl.glMatrixMode(Gl.GL_MODELVIEW);
                            Gl.glLoadIdentity();
                            Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                            break;
                        default:
                            break;
                    }
                    break;
                case YPLUS:
                    switch (openglcs.MODE)
                    {
                        case SCALE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].yScale += 0.1f;
                            break;
                        case ROTATION:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].yRotation += 2f;
                            break;
                        case TRANSLATE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].yTranslate += 1f;
                            break;
                        case AXIS_TRANSLATE:
                            openglcs.axisY += 2f;
                            break;
                        case AXIS_ROTATE:
                            openglcs.rotY += 2f;
                            break;
                        case CAMERA:
                            openglcs.rotLy += 2f;
                            Gl.glMatrixMode(Gl.GL_MODELVIEW);
                            Gl.glLoadIdentity();
                            Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                            break;
                        default:
                            break;
                    }
                    break;
                case YMINUS:
                    switch (openglcs.MODE)
                    {
                        case SCALE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].yScale -= 0.1f;
                            break;
                        case ROTATION:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].yRotation -= 2f;
                            break;
                        case TRANSLATE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].yTranslate -= 1f;
                            break;
                        case AXIS_TRANSLATE:
                            openglcs.axisY -= 2f;
                            break;
                        case AXIS_ROTATE:
                            openglcs.rotY -= 2f;
                            break;
                        case CAMERA:
                            openglcs.rotLy -= 2f;
                            Gl.glMatrixMode(Gl.GL_MODELVIEW);
                            Gl.glLoadIdentity();
                            Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                            break;
                        default:
                            break;
                    }
                    break;
                case ZPLUS:
                    switch (openglcs.MODE)
                    {
                        case SCALE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].zScale += 0.1f;
                            break;
                        case ROTATION:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].zRotation += 2f;
                            break;
                        case TRANSLATE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].zTranslate += 1f;
                            break;
                        case AXIS_TRANSLATE:
                            openglcs.axisZ += 2f;
                            break;
                        case AXIS_ROTATE:
                            openglcs.rotZ += 2f;
                            break;
                        case CAMERA:
                            openglcs.rotLz += 2f;
                            Gl.glMatrixMode(Gl.GL_MODELVIEW);
                            Gl.glLoadIdentity();
                            Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                            break;
                        default:
                            break;
                    }
                    break;
                case ZMINUS:
                    switch (openglcs.MODE)
                    {
                        case SCALE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].zScale -= 0.1f;
                            break;
                        case ROTATION:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].zRotation -= 2f;
                            break;
                        case TRANSLATE:
                            if (openglcs.selectedIndex > -1)
                                openglcs.objFiles[openglcs.selectedIndex].zTranslate -= 1f;
                            break;
                        case AXIS_TRANSLATE:
                            openglcs.axisZ -= 2f;
                            break;
                        case AXIS_ROTATE:
                            openglcs.rotZ -= 2f;
                            break;
                        case CAMERA:
                            openglcs.rotLz -= 2f;
                            Gl.glMatrixMode(Gl.GL_MODELVIEW);
                            Gl.glLoadIdentity();
                            Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        public void showClickedBtn(int i)
        {
            switch(i)
            {
                case 1:
                    btnPen.BackColor = SystemColors.ControlDark;
                    btnLine.BackColor = SystemColors.Control;
                    btnRect.BackColor = SystemColors.Control;
                    btnCircle.BackColor = SystemColors.Control;
                    btnGlScale.BackColor = SystemColors.Control;
                    btnGlrotation.BackColor = SystemColors.Control;
                    btnTranslate.BackColor = SystemColors.Control;
                    btnTranslateAxis.BackColor = SystemColors.Control;
                    btnRotateAxis.BackColor = SystemColors.Control;
                    btnEyes.BackColor = SystemColors.Control;
                    break;
                case 2:
                    btnPen.BackColor = SystemColors.Control;
                    btnLine.BackColor = SystemColors.ControlDark;
                    btnRect.BackColor = SystemColors.Control;
                    btnCircle.BackColor = SystemColors.Control;
                    btnGlScale.BackColor = SystemColors.Control;
                    btnGlrotation.BackColor = SystemColors.Control;
                    btnTranslate.BackColor = SystemColors.Control;
                    btnTranslateAxis.BackColor = SystemColors.Control;
                    btnRotateAxis.BackColor = SystemColors.Control;
                    btnEyes.BackColor = SystemColors.Control;
                    break;
                case 3:
                    btnPen.BackColor = SystemColors.Control;
                    btnLine.BackColor = SystemColors.Control;
                    btnRect.BackColor = SystemColors.ControlDark;
                    btnCircle.BackColor = SystemColors.Control;
                    btnGlScale.BackColor = SystemColors.Control;
                    btnGlrotation.BackColor = SystemColors.Control;
                    btnTranslate.BackColor = SystemColors.Control;
                    btnTranslateAxis.BackColor = SystemColors.Control;
                    btnRotateAxis.BackColor = SystemColors.Control;
                    btnEyes.BackColor = SystemColors.Control;
                    break;
                case 4:
                    btnPen.BackColor = SystemColors.Control;
                    btnLine.BackColor = SystemColors.Control;
                    btnRect.BackColor = SystemColors.Control;
                    btnCircle.BackColor = SystemColors.ControlDark;
                    btnGlScale.BackColor = SystemColors.Control;
                    btnGlrotation.BackColor = SystemColors.Control;
                    btnTranslate.BackColor = SystemColors.Control;
                    btnTranslateAxis.BackColor = SystemColors.Control;
                    btnRotateAxis.BackColor = SystemColors.Control;
                    btnEyes.BackColor = SystemColors.Control;
                    break;
                case 5:
                    btnPen.BackColor = SystemColors.Control;
                    btnLine.BackColor = SystemColors.Control;
                    btnRect.BackColor = SystemColors.Control;
                    btnCircle.BackColor = SystemColors.Control;
                    btnGlScale.BackColor = SystemColors.ControlDark;
                    btnGlrotation.BackColor = SystemColors.Control;
                    btnTranslate.BackColor = SystemColors.Control;
                    btnTranslateAxis.BackColor = SystemColors.Control;
                    btnRotateAxis.BackColor = SystemColors.Control;
                    btnEyes.BackColor = SystemColors.Control;
                    break;
                case 6:
                    btnPen.BackColor = SystemColors.Control;
                    btnLine.BackColor = SystemColors.Control;
                    btnRect.BackColor = SystemColors.Control;
                    btnCircle.BackColor = SystemColors.Control;
                    btnGlScale.BackColor = SystemColors.Control;
                    btnGlrotation.BackColor = SystemColors.ControlDark;
                    btnTranslate.BackColor = SystemColors.Control;
                    btnTranslateAxis.BackColor = SystemColors.Control;
                    btnRotateAxis.BackColor = SystemColors.Control;
                    btnEyes.BackColor = SystemColors.Control;
                    break;
                case 7:
                    btnPen.BackColor = SystemColors.Control;
                    btnLine.BackColor = SystemColors.Control;
                    btnRect.BackColor = SystemColors.Control;
                    btnCircle.BackColor = SystemColors.Control;
                    btnGlScale.BackColor = SystemColors.Control;
                    btnGlrotation.BackColor = SystemColors.Control;
                    btnTranslate.BackColor = SystemColors.ControlDark;
                    btnTranslateAxis.BackColor = SystemColors.Control;
                    btnRotateAxis.BackColor = SystemColors.Control;
                    btnEyes.BackColor = SystemColors.Control;
                    break;
                case 8:
                    btnPen.BackColor = SystemColors.Control;
                    btnLine.BackColor = SystemColors.Control;
                    btnRect.BackColor = SystemColors.Control;
                    btnCircle.BackColor = SystemColors.Control;
                    btnGlScale.BackColor = SystemColors.Control;
                    btnGlrotation.BackColor = SystemColors.Control;
                    btnTranslate.BackColor = SystemColors.Control;
                    btnTranslateAxis.BackColor = SystemColors.ControlDark;
                    btnRotateAxis.BackColor = SystemColors.Control;
                    btnEyes.BackColor = SystemColors.Control;
                    break;
                case 9:
                    btnPen.BackColor = SystemColors.Control;
                    btnLine.BackColor = SystemColors.Control;
                    btnRect.BackColor = SystemColors.Control;
                    btnCircle.BackColor = SystemColors.Control;
                    btnGlScale.BackColor = SystemColors.Control;
                    btnGlrotation.BackColor = SystemColors.Control;
                    btnTranslate.BackColor = SystemColors.Control;
                    btnTranslateAxis.BackColor = SystemColors.Control;
                    btnRotateAxis.BackColor = SystemColors.ControlDark;
                    btnEyes.BackColor = SystemColors.Control;
                    break;
                case 10:
                    btnPen.BackColor = SystemColors.Control;
                    btnLine.BackColor = SystemColors.Control;
                    btnRect.BackColor = SystemColors.Control;
                    btnCircle.BackColor = SystemColors.Control;
                    btnGlScale.BackColor = SystemColors.Control;
                    btnGlrotation.BackColor = SystemColors.Control;
                    btnTranslate.BackColor = SystemColors.Control;
                    btnTranslateAxis.BackColor = SystemColors.Control;
                    btnRotateAxis.BackColor = SystemColors.Control;
                    btnEyes.BackColor = SystemColors.ControlDark;
                    break;
                default:
                    break;
            }
        }
    }
}
