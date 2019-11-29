using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using System.IO;
using System.Collections;


namespace s3m
{
    public partial class frmMain : Form
    {
        public opengl openglcs;
        public tools tool;
        public Property property;
        public frmViewAssistance viewAssistance;
        public frmLight light;

        public frmViewAssistance tempViewAssistance;
        public frmLight tempLight;

        public bool sceanChanged = true;

        public frmMain()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            property = new Property();
            viewAssistance = new frmViewAssistance();
            light = new frmLight();

            tempViewAssistance = viewAssistance;
            tempLight = light;

            openglcs = new opengl(ref property, ref treeView, ref viewAssistance, ref light);
            openglcs.setMain(this);
            tool = new tools(ref openglcs, ref property);

            propertyGridSpace.SelectedObject = property;
            openglcs.Size = panel3D.Size;

            panel3D.Controls.Add(openglcs);
            panelTools.Controls.Add(tool);

            this.openglcs.Size = panel3D.Size;
            this.openglcs.simpleOpenGlControl1.Size = openglcs.Size;
            this.tool.Size = panelTools.Size;
            
        }

        private void mainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta / 120 > 0)
            {
                //if (openglcs.rotLz + openglcs.defaultRotLz - 3.0f >= 0) // z값이 일정값(15) 이하면 더 이상 확대하지 못한다.
                //{
                    openglcs.rotLz -= 8.0f;
                //}
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glLoadIdentity();
                Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            }
            else
            {
                openglcs.rotLz += 8.0f;
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glLoadIdentity();
                Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            }
        }

        //폼_리사이즈 이벤트
        private void mainForm_Resize(object sender, EventArgs e)
        {
            this.openglcs.Size = panel3D.Size;
            this.openglcs.simpleOpenGlControl1.Size = openglcs.Size;
            this.tool.Size = panelTools.Size;
        }

        // New Scean 아이콘 클릭
        private void btnNew_Click(object sender, EventArgs e)
        {
            openglcs.vertexList.Clear();
            treeView.Nodes.Clear();
        }

        // New Scean 메뉴 클릭
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openglcs.vertexList.Clear();
            openglcs.kObjList.Clear();
            openglcs.objFiles.Clear();
            treeView.Nodes.Clear();

            openglcs.LastTransformation.SetIdentity(); // Reset Rotation
            openglcs.ThisTransformation.SetIdentity(); // Reset Rotation
            openglcs.ThisTransformation.get_Renamed(openglcs.matrix);

            openglcs.boolAxises = true;
            openglcs.boolRotation = false;
            openglcs.boolGroundGrid = true;

            openglcs.axisX = 0.0f;
            openglcs.axisY = 0.0f;
            openglcs.axisZ = 0.0f;

            openglcs.rotX = 0.0f;
            openglcs.rotY = 0.0f;
            openglcs.rotZ = 0.0f;

            openglcs.rotLx = 0.0f;
            openglcs.rotLy = 0.0f;
            openglcs.rotLz = 0.0f;

            viewRotation = 1;

            propertyGridSpace.Refresh();
            propertyGridObject.Refresh();
            
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }
        

        // ****** //
        // 타이머 //
        // ****** //
        private void timer_Tick(object sender, EventArgs e)
        {
            openglcs.renderScene();

            property.AxisX = openglcs.axisX;
            property.AxisY = openglcs.axisY;
            property.AxisZ = openglcs.axisZ;

            property.EYEX = openglcs.rotLx;
            property.EYEY = openglcs.rotLy;
            property.EYEZ = openglcs.rotLz;

            property.RotX = openglcs.rotX;
            property.RotY = openglcs.rotY;
            property.RotZ = openglcs.rotZ;

            propertyGridSpace.Refresh();
            propertyGridObject.Refresh();

            if (isZoomIn)
            {
                if (openglcs.rotLz + openglcs.defaultRotLz - 3.0f >= 0) // z값이 일정값(15) 이하면 더 이상 확대하지 못한다.
                {
                    openglcs.rotLz -= 2.0f;
                }
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glLoadIdentity();
                Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            }

            if (isZoomOut)
            {
                openglcs.rotLz += 2.0f;
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glLoadIdentity();
                Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            }

            // ******************* //
            // 실행/실행 취소 설정 //
            // ******************* //
            if (openglcs.tempObjFiles.Count > 0)
            {
                doToolStripMenuItem.Enabled = true;
                pBoxRedo.Enabled = true;
                pBoxRedo.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                doToolStripMenuItem.Enabled = false;
                pBoxRedo.Enabled = false;
                pBoxRedo.BackColor = Color.Gray;
            }
            if (openglcs.tempObjFiles.Count < 3)
            {
                undoToolStripMenuItem.Enabled = true;
                pBoxUndo.Enabled = true;
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
                pBoxUndo.Enabled = false;
            }

        }



        #region 스트립 메뉴

        private void aboutS3DMakerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmabout = new frmAbout();
            frmabout.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExit frmEx = new frmExit();
            frmEx.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importOBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogOBJ.ShowDialog() == DialogResult.OK)
            {
                if ((openFileDialogOBJ.OpenFile()) != null)
                {
                    openglcs.fileNames.Clear();
                    openglcs.fileNames.Add(openFileDialogOBJ.FileName);
                    openglcs.readObj();
                    openglcs.fileNames.Clear();
                }
            }
        }

        private void exportOBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (saveFileDialogOBJ.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialogOBJ.OpenFile()) != null)
                {
                    // Insert code to read the stream here.
                    myStream.Close();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sceanChanged)
            {
                //Stream myStream;
                //saveFileDialogS3M.Title = "저장";
                //if (saveFileDialogS3M.ShowDialog() == DialogResult.OK)
                //{
                //    if ((myStream = saveFileDialogS3M.OpenFile()) != null)
                //    {
                //        // Insert code to read the stream here.
                //        myStream.Close();
                //    }
                //}
                //sceanChanged = true;
            }
            else
            {
                //다이얼로그 없이 바로 저장
                sceanChanged = true;
            }
        }
        
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            //saveFileDialogS3M.Title = "다른 이름으로 저장";
            //if (saveFileDialogS3M.ShowDialog() == DialogResult.OK)
            //{
            //    if ((myStream = saveFileDialogS3M.OpenFile()) != null)
            //    {
            //        // Insert code to read the stream here.
            //        myStream.Close();
            //    }
            //}
        }

        /// <summary>
        /// X,Y,Z 축 ON / OFF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xYZAxisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xYZAxisesToolStripMenuItem.Checked = !xYZAxisesToolStripMenuItem.Checked;
            openglcs.boolAxises = !openglcs.boolAxises;
        }

        /// <summary>
        /// 그라운드 그리드 ON / OFF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groundGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groundGridToolStripMenuItem.Checked = !groundGridToolStripMenuItem.Checked;
            openglcs.boolGroundGrid = !openglcs.boolGroundGrid;
            if (openglcs.boolGroundGrid)
            {
                pBoxView.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                pBoxView.BorderStyle = BorderStyle.None;
            }
        }

        /// <summary>
        /// 솔리드 모드로 보기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solidViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!solidViewToolStripMenuItem.Checked)
            {
                solidViewToolStripMenuItem.Checked = !solidViewToolStripMenuItem.Checked;
                wireViewToolStripMenuItem.Checked = !wireViewToolStripMenuItem.Checked;
                openglcs.boolWireMode = !openglcs.boolWireMode;
            }
            if (openglcs.boolWireMode)
            {
                pBoxViewMode.Image = global::s3m.Properties.Resources.wire;
                pBoxViewMode.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                pBoxViewMode.Image = global::s3m.Properties.Resources.solid;
                pBoxViewMode.BorderStyle = BorderStyle.None;
            }
        }

        /// <summary>
        /// 와이어 모드로 보기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wireViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!wireViewToolStripMenuItem.Checked)
            {
                wireViewToolStripMenuItem.Checked = !wireViewToolStripMenuItem.Checked;
                solidViewToolStripMenuItem.Checked = !solidViewToolStripMenuItem.Checked;
                openglcs.boolWireMode = !openglcs.boolWireMode;
            }
            if (openglcs.boolWireMode)
            {
                pBoxViewMode.Image = global::s3m.Properties.Resources.wire;
                pBoxViewMode.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                pBoxViewMode.Image = global::s3m.Properties.Resources.solid;
                pBoxViewMode.BorderStyle = BorderStyle.None;
            }
        }


        /// <summary>
        /// View Assistance 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewAssistance.Show();
        }

        /// <summary>
        /// 조명효과 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lightEffectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            light.Show();
        }

        #endregion



        /// <summary>
        /// 키보드 이벤트
        /// </summary>
        /// <param name="msg">메시지</param>
        /// <param name="e">이벤트</param>
        /// <returns>이벤트 발생 여부</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys e)
        {
            switch (e)
            {
                case Keys.F1:       // X, Y, Z 축 라인 표시 On/Off
                    openglcs.boolAxises = !openglcs.boolAxises;
                    break;
                case Keys.F2:       // X, Y, Z 축 자동 회전 On/Off
                    openglcs.boolRotation = !openglcs.boolRotation;
                    break;
                case Keys.Space:    // 초기화
                    openglcs.LastTransformation.SetIdentity(); // Reset Rotation
                    openglcs.ThisTransformation.SetIdentity(); // Reset Rotation
                    openglcs.ThisTransformation.get_Renamed(openglcs.matrix);

                    openglcs.boolRotation = false;

                    openglcs.axisX = 0.0f;
                    openglcs.axisY = 0.0f;
                    openglcs.axisZ = 0.0f;

                    openglcs.rotX = 0.0f;
                    openglcs.rotY = 0.0f;
                    openglcs.rotZ = 0.0f;

                    openglcs.rotLx = 0.0f;
                    openglcs.rotLy = 0.0f;
                    openglcs.rotLz = 0.0f;

                    viewRotation = 1;

                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
                    break;

                case Keys.W:    // 와이어 모드
                    openglcs.boolWireMode = !openglcs.boolWireMode;
                    break;
                case Keys.G:    // 그리드 표시
                    openglcs.boolGroundGrid = !openglcs.boolGroundGrid;
                    break;

                // Gl.glRotatef()
                case Keys.X:                    // X축 -회전
                    openglcs.rotX -= 1.0f;
                    break;
                case Keys.X | Keys.Shift:       // X축 +회전
                    openglcs.rotX += 1.0f;
                    break;
                case Keys.Y:	                // Y축 -회전
                    openglcs.rotY -= 1.0f;
                    break;
                case Keys.Y | Keys.Shift:	    // Y축 +회전
                    openglcs.rotY += 1.0f;
                    break;
                case Keys.Z:                    // Z축 -회전
                    openglcs.rotZ -= 1.0f;
                    break;
                case Keys.Z | Keys.Shift:       // Z축 +회전
                    openglcs.rotZ += 1.0f;
                    break;

                //Gl.glRotatef() |90|
                case Keys.U:                    // X축 기준으로 -90도 회전
                    openglcs.rotX -= 90.0f;
                    break;
                case Keys.U | Keys.Shift:       // X축 기준으로 +90도 회전
                    openglcs.rotX += 90.0f;
                    break;
                case Keys.I:	    		    // Y축 기준으로 -90도 회전
                    openglcs.rotY -= 90.0f;
                    break;
                case Keys.I | Keys.Shift:	    // Y축 기준으로 +90도 회전
                    openglcs.rotY += 90.0f;
                    break;
                case Keys.O:	    		    // Z축 기준으로 -90도 회전
                    openglcs.rotZ -= 90.0f;
                    break;
                case Keys.O | Keys.Shift:	    // Z축 기준으로 +90도 회전
                    openglcs.rotZ += 90.0f;
                    break;

                // Glu.gluLookAt()
                case Keys.OemOpenBrackets: // [ Key
                    openglcs.rotLx -= 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case Keys.OemCloseBrackets: // ] Key
                    openglcs.rotLx += 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case Keys.OemSemicolon: // ; Key
                    openglcs.rotLy -= 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case Keys.OemQuotes: // ' Key
                    openglcs.rotLy += 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case Keys.Add:
                case Keys.Oemplus:
                    if (openglcs.rotLz + openglcs.defaultRotLz - 3.0f >= 0) // z값이 일정값(15) 이하면 더 이상 확대하지 못한다.
                    {
                        openglcs.rotLz -= 2.0f;
                    }
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;
                case Keys.Subtract:
                case Keys.OemMinus:
                    openglcs.rotLz += 2.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                    break;

                //Gl.glTranslatef()
                case Keys.Left:     // X축 -이동
                    openglcs.axisX -= 2.0f;
                    break;
                case Keys.Right:	// X축 +이동
                    openglcs.axisX += 2.0f;
                    break;
                case Keys.Up:		// Y축 -이동
                    openglcs.axisY += 2.0f;
                    break;
                case Keys.Down:	    // Y축 +이동
                    openglcs.axisY -= 2.0f;
                    break;
                case Keys.PageUp:   // Z축 -이동
                    openglcs.axisZ -= 2.0f;
                    break;
                case Keys.PageDown: // Z축 +이동
                    openglcs.axisZ += 2.0f;
                    break;

                case Keys.OemPeriod:
                    openglcs.boolTeapot = !openglcs.boolTeapot;
                    break;

                case Keys.Delete:
                    if (treeView.Nodes.Count == 0)
                    {
                        openglcs.selectedIndex = -1;    // 아무것도 선택 안되게
                    }
                    else
                    {
                        openglcs.objFiles.RemoveAt(openglcs.selectedIndex);
                    }

                    if (openglcs.selectedIndex != -1)
                    {
                        treeView.Nodes.RemoveAt(openglcs.selectedIndex);
                    }

                    if (treeView.Nodes.Count == openglcs.selectedIndex)
                    {
                        --openglcs.selectedIndex;
                    }

                    if (openglcs.selectedIndex == -1)
                    {
                        propertyGridObject.SelectedObject = null;
                        propertyGridObject.Refresh();
                    }
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, e);
        }




        /// <summary>
        /// Tree View, Node 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            openglcs.selectedIndex = e.Node.Index;
        }

        /// <summary>
        /// Tree View, Node 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public String _nodeName="";
        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            openglcs.selectedIndex = e.Node.Index;
            frmNodeName nodeName = new frmNodeName();
            nodeName.Owner = this;
            nodeName.nodeName = e.Node.Text;
            if (nodeName.ShowDialog() == DialogResult.OK)
            {
                e.Node.Text = _nodeName;
            }
        }





        private void pBoxNew_MouseEnter(object sender, EventArgs e)
        {
            pBoxNew.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxNew_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxNew.BorderStyle = BorderStyle.Fixed3D;

            openglcs.vertexList.Clear();
            openglcs.kObjList.Clear();
            openglcs.objFiles.Clear();
            treeView.Nodes.Clear();

            openglcs.LastTransformation.SetIdentity(); // Reset Rotation
            openglcs.ThisTransformation.SetIdentity(); // Reset Rotation
            openglcs.ThisTransformation.get_Renamed(openglcs.matrix);

            openglcs.boolAxises = true;
            openglcs.boolRotation = false;
            openglcs.boolGroundGrid = true;

            openglcs.axisX = 0.0f;
            openglcs.axisY = 0.0f;
            openglcs.axisZ = 0.0f;

            openglcs.rotX = 0.0f;
            openglcs.rotY = 0.0f;
            openglcs.rotZ = 0.0f;

            openglcs.rotLx = 0.0f;
            openglcs.rotLy = 0.0f;
            openglcs.rotLz = 0.0f;

            viewRotation = 1;

            propertyGridSpace.Refresh();
            propertyGridObject.Refresh();

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }
        private void pBoxNew_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxNew.BorderStyle = BorderStyle.None;
        }
        private void pBoxNew_MouseLeave(object sender, EventArgs e)
        {
            pBoxNew.BorderStyle = BorderStyle.None;
        }



        private void pBoxOpen_MouseEnter(object sender, EventArgs e)
        {
            pBoxOpen.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxOpen_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxOpen.BorderStyle = BorderStyle.Fixed3D;

            if (openFileDialogOBJ.ShowDialog() == DialogResult.OK)
            {
                if ((openFileDialogOBJ.OpenFile()) != null)
                {
                    openglcs.fileNames.Clear();
                    openglcs.fileNames.Add(openFileDialogOBJ.FileName);
                    openglcs.readObj();
                    openglcs.fileNames.Clear();
                }
            }
        }
        private void pBoxOpen_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxOpen.BorderStyle = BorderStyle.None;
        }
        private void pBoxOpen_MouseLeave(object sender, EventArgs e)
        {
            pBoxOpen.BorderStyle = BorderStyle.None;
        }



        // ************* //
        // OBJ 파일 저장 //
        // ************* //
        private void pBoxSave_MouseEnter(object sender, EventArgs e)
        {
            pBoxSave.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxSave_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxSave.BorderStyle = BorderStyle.Fixed3D;

            Stream myStream;

            if (saveFileDialogOBJ.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialogOBJ.OpenFile()) != null)
                {
                    saveObj(myStream);
                    
                }
            }
        }

        private void pBoxSave_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxSave.BorderStyle = BorderStyle.None;
        }
        private void pBoxSave_MouseLeave(object sender, EventArgs e)
        {
            pBoxSave.BorderStyle = BorderStyle.None;
        }



        private void pBoxUndo_MouseEnter(object sender, EventArgs e)
        {
            pBoxUndo.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxUndo_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxUndo.BorderStyle = BorderStyle.Fixed3D;
            if (openglcs.objFiles.Count > 0)
            {
                openglcs.tempObjFiles.Add(openglcs.objFiles[openglcs.objFiles.Count - 1]);
                openglcs.objFiles.RemoveAt(openglcs.objFiles.Count - 1);
            }
        }
        private void pBoxUndo_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxUndo.BorderStyle = BorderStyle.None;
        }
        private void pBoxUndo_MouseLeave(object sender, EventArgs e)
        {
            pBoxUndo.BorderStyle = BorderStyle.None;
        }




        private void pBoxRedo_MouseEnter(object sender, EventArgs e)
        {
            pBoxRedo.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxRedo_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxRedo.BorderStyle = BorderStyle.Fixed3D;
            openglcs.objFiles.Add(openglcs.tempObjFiles[openglcs.tempObjFiles.Count - 1]);
            openglcs.tempObjFiles.RemoveAt(openglcs.tempObjFiles.Count - 1);
        }
        private void pBoxRedo_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxRedo.BorderStyle = BorderStyle.None;
        }
        private void pBoxRedo_MouseLeave(object sender, EventArgs e)
        {
            pBoxRedo.BorderStyle = BorderStyle.None;
        }




        private void pBoxDefault_MouseEnter(object sender, EventArgs e)
        {
            pBoxDefault.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxDefault_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxDefault.BorderStyle = BorderStyle.Fixed3D;

            openglcs.LastTransformation.SetIdentity(); // Reset Rotation
            openglcs.ThisTransformation.SetIdentity(); // Reset Rotation
            openglcs.ThisTransformation.get_Renamed(openglcs.matrix);

            openglcs.boolRotation = false;

            openglcs.axisX = 0.0f;
            openglcs.axisY = 0.0f;
            openglcs.axisZ = 0.0f;

            openglcs.rotX = 0.0f;
            openglcs.rotY = 0.0f;
            openglcs.rotZ = 0.0f;

            openglcs.rotLx = 0.0f;
            openglcs.rotLy = 0.0f;
            openglcs.rotLz = 0.0f;

            viewRotation = 1;

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(openglcs.rotLx, openglcs.rotLy, openglcs.defaultRotLz + openglcs.rotLz, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }
        private void pBoxDefault_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxDefault.BorderStyle = BorderStyle.None;
        }
        private void pBoxDefault_MouseLeave(object sender, EventArgs e)
        {
            pBoxDefault.BorderStyle = BorderStyle.None;
        }


        #region 전후좌우상하 6면 뷰 전환

        public int viewRotation = 1;

        // ********* //
        // 앞면 보기 //
        // ********* //
        private void pBoxFront_MouseEnter(object sender, EventArgs e)
        {
            pBoxFront.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxFront_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxFront.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pBoxFront_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxFront.BorderStyle = BorderStyle.None;
            viewRotation = 1;
            ViewTimer.Start();
        }
        private void pBoxFront_MouseLeave(object sender, EventArgs e)
        {
            pBoxFront.BorderStyle = BorderStyle.None;
        }



        // ********* //
        // 뒷면 보기 //
        // ********* //
        private void pBoxBack_MouseEnter(object sender, EventArgs e)
        {
            pBoxBack.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxBack_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxBack.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pBoxBack_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxBack.BorderStyle = BorderStyle.None;
            viewRotation = 2;
            ViewTimer.Start();
        }
        private void pBoxBack_MouseLeave(object sender, EventArgs e)
        {
            pBoxBack.BorderStyle = BorderStyle.None;
        }



        // ********* //
        // 좌면 보기 //
        // ********* //
        private void pBoxLeft_MouseEnter(object sender, EventArgs e)
        {
            pBoxLeft.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxLeft_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxLeft.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pBoxLeft_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxLeft.BorderStyle = BorderStyle.None;
            viewRotation = 3;
            ViewTimer.Start();
        }
        private void pBoxLeft_MouseLeave(object sender, EventArgs e)
        {
            pBoxLeft.BorderStyle = BorderStyle.None;
        }



        // ********* //
        // 우면 보기 //
        // ********* //
        private void pBoxRight_MouseEnter(object sender, EventArgs e)
        {
            pBoxRight.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxRight_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxRight.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pBoxRight_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxRight.BorderStyle = BorderStyle.None;
            viewRotation = 4;
            ViewTimer.Start();
        }
        private void pBoxRight_MouseLeave(object sender, EventArgs e)
        {
            pBoxRight.BorderStyle = BorderStyle.None;
        }



        // ********* //
        // 상면 보기 //
        // ********* //
        private void pBoxTop_MouseEnter(object sender, EventArgs e)
        {
            pBoxTop.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxTop_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxTop.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pBoxTop_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxTop.BorderStyle = BorderStyle.None;
            viewRotation = 5;
            ViewTimer.Start();
        }
        private void pBoxTop_MouseLeave(object sender, EventArgs e)
        {
            pBoxTop.BorderStyle = BorderStyle.None;
        }



        // ********* //
        // 하면 보기 //
        // ********* //
        private void pBoxBottom_MouseEnter(object sender, EventArgs e)
        {
            pBoxBottom.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxBottom_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxBottom.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pBoxBottom_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxBottom.BorderStyle = BorderStyle.None;
            viewRotation = 6;
            ViewTimer.Start();
        }
        private void pBoxBottom_MouseLeave(object sender, EventArgs e)
        {
            pBoxBottom.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// 전후좌우상하 뷰 전환
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewTimer_Tick(object sender, EventArgs e)
        {
            int stdX = 0;
            int stdY = 0;
            int stdZ = 0;
            switch (viewRotation)
            {
                case 1: //전
                    stdX = 0;
                    stdY = 0;
                    stdZ = 0;
                    break;
                case 2: //후
                    stdX = 0;
                    stdY = 180;
                    stdZ = 0;
                    break;
                case 3: //좌
                    stdX = 0;
                    stdY = 90;
                    stdZ = 0;
                    break;
                case 4: //우
                    stdX = 0;
                    stdY = -90;
                    stdZ = 0;
                    break;
                case 5: //상
                    stdX = 90;
                    stdY = 0;
                    stdZ = 0;
                    break;
                case 6: //하
                    stdX = -90;
                    stdY = 0;
                    stdZ = 0;
                    break;
                default:
                    break;
            }
            if (openglcs.rotX > stdX)
            {
                openglcs.rotX -= 1f;
                openglcs.renderScene();
            }
            else if (openglcs.rotX < stdX)
            {
                openglcs.rotX += 1f;
                openglcs.renderScene();
            }
            if (openglcs.rotY > stdY)
            {
                openglcs.rotY -= 1f;
                openglcs.renderScene();
            }
            else if (openglcs.rotY < stdY)
            {
                openglcs.rotY += 1f;
                openglcs.renderScene();
            }
            if (openglcs.rotZ > stdZ)
            {
                openglcs.rotZ -= 1f;
                openglcs.renderScene();
            }
            else if (openglcs.rotZ < stdZ)
            {
                openglcs.rotZ += 1f;
                openglcs.renderScene();
            }

        }

        #endregion



        // ******************** //
        // 와이어 / 솔리드 모드 //
        // ******************** //
        private void pBoxViewMode_MouseEnter(object sender, EventArgs e)
        {
            pBoxViewMode.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxViewMode_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxViewMode.BorderStyle = BorderStyle.Fixed3D;
            openglcs.boolWireMode = !openglcs.boolWireMode;
            if (openglcs.boolWireMode)
            {
                pBoxViewMode.Image = global::s3m.Properties.Resources.wire;
                wireViewToolStripMenuItem.Checked = !wireViewToolStripMenuItem.Checked;
                solidViewToolStripMenuItem.Checked = !solidViewToolStripMenuItem.Checked;
            }
            else
            {
                pBoxViewMode.Image = global::s3m.Properties.Resources.solid;
                wireViewToolStripMenuItem.Checked = !wireViewToolStripMenuItem.Checked;
                solidViewToolStripMenuItem.Checked = !solidViewToolStripMenuItem.Checked;
            }
        }
        private void pBoxViewMode_MouseUp(object sender, MouseEventArgs e)
        {
            if (openglcs.boolWireMode)
            {
                pBoxViewMode.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                pBoxViewMode.BorderStyle = BorderStyle.None;
            }
        }
        private void pBoxViewMode_MouseLeave(object sender, EventArgs e)
        {
            if (openglcs.boolWireMode)
            {
                pBoxViewMode.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                pBoxViewMode.BorderStyle = BorderStyle.None;
            }
        }



        // ************* //
        // 조명 ON / OFF //
        // ************* //
        private void pBoxLight_MouseEnter(object sender, EventArgs e)
        {
            pBoxLight.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxLight_MouseDown(object sender, MouseEventArgs e)
        {
            if (!openglcs.light.ambientLight)
            {
                pBoxLight.BorderStyle = BorderStyle.Fixed3D;
            }
            openglcs.light.ambientLight = !openglcs.light.ambientLight;
        }
        private void pBoxLight_MouseUp(object sender, MouseEventArgs e)
        {
            if (!openglcs.light.ambientLight)
            {
                pBoxLight.BorderStyle = BorderStyle.None;
            }
            else
            {
                pBoxLight.BorderStyle = BorderStyle.Fixed3D;
            }
        }
        private void pBoxLight_MouseLeave(object sender, EventArgs e)
        {
            if (!openglcs.light.ambientLight)
            {
                pBoxLight.BorderStyle = BorderStyle.None;
            }
            else
            {
                pBoxLight.BorderStyle = BorderStyle.Fixed3D;
            }
        }



        // *************** //
        // 그리드 ON / OFF //
        // *************** //
        private void pBoxView_MouseEnter(object sender, EventArgs e)
        {
            pBoxView.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxView_MouseDown(object sender, MouseEventArgs e)
        {
            if (!openglcs.boolGroundGrid)
            {
                pBoxView.BorderStyle = BorderStyle.Fixed3D;
            }
            openglcs.boolGroundGrid = !openglcs.boolGroundGrid;
            groundGridToolStripMenuItem.Checked = !groundGridToolStripMenuItem.Checked;
        }
        private void pBoxView_MouseUp(object sender, MouseEventArgs e)
        {
            if (!openglcs.boolGroundGrid)
            {
                pBoxView.BorderStyle = BorderStyle.None;
            }
            else
            {
                pBoxView.BorderStyle = BorderStyle.Fixed3D;
            }
        }
        private void pBoxView_MouseLeave(object sender, EventArgs e)
        {
            if (!openglcs.boolGroundGrid)
            {
                pBoxView.BorderStyle = BorderStyle.None;
            }
            else
            {
                pBoxView.BorderStyle = BorderStyle.Fixed3D;
            }
        }


        // ****** //
        // 텍스쳐 //
        // ****** //
        private void pBoxTexture_MouseEnter(object sender, EventArgs e)
        {
            pBoxTexture.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxTexture_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxTexture.BorderStyle = BorderStyle.Fixed3D;

            ImageObjectExtration.Form1 form = new ImageObjectExtration.Form1();
            form.Set3DForm(this);
            form.Show();



        }

        


        private void pBoxTexture_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxTexture.BorderStyle = BorderStyle.None;
        }
        private void pBoxTexture_MouseLeave(object sender, EventArgs e)
        {
            pBoxTexture.BorderStyle = BorderStyle.None;
        }




        public bool isZoomIn;
        // ***** //
        // 줌 인 //
        // ***** //
        private void pBoxZoomIn_MouseEnter(object sender, EventArgs e)
        {
            pBoxZoomIn.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxZoomIn.BorderStyle = BorderStyle.Fixed3D;
            isZoomIn = true;
        }
        private void pBoxZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            isZoomIn = false;
            pBoxZoomIn.BorderStyle = BorderStyle.None;
        }
        private void pBoxZoomIn_MouseLeave(object sender, EventArgs e)
        {
            isZoomIn = false;
            pBoxZoomIn.BorderStyle = BorderStyle.None;
        }


        public bool isZoomOut;
        // ******* //
        // 줌 아웃 //
        // ******* //
        private void pBoxZoomOut_MouseEnter(object sender, EventArgs e)
        {
            pBoxZoomOut.BorderStyle = BorderStyle.FixedSingle;
        }
        private void pBoxZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            pBoxZoomOut.BorderStyle = BorderStyle.Fixed3D;
            isZoomOut = true;
        }
        private void pBoxZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            isZoomOut = false;
            pBoxZoomOut.BorderStyle = BorderStyle.None;
        }
        private void pBoxZoomOut_MouseLeave(object sender, EventArgs e)
        {
            isZoomOut = false;
            pBoxZoomOut.BorderStyle = BorderStyle.None;
        }


        /// <summary>
        /// 실행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openglcs.objFiles.Add(openglcs.tempObjFiles[openglcs.tempObjFiles.Count - 1]);
            openglcs.tempObjFiles.RemoveAt(openglcs.tempObjFiles.Count - 1);
        }

        /// <summary>
        /// 실행 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openglcs.objFiles.Count > 0)
            {
                openglcs.tempObjFiles.Add(openglcs.objFiles[openglcs.objFiles.Count - 1]);
                openglcs.objFiles.RemoveAt(openglcs.objFiles.Count - 1);
            }
        }



        bool isCopied = false;
        /// <summary>
        /// Object 복사
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCopied = true;
            if (openglcs.selectedIndex != -1)
            {
                openglcs.CopyObjFile = (obj)openglcs.objFiles[openglcs.selectedIndex].Clone();
            }
        }

        

        /// <summary>
        /// Object 붙여넣기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isCopied)
            {
                for (int i = 0; i < openglcs.CopyObjFile.v.Length / 4; i++)
                {
                    openglcs.CopyObjFile.v[i, 0] += 10;
                    openglcs.CopyObjFile.v[i, 1] += 10;
                }
                if (openglcs.CopyObjFile != null)
                {
                    openglcs.objFiles.Add(new obj(openglcs.CopyObjFile.type, openglcs.CopyObjFile.v, openglcs.CopyObjFile.vt, openglcs.CopyObjFile.vn, openglcs.CopyObjFile.f));
                    openglcs.addTreeView("CopiedObject" + openglcs.objectCount);
                }
                openglcs.selectedIndex = openglcs.objFiles.Count - 1;
            }
            isCopied = false;
        }



        // **** //
        // 회전 //
        // **** //
        private void pBoxRotation_MouseEnter(object sender, EventArgs e)
        {
            if (!openglcs.boolRotation)
            {
                pBoxRotation.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void pBoxRotation_MouseDown(object sender, MouseEventArgs e)
        {
            if (!openglcs.boolRotation)
            {
                pBoxView.BorderStyle = BorderStyle.Fixed3D;
            }
            openglcs.boolRotation = !openglcs.boolRotation;
        }
        private void pBoxRotation_MouseUp(object sender, MouseEventArgs e)
        {
            if (!openglcs.boolRotation)
            {
                pBoxRotation.BorderStyle = BorderStyle.None;
            }
            else
            {
                pBoxRotation.BorderStyle = BorderStyle.Fixed3D;
            }
        }
        private void pBoxRotation_MouseLeave(object sender, EventArgs e)
        {
            if (openglcs.boolRotation)
            {
                pBoxRotation.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                pBoxRotation.BorderStyle = BorderStyle.None;
            }
        }


        /// <summary>
        /// 속성 그리드 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabProperty_Click(object sender, EventArgs e)
        {
            if (openglcs.selectedIndex != -1)
            {
                propertyGridObject.SelectedObject = openglcs.objFiles[openglcs.selectedIndex];
                treeView.SelectedNode = treeView.Nodes[openglcs.selectedIndex];
            }
            else
            {
                propertyGridObject.SelectedObject = null;
            }
        }

        // ************************ //
        // 환경 속성 값 변경 이벤트 //
        // ************************ //
        private void propertyGridSpace_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            openglcs.axisX = property.AxisX;
            openglcs.axisY = property.AxisY;
            openglcs.axisZ = property.AxisZ;

            openglcs.rotLx = property.EYEX;
            openglcs.rotLy = property.EYEY;
            openglcs.rotLz = property.EYEZ;

            openglcs.rotX = property.RotX;
            openglcs.rotY = property.RotY;
            openglcs.rotZ = property.RotZ;

            propertyGridSpace.Refresh();
            openglcs.renderScene();
        }

        private void propertyGridSpace_Enter(object sender, EventArgs e)
        {
            timer.Stop();
            propertyGridSpace.Refresh();
            //Console.WriteLine("STOP");
        }

        private void propertyGridSpace_Leave(object sender, EventArgs e)
        {
            timer.Start();
            propertyGridSpace.Refresh();
            //Console.WriteLine("START");
        }


        // *************************** //
        // 오브젝트 속성값 변경 이벤트 //
        // *************************** //
        private void propertyGridObject_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            propertyGridObject.Refresh();
            openglcs.renderScene();
            //Console.WriteLine("Changed");
        }

        private void propertyGridObject_Enter(object sender, EventArgs e)
        {
            timer.Stop();
            propertyGridObject.Refresh();
            //Console.WriteLine("STOP");
        }

        private void propertyGridObject_Leave(object sender, EventArgs e)
        {
            timer.Start();
            propertyGridObject.Refresh();
            //Console.WriteLine("START");
        }

        private void splitContainer1_Panel1_MouseEnter(object sender, EventArgs e)
        {
            timer.Start();
        }


        // **************** //
        // .OBJ 파일로 저장 //
        // **************** //
        public void saveObj(Stream stream)
        {
            int v = 0;
            int vt = 0;
            int vn = 0;
            int f = 0;

            if (openglcs.objFiles.Count > 0)
            {
                StreamWriter sw = new StreamWriter(stream);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                string[] name = (saveFileDialogOBJ.FileName).Split('\\');
                sw.WriteLine("#Simple 3D Maker");
                sw.WriteLine("# " + name[name.Length-1]);
                
                sw.WriteLine();

                //obj 객체 개수만큼 돌린다
                for (int i = 0; i < openglcs.objFiles.Count; i++)
                {
                    if (openglcs.objFiles[i].txextureMapPath == "")
                    {
                    }
                    else
                    {
                        sw.WriteLine("#mtllib " + name[name.Length-1].Replace(".obj",".mtl"));
                    }
                    sw.WriteLine();
                    sw.WriteLine("g " + "objcet" + i);
                    sw.WriteLine();

                    //i번째 obj 객체의 v
                    for (int j = 0; j < (openglcs.objFiles[i].v.Length / 4f); j++)
                    {
                        sw.Write("v");
                        sw.Write("  ");
                        sw.Write(openglcs.objFiles[i].v[j, 0]);
                        sw.Write("  ");
                        sw.Write(openglcs.objFiles[i].v[j, 1]);
                        sw.Write("  ");
                        sw.Write(openglcs.objFiles[i].v[j, 2]);
                        sw.WriteLine();
                    }
                    sw.WriteLine("# " + openglcs.objFiles[i].v.Length / 4 + "vertexes");
                    sw.WriteLine();



                    //i번째 obj 객체의 vt
                    for (int j = 0; j < (openglcs.objFiles[i].vt.Length / 4); j++)
                    {
                        sw.Write("vt");
                        sw.Write("  ");
                        sw.Write(openglcs.objFiles[i].vt[j, 0]);
                        sw.Write("  ");
                        sw.Write(openglcs.objFiles[i].vt[j, 1]);
                        sw.WriteLine();
                    }
                    sw.WriteLine("# " + openglcs.objFiles[i].v.Length / 4 + "vertex textures");
                    sw.WriteLine();



                    //i번째 obj 객체의 vn
                    for (int j = 0; j < (openglcs.objFiles[i].vn.Length / 4); j++)
                    {
                        sw.WriteLine("# here is vn list");
                    }
                    sw.WriteLine("# " + openglcs.objFiles[i].v.Length / 4 + "vertex normals");
                    sw.WriteLine();
                    if (openglcs.objFiles[i].txextureMapPath == "")
                    {
                    }
                    else
                    {
                        sw.WriteLine("#usemtl " + (openglcs.objFiles[i].txextureMapPath).Substring((openglcs.objFiles[i].txextureMapPath).LastIndexOf("\\")+1, (openglcs.objFiles[i].txextureMapPath).Length - (openglcs.objFiles[i].txextureMapPath).LastIndexOf("\\")-5));

                        FileStream fs = new FileStream(saveFileDialogOBJ.FileName.Replace(".obj",".mtl"), FileMode.Append);
                        
                        StreamWriter sw_mtl = new StreamWriter(fs);
                        
                        sw_mtl.BaseStream.Seek(0, SeekOrigin.End);
                        sw_mtl.WriteLine("newmtl " + (openglcs.objFiles[i].txextureMapPath).Substring((openglcs.objFiles[i].txextureMapPath).LastIndexOf("\\") + 1, (openglcs.objFiles[i].txextureMapPath).Length - (openglcs.objFiles[i].txextureMapPath).LastIndexOf("\\") - 5));
                        sw_mtl.WriteLine();
                        sw_mtl.WriteLine("map_Kd " + (openglcs.objFiles[i].txextureMapPath).Substring((openglcs.objFiles[i].txextureMapPath).LastIndexOf("\\") + 1, (openglcs.objFiles[i].txextureMapPath).Length - (openglcs.objFiles[i].txextureMapPath).LastIndexOf("\\") - 1));
                        sw_mtl.Close();
                        fs.Close();
                    }
                    sw.WriteLine();

                    //i번째 obj 객체의 f
                    for (int j = 0; j < (openglcs.objFiles[i].f.Length / 12); j++)
                    {
                        sw.Write("f");

                        sw.Write("  ");

                        sw.Write(openglcs.objFiles[i].f[j, 0, 0] + v);
                        sw.Write("/");
                        sw.Write(openglcs.objFiles[i].f[j, 0, 1] + vt);
                        sw.Write("/");
                        sw.Write(openglcs.objFiles[i].f[j, 0, 2] + vn);

                        sw.Write("  ");

                        sw.Write(openglcs.objFiles[i].f[j, 1, 0] + v);
                        sw.Write("/");
                        sw.Write(openglcs.objFiles[i].f[j, 1, 1] + vt);
                        sw.Write("/");
                        sw.Write(openglcs.objFiles[i].f[j, 1, 2] + vn);

                        sw.Write("  ");

                        sw.Write(openglcs.objFiles[i].f[j, 2, 0] + v);
                        sw.Write("/");
                        sw.Write(openglcs.objFiles[i].f[j, 2, 1] + vt);
                        sw.Write("/");
                        sw.Write(openglcs.objFiles[i].f[j, 2, 2] + vn);

                        sw.WriteLine();
                        
                        sw.WriteLine("# " + openglcs.objFiles[i].f.Length / 12 + "faces");
                    }
                    v += openglcs.objFiles[i].v.Length / 4; // 누적된 v값 수
                    vt += openglcs.objFiles[i].vt.Length / 4; // 누적된 v값 수
                    vn += openglcs.objFiles[i].vn.Length / 4; // 누적된 v값 수
                    f += openglcs.objFiles[i].f.Length / 12; // 누적된 v값 수
                }

                sw.Flush();
                sw.Close();
            }
        }
        public void ShowIamgePath(string path)
        {
            MessageBox.Show(path);
            openglcs.TexMapping(path);
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                if ((openFileDialogImage.OpenFile()) != null)
                {
                    openglcs.TexMapping(openFileDialogImage.FileName);
                }
            }
        }
        
    }
}
