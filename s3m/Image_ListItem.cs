using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageObjectExtration
{
    public partial class Image_ListItem : UserControl
    {
        public Image_ListItem()
        {
            InitializeComponent();
        }
        string _uri;
        string _text;
        public PictureBox Get_Picture = new PictureBox();
        public string Image_Uri
        {
            get { return _uri; }
            set
            {
                _uri = value;
                Image.LoadAsync(_uri);
               
            }
        }

        public string _Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Label_Text.Text = _text;
            }
        }

        private void Image_ListItem_Click(object sender, EventArgs e)
        {

        }
    }
}
