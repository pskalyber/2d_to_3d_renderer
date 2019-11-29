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
    public partial class frmLight : Form
    {
        public bool ambientLight;

        public float diffuseA1;
        public float specularX1;
        public float specularY1;
        public float specularZ1;
        public float specluarA1;

        public float diffuseA2;
        public float specularX2;
        public float specularY2;
        public float specularZ2;
        public float specluarA2;

        public float diffuseA3;
        public float specularX3;
        public float specularY3;
        public float specularZ3;
        public float specluarA3;

        private float step = -20f;

        public frmLight()
        {
            InitializeComponent();

            ambientLight = cboxLight.Checked = true;

            diffuseA1 = 0.1f * float.Parse(tbarBrightness1.Value.ToString());
            tboxXLight1.Text = ((5 - tbarX1.Value) * step).ToString();
            specularX1 = float.Parse(tboxXLight1.Text);
            tboxYLight1.Text = ((5 - tbarY1.Value) * step).ToString();
            specularY1 = float.Parse(tboxYLight1.Text);
            tboxZLight1.Text = ((5 - tbarZ1.Value) * step).ToString();
            specularZ1 = float.Parse(tboxZLight1.Text);
            specluarA1 = 0.1f * float.Parse(tbarSpecular1.Value.ToString());

            diffuseA2 = 0.1f * float.Parse(tbarBrightness2.Value.ToString());
            tboxXLight2.Text = ((5 - tbarX2.Value) * step).ToString();
            specularX2 = float.Parse(tboxXLight2.Text);
            tboxYLight2.Text = ((5 - tbarY2.Value) * step).ToString();
            specularY2 = float.Parse(tboxYLight2.Text);
            tboxZLight2.Text = ((5 - tbarZ2.Value) * step).ToString();
            specularZ2 = float.Parse(tboxZLight2.Text);
            specluarA2 = 0.1f * float.Parse(tbarSpecular2.Value.ToString());

            diffuseA3 = 0.1f * float.Parse(tbarBrightness3.Value.ToString());
            tboxXLight3.Text = ((5 - tbarX3.Value) * step).ToString();
            specularX3 = float.Parse(tboxXLight3.Text);
            tboxYLight3.Text = ((5 - tbarY3.Value) * step).ToString();
            specularY3 = float.Parse(tboxYLight3.Text);
            tboxZLight3.Text = ((5 - tbarZ3.Value) * step).ToString();
            specularZ3 = float.Parse(tboxZLight3.Text);
            specluarA3 = 0.1f * float.Parse(tbarSpecular3.Value.ToString());
        }
        
        #region 조명1
        /// <summary>
        /// 조명1. 분산광 밝기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarBrightness1_Scroll(object sender, EventArgs e)
        {
            diffuseA1 = 0.1f * float.Parse(tbarBrightness1.Value.ToString());
        }

        /// <summary>
        /// 조명1. X위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarX1_Scroll(object sender, EventArgs e)
        {
            tboxXLight1.Text = ((5 - tbarX1.Value) * step).ToString();
            specularX1 = float.Parse(tboxXLight1.Text);
        }

        /// <summary>
        /// 조명1. Y위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarY1_Scroll(object sender, EventArgs e)
        {
            tboxYLight1.Text = ((5 - tbarY1.Value) * step).ToString();
            specularY1 = float.Parse(tboxYLight1.Text);
        }

        /// <summary>
        /// 조명1. Z위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarZ1_Scroll(object sender, EventArgs e)
        {
            tboxZLight1.Text = ((5 - tbarZ1.Value) * step).ToString();
            specularZ1 = float.Parse(tboxZLight1.Text);
        }

        /// <summary>
        /// 조명1. 반사광 밝기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarSpecular1_Scroll(object sender, EventArgs e)
        {
            specluarA1 = 0.1f * float.Parse(tbarSpecular1.Value.ToString());
        }
        #endregion

        #region 조명2
        /// <summary>
        /// 조명2. 분산광 밝기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarBrightness2_Scroll(object sender, EventArgs e)
        {
            diffuseA2 = 0.1f * float.Parse(tbarBrightness2.Value.ToString());
        }

        /// <summary>
        /// 조명2. X위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarX2_Scroll(object sender, EventArgs e)
        {
            tboxXLight2.Text = ((5 - tbarX2.Value) * step).ToString();
            specularX2 = float.Parse(tboxXLight2.Text);
        }

        /// <summary>
        /// 조명2. Y위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarY2_Scroll(object sender, EventArgs e)
        {
            tboxYLight2.Text = ((5 - tbarY2.Value) * step).ToString();
            specularY2 = float.Parse(tboxYLight2.Text);
        }

        /// <summary>
        /// 조명2. Z위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarZ2_Scroll(object sender, EventArgs e)
        {
            tboxZLight2.Text = ((5 - tbarZ2.Value) * step).ToString();
            specularZ2 = float.Parse(tboxZLight2.Text);
        }

        /// <summary>
        /// 조명2. 반사광 밝기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarSpecular2_Scroll(object sender, EventArgs e)
        {
            specluarA2 = 0.1f * float.Parse(tbarSpecular2.Value.ToString());
        }
        #endregion

        #region 조명3
        /// <summary>
        /// 조명3. 분산광 밝기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarBrightness3_Scroll(object sender, EventArgs e)
        {
            diffuseA3 = 0.1f * float.Parse(tbarBrightness3.Value.ToString());
        }

        /// <summary>
        /// 조명3. X위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarX3_Scroll(object sender, EventArgs e)
        {
            tboxXLight3.Text = ((5 - tbarX3.Value) * step).ToString();
            specularX3 = float.Parse(tboxXLight3.Text);
        }

        /// <summary>
        /// 조명3. Y위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarY3_Scroll(object sender, EventArgs e)
        {
            tboxYLight3.Text = ((5 - tbarY3.Value) * step).ToString();
            specularY3 = float.Parse(tboxYLight3.Text);
        }

        /// <summary>
        /// 조명3. Z위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarZ3_Scroll(object sender, EventArgs e)
        {
            tboxZLight3.Text = ((5 - tbarZ3.Value) * step).ToString();
            specularZ3 = float.Parse(tboxZLight3.Text);
        }

        /// <summary>
        /// 조명3. 반사광 위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarSpecular3_Scroll(object sender, EventArgs e)
        {
            specluarA3 = 0.1f * float.Parse(tbarSpecular3.Value.ToString());
        }
        #endregion

        /// <summary>
        /// 조명 효과 ON / OFF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxLight_CheckedChanged(object sender, EventArgs e)
        {
            ambientLight = !ambientLight;
        }

        /// <summary>
        /// 설정 적용
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        /// <summary>
        /// 설정 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefalut_Click(object sender, EventArgs e)
        {
            ambientLight = cboxLight.Checked = true;

            tbarBrightness1.Value = 10;
            tbarBrightness2.Value = 10;
            tbarBrightness3.Value = 10;

            tbarX1.Value = 0;
            tbarY1.Value = 10;
            tbarZ1.Value = 0;

            tbarX2.Value = 10;
            tbarY2.Value = 10;
            tbarZ2.Value = 0;

            tbarX3.Value = 0;
            tbarY3.Value = 10;
            tbarZ3.Value = 10;

            tbarSpecular1.Value = 9;
            tbarSpecular2.Value = 9;
            tbarSpecular3.Value = 9;

            diffuseA1 = 0.1f * float.Parse(tbarBrightness1.Value.ToString());
            tboxXLight1.Text = ((5 - tbarX1.Value) * step).ToString();
            specularX1 = float.Parse(tboxXLight1.Text);
            tboxYLight1.Text = ((5 - tbarY1.Value) * step).ToString();
            specularY1 = float.Parse(tboxYLight1.Text);
            tboxZLight1.Text = ((5 - tbarZ1.Value) * step).ToString();
            specularZ1 = float.Parse(tboxZLight1.Text);
            specluarA1 = 0.1f * float.Parse(tbarSpecular1.Value.ToString());

            diffuseA2 = 0.1f * float.Parse(tbarBrightness2.Value.ToString());
            tboxXLight2.Text = ((5 - tbarX2.Value) * step).ToString();
            specularX2 = float.Parse(tboxXLight2.Text);
            tboxYLight2.Text = ((5 - tbarY2.Value) * step).ToString();
            specularY2 = float.Parse(tboxYLight2.Text);
            tboxZLight2.Text = ((5 - tbarZ2.Value) * step).ToString();
            specularZ2 = float.Parse(tboxZLight2.Text);
            specluarA2 = 0.1f * float.Parse(tbarSpecular2.Value.ToString());

            diffuseA3 = 0.1f * float.Parse(tbarBrightness3.Value.ToString());
            tboxXLight3.Text = ((5 - tbarX3.Value) * step).ToString();
            specularX3 = float.Parse(tboxXLight3.Text);
            tboxYLight3.Text = ((5 - tbarY3.Value) * step).ToString();
            specularY3 = float.Parse(tboxYLight3.Text);
            tboxZLight3.Text = ((5 - tbarZ3.Value) * step).ToString();
            specularZ3 = float.Parse(tboxZLight3.Text);
            specluarA3 = 0.1f * float.Parse(tbarSpecular3.Value.ToString());
        }
    }
}
