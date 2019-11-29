using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Microsoft.DirectX;
using System.IO;
using System.Drawing;
using kObjectClass;
using System.Drawing.Imaging;

namespace s3m
{
    public struct vertex
    {
        public int type;
        
        public float x;
        public float y;
        public float z;

        public vertex(float _x, float _y, float _z)
        {
            type = -1;
            x = _x;
            y = _y;
            z = _z;
        }

        public vertex(int _type, float _x, float _y, float _z)
        {
            type = _type;
            x = _x;
            y = _y;
            z = _z;
        }
    }

    public partial class opengl : UserControl
    {

        //성민이 변수
        bool isTexture = true;
        int[] tempTexture;
        int TextureIndex = 0;
        frmMain thisfrmMain;


        // OBJ 파일 ------------------------------ //

        string line = "";
        string[] lines;

        int vIndex = 0;
        int vnIndex = 0;
        int vtIndex = 0;
        int fIndex = 0;

        public int numberOfVertexCoords  = 0;
        public int numberOfTextureCoords = 0;
        public int numberOfNormals       = 0;
        public int numberOfPolygons      = 0;

        List<StreamReader> objReader = new List<StreamReader>();
        List<StreamReader> reObjReader = new List<StreamReader>();
        public List<string> fileNames = new List<string>();
        public List<obj> objFiles = new List<obj>();
        public List<obj> tempObjFiles = new List<obj>();
        public obj CopyObjFile = new obj();

        public int selectedIndex=-1;

        // OBJ 파일 ------------------------------ //



        // OBJ 파일 변환 ------------------------- //

        public float[] xScale;
        public float[] yScale;
        public float[] zScale;

        public List<float> xRot;
        public List<float> yRot;
        public List<float> zRot;

        public float[] xTrans;
        public float[] yTrans;
        public float[] zTrans;

        public float[] xSort;
        public float[] ySort;
        public float[] zSort;

        public int edit;

        // OBJ 파일 변환 ------------------------- //




        // 정육면체, 구를 OBJ로 포맷으로 저장 ---------- //

        float[,] vRect;
        float[,] vtRect;
        float[,] vnRect;
        int[, ,] fRect;     // 폴리곤 갯수, 4개의 V, V의 XYZ

        float[,] vSphere;
        float[,] vtSphere;
        float[,] vnSphere;
        int[, ,] fSphere;

        // 정육면체 OBJ로 포맷으로 저장 ---------- //


        // 속성 설정 ---------------------------------- //

        public Property property;   // 속성 뷰
        public TreeView treeView;   // 오브젝트 뷰
        public frmViewAssistance viewAssistance;
        public frmLight light;

        public int MODE=0;          // 그리기 모드
        const int PEN = 0;
        const int LINE = 1;
        const int RECT = 2;
        const int CIRCLE = 3;

        const int SELECT = 11;
        const int SCALE = 12;
        const int ROTATION = 13;
        const int TRANSLATE = 14;
        const int AXIS = 15;

        const float RANGE = 100.0f;

        // 속성 설정 ---------------------------------- //



        // 좌표 및 회전값 ----------------------------------------- //

        public float axisX = 0.0f;		// X축 중심 위치
        public float axisY = 0.0f;		// Y축 중심 위치
        public float axisZ = 0.0f;		// Z축 중심 위치

        public float x = 0.0f;          // x좌표
        public float y = 0.0f;          // y좌표
        public float z = 0.0f;          // z좌표
        public float t = 0.0f;          // 임시 좌표

        float startX;                   // 마우스 다운시 X좌표
        float startY;                   // 마우스 다운시 Y좌표
        float startZ;                   // 마우스 다운시 Z좌표

        public float rotX = 0.0f;	    // X축 회전값
        public float rotY = 0.0f;	    // Y축 회전값
        public float rotZ = 0.0f;	    // Z축 회전값

        public float rotLx = 0.0f;      // X축 시점 이동
        public float rotLy = 0.0f;      // Y축 시점 이동
        public float rotLz = 0.0f;      // Z축 시점 이동

        public float defaultRotLz = RANGE / 2;  //Z축 기본 카메라 위치

        public List<vertex> vertexList = new List<vertex>();    // 정점 정보
        public List<kObject> kObjList = new List<kObject>();    // 정점 정보를 저장하는 3D 오브젝트

        // 좌표 및 회전값 ----------------------------------------- //



        // ArcBall 구현 ------------------------------------------- //

        private System.Object matrixLock = new System.Object();
        private ArcBall arcBall;
        public float[] matrix = new float[16];
        public Matrix4f LastTransformation = new Matrix4f();
        public Matrix4f ThisTransformation = new Matrix4f();
        private float arcStartX = 0.0f;
        private float arcStartY = 0.0f;

        // ArcBall 구현 ------------------------------------------- //



        // ON / OFF 모드 설정 ------------------------------------- //

        public bool boolAxises      = true;         // X, Y, Z축 보기
        public bool boolRotation    = false;        // 축 자동 회전
        public bool boolGroundGrid  = true;         // 그라운드 그리드 보기
        public bool boolWireMode    = false;        // 와이어 모드 보기
        public bool boolTeapot      = false;         // 테스트용 주전자 보기

        // ON / OFF 모드 설정 ------------------------------------- //



        public opengl()
        {
            InitializeComponent();
        }

        public opengl(ref Property property)
        {
            InitializeComponent();
            this.property = property;
            viewAssistance = new frmViewAssistance();
        }

