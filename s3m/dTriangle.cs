using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace kObjectClass
{

    /// <summary>
    /// mesh를 구성하는 각 삼각형 정보를 가지는 클래스
    /// </summary>
    public class dTriangle
    {

        public int[] vv = new int[3];
        public dTriangleET e0, e1, e2;
        private dTriangleT tType;
        public bool Check = false;

        /// <summary>
        /// 삼각형을 이루는 정점들의 번호를 지정하는 함수
        /// </summary>
        /// <param name="p0">첫번째 정점</param>
        /// <param name="p1">두번째 정점</param>
        /// <param name="p2">세번째 정점</param>
        public void SetVidcs(int p0, int p1, int p2)
        {
            vv[0] = p0;
            vv[1] = p1;
            vv[2] = p2;

            //                 SetEdges();
            //                 SetType();

        }

        /// <summary>
        /// 삼각형을 이루는 변들이 어떤 타입인지 정함
        /// 타입 : external, internal
        /// </summary>
        /// <param name="MaxValue">마지막 정점번호</param>
        public void SetEdges(int MaxValue)
        {

            int t = vv[0] - vv[1];

            if (1 == Math.Abs(t) || MaxValue - 1 == Math.Abs(t))
                e0 = dTriangleET.eExternal;

            else
                e0 = dTriangleET.eInternal;

            t = vv[1] - vv[2];
            if (1 == Math.Abs(t) || MaxValue - 1 == Math.Abs(t))
                e1 = dTriangleET.eExternal;
            else
                e1 = dTriangleET.eInternal;

            t = vv[2] - vv[0];
            if (1 == Math.Abs(t) || MaxValue - 1 == Math.Abs(t))
                e2 = dTriangleET.eExternal;
            else
                e2 = dTriangleET.eInternal;


            SetType();
        }

        /// <summary>
        /// 삼각형을 이루는 변들의 구성에 따라 삼각형의 타입 지정
        /// 타입 : junction, sleeve, terminal
        /// </summary>
        void SetType()
        {

            int k = (int)e0 + (int)e1 + (int)e2;
            // type 0 - external, type 1 - internal
            // 1개 internal - terminal tri
            if (k == 2)
                tType = dTriangleT.Terminal; // terminal
            else if (k == 1)
                tType = dTriangleT.Sleeve; // sleeve
            else if (k == 0)
                tType = dTriangleT.Junction; // junction


        }


        /// <summary>
        /// 삼각형의 타입을 반환
        /// </summary>
        /// <returns>삼각형 타입</returns>
        public dTriangleT GetTType()
        {
            return tType;
        }

    }

}
