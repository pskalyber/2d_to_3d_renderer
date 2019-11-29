using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace s3m
{
    public class obj : ICloneable
    {
        public int type;

        public float[,] v;
        public float[,] vt;
        public float[,] vn;
        public int[, ,] f;

        public float[] _v;

        public float[,] vClone;

        public float[,] rotatedVClone;
        public float[,] translatedVClone;
        public float[,] scaledVClone;

        public float xScale;
        public float yScale;
        public float zScale;

        public float xRotation;
        public float yRotation;
        public float zRotation;

        public float xTranslate;
        public float yTranslate;
        public float zTranslate;

        public int textureMapIndex=-1;
        public string txextureMapPath="";
        public string txextureMapName = "";

        [DisplayName("X Scale"), Category("Scale"), Description("도형의 X값 상대 크기")]
        public float XSCALE
        {
            get { return xScale; }
            set { xScale = value; }
        }
        [DisplayName("Y Scale"), Category("Scale"), Description("도형의 Y값 상대 크기")]
        public float YSCALE
        {
            get { return yScale; }
            set { yScale = value; }
        }
        [DisplayName("Z Scale"), Category("Scale"), Description("도형의 Z값 상대 크기")]
        public float ZSCALE
        {
            get { return zScale; }
            set { zScale = value; }
        }

        [DisplayName("X Rotation"), Category("Rotation"), Description("도형의 X값 회전 정도")]
        public float XROTATION
        {
            get { return xRotation; }
            set { xRotation = value; } 
        }
        [DisplayName("Y Rotation"), Category("Rotation"), Description("도형의 Y값 회전 정도")]
        public float YROTATION
        {
            get { return yRotation; }
            set { yRotation = value; }
        }
        [DisplayName("Z Rotation"), Category("Rotation"), Description("도형의 Z값 회전 정도")]
        public float ZROTATION
        {
            get { return zRotation; }
            set { zRotation = value; }
        }

        [DisplayName("X Translate"), Category("Translate"), Description("도형의 X값 이동 정도")]
        public float XTRANSLATE
        {
            get { return xTranslate; }
            set { xTranslate = value; }
        }
        [DisplayName("Y Translate"), Category("Translate"), Description("도형의 Y값 이동 정도")]
        public float YTRANSLATE
        {
            get { return yTranslate; }
            set { yTranslate = value; }
        }
        [DisplayName("Z Translate"), Category("Translate"), Description("도형의 Z값 이동 정도")]
        public float ZTRANSLATE
        {
            get { return zTranslate; }
            set { zTranslate = value; }
        }

        [DisplayName("V 값"), Category("정점값"), Description("도형을 이루는 버텍스 배열")]
        public float[] V
        {
            get { return _v; }
            set { _v = value; }
        }

        public obj()
        {

        }

        public obj(int _type, float[,] _v, float[,] _vt, float[,] _vn, int[, ,] _f)
        {
            type = _type;

            v = _v;
            vClone = (float[,])_v.Clone();
            rotatedVClone = (float[,])_v.Clone();
            scaledVClone = (float[,])_v.Clone();
            translatedVClone = (float[,])_v.Clone();

            vt = _vt;
            vn = _vn;
            f = _f;

            this._v=new float[_v.Length];
            xScale = 1;
            yScale = 1;
            zScale = 1;

            xRotation = 0;
            yRotation = 0;
            zRotation = 0;

            xTranslate = 0;
            yTranslate = 0;
            zTranslate = 0;

            int n = 0;
            for (int i = 0; i < _v.Length / 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this._v[n++] = _v[i, j];
                }
            }
        }

        public object Clone()
        {
            return this;
        }
    }
}