        public opengl(ref Property property, ref TreeView treeView, ref frmViewAssistance viewAssistance, ref frmLight light)
        {
            InitializeComponent();
            this.property = property;
            this.treeView = treeView;
            this.viewAssistance = viewAssistance;
            this.light = light;

            tempTexture = new int[1024];
            Gl.glGenTextures(100, tempTexture);
            
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            simpleOpenGlControl1.InitializeContexts();
            simpleOpenGlControl1.Size = this.Size;

            arcBall = new ArcBall(this.Width, this.Height);
            LastTransformation.SetIdentity();
            ThisTransformation.SetIdentity();
            ThisTransformation.get_Renamed(matrix);

            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width, simpleOpenGlControl1.Size.Height);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(90, (float)simpleOpenGlControl1.Size.Width / (float)simpleOpenGlControl1.Size.Height, 0.1, 1000.0);
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glu.gluLookAt(rotLx, rotLy, defaultRotLz + rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            simpleOpenGlControl1.InitializeContexts();
            simpleOpenGlControl1.Size = this.Size;

            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width, simpleOpenGlControl1.Size.Height);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(90, (float)simpleOpenGlControl1.Size.Width / (float)simpleOpenGlControl1.Size.Height, 0.1, 1000.0);
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glu.gluLookAt(rotLx, rotLy, defaultRotLz + rotLz, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            ThisTransformation.get_Renamed(matrix);

            boolAxises = true;
            boolRotation = false;
            axisX = axisY = 0.0f;
            axisZ = 0.0f;
            rotX = 0.0f;
            rotY = 0.0f;
            rotZ = 0.0f;
            rotLx = 0.0f;
            rotLy = 0.0f;
            rotLz = 0.0f;
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(rotLx, rotLy, defaultRotLz + rotLz, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
            
        }

        /// <summary>
        /// TreeView 부모 노드 추가
        /// </summary>
        /// <param name="parentNodes">추가할 부모 노드</param>
        public void addTreeView(string parentNodes)
        {
            //treeView.Nodes.Clear();
            treeView.BeginUpdate();
            treeView.Nodes.Add(parentNodes);
            treeView.EndUpdate();
        }

        /// <summary>
        /// TreeView 노드 삭제
        /// </summary>
        public void removeTreeView()
        {
            treeView.BeginUpdate();
            treeView.Nodes.RemoveAt(selectedIndex);
            treeView.EndUpdate();
        }


        /// <summary>
        /// 그리기
        /// </summary>
        public void renderScene()
        {
            if (property.Mode == "SELECT")
            {
                simpleOpenGlControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
            {
                simpleOpenGlControl1.Cursor = System.Windows.Forms.Cursors.Default;
            }

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
            Gl.glMultMatrixf(matrix);
            
            // ******************* //
            // 회전값, 축이동 적용 //
            // ******************* //
            Gl.glRotatef(rotX, 1.0f, 0.0f, 0.0f);			// X축 회전
            Gl.glRotatef(rotY, 0.0f, 1.0f, 0.0f);			// Y축 회전
            Gl.glRotatef(rotZ, 0.0f, 0.0f, 1.0f);			// Z축 회전

            if (boolRotation) // F2 키로 회전 Bool 값 변환 가능
            {
                rotX += 0.5f;
                rotY += 0.5f;
                rotZ += 0.5f;
            }

            Gl.glTranslatef(axisX, axisY, axisZ);		// X, Y, Z 값으로 이동

            // ********************** //
            // X, Y, Z 축 Line 그리기 //
            // ********************** //
            if (boolAxises)
            {
                // X, Y, Z 양의 축
                Gl.glLineWidth(3.0f);
                Gl.glBegin(Gl.GL_LINES);
                    Gl.glColor3f(viewAssistance.axisXColorR / 255, viewAssistance.axisXColorG / 255, viewAssistance.axisXColorB / 255);		    // X축 빨간색
                    Gl.glVertex3f(0f, 0f, 0f);
                    Gl.glVertex3f(viewAssistance.AxisesSize, 0f, 0f);
                    Gl.glColor3f(viewAssistance.axisYColorR / 255, viewAssistance.axisYColorG / 255, viewAssistance.axisYColorB / 255);			// Y축 초록색
                    Gl.glVertex3f(0f, 0f, 0f);
                    Gl.glVertex3f(0f, viewAssistance.AxisesSize, 0f);
                    Gl.glColor3f(viewAssistance.axisZColorR / 255, viewAssistance.axisZColorG / 255, viewAssistance.axisZColorB / 255);			// Z축 파란색
                    Gl.glVertex3f(0f, 0f, 0f);
                    Gl.glVertex3f(0f, 0f, viewAssistance.AxisesSize);
                Gl.glEnd();

                // X, Y, Z 음의 축
                Gl.glEnable(Gl.GL_LINE_STIPPLE);				// 점선으로 그리기
                Gl.glLineStipple(1, 0x00FF);                    // 점선 간격

                Gl.glLineWidth(3.0f);
                Gl.glBegin(Gl.GL_LINES);
                    Gl.glColor3f(viewAssistance.axisXColorR / 255, viewAssistance.axisXColorG / 255, viewAssistance.axisXColorB / 255);			    // X축 빨간색
                    Gl.glVertex3f(-viewAssistance.AxisesSize, 0f, 0f);
                    Gl.glVertex3f(0f, 0f, 0f);
                    Gl.glColor3f(viewAssistance.axisYColorR / 255, viewAssistance.axisYColorG / 255, viewAssistance.axisYColorB / 255);				// Y축 초록색
                    Gl.glVertex3f(0f, 0f, 0f);
                    Gl.glVertex3f(0f, -viewAssistance.AxisesSize, 0f);
                    Gl.glColor3f(viewAssistance.axisZColorR / 255, viewAssistance.axisZColorG / 255, viewAssistance.axisZColorB / 255);				// Z축 파란색
                    Gl.glVertex3f(0f, 0f, 0f);
                    Gl.glVertex3f(0f, 0f, -viewAssistance.AxisesSize);
                Gl.glEnd();

                Gl.glDisable(Gl.GL_LINE_STIPPLE);               // 점선으로 그리기 끝
            }



            // ********************** //
            // 그라운드 그리드 그리기 //
            // ********************** //
            if (boolGroundGrid)
            {
                float step = viewAssistance.gridStep; // 그리드 단위
                float y = viewAssistance.gridLocationY;    //Y축 0보다 조금 낮게 그리기 ( 그래야 X, Z축이 보이니까 )

                Gl.glLineWidth(0.1f);
                Gl.glBegin(Gl.GL_LINES);
                for (float line = -viewAssistance.gridSize; line <= viewAssistance.gridSize; line += step)
                {
                    Gl.glColor3f(viewAssistance.gridColorR / 255, viewAssistance.gridColorG / 255, viewAssistance.gridColorB / 255);

                    Gl.glVertex3f(line, y, viewAssistance.gridSize); //Z축 방향 라인 그리기
                    Gl.glVertex3f(line, y, -viewAssistance.gridSize);

                    Gl.glVertex3f(viewAssistance.gridSize, y, line); //X축 방향 라인 그리기
                    Gl.glVertex3f(-viewAssistance.gridSize, y, line);
                }
                Gl.glEnd();
            }



            // ************** //
            // 광원 효과 설정 //
            // ************** //
            if (light.ambientLight)
            {
                Gl.glEnable(Gl.GL_DEPTH_TEST);      // 숨겨진 면 지우기
                Gl.glEnable(Gl.GL_LIGHTING);        // 조명 효과 사용
                Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, new float[4] { 0.7f, 0.7f, 0.7f, 1.0f }); // 주변광
            }
            else
            {
                Gl.glDisable(Gl.GL_LIGHTING);
            }

            // 조명1
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, new float[4] { 0.5f, 0.5f, 0.5f, light.diffuseA1 });
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, new float[4] { 0.7f, 0.7f, 0.7f, light.specluarA1 });
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, new float[4] { light.specularX1, light.specularY1, light.specularZ1, 1.0f });
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_CUTOFF, 45.0f);
            Gl.glEnable(Gl.GL_LIGHT0);

            // 조명2
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, new float[4] { 0.5f, 0.5f, 0.5f, light.diffuseA2 });
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, new float[4] { 0.7f, 0.7f, 0.7f, light.specluarA2 });
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, new float[4] { light.specularX2, light.specularY2, light.specularZ2, 1.0f });
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 45.0f);
            Gl.glEnable(Gl.GL_LIGHT1);

            // 조명3
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, new float[4] { 0.5f, 0.5f, 0.5f, light.diffuseA3 });
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, new float[4] { 0.7f, 0.7f, 0.7f, light.specluarA3 });
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, new float[4] { light.specularX3, light.specularY3, light.specularZ3, 1.0f });
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_CUTOFF, 45.0f);
            Gl.glEnable(Gl.GL_LIGHT2);

            Gl.glEnable(Gl.GL_COLOR_MATERIAL);  // 색상 트래킹 사용
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE); //주변광, 분산광을 물체의 앞면에 적용

            // 재질이 반사광 반사 속성을 갖도록 설정
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, new float[4] { 1.0f, 1.0f, 1.0f, 1.0f }); 
            Gl.glMateriali(Gl.GL_FRONT, Gl.GL_SHININESS, 128);



            // ******************** //
            // 테스트용 주전자 표시 //
            // ******************** //
            if (boolTeapot)
            {
                //Gl.glPushMatrix();
                Gl.glColor3f(0.5f, 0.5f, 0.5f);
                Glut.glutSolidTeapot(RANGE/4);
                //Glut.glutWireSphere(50, 30, 30);
                //Gl.glRotatef(10f, 0f, 1f, 0f);
                //Gl.glPopMatrix();
            }



            // *************** //
            // 와이어모드 보기 //
            // *************** //
            if (boolWireMode)
            {
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
            }
            else
            {
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            }



            // ********************* //
            // 2D 그리기 //
            // ********************* //
            Gl.glLineWidth(1.0f);               // 선 두께
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glColor3f(1f, 1f, 1f);     // 그리기 색상
                for (int i = 0; i < vertexList.Count; i++)
                {
                    if (vertexList[i].x == 0 && vertexList[i].y == 0 && vertexList[i].z == 0)
                    {
                        Gl.glEnd();
                    }
                    else
                    {
                        if (vertexList[i].type == PEN || vertexList[i].type == LINE)
                        {
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            Gl.glVertex3f(vertexList[i].x, vertexList[i].y, vertexList[i].z);
                        }
                        else if (vertexList[i].type==RECT)
                        {
                            Gl.glBegin(Gl.GL_TRIANGLES);
                            Gl.glVertex3f(vertexList[i].x, vertexList[i].y, vertexList[i].z);
                        }
                        else if (vertexList[i].type == CIRCLE)
                        {
                            //Gl.glBegin(Gl.GL_QUAD_STRIP);
                            Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
                            Gl.glVertex3f(vertexList[i].x, vertexList[i].y, vertexList[i].z);
                        }
                    }
                }
            Gl.glEnd();



            // ************************************* //
            // 3D OBJECT 그리기 - .obj + 구 + 육면체 //
            // ************************************* //
            drawObj();

            simpleOpenGlControl1.Draw();
            Gl.glPopMatrix();							    
            Gl.glFinish();
        }

        /// <summary>
        /// X,Y,Z 축을 기준으로 회전에 따른 마우스 2D 좌표의 3D 변환
        /// </summary>
        void recalcoordination()
        {
            // X축 회전
            t = z;
            z = -y * (float)Math.Sin(Math.PI * Convert.ToDouble(rotX) / 180.0) + z * (float)Math.Cos(Math.PI * Convert.ToDouble(rotX) / 180.0);
            y = t * (float)Math.Sin(Math.PI * Convert.ToDouble(rotX) / 180.0) + y * (float)Math.Cos(Math.PI * Convert.ToDouble(rotX) / 180.0);

            // Y축 회전
            t = x;
            x = -z * (float)Math.Sin(Math.PI * Convert.ToDouble(rotY) / 180.0) + x * (float)Math.Cos(Math.PI * Convert.ToDouble(rotY) / 180.0);
            z = t * (float)Math.Sin(Math.PI * Convert.ToDouble(rotY) / 180.0) + z * (float)Math.Cos(Math.PI * Convert.ToDouble(rotY) / 180.0);

            // Z축 회전
            t = y;
            y = -x * (float)Math.Sin(Math.PI * Convert.ToDouble(rotZ) / 180.0) + y * (float)Math.Cos(Math.PI * Convert.ToDouble(rotZ) / 180.0);
            x = t * (float)Math.Sin(Math.PI * Convert.ToDouble(rotZ) / 180.0) + x * (float)Math.Cos(Math.PI * Convert.ToDouble(rotZ) / 180.0);

            property.X = x;
            property.Y = y;
            property.Z = z;
        }

        void ReverseRecalcoordination()
        {
            // X축 회전
            t = z;
            z = -y * (float)Math.Sin(Math.PI * Convert.ToDouble(-rotX) / 180.0) + z * (float)Math.Cos(Math.PI * Convert.ToDouble(-rotX) / 180.0);
            y = t * (float)Math.Sin(Math.PI * Convert.ToDouble(-rotX) / 180.0) + y * (float)Math.Cos(Math.PI * Convert.ToDouble(-rotX) / 180.0);

            // Y축 회전
            t = x;
            x = -z * (float)Math.Sin(Math.PI * Convert.ToDouble(-rotY) / 180.0) + x * (float)Math.Cos(Math.PI * Convert.ToDouble(-rotY) / 180.0);
            z = t * (float)Math.Sin(Math.PI * Convert.ToDouble(-rotY) / 180.0) + z * (float)Math.Cos(Math.PI * Convert.ToDouble(-rotY) / 180.0);

            // Z축 회전
            t = y;
            y = -x * (float)Math.Sin(Math.PI * Convert.ToDouble(-rotZ) / 180.0) + y * (float)Math.Cos(Math.PI * Convert.ToDouble(-rotZ) / 180.0);
            x = t * (float)Math.Sin(Math.PI * Convert.ToDouble(-rotZ) / 180.0) + x * (float)Math.Cos(Math.PI * Convert.ToDouble(-rotZ) / 180.0);

            property.X = x;
            property.Y = y;
            property.Z = z;
        }

        /// <summary>
        /// X,Y,Z 축을 기준으로 회전에 따른 마우스 다운 시의 2D 좌표의 3D 변환
        /// </summary>
        void recalcoordination2()
        {
            // X축 회전
            t = startZ;
            startZ = -startY * (float)Math.Sin(Math.PI * Convert.ToDouble(rotX) / 180.0) + startZ * (float)Math.Cos(Math.PI * Convert.ToDouble(rotX) / 180.0);
            startY = t * (float)Math.Sin(Math.PI * Convert.ToDouble(rotX) / 180.0) + startY * (float)Math.Cos(Math.PI * Convert.ToDouble(rotX) / 180.0);

            // Y축 회전
            t = startX;
            startX = -startZ * (float)Math.Sin(Math.PI * Convert.ToDouble(rotY) / 180.0) + startX * (float)Math.Cos(Math.PI * Convert.ToDouble(rotY) / 180.0);
            startZ = t * (float)Math.Sin(Math.PI * Convert.ToDouble(rotY) / 180.0) + startZ * (float)Math.Cos(Math.PI * Convert.ToDouble(rotY) / 180.0);

            // Z축 회전
            t = startY;
            startY = -startX * (float)Math.Sin(Math.PI * Convert.ToDouble(rotZ) / 180.0) + startY * (float)Math.Cos(Math.PI * Convert.ToDouble(rotZ) / 180.0);
            startX = t * (float)Math.Sin(Math.PI * Convert.ToDouble(rotZ) / 180.0) + startX * (float)Math.Cos(Math.PI * Convert.ToDouble(rotZ) / 180.0);
        }

        /// <summary>
        /// 마우스 무브 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">마우스 이벤트 값</param>
        private void simpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            float center_x;
            float center_y;
            float center_z;

            x = (2 * RANGE * (float)e.X / (float)simpleOpenGlControl1.Width) - RANGE;
            y = 2 * RANGE * (1.0f - ((float)e.Y / (float)simpleOpenGlControl1.Height)) - RANGE;
            z = 0.0f;

            recalcoordination();

            property.X = x;
            property.Y = y;
            property.Z = z;

            center_x = (startX + x) / 2.0f;
            center_y = (startY + y) / 2.0f;
            center_z = (startZ + z) / 2.0f;

            property.RotX = rotX;
            property.RotY = rotY;
            property.RotZ = rotZ;

            rotX = rotX % 360;
            rotY = rotY % 360;
            rotZ = rotZ % 360;

            Quat4f ThisQuat = new Quat4f();
            arcBall.drag(new Point(e.X, e.Y), ThisQuat);

            // ArcBall 구현
            if (e.Button == MouseButtons.Right)
            {
                ThisTransformation.Pan = new Vector3f(0, 0, 0);
                ThisTransformation.Scale = 1.0f;
                ThisTransformation.Rotation = ThisQuat;
                ThisTransformation.MatrixMultiply(ThisTransformation, LastTransformation);

                ThisTransformation.get_Renamed(matrix);
            }
            // X,Y,Z 좌표 이동 ( glTranslate() )
            else if (e.Button == MouseButtons.Middle)
            {
                float _x = (x - arcStartX) / 2 * RANGE;
                float _y = (y - arcStartY) / 2 * RANGE;
                float _z = 0.0f;
                ThisTransformation.Pan = new Vector3f(_x/10, _y/10, _z/10);
                ThisTransformation.Scale = 1.0f;
                ThisTransformation.Rotation = new Quat4f();
                ThisTransformation.MatrixMultiply(ThisTransformation, LastTransformation);

                ThisTransformation.get_Renamed(matrix);
            }
            // 사용자 정의 그리기
            else if (e.Button == MouseButtons.Left)
            {
                switch (MODE)
                {
                    case PEN:
                        vertexList.Add(new vertex(PEN, x, y, z));
                        ////Console.WriteLine(y.ToString());
                        break;
                    case LINE:
                        if (vertexList.Count >= 2)
                        {
                            vertexList.RemoveAt(vertexList.Count - 1);
                        }
                        //vertexList.Add(new vertex(LINE, startX, startY, startZ));
                        vertexList.Add(new vertex(LINE, x, y, z));
                        break;
                    case RECT:
                        #region 정육면체 그리기

                        float depth = (Math.Abs((x - startX)) + Math.Abs((y - startY))) / 2;

                        float _startX = startX;
                        float _startY = startY;
                        float _startZ = startZ;

                        if (vertexList.Count >= 36)
                        {
                            for (int i = 0; i < 36; i++)
                            {
                                vertexList.RemoveAt(vertexList.Count - 1);
                            }
                        }

                        x = x - center_x;
                        startY = startY - center_y;
                        startZ = startZ - center_z;

                        x = x + center_x;
                        startY = startY + center_y;
                        startZ = startZ + center_z;

                        vertexList.Add(new vertex(RECT, startX, y, -depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY,- depth / 2));
                        vertexList.Add(new vertex(RECT, x, y, -depth / 2));

                        vertexList.Add(new vertex(RECT, startX, y, -depth / 2)); 
                        vertexList.Add(new vertex(RECT, startX, startY, -depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY, -depth / 2));

                        vertexList.Add(new vertex(RECT, startX, y, -depth / 2));
                        vertexList.Add(new vertex(RECT, startX, startY, depth / 2));
                        vertexList.Add(new vertex(RECT, startX, startY, -depth / 2));

                        vertexList.Add(new vertex(RECT, startX, y, -depth / 2));
                        vertexList.Add(new vertex(RECT, startX, y, +depth / 2));
                        vertexList.Add(new vertex(RECT, startX, startY, +depth / 2));

                        vertexList.Add(new vertex(RECT, startX, startY, -depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY, +depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY, -depth / 2));

                        vertexList.Add(new vertex(RECT, startX, startY, -depth / 2));
                        vertexList.Add(new vertex(RECT, startX, startY, +depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY, +depth / 2));

                        vertexList.Add(new vertex(RECT, x, y, -depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY, -depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY, +depth / 2));

                        vertexList.Add(new vertex(RECT, x, y, -depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY, +depth / 2));
                        vertexList.Add(new vertex(RECT, x, y, +depth / 2));

                        vertexList.Add(new vertex(RECT, startX, y, -depth / 2));
                        vertexList.Add(new vertex(RECT, x, y, -depth / 2));
                        vertexList.Add(new vertex(RECT, x, y, +depth / 2));

                        vertexList.Add(new vertex(RECT, startX, y, -depth / 2));
                        vertexList.Add(new vertex(RECT, x, y, depth / 2));
                        vertexList.Add(new vertex(RECT, startX, y, +depth / 2));

                        vertexList.Add(new vertex(RECT, startX, y, +depth / 2));
                        vertexList.Add(new vertex(RECT, x, y, depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY, +depth / 2));

                        vertexList.Add(new vertex(RECT, startX, y, +depth / 2));
                        vertexList.Add(new vertex(RECT, x, startY, depth / 2));
                        vertexList.Add(new vertex(RECT, startX, startY, +depth / 2));

                        vRect = new float[8, 4] { { startX, y, -depth/2, 0f }, { startX, y, depth/2, 0f }, { startX, startY, -depth/2, 0f }, { startX, startY, depth/2, 0f }, { x, y, -depth/2, 0f }, { x, y, depth/2, 0f }, { x, startY, -depth/2, 0f }, { x, startY, depth/2, 0f } };
                        vtRect = new float[1, 3] { { 0f, 0f, 0f } }; // 그냥 비워둠
                        vnRect = new float[1, 3] { { 0f, 0f, 0f } }; // 그냥 비워둠
                        fRect = new int[12, 4, 3] { {{ 1, 0, 0 }, { 7, 0, 0 }, { 5, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 1, 0, 0 }, { 3, 0, 0 }, { 7, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 1, 0, 0 }, { 4, 0, 0 }, { 3, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 1, 0, 0 }, { 2, 0, 0 }, { 4, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 3, 0, 0 }, { 8, 0, 0 }, { 7, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 3, 0, 0 }, { 4, 0, 0 }, { 8, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 5, 0, 0 }, { 7, 0, 0 }, { 8, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 5, 0, 0 }, { 8, 0, 0 }, { 6, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 1, 0, 0 }, { 5, 0, 0 }, { 6, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 1, 0, 0 }, { 6, 0, 0 }, { 2, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 2, 0, 0 }, { 6, 0, 0 }, { 8, 0, 0 }, { 0, 0, 0 }},
                                                    {{ 2, 0, 0 }, { 8, 0, 0 }, { 4, 0, 0 }, { 0, 0, 0 }} };
                        startX = _startX;
                        startY = _startY;
                        startZ = _startZ;
                        #endregion
                        ////Console.WriteLine(vertexList.Count.ToString());
                        break;
                    case CIRCLE:
                        
                        float _x, _y, _z;
                        float c = 0.02f;
                        float radius = (float)Math.Sqrt((center_x - x) * (center_x - x) + (center_y - y) * (center_y - y));

                        if (vertexList.Count >= 342)
                        {
                            for (int i = 0; i < 342; i++)
                            {
                                vertexList.RemoveAt(vertexList.Count - 1);
                            }
                        }

                        for (float phi = -90.0f; phi <= 70.0f; phi += 20.0f)
                        {
                            for (float theta = -180.0f; theta <= 180.0; theta += 20.0f)
                            {
                                _x = center_x + radius * (float)(Math.Sin(c * theta) * Math.Cos(c * phi));
                                _y = center_y + radius * (float)(Math.Cos(c * theta) * Math.Cos(c * phi));
                                _z = radius * (float)(Math.Sin(c * phi));
                                vertexList.Add(new vertex(CIRCLE, _x, _y, _z));

                                _x = center_x + radius * (float)(Math.Sin(c * theta) * Math.Cos(c * (phi + 20.0)));
                                _y = center_y + radius * (float)(Math.Cos(c * theta) * Math.Cos(c * (phi + 20.0)));
                                _z = radius * (float)(Math.Sin(c * (phi + 20.0)));
                                vertexList.Add(new vertex(CIRCLE, _x, _y, _z));
                            }
                        }

                        vSphere = new float[342, 4];
                        vtSphere = new float[1, 3] { { 0f, 0f, 0f } }; // 그냥 비워둠
                        vnSphere = new float[1, 3] { { 0f, 0f, 0f } }; // 그냥 비워둠
                        fSphere = new int[114, 4, 3];

                        for (int i = 0; i < 342; i++)
                        {
                            vSphere[i, 0] = vertexList[i].x;    //x
                            vSphere[i, 1] = vertexList[i].y;    //y
                            vSphere[i, 2] = vertexList[i].z;    //z
                            vSphere[i, 3] = 0.0f;               //w
                        }

                        for (int i = 0; i < 114; i++)
                        {
                            fSphere[i, 0, 0] = 3*i+0+1;
                            fSphere[i, 1, 0] = 3*i+1+1;
                            fSphere[i, 2, 0] = 3*i+2+1;
                            fSphere[i, 3, 0] = 0;
                        }

                        break;
                    case SELECT:
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 마우스 다운 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">마우스 이벤트 값</param>
        private void simpleOpenGlControl1_MouseDown(object sender, MouseEventArgs e)
        {
            x = (2 * RANGE * (float)e.X / (float)simpleOpenGlControl1.Width) - RANGE;
            y = 2 * RANGE * (1.0f - ((float)e.Y / (float)simpleOpenGlControl1.Height)) - RANGE;
            z = 0.0f;

            property.RotX = rotX;
            property.RotY = rotY;
            property.RotZ = rotZ;

            // ArcBall 구현
            if (e.Button == MouseButtons.Right)
            {
                LastTransformation.set_Renamed(ThisTransformation); // Set Last Static Rotation To Last Dynamic One
                arcBall.click(new Point(e.X, e.Y)); // Update Start Vector And Prepare For Dragging

                arcStartX = e.X;
                arcStartY = e.Y;

                ThisTransformation.get_Renamed(matrix);

            }
            // X,Y,Z 좌표 이동 ( glTranslate() )
            else if (e.Button == MouseButtons.Middle)
            {
                this.simpleOpenGlControl1.Cursor = System.Windows.Forms.Cursors.Hand;

                LastTransformation.set_Renamed(ThisTransformation); // Set Last Static Rotation To Last Dynamic One
                arcBall.click(new Point(e.X, e.Y)); // Update Start Vector And Prepare For Dragging

                arcStartX = x;
                arcStartY = y;

                ThisTransformation.get_Renamed(matrix);
            }
            // 사용자 정의 그리기
            else if (e.Button == MouseButtons.Left)
            {
                switch (MODE)
                {
                    case PEN:
                        recalcoordination();
                        vertexList.Add(new vertex(PEN, x, y, z));
                        break;
                    case LINE:
                        recalcoordination();
                        vertexList.Add(new vertex(LINE, x, y, z));
                        startX = x;
                        startY = y;
                        startZ = z;
                        break;
                    case RECT:
                        recalcoordination();
                        //vertexList.Add(new vertex(RECT, x, y, z));
                        startX = x;
                        startY = y;
                        startZ = z;
                        break;
                    case CIRCLE:
                        recalcoordination();
                        //vertexList.Add(new vertex(CIRCLE, x, y, z));
                        startX = x;
                        startY = y;
                        startZ = z;
                        break;
                    case SELECT:
                        int selected = Select(e.X, e.Y);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 마우스 업 이벤트 ( 한 획이 끝남을 의미 )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">마우스 이벤트 값</param>
        public int objectCount = 1;
        private void simpleOpenGlControl1_MouseUp(object sender, MouseEventArgs e)
        {
            this.simpleOpenGlControl1.Cursor = System.Windows.Forms.Cursors.Default;

            // 사용자 정의 그리기
            if (e.Button== MouseButtons.Left)
            {
                //vertexList.Add(new vertex(0f, 0f, 0f)); // 한 획의 끝남을 의미

                switch (MODE)
                {
                    case PEN:
                        break;
                    case LINE:
                        break;
                    case RECT:
                        objFiles.Add(new obj(RECT, (float[,])vRect.Clone(), (float[,])vtRect.Clone(), (float[,])vnRect.Clone(), (int[, ,])fRect.Clone()));
                        vertexList.Clear();
                        addTreeView("Rectangle" + objectCount);
                        ++objectCount;
                        break;
                    case CIRCLE:
                        objFiles.Add(new obj(CIRCLE, (float[,])vSphere.Clone(), (float[,])vtSphere.Clone(), (float[,])vnSphere.Clone(), (int[, ,])fSphere.Clone()));
                        vertexList.Clear();
                        addTreeView("Circle" + objectCount);
                        ++objectCount;
                        break;
                    case SELECT:
                        break;
                    default:
                        break;
                }
            }
        }

        //파일을 드래그 해서 폼 안으로 들어왔을 때
        private void simpleOpenGlControl1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //파일을 드래그 해서 폼 안에서 드랍했을 때
        private void simpleOpenGlControl1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < files.Length; i++)
                {
                    fileNames.Add(files[i]);
                }
            }
            readObj();
            fileNames.Clear();
        }

        /// <summary>
        /// OBJ 파일 읽기
        /// </summary>
        /// <param name="fileName">OBJ 파일의 경로 및 이름</param>
        public void readObj()
        {
            objReader.Clear();
            reObjReader.Clear();
            //objFiles.Clear();
            string mtlFileName="";
            string map_kd="";
            string OpenURL;
            for (int i = 0; i < fileNames.Count; i++)
            {
                numberOfNormals = 0;
                numberOfVertexCoords = 0;
                numberOfVertexCoords = 0;
                numberOfPolygons = 0;

                objReader.Add(new StreamReader(fileNames[i]));
                
                while (!objReader[i].EndOfStream)
                {
                    line = objReader[i].ReadLine();
                    lines = line.Split(' ');

                    //Console.WriteLine(line);

                    switch (lines[0])
                    {
                        case "f":   // v, v//vn, v/vt, v/vt/vn.
                            ++numberOfPolygons;
                            break;
                        case "m":   // mtllib
                            //importMaterials(name.c_str());
                            break;
                        case "v":
                            ++numberOfVertexCoords;
                            break;
                        case "#v":
                            ++numberOfVertexCoords;
                            break;
                        case "vn":
                            ++numberOfNormals;
                            break;
                        case "vt":
                            ++numberOfTextureCoords;
                            break;
                        default:
                            break;
                    }
                }
                
                float[,] v = new float[numberOfVertexCoords, 4];
                float[,] vt = new float[numberOfTextureCoords, 3];
                float[,] vn = new float[numberOfNormals, 3];
                int[, ,] f = new int[numberOfPolygons, 4, 3];   // 폴리곤 갯수, 4개의 V, 3개의 정점

                reObjReader.Add(new StreamReader(fileNames[i]));

                while (!reObjReader[i].EndOfStream)
                {
                    line = reObjReader[i].ReadLine();
                    lines = line.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);

                    if (lines.Length == 0)
                    {
                        lines = new String[1];
                        lines[0] = "";
                    }

                    switch (lines[0])
                    {
                        case "f":
                            if (lines.Length == 4)    //f  v  v  v
                            {
                                f[fIndex, 0, 0] = int.Parse(lines[1]);
                                f[fIndex, 0, 1] = 0;
                                f[fIndex, 0, 2] = 0;
                                f[fIndex, 1, 0] = int.Parse(lines[2]);
                                f[fIndex, 1, 1] = 0;
                                f[fIndex, 1, 2] = 0;
                                f[fIndex, 2, 0] = int.Parse(lines[3]);
                                f[fIndex, 2, 1] = 0;
                                f[fIndex, 2, 2] = 0;
                                f[fIndex, 3, 0] = 0;
                                f[fIndex, 3, 1] = 0;
                                f[fIndex, 3, 2] = 0;
                            }
                            else if (lines.Length == 5 || lines.Length == 6) //f  v  v  v  v (v)
                            {
                                f[fIndex, 0, 0] = int.Parse(lines[1]);
                                f[fIndex, 0, 1] = 0;
                                f[fIndex, 0, 2] = 0;
                                f[fIndex, 1, 0] = int.Parse(lines[2]);
                                f[fIndex, 1, 1] = 0;
                                f[fIndex, 1, 2] = 0;
                                f[fIndex, 2, 0] = int.Parse(lines[3]);
                                f[fIndex, 2, 1] = 0;
                                f[fIndex, 2, 2] = 0;
                                f[fIndex, 3, 0] = int.Parse(lines[4]);
                                f[fIndex, 3, 1] = 0;
                                f[fIndex, 3, 2] = 0;
                            }
                            else if (lines.Length == 7) //f  v//vn  v//vn  v//vn
                            {
                                f[fIndex, 0, 0] = int.Parse(lines[1]);
                                f[fIndex, 0, 1] = 0;
                                f[fIndex, 0, 2] = int.Parse(lines[2]);
                                f[fIndex, 1, 0] = int.Parse(lines[3]);
                                f[fIndex, 1, 1] = 0;
                                f[fIndex, 1, 2] = int.Parse(lines[4]);
                                f[fIndex, 2, 0] = int.Parse(lines[5]);
                                f[fIndex, 2, 1] = 0;
                                f[fIndex, 2, 2] = int.Parse(lines[6]);
                                f[fIndex, 3, 0] = 0;
                                f[fIndex, 3, 1] = 0;
                                f[fIndex, 3, 2] = 0;
                            }
                            else if (lines.Length == 10)    //f  v/vt/vn  v/vt/vn  v/vt/vn
                            {
                                f[fIndex, 0, 0] = int.Parse(lines[1]);
                                f[fIndex, 0, 1] = int.Parse(lines[2]);
                                f[fIndex, 0, 2] = int.Parse(lines[3]);
                                f[fIndex, 1, 0] = int.Parse(lines[4]);
                                f[fIndex, 1, 1] = int.Parse(lines[5]);
                                f[fIndex, 1, 2] = int.Parse(lines[6]);
                                f[fIndex, 2, 0] = int.Parse(lines[7]);
                                f[fIndex, 2, 1] = int.Parse(lines[8]);
                                f[fIndex, 2, 2] = int.Parse(lines[9]);
                                f[fIndex, 3, 0] = 0;
                                f[fIndex, 3, 1] = 0;
                                f[fIndex, 3, 2] = 0;
                            }
                            else
                            {
                                //차후 추가
                            }
                            ++fIndex;
                            break;
                        case "u":
                            //나중에 처리 usemtl
                            break;
                        case "v":
                            if (lines.Length == 4)
                            {
                                v[vIndex, 0] = float.Parse(lines[1]);
                                v[vIndex, 1] = float.Parse(lines[2]);
                                v[vIndex, 2] = float.Parse(lines[3]);
                                v[vIndex, 3] = 1.0f;
                            }
                            else if (lines.Length == 5)
                            {
                                v[vIndex, 0] = float.Parse(lines[1]);
                                v[vIndex, 1] = float.Parse(lines[2]);
                                v[vIndex, 2] = float.Parse(lines[3]);
                                v[vIndex, 3] = float.Parse(lines[4]);
                            }
                            ++vIndex;
                            break;
                        case "#v":
                            if (lines.Length == 4)
                            {
                                v[vIndex, 0] = float.Parse(lines[1]);
                                v[vIndex, 1] = float.Parse(lines[2]);
                                v[vIndex, 2] = float.Parse(lines[3]);
                                v[vIndex, 3] = 1.0f;
                            }
                            else if (lines.Length == 5)
                            {
                                v[vIndex, 0] = float.Parse(lines[1]);
                                v[vIndex, 1] = float.Parse(lines[2]);
                                v[vIndex, 2] = float.Parse(lines[3]);
                                v[vIndex, 3] = float.Parse(lines[4]);
                            }
                            ++vIndex;
                            break;
                        case "vn":
                            vn[vnIndex, 0] = float.Parse(lines[1]);
                            vn[vnIndex, 1] = float.Parse(lines[2]);
                            vn[vnIndex, 2] = float.Parse(lines[3]);
                            ++vnIndex;
                            break;
                        case "vt":
                            vt[vtIndex, 0] = float.Parse(lines[1]);
                            vt[vtIndex, 1] = float.Parse(lines[2]);
                            vt[vtIndex, 2] = float.Parse(lines[3]);
                            ++vtIndex;
                            break;
                        case "#mtllib":
                            mtlFileName = lines[1];
                            break;
                        case "mtllib":
                            mtlFileName = lines[1];
                            break;
                        default:
                            break;
                    }
                }


                if (mtlFileName != "")
                {
                    OpenURL = fileNames[i].Substring(0, fileNames[i].LastIndexOfAny(("\\").ToCharArray()) + 1);
                    mtlFileName = OpenURL + mtlFileName;
                    StreamReader mtlReader = new StreamReader(mtlFileName);
                    string mtlLine;
                    string[] mtlLines;
                    while (!mtlReader.EndOfStream)
                    {
                        mtlLine = mtlReader.ReadLine();
                        mtlLines = mtlLine.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);

                        if (mtlLines.Length == 0)
                        {
                            mtlLines = new String[1];
                            mtlLines[0] = "";
                        }

                        switch (mtlLines[0])
                        {
                            case "newmtl":
                                //Tex_Data[Tex_Data_Count, 0] = mtlLines[1];
                                while (!mtlReader.EndOfStream)
                                {

                                    mtlLine = mtlReader.ReadLine();
                                    mtlLines = mtlLine.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
                                    if ("map_Kd" == mtlLines[0])
                                    {
                                        map_kd = OpenURL + mtlLines[1];
                                        break;
                                    }

                                }
                                break;

                            case "#newmtl":
                               // Tex_Data[Tex_Data_Count, 0] = mtlLines[1];
                                while (!mtlReader.EndOfStream)
                                {

                                    mtlLine = mtlReader.ReadLine();
                                    mtlLines = mtlLine.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
                                    if ("map_Kd" == mtlLines[0])
                                    {
                                        map_kd = OpenURL + mtlLines[1];
                                        break;
                                    }

                                }
                                break;
                        }


                    }
                }


                vIndex = 0;
                vtIndex = 0;
                vnIndex = 0;
                fIndex = 0;

                objReader[i].Close();
                reObjReader[i].Close();

                objFiles.Add(new obj(-1, (float[,])v.Clone(), (float[,])vt.Clone(), (float[,])vn.Clone(), (int[,,])f.Clone()));
                objFiles[objFiles.Count - 1].txextureMapPath = map_kd;
                if (objFiles[objFiles.Count - 1].txextureMapPath != "")
                {
                    FileTexMapping();
                }
                addTreeView("Object" + objectCount);
                ++objectCount;
            }

            #region 콘솔출력 확인
            //for (int i = 0; i < numberOfVertexCoords; i++)
            //{
            //    //Console.Write(v[i, 0].ToString());
            //    //Console.Write("\t");
            //    //Console.Write(v[i, 1].ToString());
            //    //Console.Write("\t");
            //    //Console.Write(v[i, 2].ToString());
            //    //Console.WriteLine();
            //}
            ////Console.WriteLine();
            //for (int i = 0; i < numberOfNormals; i++)
            //{
            //    //Console.Write(vn[i, 0].ToString());
            //    //Console.Write("\t");
            //    //Console.Write(vn[i, 1].ToString());
            //    //Console.Write("\t");
            //    //Console.Write(vn[i, 2].ToString());
            //    //Console.WriteLine();
            //}
            ////Console.WriteLine();
            //for (int i = 0; i < numberOfPolygons; i++)
            //{
            //    //Console.Write(f[i, 0, 0].ToString());
            //    //Console.Write("/");
            //    //Console.Write(f[i, 0, 1].ToString());
            //    //Console.Write("/");
            //    //Console.Write(f[i, 0, 2].ToString());
            //    //Console.Write("\t");
            //    //Console.Write(f[i, 1, 0].ToString());
            //    //Console.Write("/");
            //    //Console.Write(f[i, 1, 1].ToString());
            //    //Console.Write("/");
            //    //Console.Write(f[i, 1, 2].ToString());
            //    //Console.Write("\t");
            //    //Console.Write(f[i, 2, 0].ToString());
            //    //Console.Write("/");
            //    //Console.Write(f[i, 2, 1].ToString());
            //    //Console.Write("/");
            //    //Console.Write(f[i, 2, 2].ToString());
            //    //Console.Write("\t");
            //    //Console.WriteLine();
            //}
            ////Console.WriteLine();
            #endregion
        }

        /// <summary>
        /// Obj 파일 그리기
        /// </summary>
        public void drawObj()
        {
            if (objFiles.Count == 0)
            {
                selectedIndex = -1;
            }

            for (int i = 0; i < objFiles.Count; i++)
            {
                Gl.glPushMatrix();
                Gl.glPushName(i);
                
                if (selectedIndex == i)
                {
                    Gl.glColor3f(0.7f, 0.7f, 0.7f);
                }
                else
                {
                    Gl.glColor3f(1f, 1f, 1f);
                }

                glTranslatef(i);
                glScalef(i);
                glRotationf(i);

                if (objFiles[i].type != CIRCLE)
                {
                    //성민이 추가
                    Gl.glEnable(Gl.GL_TEXTURE_2D);

                    Gl.glBegin(Gl.GL_TRIANGLES);
                                        
                }
                else
                {
                    //구 그릴 때는 GL_TRIANGLE_STRIP
                    Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
                }

                //성민
                Gl.glPushAttrib(Gl.GL_ENABLE_BIT | Gl.GL_POLYGON_BIT | Gl.GL_LINE_BIT | Gl.GL_POINT_BIT | Gl.GL_DEPTH_BUFFER_BIT);


                for (int j = 0; j < objFiles[i].f.Length / 12; j++)
                {
                    if (objFiles[i].txextureMapPath == "")
                    {
                        Gl.glVertex3f(objFiles[i].v[objFiles[i].f[j, 0, 0] - 1, 0], objFiles[i].v[objFiles[i].f[j, 0, 0] - 1, 1], objFiles[i].v[objFiles[i].f[j, 0, 0] - 1, 2]);
                        Gl.glVertex3f(objFiles[i].v[objFiles[i].f[j, 1, 0] - 1, 0], objFiles[i].v[objFiles[i].f[j, 1, 0] - 1, 1], objFiles[i].v[objFiles[i].f[j, 1, 0] - 1, 2]);
                        Gl.glVertex3f(objFiles[i].v[objFiles[i].f[j, 2, 0] - 1, 0], objFiles[i].v[objFiles[i].f[j, 2, 0] - 1, 1], objFiles[i].v[objFiles[i].f[j, 2, 0] - 1, 2]);

                    }

                    
                    else
                    {
                        if (!isTexture)
                        {
                            
                            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);


                            for (int s = 0; s <= TextureIndex; s++)
                            {

                                if (objFiles[i].textureMapIndex == -1 )
                                {
                                    continue;
                                }

                                Gl.glBindTexture(Gl.GL_TEXTURE_2D, objFiles[i].textureMapIndex);



                                //Gl.glTexCoord3f(1.0f,1.0f,0);
                                Gl.glTexCoord3f(objFiles[i].vt[objFiles[i].f[j, 0, 0] - 1, 0], objFiles[i].vt[objFiles[i].f[j, 0, 0] - 1, 1], 0);
                                Gl.glVertex3f(objFiles[i].v[objFiles[i].f[j, 0, 0] - 1, 0], objFiles[i].v[objFiles[i].f[j, 0, 0] - 1, 1], objFiles[i].v[objFiles[i].f[j, 0, 0] - 1, 2]);
                                //Gl.glNormal3f(1.0f, 0f, 0f);
                                //Gl.glTexCoord3f(1.0f, 0.0f, 0);
                                Gl.glTexCoord3f(objFiles[i].vt[objFiles[i].f[j, 1, 0] - 1, 0], objFiles[i].vt[objFiles[i].f[j, 1, 0] - 1, 1], 0);
                                Gl.glVertex3f(objFiles[i].v[objFiles[i].f[j, 1, 0] - 1, 0], objFiles[i].v[objFiles[i].f[j, 1, 0] - 1, 1], objFiles[i].v[objFiles[i].f[j, 1, 0] - 1, 2]);
                                //Gl.glNormal3f(1.0f, 0f, 0f);
                                //Gl.glTexCoord3f(0.0f, 1.0f, 0);
                                Gl.glTexCoord3f(objFiles[i].vt[objFiles[i].f[j, 2, 0] - 1, 0], objFiles[i].vt[objFiles[i].f[j, 2, 0] - 1, 1], 0);
                                Gl.glVertex3f(objFiles[i].v[objFiles[i].f[j, 2, 0] - 1, 0], objFiles[i].v[objFiles[i].f[j, 2, 0] - 1, 1], objFiles[i].v[objFiles[i].f[j, 2, 0] - 1, 2]);
                                //Gl.glNormal3f(1.0f, 0f, 0f);
                                //Console.WriteLine("1:" + objFiles[i].vt[objFiles[i].f[j, 0, 0] - 1, 0].ToString() + "\n" + objFiles[i].vt[objFiles[i].f[j, 0, 0] - 1, 1]);
                                //Console.WriteLine(objFiles[i].vt[objFiles[i].f[j, 1, 0] - 1, 0].ToString() + "\n" + objFiles[i].vt[objFiles[i].f[j, 1, 0] - 1, 1]);
                                //Console.WriteLine(objFiles[i].vt[objFiles[i].f[j, 2, 0] - 1, 0].ToString() + "\n" + objFiles[i].vt[objFiles[i].f[j, 2, 0] - 1, 1]);
                                Gl.glDisable(Gl.GL_TEXTURE_2D);
                            }
                        }
                    }

                    Gl.glFlush();

                }
                


                Gl.glEnd();
                //성민 텍스쳐
                Gl.glDisable(Gl.GL_TEXTURE_2D);

                Gl.glPopName();
                Gl.glPopMatrix();
            }
        }



        /// <summary>
        /// OBJECT 회전 조절
        /// </summary>
        /// <param name="i"></param>
        public void glRotationf(int i)
        {
            xSort = new float[objFiles[i].v.Length];
            ySort = new float[objFiles[i].v.Length];
            zSort = new float[objFiles[i].v.Length];

            float[] xSortTemp = new float[xSort.Length];
            float[] ySortTemp = new float[ySort.Length];
            float[] zSortTemp = new float[zSort.Length];

            for (int j = 0; j < objFiles[i].v.Length / 4; j++)
            {
                xSort[j] = objFiles[i].v[j, 0];
                ySort[j] = objFiles[i].v[j, 1];
                zSort[j] = objFiles[i].v[j, 2];
            }

            Array.Copy(xSort, xSortTemp, xSort.Length);
            Array.Copy(ySort, ySortTemp, ySort.Length);
            Array.Copy(zSort, zSortTemp, zSort.Length);

            Array.Sort(xSortTemp);
            Array.Sort(ySortTemp);
            Array.Sort(zSortTemp);

            float xHalf = (xSortTemp[0] + xSortTemp[xSortTemp.Length - 1]) / 2;
            float yHalf = (ySortTemp[0] + ySortTemp[ySortTemp.Length - 1]) / 2;
            float zHalf = (zSortTemp[0] + zSortTemp[zSortTemp.Length - 1]) / 2;

            for (int j = 0; j < objFiles[i].v.Length / 4; j++)
            {
                objFiles[i].v[j, 0] -= xHalf;
                objFiles[i].v[j, 1] -= yHalf;
                objFiles[i].v[j, 2] -= zHalf;

                objFiles[i].scaledVClone[j, 0] -= xHalf;
                objFiles[i].scaledVClone[j, 1] -= yHalf;
                objFiles[i].scaledVClone[j, 2] -= zHalf;
            }

            //Console.WriteLine(xHalf + "\t" + yHalf + "\t" + zHalf);

            //Gl.glRotatef(objFiles[i].xRotation, 1f, 0f, 0f);
            //Gl.glRotatef(objFiles[i].yRotation, 0f, 1f, 0f);
            //Gl.glRotatef(objFiles[i].zRotation, 0f, 0f, 1f);

            for (int j = 0; j < objFiles[i].v.Length / 4; j++)
            {
                //X축 회전 했을 때
                objFiles[i].v[j, 1] = objFiles[i].scaledVClone[j, 1] * (float)Math.Cos(Math.PI * objFiles[i].xRotation / 180) - objFiles[i].scaledVClone[j, 2] * (float)Math.Sin(Math.PI * objFiles[i].xRotation / 180);
                objFiles[i].v[j, 2] = objFiles[i].scaledVClone[j, 1] * (float)Math.Sin(Math.PI * objFiles[i].xRotation / 180) + objFiles[i].scaledVClone[j, 2] * (float)Math.Cos(Math.PI * objFiles[i].xRotation / 180);

                //Y축 회전 했을 때
                objFiles[i].v[j, 0] = objFiles[i].scaledVClone[j, 0] * (float)Math.Cos(Math.PI * objFiles[i].yRotation / 180) + objFiles[i].v[j, 2] * (float)Math.Sin(Math.PI * objFiles[i].yRotation / 180);
                objFiles[i].v[j, 2] = -objFiles[i].scaledVClone[j, 0] * (float)Math.Sin(Math.PI * objFiles[i].yRotation / 180) + objFiles[i].v[j, 2] * (float)Math.Cos(Math.PI * objFiles[i].yRotation / 180);

                //Z축 회전 했을 때
                objFiles[i].v[j, 0] = objFiles[i].v[j, 0] * (float)Math.Cos(Math.PI * objFiles[i].zRotation / 180) - objFiles[i].v[j, 1] * (float)Math.Sin(Math.PI * objFiles[i].zRotation / 180);
                objFiles[i].v[j, 1] = objFiles[i].v[j, 0] * (float)Math.Sin(Math.PI * objFiles[i].zRotation / 180) + objFiles[i].v[j, 1] * (float)Math.Cos(Math.PI * objFiles[i].zRotation / 180);
            }

            for (int j = 0; j < objFiles[i].v.Length / 4; j++)
            {
                objFiles[i].v[j, 0] += xHalf;
                objFiles[i].v[j, 1] += yHalf;
                objFiles[i].v[j, 2] += zHalf;

                objFiles[i].scaledVClone[j, 0] += xHalf;
                objFiles[i].scaledVClone[j, 1] += yHalf;
                objFiles[i].scaledVClone[j, 2] += zHalf;
            }
        }


        /// <summary>
        /// OBJECT 크기 조절
        /// </summary>
        /// <param name="i">OBJECT INDEX</param>
        public void glScalef(int i)
        {
            float[] xSort = new float[objFiles[i].v.Length];
            float[] ySort = new float[objFiles[i].v.Length];
            float[] zSort = new float[objFiles[i].v.Length];

            float[] xSortTemp = new float[xSort.Length];
            float[] ySortTemp = new float[ySort.Length];
            float[] zSortTemp = new float[zSort.Length];

            for (int j = 0; j < objFiles[i].v.Length / 4; j++)
            {
                xSort[j] = objFiles[i].translatedVClone[j, 0];
                ySort[j] = objFiles[i].translatedVClone[j, 1];
                zSort[j] = objFiles[i].translatedVClone[j, 2];
                ////Console.WriteLine(xSort[j]);
            }

            Array.Copy(xSort, xSortTemp, xSort.Length);
            Array.Copy(ySort, ySortTemp, ySort.Length);
            Array.Copy(zSort, zSortTemp, zSort.Length);

            Array.Sort(xSortTemp);
            Array.Sort(ySortTemp);
            Array.Sort(zSortTemp);
             
            float xHalf = (xSortTemp[0] + xSortTemp[xSortTemp.Length - 1]) / 2;
            float yHalf = (ySortTemp[0] + ySortTemp[ySortTemp.Length - 1]) / 2;
            float zHalf = (zSortTemp[0] + zSortTemp[zSortTemp.Length - 1]) / 2;
             
            for (int j = 0; j < objFiles[i].v.Length / 4; j++)
            {
                objFiles[i].v[j, 0] -= xHalf;
                objFiles[i].v[j, 1] -= yHalf;
                objFiles[i].v[j, 2] -= zHalf;

                objFiles[i].translatedVClone[j, 0] -= xHalf;
                objFiles[i].translatedVClone[j, 1] -= yHalf;
                objFiles[i].translatedVClone[j, 2] -= zHalf;
            }

            for (int j = 0; j < objFiles[i].v.Length / 4; j++)
            {
                objFiles[i].v[j, 0] = objFiles[i].translatedVClone[j, 0] * objFiles[i].xScale;
                objFiles[i].v[j, 1] = objFiles[i].translatedVClone[j, 1] * objFiles[i].yScale;
                objFiles[i].v[j, 2] = objFiles[i].translatedVClone[j, 2] * objFiles[i].zScale;
            }

            for (int j = 0; j < objFiles[i].v.Length / 4; j++)
            {
                objFiles[i].v[j, 0] += xHalf;
                objFiles[i].v[j, 1] += yHalf;
                objFiles[i].v[j, 2] += zHalf;

                objFiles[i].translatedVClone[j, 0] += xHalf;
                objFiles[i].translatedVClone[j, 1] += yHalf;
                objFiles[i].translatedVClone[j, 2] += zHalf;

                objFiles[i].scaledVClone[j, 0] = objFiles[i].v[j, 0];
                objFiles[i].scaledVClone[j, 1] = objFiles[i].v[j, 1];
                objFiles[i].scaledVClone[j, 2] = objFiles[i].v[j, 2];

            }
        }


        /// <summary>
        /// OBJECT 위치 조절
        /// </summary>
        /// <param name="i"></param>
        public void glTranslatef(int i)
        {
            for (int j = 0; j < objFiles[i].v.Length / 4; j++)
            {
                objFiles[i].v[j, 0] = objFiles[i].vClone[j, 0] + objFiles[i].xTranslate;
                objFiles[i].v[j, 1] = objFiles[i].vClone[j, 1] + objFiles[i].yTranslate;
                objFiles[i].v[j, 2] = objFiles[i].vClone[j, 2] + objFiles[i].zTranslate;

                objFiles[i].translatedVClone[j, 0] = objFiles[i].v[j, 0];
                objFiles[i].translatedVClone[j, 1] = objFiles[i].v[j, 1];
                objFiles[i].translatedVClone[j, 2] = objFiles[i].v[j, 2];
            }
        }

        /// <summary>
        /// 피킹
        /// </summary>
        /// <param name="x">마우스 x좌표</param>
        /// <param name="y">마우스 y좌표</param>
        /// <returns></returns>
        public int Select(float x, float y)
        {
            int[] viewport = new int[4];    //Current Viewport 
            int[] selectBuf = new int[512]; // will hold the id's of selected objects
            //1) Get Current Viewport 

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);
            // 2 , selection buffer and selection mode
            Gl.glSelectBuffer(512, selectBuf); // Assign a selection buffer 
            Gl.glRenderMode(Gl.GL_SELECT); // switch to selection mode 

            Gl.glInitNames(); // Init Name Stack 

            // go ahead and put a name in
            //Gl.glPushName(5);


            // 4 matrix mode and initialize
            Gl.glMatrixMode(Gl.GL_PROJECTION); // Change Matrix Mode to projection 
            Gl.glPushMatrix(); // Don't disturb other things 
            Gl.glLoadIdentity(); // Reset the axis 

            // 6 - create pick matrix around current point
            // Main function! Thiss make a virtual clipping region with 
            // center x, y and width and height 1 each w.r.t the current viewport.  
            // Note the "viewport[3]-y" parameter instead of y! 
            Glu.gluPickMatrix(
                (double)x, (double)(viewport[3] - y),
                //Specify the center of a picking region in window coordinates.
                3.0, 3.0, // delx, dely
                viewport // current viewport
            );

            Glu.gluPerspective(90f, (viewport[2] + 0.0) / viewport[3], 0.1, 1000.0);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            //Call our Render funtion to load object with names. 
            // Note that since our Render mode is GL_SELECT nothing will be drawn 
            // on the screen due to this function call! 

            renderScene();

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix(); // Don't disturb other things 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glFlush();
            //Switch back to default mode! 
            //This time the "glRenderMode" function returns the no. 
            // of objects that were found to be drawn in the clipping region made by glPickMatrix.  
            int hits = Gl.glRenderMode(Gl.GL_RENDER);
            //Console.WriteLine("Select, number of hits:" + hits.ToString());
            return ProcessHits(hits, selectBuf);
        }


        /// <summary>
        /// 피킹 처리
        /// </summary>
        /// <param name="hits"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private int ProcessHits(int hits, int[] buffer)
        {
            uint i, j;
            int names;
            int[] ptr;
            int result = 0;
            //Console.WriteLine("ProcessHits  hits = {0}", hits);
            ptr = buffer;
            if (hits == 0) selectedIndex = -1;

            for (i = 0; i < hits; i++)
            {             // For Each Hit
                names = ptr[i];
                //Console.WriteLine(" number of names for hit = {0}", names);
                i++;
                //Console.WriteLine(" z1 is {0}", (float)ptr[i] / 0x7fffffff);
                i++;
                //Console.WriteLine(" z2 is {0}", (float)ptr[i] / 0x7fffffff);
                i++;
                //Console.Write(" the name is ");
                for (j = 0; j < names; j++)
                {           // For Each Name
                    //Console.Write("{0} ", ptr[i]);
                    selectedIndex = ptr[i];
                    result = ptr[i]; // if there are multiple selections, this is an ERROR, but at least for the time being, return something
                    i++;
                }
                //Console.Write("\n");
            }
            //Console.Write("\n");

            return result;
        }



        //public List<kObject> kObjList = new List<kObject>();

        public void CreateKObj()
        {
            //  vertexList.Add(vertexList[0]);
            kObject tmpK = new kObject(vertexList);

            kObjList.Add(tmpK);

            tmpK.SaveVertex();
            tmpK.SaveVtData();

            float[,] _v = new float[tmpK.kObjVtx.Count*3, 4];
            float[,] _vt = new float[tmpK.kObjVtx.Count * 3, 2];
            float[,] _vn = new float[1, 3] { { 0, 0, 0 } }; // 임시
            int[, ,] _f = new int[tmpK.kObjVtx.Count, 4, 3];

            for (int i = 0, j= 0; j < tmpK.kObjVtx.Count; i += 3, j++)
            {
                _v[i, 0] = tmpK.kObjVtx[j].v0[0];
                _v[i, 1] = tmpK.kObjVtx[j].v0[1];
                _v[i, 2] = tmpK.kObjVtx[j].v0[2];
                _v[i + 1, 0] = tmpK.kObjVtx[j].v1[0];
                _v[i + 1, 1] = tmpK.kObjVtx[j].v1[1];
                _v[i + 1, 2] = tmpK.kObjVtx[j].v1[2];
                _v[i + 2, 0] = tmpK.kObjVtx[j].v2[0];
                _v[i + 2, 1] = tmpK.kObjVtx[j].v2[1];
                _v[i + 2, 2] = tmpK.kObjVtx[j].v2[2];
            }

            for (int i = 0, j = 0; j < tmpK.kObjVtx.Count; i += 3, j++)
            {
                _f[j,0,0]=i+1;
                _f[j,1,0]=i+2;
                _f[j,2,0]=i+3;
            }

            for (int i = 0, j = 0; j < tmpK.kObjVtx.Count; i += 3, j++)
            {
                if (tmpK.kObjVtx[j].uv[0] == null)
                {
                    continue;
                }
                _vt[i, 0] = tmpK.kObjVtx[j].uv[0].x;
                _vt[i, 1] = tmpK.kObjVtx[j].uv[0].y;

                _vt[i + 1, 0] = tmpK.kObjVtx[j].uv[1].x;
                _vt[i + 1, 1] = tmpK.kObjVtx[j].uv[1].y;

                _vt[i + 2, 0] = tmpK.kObjVtx[j].uv[2].x;
                _vt[i + 2, 1] = tmpK.kObjVtx[j].uv[2].y;
            }

            
            objFiles.Add(new obj(-1, (float[,])_v.Clone(), (float[,])_vt.Clone(), (float[,])_vn.Clone(), (int[, ,])_f.Clone()));
            
            

            vertexList.Clear();
        }


        public void TexMapping(string ImgPath)
        {
            isTexture = true;


            if (selectedIndex == -1)
            {
                return;
            }



            tempTexture[TextureIndex] = new int();


            objFiles[selectedIndex].txextureMapPath = ImgPath;
                //성민 png로 인터넷에서 때어온 이미지 경로로 저장 할 것.
               Bitmap texture = new Bitmap(objFiles[selectedIndex].txextureMapPath);

            

            //Gl.glEnable(Gl.GL_TEXTURE_2D);


            Gl.glBindTexture(Gl.GL_TEXTURE_2D, tempTexture[TextureIndex]);

            objFiles[selectedIndex].textureMapIndex = tempTexture[TextureIndex];
            TextureIndex++;

            texture.RotateFlip(RotateFlipType.RotateNoneFlipY);


            Rectangle rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            // Get The Bitmap's Pixel Data From The Locked Bitmap
            BitmapData bitmapData = texture.LockBits(rectangle, ImageLockMode.ReadOnly, texture.PixelFormat);


            // Create Linear Filtered Texture


            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_CLAMP);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_CLAMP);
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);


            //Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_ALPHA_SCALE, 1);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, texture.Width,
                texture.Height, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);


            //Gl.glDisable(Gl.GL_TEXTURE_2D);
            if (texture != null)
            {
                texture.UnlockBits(bitmapData);              // Unlock The Pixel Data From Memory
                texture.Dispose();                           // Dispose The Bitmap
            }

            isTexture = false;
        }


        public void FileTexMapping()
        {
            isTexture = true;

            
            //objFiles[objFiles.Count -1].txextureMapPath = ImgPath;
            //성민 png로 인터넷에서 때어온 이미지 경로로 저장 할 것.
            Bitmap texture = new Bitmap(objFiles[objFiles.Count - 1].txextureMapPath);



            //Gl.glEnable(Gl.GL_TEXTURE_2D);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, tempTexture[TextureIndex]);

            objFiles[objFiles.Count-1].textureMapIndex = tempTexture[TextureIndex];
            TextureIndex++;


            Rectangle rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            // Get The Bitmap's Pixel Data From The Locked Bitmap
            BitmapData bitmapData = texture.LockBits(rectangle, ImageLockMode.ReadOnly, texture.PixelFormat);


            // Create Linear Filtered Texture


            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_CLAMP);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_CLAMP);
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);


            //Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_ALPHA_SCALE, 1);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, texture.Width,
                texture.Height, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);


            //Gl.glDisable(Gl.GL_TEXTURE_2D);
            if (texture != null)
            {
                texture.UnlockBits(bitmapData);              // Unlock The Pixel Data From Memory
                texture.Dispose();                           // Dispose The Bitmap
            }

            isTexture = false;
        }
       

        public void setMain(frmMain thisfrmMain)
        {
            this.thisfrmMain = thisfrmMain;
        }
    }
}
