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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            this.Location.Offset(this.Size.Width / 2, this.Size.Height / 2);
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
