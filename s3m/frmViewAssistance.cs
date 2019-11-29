using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace s3m
{
    public partial class frmViewAssistance : Form
    {
        public float gridSize;
        public float gridStep;
        public float gridLocationY;

        public float AxisesSize;

        public float gridColorR;
        public float gridColorG;
        public float gridColorB;

        public float axisXColorR;
        public float axisXColorG;
        public float axisXColorB;

        public float axisYColorR;
        public float axisYColorG;
        public float axisYColorB;

        public float axisZColorR;
        public float axisZColorG;
        public float axisZColorB;

        public frmViewAssistance()
        {
            InitializeComponent();

            gridSize = 100f;
            gridStep = 10f;
            gridLocationY = 0.0f;

            AxisesSize = 100f;

            gridColorR = 255f;
            gridColorG = 255f;
            gridColorB = 255f;

            axisXColorR = 255f;
            axisXColorG = 0f;
            axisXColorB = 0f;

            axisYColorR = 0f;
            axisYColorG = 255f;
            axisYColorB = 0f;

            axisZColorR = 0f;
            axisZColorG = 0f;
            axisZColorB = 255f;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.Visible = false;
        }

        private void tbarGridSize_Scroll(object sender, EventArgs e)
        {
            tboxGridSize.Text = (tbarGridSize.Value * 10).ToString();
            gridSize = float.Parse(tboxGridSize.Text);
        }

        private void tbarGridStep_Scroll(object sender, EventArgs e)
        {
            tboxGridStep.Text = tbarGridStep.Value.ToString();
            gridStep = float.Parse(tboxGridStep.Text);
        }

        private void tbarGridLocationY_Scroll(object sender, EventArgs e)
        {
            tboxGridLocationY.Text = (tbarGridLocationY.Value * -0.1).ToString();
            gridLocationY = float.Parse(tboxGridLocationY.Text);
        }

        private void tbarAxisesSize_Scroll(object sender, EventArgs e)
        {
            tboxAxisesSize.Text = (tbarAxisesSize.Value * 10).ToString();
            AxisesSize = float.Parse(tboxAxisesSize.Text);
        }

        private void pboxGridColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pboxGridColor.BackColor = colorDialog.Color;
                gridColorR = colorDialog.Color.R;
                gridColorG = colorDialog.Color.G;
                gridColorB = colorDialog.Color.B;
            }
        }

        private void pboxXColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pboxXColor.BackColor = colorDialog.Color;
                axisXColorR = colorDialog.Color.R;
                axisXColorG = colorDialog.Color.G;
                axisXColorB = colorDialog.Color.B;
            }
        }

        private void pboxYColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pboxYColor.BackColor = colorDialog.Color;
                axisYColorR = colorDialog.Color.R;
                axisYColorG = colorDialog.Color.G;
                axisYColorB = colorDialog.Color.B;
            }
        }

        private void pboxZColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pboxZColor.BackColor = colorDialog.Color;
                axisZColorR = colorDialog.Color.R;
                axisZColorG = colorDialog.Color.G;
                axisZColorB = colorDialog.Color.B;
            }
        }

        private void btnDefalut_Click(object sender, EventArgs e)
        {
            gridColorR = 255f;
            gridColorG = 255f;
            gridColorB = 255f;

            axisXColorR = 255f;
            axisXColorG = 0f;
            axisXColorB = 0f;

            axisYColorR = 0f;
            axisYColorG = 255f;
            axisYColorB = 0f;

            axisZColorR = 0f;
            axisZColorG = 0f;
            axisZColorB = 255f;

            tbarGridSize.Value = 10;
            tbarGridStep.Value = 10;
            tbarGridLocationY.Value = 3;
            tbarAxisesSize.Value = 10;

            tboxGridSize.Text = (tbarGridSize.Value * 10).ToString();
            tboxGridStep.Text = tbarGridStep.Value.ToString();
            tboxGridLocationY.Text = tbarGridLocationY.Value.ToString();
            tboxAxisesSize.Text = (tbarAxisesSize.Value * 10).ToString();

            pboxGridColor.BackColor = Color.White;
            pboxXColor.BackColor = Color.Red;
            pboxYColor.BackColor = Color.Green;
            pboxZColor.BackColor = Color.Blue;
        }


    }
}
