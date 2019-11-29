using System;

using System.Threading;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using s3m;

using Tao.FreeGlut;
using Tao.OpenGl;
namespace kObjectClass
{
    // enum

    /// <summary>
    /// 삼각형 타입
    /// </summary>
    public enum dTriangleT
    {
        Terminal, Sleeve, Junction
    };

    /// <summary>
    /// 삼각형 이루는 변들의 타입
    /// </summary>
    public enum dTriangleET
    {
        eInternal = 0, eExternal = 1
    };
    /*
    public enum dPointT
        {
            NotFan, Fan, Fan_Junction, Sleeve, CAxis
        };
    */


    /// <summary>
    /// 삼각형을 구성하는 정점 정보를 가진 구조체
    /// </summary>
    public struct kTriangle_Point
    {
        public Point v0, v1, v2;

    }



    /// <summary>
    /// 삼각형으로 구성된 하나의 객체에 대한 정보 및 함수를 가진 클래스
    /// </summary>
    public class kObject
    {
        // struct
        /// <summary>
        /// 삼각형을 포함하는 사각형 정보를 가지는 구조체
        /// </summary>
        struct kRectangle
        {
            public float maxX, maxY;
            public float minX, minY;

        }

        /// <summary>
        /// 삼각형을 이루는 정점들 정보를 가지는 클래스
        /// </summary>
        public struct kPoint
        {
            public List<float> depthValue;
            public List<Point> PointList;
            public Point2f[,] UvList;
        }
        // variables
        /// <summary>
        /// 객체를 저장할 때 정점정보를 저장하는 구조인 클래스
        /// </summary>
        public class SaveTemplate
        {
            public float[] v0 = new float[3];
            public float[] v1 = new float[3];
            public float[] v2 = new float[3];

            public Point2f[] uv = new Point2f[3];
        }

        public kPoint kFitPoly = new kPoint();
        public List<dTriangle> Triangle = new List<dTriangle>(); // for drawing

        public int HowMany = -1;


        public List<Point> kDrawPoly = new List<Point>();
        List<Point> kPolygon = new List<Point>();
        kPoint tempPList = new kPoint();

        kRectangle kRect = new kRectangle();

        List<vertex> tVertexList;


        //Creator
        /// <summary>
        /// 생성자함수. 3차원 객체를 생성하기위한 함수를 모두 호출.
        /// </summary>
        /// <param name="vertexList">마우스로 그린 스케치 좌표를 받아서 활용</param>
        public kObject(List<vertex> vertexList)
        {
            tVertexList = vertexList.ToList();
            FirstInitialize();

            Vtx2Pt(vertexList);

            LineFitting();
            //MessageBox.Show(kFitPoly.PointList.Count.ToString());
            CreateRect();

            HowMany = ConstrainedTriangulate();

            CheckTTri();

            FanningTriangles();
        }


        // Init

        /// <summary>
        /// vertex 형태의 정점을 point형으로 변환하는 함수
        /// </summary>
        /// <param name="vertexList">vertex형태의 마우스 좌표값 리스트</param>
        public void Vtx2Pt(List<vertex> vertexList)
        {

            //             for (int i = 0; i < vertexList.Count; i++)
            //             {
            //                 kPolygon.Add(new Point((int)vertexList[i].x, (int)vertexList[i].y));
            //             }
            for (int i = 0; i < tVertexList.Count; i++)
            {

                kPolygon.Add(new Point((int)tVertexList[i].x, (int)tVertexList[i].y));
            }

        }


        /// <summary>
        /// 모든 자료구조의 초기화 함수
        /// </summary>
        public void FirstInitialize()
        {
            kPolygon.Add(new Point());

            kFitPoly.PointList = new List<Point>();
            kFitPoly.depthValue = new List<float>();
            //kFitPoly.UvList = new List<Point2f>();
            kFitPoly.PointList.Add(new Point());
            kFitPoly.depthValue.Add(0);
            //kFitPoly.UvList.Add(new Point2f(0,0));
            Triangle.Add(new dTriangle());

        }



        // Line Fitting
        /// <summary>
        /// 모든 정점을 사용하지 않고 정점의 개수를 줄이는 함수
        /// </summary>
        public void LineFitting()
        {

            int i;


            for (i = 1; i < kPolygon.Count; i++)
            {
                i += 3;
                if (i >= kPolygon.Count) break;
                //kPolygon.RemoveAt(i);
                kFitPoly.PointList.Add(kPolygon[i]);
                kFitPoly.depthValue.Add(0);
            }
            kFitPoly.PointList.Add(kPolygon[1]);
            kFitPoly.depthValue.Add(0);
            kPolygon.Clear();

            kDrawPoly = kFitPoly.PointList.ToList();



            //            kFitPoly.PointList.Add(kPolygon[0]);

        }

        // 외접사각형 생성

        public int maxX, minX;
        public int maxY, minY;
        /// <summary>
        /// 객체를 포함하는 외접 사각형의 정보 생성
        /// </summary>
        public void CreateRect()
        {


            for (int i = 1; i < kFitPoly.PointList.Count; i++)
            {
                if (i == 1)
                {
                    maxX = kFitPoly.PointList[i].X;
                    maxY = kFitPoly.PointList[i].Y;

                    minX = kFitPoly.PointList[i].X;
                    minY = kFitPoly.PointList[i].Y;
                }
                else
                {
                    maxX = Math.Max(maxX, kFitPoly.PointList[i].X);
                    maxY = Math.Max(maxY, kFitPoly.PointList[i].Y);

                    minX = Math.Min(minX, kFitPoly.PointList[i].X);
                    minY = Math.Min(minY, kFitPoly.PointList[i].Y);

                }

            }


            kRect.minX = minX;
            kRect.minY = minY;
            kRect.maxX = maxX;
            kRect.maxY = maxY;


            ////MessageBox.Show(minX.ToString() + "," + minY.ToString());

        }


        //
        #region 삼각화


