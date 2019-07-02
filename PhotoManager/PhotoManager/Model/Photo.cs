﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.IO;
/*
https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/how-to-encode-and-decode-a-jpeg-image
*/

namespace PhotoManager.Model
{
	public class Photo
	{
        #region Fields
        private int? id;
		private string name;
		private DateTime creationDate;
		private ImageFormat format;
        private double photoSize;
        #endregion Fields

        #region Constructors
        public Photo(int? id, string name, DateTime creationDate,
		 ImageFormat format, double photoSize)
		{
			this.id = id;
			this.name = name;
			this.format = format;
			this.photoSize = photoSize;
			this.creationDate = creationDate;
		}
        #endregion Constructors

        #region Properties
        public string Name
        {
            set { name = value;}
            get { return name; }
        }
        public DateTime CreationDate
        {
            set { creationDate = value; }
            get { return creationDate; }
        }
        public ImageFormat Format
        {
            set { format = value; }
            get { return format; }
        }
        public double PhotoSize
        {
            set { photoSize = value; }
            get { return photoSize; }
        }

        #endregion Properties

        #region Methods
        public string EncodePhoto(string path)
        {
            FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fStream.Length];
            fStream.Read(data, 0, (int)fStream.Length);
            fStream.Close();

            string hex = BitConverter.ToString(data);
            hex = hex.Replace("-", "");
            return hex;
        }

		public string DecodePhoto()
		{
            return "";
		}

        #endregion Methods
    }
}
