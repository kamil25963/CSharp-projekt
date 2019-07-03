﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager.View
{
	public partial class imgViewer : Form
	{

		public imgViewer()
		{
            
            InitializeComponent();
            //this.Size = new Size(10, 10);
            //panel.Size = new Size(pictureBox.Width, pictureBox.Height);
            //pictureBox.Size = new Size(20, 20);
            //this.panel.Size = Screen.FromControl(this).Bounds.Size;
		}

		public Image ImgBox
		{
			set
			{
				this.pictureBox.Image = value;
				this.pictureBox.Size = value.Size;
			}
		}

		private void imgViewer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(this.pictureBox.Image != null)
			{
				pictureBox.Dispose();
			}
		}
	}
}