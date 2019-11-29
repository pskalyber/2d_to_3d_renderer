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
    public partial class frmExit : Form
    {
        public frmExit()
        {
            InitializeComponent();
        }

        private void saveY_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saved");
            Application.Exit();
        }

        private void saveNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
