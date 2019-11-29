using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace s3m
{
    public class Property
    {
        private float eyex;
        private float eyey;
        private float eyez;
        private double x;
        private double y;
        private double z;
        private float axisX;
        private float axisY;
        private float axisZ;
        private float rotX;
        private float rotY;
        private float rotZ;
        private string mode;

        [DisplayName("MODE"), Category("Tool"), Description("현재 선택된 그리기 툴")]
        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        [DisplayName("Eye X"), Category("Eye"), Description("카메라의 X좌표")]
        public float EYEX
        {
            get { return eyex; }
            set { eyex = value; }
        }
        [DisplayName("Eye Y"), Category("Eye"), Description("카메라의 Y좌표")]
        public float EYEY
        {
            get { return eyey; }
            set { eyey = value; }
        }
        [DisplayName("Eye Z"), Category("Eye"), Description("카메라의 Z좌표")]
        public float EYEZ
        {
            get { return eyez; }
            set { eyez = value; }
        }
        [DisplayName("Cursor X"), Category("Coordination"), Description("마우스의 X좌표")]
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        [DisplayName("Cursor Y"), Category("Coordination"), Description("마우스의 Y좌표")]
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        [DisplayName("Cursor Z"), Category("Coordination"), Description("마우스의 Z좌표")]
        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        [DisplayName("Rotation X"), Category("Rotation"), Description("X축의 회전값")]
        public float RotX
        {
            get { return rotX; }
            set { rotX = value; }
        }
        [DisplayName("Rotation Y"), Category("Rotation"), Description("Y축의 회전값")]
        public float RotY
        {
            get { return rotY; }
            set { rotY = value; }
        }
        [DisplayName("Rotation Z"), Category("Rotation"), Description("Z축의 회전값")]
        public float RotZ
        {
            get { return rotZ; }
            set { rotZ = value; }
        }
        [DisplayName("Axis X"), Category("Axis"), Description("기준축의 X좌표")]
        public float AxisX
        {
            get { return axisX; }
            set { axisX = value; }
        }
        [DisplayName("Axis Y"), Category("Axis"), Description("기준축의 Y좌표")]
        public float AxisY
        {
            get { return axisY; }
            set { axisY = value; }
        }
        [DisplayName("Axis Z"), Category("Axis"), Description("기준축의 Z좌표")]
        public float AxisZ
        {
            get { return axisZ; }
            set { axisZ = value; }
        }

    }
}