        /// <summary>
        /// 강제적 삼각화 함수로, 다각형 외부에 생긴 삼각형을 제거하는 함수
        /// </summary>
        /// <returns></returns>
        public int ConstrainedTriangulate()
        {
            int NumofTri = Triangulate(kFitPoly.PointList.Count);
            //             Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_LINE);
            //             Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_LINE);
            //             for (int i = 1; i <= NumofTri; i++)
            //             {
            //                 Gl.glColor3f(0f, 1f, 0f);
            //                 Gl.glBegin(Gl.GL_TRIANGLES);
            // 
            //                 for (int j = 0; j < 3; j++)
            //                 {
            //                     Gl.glVertex3f(kFitPoly.PointList[Triangle[i].vv[j]].X, kFitPoly.PointList[Triangle[i].vv[j]].Y, 0);
            // 
            //                 }
            //                 Gl.glEnd();
            //             }
            Point RetCom;

            int Maximum = int.MinValue;
            int tMax = int.MinValue;

            for (int i = 1; i <= NumofTri; i++)
            {


                kTriangle_Point tmp = new kTriangle_Point();
                tmp.v0 = kFitPoly.PointList[Triangle[i].vv[0]];
                tmp.v1 = kFitPoly.PointList[Triangle[i].vv[1]];
                tmp.v2 = kFitPoly.PointList[Triangle[i].vv[2]];

                tMax = Math.Max(Triangle[i].vv[0], Triangle[i].vv[1]);
                tMax = Math.Max(tMax, Triangle[i].vv[2]);
                Maximum = Math.Max(tMax, Maximum);

                RetCom = new Point();
                RetCom = GetCenterofmass(tmp);

                if (!isContainPoint(RetCom.X, RetCom.Y))
                {

                    Triangle.RemoveAt(i);
                    i--;
                    NumofTri--;

                    continue;
                }
            }


            for (int i = 1; i <= NumofTri; i++)
            {
                Triangle[i].SetEdges(Maximum);
            }

            return NumofTri;
        }


