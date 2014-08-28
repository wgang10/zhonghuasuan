using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zhonghuasuan
{
    public partial class CategoryPicture : UserControl
    {
        private string url = string.Empty;
        private string state = string.Empty;
        public CategoryPicture()
        {
            InitializeComponent();
        }

        public string Pic
        {
            set {
                pic.Image = Image.FromStream(System.Net.WebRequest.Create(value).GetResponse().GetResponseStream());
            }
        }

        public string Title
        {
            set {
                title.Text = value;
            }
        }

        public string Price
        {
            set {
                price.Text = value;
            }
        }

        public string Url
        {
            set {
                url = value;
            }
        }

        public string State
        {
            set
            {
                state = value;
                if (value == "活动结束")
                {
                    title.ForeColor = Color.Red;
                }
                else if (value == "还有机会")
                {
                    title.ForeColor = Color.Green;
                }
                else if (value == "我要抢购")
                {
                    title.ForeColor = Color.Black;
                }
            }
        }

        private void price_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void pic_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(url);
        }

        
    }
}
