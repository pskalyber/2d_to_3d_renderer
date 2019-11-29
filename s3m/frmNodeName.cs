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
    public partial class frmNodeName : Form
    {
        public String nodeName="";

        public frmNodeName()
        {
            InitializeComponent();
        }

        private void frmNodeName_Load(object sender, EventArgs e)
        {
            tboxNodeName.Text = nodeName;
        }

        private void tboxNodeName_TextChanged(object sender, EventArgs e)
        {
            this.nodeName = tboxNodeName.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmMain main = (frmMain)Owner;
            main._nodeName = tboxNodeName.Text;
            this.Close();
        }

        private void tboxNodeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                frmMain main = (frmMain)Owner;
                main._nodeName = tboxNodeName.Text;
                this.Close();
            }
        }
    }
}