        public void ConstrainedTriangulate_Printf()
        {
            //Console.WriteLine("ConstrainedTriangulate_Start");

            //Console.WriteLine("");
            Gl.glColor3f(1f, 0f, 0f);
            Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_LINE);
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_LINE);
            for (int i = 1; i <= HowMany; i++)
            {
                Gl.glBegin(Gl.GL_TRIANGLES);

                for (int j = 0; j < 3; j++)
                {
                    Gl.glVertex3f(kFitPoly.PointList[Triangle[i].vv[j]].X, kFitPoly.PointList[Triangle[i].vv[j]].Y, 0);

                }
                Gl.glEnd();
            }
        }


        /// <summary>
        /// 삼각화 함수로 다각형 외부 정점으로 삼각분할을 하는 함수
        /// </summary>
        /// <param name="nvert">정점의 개수</param>
        /// <returns></returns>
        public int Triangulate(int nvert)
        {
            int retval = 0;

            List<bool> Complete = new List<bool>();
            int[,] Edges = new int[3, 500 * 3];



            double xmin;
            double xmax;
            double ymin;
            double ymax;
            double xmid;
            double ymid;
            double dx;
            double dy;
            double dmax;


            int i;
            int j;
            int k;
            bool inc;

            double xc;
            xc = 0;
            double yc;
            yc = 0;
            double r;
            r = 0;
            int Nedge = 0;
            int ntri;

            xmin = kFitPoly.PointList[1].X;
            ymin = kFitPoly.PointList[1].Y;
            xmax = xmin;
            ymax = ymin;
            Complete.Add(true);


            for (i = 2; i < nvert; i++)
            {
                if (kFitPoly.PointList[i].X < xmin)
                {
                    xmin = kFitPoly.PointList[i].X;
                }
                if (kFitPoly.PointList[i].X > xmax)
                {
                    xmax = kFitPoly.PointList[i].X;
                }
                if (kFitPoly.PointList[i].Y < ymin)
                {
                    ymin = kFitPoly.PointList[i].Y;
                }
                if (kFitPoly.PointList[i].Y > ymax)
                {
                    ymax = kFitPoly.PointList[i].Y;
                }
            }

            dx = xmax - xmin;
            dy = ymax - ymin;

            if (dx > dy)
            {
                dmax = dx;
            }
            else
            {
                dmax = dy;
            }

            xmid = (xmax + xmin) / 2;
            ymid = (ymax + ymin) / 2;


            kFitPoly.PointList.Add(new Point(kFitPoly.PointList[kFitPoly.PointList.Count - 1].X, kFitPoly.PointList[kFitPoly.PointList.Count - 1].Y));
            kFitPoly.depthValue.Add(0);


            float tmpx, tmpy;
            tmpx = (float)(xmid - 2 * dmax);
            tmpy = (float)(ymid - dmax);
            Point tp = new Point((int)tmpx, (int)tmpy);
            kFitPoly.PointList.Add(tp);
            kFitPoly.depthValue.Add(0);

            tmpx = (float)xmid;
            tmpy = (float)(ymid + 2 * dmax);
            tp = new Point((int)tmpx, (int)tmpy);
            kFitPoly.PointList.Add(tp);
            kFitPoly.depthValue.Add(0);

            tmpx = (float)(xmid + ((float)(2 * dmax)));
            tmpy = (float)(ymid - dmax);
            tp = new Point((int)tmpx, (int)tmpy);
            kFitPoly.PointList.Add(tp);
            kFitPoly.depthValue.Add(0);

            dTriangle tT = new dTriangle();
            tT.SetVidcs(nvert + 1, nvert + 2, nvert + 3);

            if (Triangle.Count == 1)
            {
                Triangle.Add(tT);
                Complete.Add(false);
            }

            ntri = 1;

            for (i = 1; i < nvert; i++)
            {

                Nedge = 0;
                j = 0;

                do
                {
                    j = j + 1;
                    if (Complete[j] != true)
                    {
                        inc = InCircle(kFitPoly.PointList[i].X, kFitPoly.PointList[i].Y, kFitPoly.PointList[Triangle[j].vv[0]].X, kFitPoly.PointList[Triangle[j].vv[0]].Y, kFitPoly.PointList[Triangle[j].vv[1]].X, kFitPoly.PointList[Triangle[j].vv[1]].Y, kFitPoly.PointList[Triangle[j].vv[2]].X, kFitPoly.PointList[Triangle[j].vv[2]].Y, xc, yc, r);

                        //                         if (inc == false)
                        //                             //Console.WriteLine("1\n");
                        if (inc)
                        {



                            Edges[1, Nedge + 1] = Triangle[j].vv[0];
                            Edges[2, Nedge + 1] = Triangle[j].vv[1];
                            Edges[1, Nedge + 2] = Triangle[j].vv[1];
                            Edges[2, Nedge + 2] = Triangle[j].vv[2];
                            Edges[1, Nedge + 3] = Triangle[j].vv[2];
                            Edges[2, Nedge + 3] = Triangle[j].vv[0];


                            dTriangle tdT = new dTriangle();

                            tdT.SetVidcs(Triangle[ntri].vv[0], Triangle[ntri].vv[1], Triangle[ntri].vv[2]);


                            Nedge = Nedge + 3;

                            Triangle[j] = tdT;
                            Complete[j] = Complete[ntri];



                            j = j - 1;
                            ntri = ntri - 1;



                        }


                    }
                } while (j < ntri);



                for (j = 1; j <= Nedge - 1; j++)
                {
                    if (Edges[1, j] != 0 && Edges[2, j] != 0)
                    {
                        for (k = j + 1; k <= Nedge; k++)
                        {
                            if (Edges[1, k] != 0 && Edges[2, k] != 0)
                            {
                                if (Edges[1, j] == Edges[2, k])
                                {
                                    if (Edges[2, j] == Edges[1, k])
                                    {
                                        Edges[1, j] = 0;
                                        Edges[2, j] = 0;
                                        Edges[1, k] = 0;
                                        Edges[2, k] = 0;
                                    }
                                }
                            }
                        }
                    }
                }



                for (j = 1; j <= Nedge; j++)
                {
                    if (Edges[1, j] != 0 && Edges[2, j] != 0)
                    {


                        dTriangle tdT = new dTriangle();

                        tdT.SetVidcs(Edges[1, j], Edges[2, j], i);


                        ntri = ntri + 1;
                        if (ntri < Triangle.Count && j < Triangle.Count)
                        {
                            Triangle[ntri] = tdT;
                            Complete[ntri] = false;

                        }
                        else
                        {
                            Triangle.Add(tdT);
                            Complete.Add(false);
                        }
                    }
                }

            }

            i = 0;

            do
            {

                i = i + 1;
                if (Triangle[i].vv[0] > nvert || Triangle[i].vv[1] > nvert || Triangle[i].vv[2] > nvert)
                {
                    dTriangle tdT = new dTriangle();


                    tdT.SetVidcs(Triangle[ntri].vv[0], Triangle[ntri].vv[1], Triangle[ntri].vv[2]);



                    Triangle[i] = tdT;
                    i = i - 1;
                    ntri = ntri - 1;
                }
            } while (i < ntri);

            retval = ntri;

            return retval;
        }



        /// <summary>
        /// 삼각화 과정에서 삼각형의 외접원을 구성하고 외접원 내에 다른 정점이 없는지 검사
        /// </summary>
        /// <returns></returns>
        private bool InCircle(float xp, float yp, float x1, float y1, float x2, float y2, float x3, float y3, double xc, double yc, double r)
        {

            bool TheResult;

            double eps;
            double m1;
            double m2;
            double mx1;
            double mx2;
            double my1;
            double my2;
            double dx;
            double dy;
            double rsqr;
            double drsqr;

            TheResult = false;
            eps = 0.000001;

            if (System.Math.Abs(y1 - y2) < eps && System.Math.Abs(y2 - y3) < eps)
            {
                ////MessageBox.Show("INCIRCUM - F - Points are coincident !!");
                TheResult = false;
                return TheResult;
            }


            if (System.Math.Abs(y2 - y1) < eps)
            {
                m2 = (double)-(x3 - x2) / (y3 - y2);
                mx2 = (double)(x2 + x3) / 2;
                my2 = (double)(y2 + y3) / 2;
                xc = (x2 + x1) / 2;
                yc = m2 * (xc - mx2) + my2;
            }
            else if (System.Math.Abs(y3 - y2) < eps)
            {
                m1 = (double)-(x2 - x1) / (y2 - y1);
                mx1 = (double)(x1 + x2) / 2;
                my1 = (double)(y1 + y2) / 2;
                xc = (x3 + x2) / 2;
                yc = m1 * (xc - mx1) + my1;
            }
            else
            {
                m1 = (double)-(x2 - x1) / (y2 - y1);
                m2 = (double)-(x3 - x2) / (y3 - y2);
                mx1 = (double)(x1 + x2) / 2;
                mx2 = (double)(x2 + x3) / 2;
                my1 = (double)(y1 + y2) / 2;
                my2 = (double)(y2 + y3) / 2;
                xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2);
                yc = m1 * (xc - mx1) + my1;
            }

            dx = x2 - xc;
            dy = y2 - yc;
            rsqr = dx * dx + dy * dy;
            r = System.Math.Sqrt(rsqr);
            dx = xp - xc;
            dy = yp - yc;
            drsqr = dx * dx + dy * dy;

            if (drsqr <= rsqr)
            {
                TheResult = true;

            }
            return TheResult;

        }
        #endregion

        #region 중점구해서 폴리곤 내/외부 판별


        /// <summary>
        /// 삼각형으 중점을 구하는 함수
        /// </summary>
        /// <param name="tTri">삼각형의 정점정보</param>
        /// <returns></returns>
        private Point GetCenterofmass(kTriangle_Point tTri)
        {
            Point retval = new Point();

            double wx, wy;

            wx = tTri.v0.X + tTri.v1.X + tTri.v2.X;
            wx = (double)wx / 3;

            wy = tTri.v0.Y + tTri.v1.Y + tTri.v2.Y;
            wy = (double)wy / 3;


            retval.X = (int)wx;
            retval.Y = (int)wy;

            return retval;
        }


        /// <summary>
        /// 해당 정점이 다각형안에 정점이 포함되는지 검사하는 함수
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool isContainPoint(int x, int y)
        {
            int hitCount = 0;

            if (kRect.maxX < x || x < kRect.minX)
            {

                return false;

            }
            if (kRect.maxY < y || y < kRect.minY)
            {

                return false;

            }


            Point[] tPoint = new Point[kDrawPoly.Count];
            for (int i = 1; i < kDrawPoly.Count; i++)
            {
                if (i != kDrawPoly.Count - 1)
                {
                    tPoint[i] = kDrawPoly[i + 1];

                }
                else
                {
                    tPoint[i] = kDrawPoly[1];
                }


            }

            for (int i = 1; i < kDrawPoly.Count; i++)
            {
                if (Math.Min(kDrawPoly[i].Y, tPoint[i].Y) > y)
                    continue;
                if (Math.Max(kDrawPoly[i].Y, tPoint[i].Y) < y)
                    continue;

                int tempParam = 0;
                if (x > 0)
                    tempParam = (int)(x + kRect.maxX);
                else
                    tempParam = (int)(kRect.maxX - kRect.minX);
                //if (Intersection(kDrawPoly[i], tPoint[i], new Point(x, y), new Point((int)x+(int)kRect.maxX, y)))
                if (Intersection(kDrawPoly[i], tPoint[i], new Point(x, y), new Point(tempParam, y)))
                {
                    hitCount++;
                }

            }


            //

            if (hitCount % 2 == 0)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 교차 판정 함수
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns></returns>
        public bool Intersection(Point p1, Point p2, Point p3, Point p4)
        {
            if ((SignedArea(p1, p2, p3) * SignedArea(p1, p2, p4) <= 0) &&
                (SignedArea(p3, p4, p1) * SignedArea(p3, p4, p2) <= 0))
                return true;
            else
                return false;

        }

        /// <summary>
        /// 정점들의 상관관계로 교차판정을 돕는 함수
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public int SignedArea(Point p1, Point p2, Point p3)
        {
            long area = ((p1.X * p2.Y - p1.Y * p2.X) +
                        (p2.X * p3.Y - p2.Y * p3.X) +
                        (p3.X * p1.Y - p3.Y * p1.X));

            if (area > 0)
                return 1;
            else
                return -1;

        }
        #endregion


        #region 삼각형 팬화, 중점따기

        /// <summary>
        /// 삼각형 내부에 정점을 찍고 fan형으로 변형 및 chordal axis구하는 함수
        /// </summary>
        public void CheckTTri()
        {
            tempPList.PointList = new List<Point>();
            tempPList.depthValue = new List<float>();

            for (int i = 1; i <= HowMany; i++)
            {
                // Terminal
                if (Triangle[i].GetTType() == dTriangleT.Terminal)
                {
                    TTri_To_FanningTri(i);

                }
            }

            //  if (tempPList.PointList == null) return;
            // CDT안된 부분도 모두 검사하기때문에 그부분을 제외해야함
            for (int i = 0; i < tempPList.PointList.Count; i++)
            {
                if (isContainPoint(tempPList.PointList[i].X, tempPList.PointList[i].Y) == false)
                {
                    tempPList.PointList.RemoveAt(i);
                    tempPList.depthValue.RemoveAt(i);
                    i--;

                    continue;
                }

            }

        }



        /// <summary>
        /// 외부 삼각형을 fan형으로 병합하는 함수
        /// </summary>
        /// <param name="i"></param>
        private void TTri_To_FanningTri(int i)
        {

            // Test



            List<Point> isinSemiCircle = new List<Point>();
            int stP = -1, edP = -1;
            float tx, ty, tresult;

            double midx, midy;
            Point midPoint;// = new Point();
            double radius, compRadius;

            double areaValue = 0;

            // find Internal Edge //



            // edge = v0 -> v1
            if (Triangle[i].e0 == dTriangleET.eInternal)
            {
                stP = Triangle[i].vv[0];
                edP = Triangle[i].vv[1];
            }
            // v1 -> v2
            else if (Triangle[i].e1 == dTriangleET.eInternal)
            {
                stP = Triangle[i].vv[1];
                edP = Triangle[i].vv[2];
            }
            // v2 -> v0
            else if (Triangle[i].e2 == dTriangleET.eInternal)
            {
                stP = Triangle[i].vv[2];
                edP = Triangle[i].vv[0];

            }

            isinSemiCircle.Add(kFitPoly.PointList[Triangle[i].vv[0]]);
            isinSemiCircle.Add(kFitPoly.PointList[Triangle[i].vv[1]]);
            isinSemiCircle.Add(kFitPoly.PointList[Triangle[i].vv[2]]);

            Triangle[i].Check = true;


            areaValue = GetTriangleArea(kFitPoly.PointList[Triangle[i].vv[0]], kFitPoly.PointList[Triangle[i].vv[1]], kFitPoly.PointList[Triangle[i].vv[2]]);


            int loop = 0;
            while (true)
            {
                // calculate midpoint
                midx = kFitPoly.PointList[stP].X + kFitPoly.PointList[edP].X;
                midx = (double)midx / 2;

                midy = kFitPoly.PointList[stP].Y + kFitPoly.PointList[edP].Y;
                midy = (double)midy / 2;

                midPoint = new Point();
                midPoint.X = (int)midx;
                midPoint.Y = (int)midy;

                //calculate radius

                midx = kFitPoly.PointList[stP].X - kFitPoly.PointList[edP].X;
                midx = Math.Pow(midx, 2);

                midy = kFitPoly.PointList[stP].Y - kFitPoly.PointList[edP].Y;
                midy = Math.Pow(midy, 2);

                radius = midx + midy;
                radius = Math.Sqrt(radius);
                radius = radius / 2;



                for (int c = 0; c < isinSemiCircle.Count; c++)
                {

                    // 원의 중심 라인은 검사 X
                    if (isinSemiCircle[c] == kFitPoly.PointList[stP] || isinSemiCircle[c] == kFitPoly.PointList[edP])
                        continue;


                    // (x1-x2)^2
                    midx = midPoint.X - isinSemiCircle[c].X;
                    midx = Math.Pow(midx, 2);
                    // (y1-y2)^2
                    midy = midPoint.Y - isinSemiCircle[c].Y;
                    midy = Math.Pow(midy, 2);

                    // (x1-x2)^2+(y1-y2)^2 -> root
                    compRadius = midx + midy;
                    compRadius = Math.Sqrt(compRadius);

                    // Thread.Sleep(300);
                    if (compRadius > radius)
                    {
                        radius = -1;
                        break;
                    }
                }


                if (radius == -1)
                {
                    // fan Point

                    // if (areaValue > 400)
                    {
                        tx = kFitPoly.PointList[stP].X - kFitPoly.PointList[edP].X;
                        tx = (float)Math.Pow(tx, 2);
                        ty = kFitPoly.PointList[stP].Y - kFitPoly.PointList[edP].Y;
                        ty = (float)Math.Pow(ty, 2);

                        tresult = tx + ty;
                        tresult = (float)Math.Sqrt(tresult);

                        tresult *= 0.5f;

                        tempPList.PointList.Add(midPoint);
                        // if (areaValue > 500) // 넓이가 좀 넓어서 sleeve level..
                        {
                            //  //Console.WriteLine("여기여기");

                            tempPList.depthValue.Add(tresult);
                        }


                        break;
                    }

                }


                // find Triangle jointed current triangle //
                loop++;
                if (loop == HowMany + 1) break;
                // find jointed triangle
                int jointedTri = 0;
                int k = -1, r = -1, kr = -1;
                for (k = 1; k <= HowMany; k++)
                {
                    if (k == i) continue;
                    //if (Triangle[k].Check == true) continue;
                    for (r = 0; r < 3; r++)
                    {

                        if (Triangle[k].vv[r] == stP)
                        {
                            for (kr = 0; kr < 3; kr++)
                            {
                                if (kr == r) continue;
                                if (Triangle[k].vv[kr] == edP)
                                {
                                    jointedTri = k;
                                    break;
                                }

                            }

                        }

                        if (jointedTri != 0) break;
                    }
                    if (jointedTri != 0) { break; }
                }

                if (jointedTri == 0) break;

                int tempP;

                areaValue += GetTriangleArea(kFitPoly.PointList[Triangle[jointedTri].vv[0]], kFitPoly.PointList[Triangle[jointedTri].vv[1]], kFitPoly.PointList[Triangle[jointedTri].vv[2]]);


                if (Triangle[jointedTri].GetTType() == dTriangleT.Junction)
                {
                    tx = kFitPoly.PointList[stP].X - kFitPoly.PointList[edP].X;
                    tx = (float)Math.Pow(tx, 2);
                    ty = kFitPoly.PointList[stP].Y - kFitPoly.PointList[edP].Y;
                    ty = (float)Math.Pow(ty, 2);

                    tresult = tx + ty;
                    tresult = (float)Math.Sqrt(tresult);

                    tresult *= 0.5f;

                    tempPList.PointList.Add(midPoint);


                    tempPList.depthValue.Add(tresult);


                    break;
                }
                else if (Triangle[jointedTri].Check == true) break;
                else
                {
                    areaValue += GetTriangleArea(kFitPoly.PointList[Triangle[jointedTri].vv[0]], kFitPoly.PointList[Triangle[jointedTri].vv[1]], kFitPoly.PointList[Triangle[jointedTri].vv[2]]);
                    // set current line..
                    // add new vertex in finding jointed triangle
                    Triangle[jointedTri].Check = true;
                    tempP = Triangle[jointedTri].vv[3 - r - kr];
                    isinSemiCircle.Add(kFitPoly.PointList[tempP]);
                    if (Math.Abs(tempP - stP) == 1)//|| Math.Abs(tempP-stP) == Maximum -1)
                    {
                        stP = tempP;
                    }
                    else if (Math.Abs(tempP - edP) == 1)// || Math.Abs(tempP - stP) == Maximum - 1)
                    {
                        edP = tempP;
                    }
                }
            }
        }



        //
        #endregion



        /// <summary>
        /// 합병한 삼각형들의 넓이를 계산하는 함수
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        private double GetTriangleArea(Point p1, Point p2, Point p3)
        {
            double retVal = 0;
            double tf1 = 0;
            double tf2 = 0;

            tf1 = Math.Abs(p1.X * p2.Y);
            tf1 += Math.Abs(p2.X * p3.Y);
            tf1 += Math.Abs(p3.X * p1.Y);

            tf2 = Math.Abs(p2.X * p1.Y);
            tf2 += Math.Abs(p3.X * p2.Y);
            tf2 += Math.Abs(p1.X * p3.Y);

            retVal = tf1 - tf2;
            retVal = Math.Abs(retVal);

            return retVal;
        }



        /// <summary>
        /// 새롭게 구한 chordal axis 정점들의 정보를 저장하는 함수
        /// </summary>
        private void AddtempPList()
        {
            double midx, midy;
            Point addPoint;

            float tx, ty, tresult;
            float tmaxline = float.MinValue;
            for (int i = 1; i < Triangle.Count; i++)
            {

                if (Triangle[i].Check == true) continue;



                if (Triangle[i].GetTType() == dTriangleT.Junction)
                {
                    kTriangle_Point tk = new kTriangle_Point();
                    tk.v0 = kFitPoly.PointList[Triangle[i].vv[0]];
                    tk.v1 = kFitPoly.PointList[Triangle[i].vv[1]];
                    tk.v2 = kFitPoly.PointList[Triangle[i].vv[2]];
                    addPoint = new Point();
                    addPoint = GetCenterofmass(tk);

                    for (int ti = 0; ti < 3; ti++)
                    {
                        tx = kFitPoly.PointList[Triangle[i].vv[ti]].X - kFitPoly.PointList[Triangle[i].vv[(ti + 1) % 3]].X;
                        tx = (float)Math.Pow(tx, 2);

                        ty = kFitPoly.PointList[Triangle[i].vv[ti]].Y - kFitPoly.PointList[Triangle[i].vv[(ti + 1) % 3]].Y;
                        ty = (float)Math.Pow(ty, 2);

                        tresult = tx + ty;
                        tresult = (float)Math.Sqrt(tresult);

                        if (tmaxline < tresult)
                            tmaxline = tresult;
                    }
                    if (!tempPList.PointList.Contains(addPoint))
                    {
                        tmaxline *= 0.5f;
                        tempPList.PointList.Add(addPoint);
                        tempPList.depthValue.Add(tmaxline);
                        continue;
                    }



                }
                else if (Triangle[i].GetTType() == dTriangleT.Sleeve)
                {
                    // v0 - v1
                    if (Triangle[i].e0 == dTriangleET.eInternal)
                    {
                        midx = kFitPoly.PointList[Triangle[i].vv[0]].X + kFitPoly.PointList[Triangle[i].vv[1]].X;
                        midx = (double)midx / 2;

                        midy = kFitPoly.PointList[Triangle[i].vv[0]].Y + kFitPoly.PointList[Triangle[i].vv[1]].Y;
                        midy = (double)midy / 2;

                        addPoint = new Point((int)midx, (int)midy);
                        if (!tempPList.PointList.Contains(addPoint))
                        {

                            tx = kFitPoly.PointList[Triangle[i].vv[0]].X - kFitPoly.PointList[Triangle[i].vv[1]].X;
                            tx = (float)Math.Pow(tx, 2);

                            ty = kFitPoly.PointList[Triangle[i].vv[0]].Y - kFitPoly.PointList[Triangle[i].vv[1]].Y;
                            ty = (float)Math.Pow(ty, 2);

                            tresult = tx + ty;
                            tresult = (float)Math.Sqrt(tresult);
                            tresult *= 0.5f;
                            tempPList.PointList.Add(addPoint);
                            tempPList.depthValue.Add(tresult);

                        }


                    }
                    // v1 - v2
                    if (Triangle[i].e1 == dTriangleET.eInternal)
                    {

                        midx = kFitPoly.PointList[Triangle[i].vv[1]].X + kFitPoly.PointList[Triangle[i].vv[2]].X;
                        midx = (double)midx / 2;

                        midy = kFitPoly.PointList[Triangle[i].vv[1]].Y + kFitPoly.PointList[Triangle[i].vv[2]].Y;
                        midy = (double)midy / 2;

                        addPoint = new Point((int)midx, (int)midy);
                        if (!tempPList.PointList.Contains(addPoint))
                        {
                            tx = kFitPoly.PointList[Triangle[i].vv[1]].X - kFitPoly.PointList[Triangle[i].vv[2]].X;
                            tx = (float)Math.Pow(tx, 2);

                            ty = kFitPoly.PointList[Triangle[i].vv[1]].Y - kFitPoly.PointList[Triangle[i].vv[2]].Y;
                            ty = (float)Math.Pow(ty, 2);

                            tresult = tx + ty;
                            tresult = (float)Math.Sqrt(tresult);

                            tresult *= 0.5f;
                            tempPList.PointList.Add(addPoint);
                            tempPList.depthValue.Add(tresult);
                        }
                    }
                    // v0 - v2
                    if (Triangle[i].e2 == dTriangleET.eInternal)
                    {

                        midx = kFitPoly.PointList[Triangle[i].vv[0]].X + kFitPoly.PointList[Triangle[i].vv[2]].X;
                        midx = (double)midx / 2;

                        midy = kFitPoly.PointList[Triangle[i].vv[0]].Y + kFitPoly.PointList[Triangle[i].vv[2]].Y;
                        midy = (double)midy / 2;

                        addPoint = new Point((int)midx, (int)midy);
                        if (!tempPList.PointList.Contains(addPoint))
                        {
                            tx = kFitPoly.PointList[Triangle[i].vv[0]].X - kFitPoly.PointList[Triangle[i].vv[2]].X;
                            tx = (float)Math.Pow(tx, 2);

                            ty = kFitPoly.PointList[Triangle[i].vv[0]].Y - kFitPoly.PointList[Triangle[i].vv[2]].Y;
                            ty = (float)Math.Pow(ty, 2);

                            tresult = tx + ty;
                            tresult = (float)Math.Sqrt(tresult);

                            tresult *= 0.5f;
                            tempPList.PointList.Add(addPoint);
                            tempPList.depthValue.Add(tresult);
                        }

                    }

                }
                //                 else if (Triangle[i].GetTType() == dTriangleT.Terminal)
                //                 {
                // 
                //                 }


            }

        }


        public List<dTriangle> TriangleSides = new List<dTriangle>();


        /// <summary>
        /// 생성된 3D 객체의 반대편도 복사해서 저장하는 함수
        /// </summary>
        public void CreateCopyTris()
        {
            // TriangleSides.Add(new dTriangle());
            int loopi = 0;
            TriangleSides.Add(new dTriangle());
            while (loopi != 2)
            {
                loopi++;
                for (int i = 1; i <= this.HowMany; i++)
                {

                    dTriangle tmp = new dTriangle();
                    tmp.vv[0] = Triangle[i].vv[0];
                    tmp.vv[1] = Triangle[i].vv[1];
                    tmp.vv[2] = Triangle[i].vv[2];
                    TriangleSides.Add(tmp);
                    if (loopi == 2)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (TriangleSides[i + HowMany].vv[j] > kDrawPoly.Count)
                                TriangleSides[i + HowMany].vv[j] *= (-1);
                        }
                    }
                }
            }

            for (int i = 0; i < TriangleSides.Count; i++)
            {
                //Console.WriteLine(i.ToString() + ":" + TriangleSides[i].vv[0].ToString() + "," + TriangleSides[i].vv[1].ToString() + "," + TriangleSides[i].vv[2].ToString());
            }

            //MessageBox.Show(HowMany.ToString() + "," + TriangleSides.Count.ToString());

        }


        /// <summary>
        /// 삼각형을 합병하는 함수
        /// </summary>
        public void FanningTriangles()
        {
            //             for (int i = 1; i <= HowMany; i++)
            //             {
            //                 Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_LINE);
            //                 Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_LINE);
            //                 Gl.glBegin(Gl.GL_TRIANGLES);
            //                 Gl.glColor3f(1, 0, 0);
            //                 for (int j = 0; j < 3; j++)
            //                     Gl.glVertex3f(kFitPoly.PointList[Triangle[i].vv[j]].X, kFitPoly.PointList[Triangle[i].vv[j]].Y, 0);
            //                 Gl.glEnd();
            // 
            //                
            //             }
            AddtempPList();

            for (int i = 0; i < tempPList.PointList.Count; i++)
            {
                kFitPoly.PointList.Add(tempPList.PointList[i]);
                kFitPoly.depthValue.Add(tempPList.depthValue[i]);

            }

            //             //Console.WriteLine(kFitPoly.PointList.Count.ToString());
            //             //Console.WriteLine(kFitPoly.flag.Count.ToString());

            Triangle.Clear();
            Triangle.Add(new dTriangle());
            //ResetButton_Click(null, null);
            //ConstrainedTriangulate();
            HowMany = Triangulate(kFitPoly.PointList.Count);
            Point RetCom = new Point();
            kTriangle_Point tmp = new kTriangle_Point();


            for (int i = 1; i <= HowMany; i++)
            {

                tmp.v0 = kFitPoly.PointList[Triangle[i].vv[0]];
                tmp.v1 = kFitPoly.PointList[Triangle[i].vv[1]];
                tmp.v2 = kFitPoly.PointList[Triangle[i].vv[2]];

                RetCom = GetCenterofmass(tmp);

                if (!isContainPoint(RetCom.X, RetCom.Y))
                {
                    Triangle.RemoveAt(i);
                    i--;
                    HowMany--;
                    continue;
                }

            }
            //             Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_LINE);
            //             Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_LINE);
            for (int i = 1; i <= HowMany; i++)
            {
                Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glColor3f(0, 1, 0);
                for (int j = 0; j < 3; j++)
                    Gl.glVertex3f(kFitPoly.PointList[Triangle[i].vv[j]].X, kFitPoly.PointList[Triangle[i].vv[j]].Y, 0);
                Gl.glEnd();

                //for (int k = 0; k <= 2; k++)
                //{
                //    Gl.glBegin(Gl.GL_POINTS);
                //    Gl.glVertex3f(kFitPoly.PointList[Triangle[i].vv[k]].X, kFitPoly.PointList[Triangle[i].vv[k]].Y, 0);
                //    Gl.glEnd();
                //}
            }
            CreateCopyTris();
        }


        public List<SaveTemplate> kObjVtx;



        /// <summary>
        /// 생성된 객체의 정점 정보를 저장하는 함수
        /// </summary>
        public void SaveVertex()
        {

            // level 0 - notfan
            // level 1 - fan, fan_junction
            // level 2 - sleeve
            // level 3 - junction



            int loopi = 0;
            int depthValue = 0;
            kObjVtx = new List<SaveTemplate>();


            while (loopi != 2)
            //while(depth >= 0)
            {
                loopi++;

                for (int i = 1; i <= HowMany; i++)
                {
                    if (i + HowMany == HowMany * 2) break;
                    SaveTemplate tmp = new SaveTemplate();

                    for (int j = 0; j < 3; j++)
                    {

                        float[] tv = new float[3];





                        //if (kFitPoly.depthValue[Triangle[i].vv[j]] == 0) //MessageBox.Show(Triangle[i].vv[j].ToString());
                        if (loopi == 2)
                        {
                            if (TriangleSides[i + HowMany].vv[j] < 0)
                            {
                                tv[0] = kFitPoly.PointList[-TriangleSides[i + HowMany].vv[j]].X;
                                tv[1] = kFitPoly.PointList[-TriangleSides[i + HowMany].vv[j]].Y;
                                tv[2] = -kFitPoly.depthValue[-TriangleSides[i + HowMany].vv[j]];
                            }
                            else
                            {
                                tv[0] = kFitPoly.PointList[TriangleSides[i + HowMany].vv[j]].X;
                                tv[1] = kFitPoly.PointList[TriangleSides[i + HowMany].vv[j]].Y;
                                tv[2] = kFitPoly.depthValue[TriangleSides[i + HowMany].vv[j]];
                            }

                        }
                        else
                        {
                            tv[0] = kFitPoly.PointList[TriangleSides[i].vv[j]].X;
                            tv[1] = kFitPoly.PointList[TriangleSides[i].vv[j]].Y;
                            tv[2] = kFitPoly.depthValue[TriangleSides[i].vv[j]];
                        }
                        if (j == 0)
                        {
                            tmp.v0 = tv;
                        }
                        else if (j == 1)
                        {
                            tmp.v1 = tv;

                        }
                        else if (j == 2)
                        {
                            tmp.v2 = tv;

                        }
                    }

                    kObjVtx.Add(tmp);

                }


            }


        }



        /// <summary>
        /// 텍스쳐 uv값을 저장하는 함수
        /// </summary>
        public void SaveVtData()
        {
            kFitPoly.UvList = new Point2f[kFitPoly.PointList.Count, 2];
            FindUvPoint(1, new Point2f(0.5f, 0.5f));
            int i = 0;
            for (int k = 1; k <= this.HowMany; k++)
            {


                for (int j = 0; j < 3; j++)
                {
                    kObjVtx[i].uv[j] = new Point2f(-1, -1);
                    if (kFitPoly.UvList[TriangleSides[k].vv[j], 0] != null)
                    {
                        kObjVtx[i].uv[j].x = kFitPoly.UvList[TriangleSides[k].vv[j], 0].x;
                        kObjVtx[i].uv[j].y = kFitPoly.UvList[TriangleSides[k].vv[j], 0].y;

                    }

                }
                i++;
                //                if (i > kObjVtx.Count) break;


            }

            int x = this.HowMany + 1;
            int tmpidx;
            for (int k = this.HowMany + 1; k < HowMany * 2; k++)
            {
                for (int j = 0; j < 3; j++)
                {
                    kObjVtx[x].uv[j] = new Point2f(-1, -1);
                    if (TriangleSides[k].vv[j] < 0)
                        tmpidx = -TriangleSides[k].vv[j];
                    else tmpidx = TriangleSides[k].vv[j];


                    if (kFitPoly.UvList[tmpidx, 1] != null)
                    {
                        kObjVtx[x].uv[j].x = kFitPoly.UvList[tmpidx, 1].x;
                        kObjVtx[x].uv[j].y = kFitPoly.UvList[tmpidx, 1].y;
                    }
                }

                x++;
                if (x >= kObjVtx.Count) break;
            }


        }


        /// <summary>
        /// 생성된 3차원 객체를 그리는 함수
        /// </summary>
        public void RenderObject()
        {

            for (int i = 1; i < kObjVtx.Count; i++)
            {
                Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glColor3f(0f, 1f, 1f);

                Gl.glVertex3fv(kObjVtx[i].v0);
                Gl.glVertex3fv(kObjVtx[i].v1);
                Gl.glVertex3fv(kObjVtx[i].v2);

                Gl.glEnd();
                //  //Console.WriteLine("여기");


            }

        }










        List<UvCheack> CheckPoint = new List<UvCheack>();

        //Texture에 대한 임의의 정보.

        float TexScale = 0.05f; //Vertex가 1일 때 텍스쳐는 0.03



        /// <summary>
        /// 텍스쳐 이미지의 가운데에서 시작해서 uv좌표를 설정하는 함수
        /// </summary>
        /// <param name="indexPoint"></param>
        /// <param name="UvValue"></param>
        public void FindUvPoint(int indexPoint, Point2f UvValue) //Triangle[1].vv[0];
        {
            Point2f tempUvValue = new Point2f(0, 0);

            CheckPoint.Add(new UvCheack(indexPoint, UvValue));
            bool isCheack = false;

            for (int i = 1; i < TriangleSides.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (indexPoint == TriangleSides[i].vv[j])
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            //CheackPoint에 검사할 indexPoint가 있는지를 판별. 없다면 아래에 재귀.
                            for (int z = 0; z < CheckPoint.Count; z++)
                            {
                                for (int x = 0; x < CheckPoint.Count; x++)
                                {
                                    if (TriangleSides[i].vv[k] == CheckPoint[x].index)
                                    {
                                        isCheack = true;
                                    }
                                }

                                if (CheckPoint[z].index != TriangleSides[i].vv[k] && !isCheack)
                                {
                                    //리스트 내에 존재 하지 않는 값.

                                    float tx, ty, tz, tresult;
                                    float tz_0, tz_1;
                                    float tx_0, tx_1, ty_0, ty_1;


                                    if (indexPoint < 0)
                                        tz_0 = -kFitPoly.depthValue[-indexPoint];
                                    else
                                        tz_0 = kFitPoly.depthValue[indexPoint];

                                    if (TriangleSides[i].vv[k] < 0)
                                        tz_1 = -kFitPoly.depthValue[-TriangleSides[i].vv[k]];
                                    else
                                        tz_1 = kFitPoly.depthValue[TriangleSides[i].vv[k]];


                                    if (indexPoint < 0)
                                    {
                                        tx_0 = kFitPoly.PointList[-indexPoint].X;
                                        ty_0 = kFitPoly.PointList[-indexPoint].Y;
                                    }
                                    else
                                    {
                                        tx_0 = kFitPoly.PointList[indexPoint].X;
                                        ty_0 = kFitPoly.PointList[indexPoint].Y;

                                    }
                                    if (TriangleSides[i].vv[k] < 0)
                                    {
                                        tx_1 = kFitPoly.PointList[-TriangleSides[i].vv[k]].X;
                                        ty_1 = kFitPoly.PointList[-TriangleSides[i].vv[k]].Y;

                                    }
                                    else
                                    {
                                        tx_1 = kFitPoly.PointList[TriangleSides[i].vv[k]].X;
                                        ty_1 = kFitPoly.PointList[TriangleSides[i].vv[k]].Y;

                                    }
                                    //                                     tx = tx_0 - tx_1;
                                    //                                     if (tx < 0)
                                    //                                     {
                                    //                                         tx *= tx;
                                    //                                         tresult = tx + tz;
                                    //                                         tresult = (float)Math.Sqrt(tresult);    //두 버텍스 사이의 거리
                                    //                                         tresult = tresult * -1;
                                    //                                     }
                                    //                                     else
                                    //                                     {
                                    //                                         tx *= tx;
                                    //                                         tresult = tx + tz;
                                    //                                         tresult = (float)Math.Sqrt(tresult);
                                    //                                     }
                                    //                                     tempUvValue.x = UvValue.x + tresult * TexScale;
                                    // 
                                    // 
                                    //                                     ty = ty_0 - ty_1;
                                    //                                     if (ty < 0)
                                    //                                     {
                                    //                                         ty *= ty;
                                    //                                         tresult = ty + tz;
                                    //                                         tresult = (float)Math.Sqrt(tresult);    //두 버텍스 사이의 거리
                                    //                                         if (TriangleSides[i].vv[k] > 0 && indexPoint > 0)       
                                    //                                             tresult = tresult * -1;
                                    //                                     }
                                    //                                     else
                                    //                                     {
                                    //                                         ty *= ty;
                                    //                                         tresult = ty + tz;
                                    //                                         tresult = (float)Math.Sqrt(tresult);    //두 버텍스 사이의 거리
                                    //                                     }
                                    //                                     tempUvValue.y = UvValue.y + tresult * TexScale;




                                    float x0 = tx_0, y0 = ty_0, z0 = tz_0;   //시작점
                                    float x1 = tx_1, y1 = ty_1, z1 = tz_1;   // 끝나는 점.

                                    float x, y; //나오는 x,y 좌표
                                    float r = (float)Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0) + (z1 - z0) * (z1 - z0));

                                    float cosTheta = (float)((x1 - x0) / Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0)));
                                    float sinTheta = (float)((y1 - y0) / Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0)));

                                    x = x0 + r * cosTheta;
                                    y = y0 + r * sinTheta;



                                    if (TriangleSides[i].vv[k] < 0)
                                    {
                                        tempUvValue.x = (((x - tx_0) * TexScale) + UvValue.x) * -1;
                                        tempUvValue.y = (((y - ty_0) * TexScale) + UvValue.y) * -1;

                                    }
                                    else
                                    {
                                        tempUvValue.x = ((x - tx_0) * TexScale) + UvValue.x;
                                        tempUvValue.y = ((y - ty_0) * TexScale) + UvValue.y;

                                    }




                                    if (TriangleSides[i].vv[k] > 0)
                                        kFitPoly.UvList[TriangleSides[i].vv[k], 0] = new Point2f(tempUvValue.x, tempUvValue.y);
                                    else if (TriangleSides[i].vv[k] < 0)
                                        kFitPoly.UvList[-TriangleSides[i].vv[k], 1] = new Point2f(tempUvValue.x, tempUvValue.y);


                                    if (tempUvValue.x > 1.0f || tempUvValue.x < 0 || tempUvValue.y > 1.0f || tempUvValue.y < 0)
                                        break;

                                    else
                                    {
                                        FindUvPoint(TriangleSides[i].vv[k], tempUvValue);

                                    }


                                }
                            }

                            isCheack = false;
                        }
                        isCheack = false;
                        break; //삼각형에 같은 인덱스가 없기 때문에 다음 삼각형을 검사.
                    }

                }
            }
            return;
        }

    }


    /// <summary>
    /// 텍스쳐 uv 값을 저장하는 클래스
    /// </summary>
    class UvCheack
    {
        public int index;
        public Point2f UvValue;

        public UvCheack() { }

        public UvCheack(int index, Point2f UvValue)
        {
            this.index = index;
            this.UvValue = new Point2f(UvValue.x, UvValue.y);
        }
    }



}
