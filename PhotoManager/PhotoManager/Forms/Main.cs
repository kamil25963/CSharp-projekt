﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PhotoManager.View;
using PhotoManager.Model;
using System.Drawing.Imaging;

namespace PhotoManager
{
    public partial class Main : Form, IForm1View
    {
        #region Fields
        private List<String> fileNames = new List<string>();
		private int X;
		private int Y;
        private static Main instance = null;
		private List<Album> albums;
		private List<Photo> photos; //from db
        private List<Image> KURWA;
        private bool IfAlbumSelected = false;
        private int i = 0; //indekser do wyświetlania zdjęć
        #endregion Fields

        #region Events
        public event Action<string, Photo> AddPhotoEvent;
		public event Func<List<Album>> GetAlbums;
		public event Action<Album> GetPhotosFromDB;
       
		#endregion Events

		#region Constructors
		private Main()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Properties
        public static Main InstanceForm1
        {
            get
            {
                if (instance == null)
                    instance = new Main();
                return instance;
            }
        }

        public IAddAlbumView IAddAlbumView
        {
            get
            {
                return AddAlbum.AddAlbumInstance;
            }
        }

        public List<Photo> PhotoList
        {
            set {  photos = value; }
        }
        #endregion Properties

        #region MenuMethods
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if(!IfAlbumSelected)
            {
                ShowMessage(false, "Select an album first!");
                return;
            }
            if(albumListToolStripMenuItem.DropDownItems.Count > 0)
            {
                using (OpenFileDialog ofd = new OpenFileDialog()
                {
                    Multiselect = true,
                    ValidateNames = true,
                    Filter = "JPEG|*.jpg"
                })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileName in ofd.FileNames)
                        {
                            FileInfo fi = new FileInfo(fileName);
                            fileNames.Add(fi.FullName);

                            if (AddPhotoEvent != null)
                            {
                                AddPhotoEvent(fi.FullName, new Photo(null, fi.Name, fi.CreationTime, ImageFormat.Jpeg, fi.Length)); //albums bo albumsComboBox zawierajątylko NAME 
                            }
                        }
                    }
                }
            }
            else
            {
                ShowMessage(false, "Create an album first!");
            }
		}

        private void createNewAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAlbum.AddAlbumInstance.ShowDialog();
        }

        #endregion MenuMethods

        #region OtherMethods
        public void ShowMessage(bool success, string message)
        {
            MessageBox.Show(message, success ? "Message" : "Error", MessageBoxButtons.OK);
        }
        private void imgListView_ItemActivate(object sender, EventArgs e)
        {
            if (imgListView.FocusedItem != null)
            {
                using (imgViewer iv = new imgViewer())
                {

                    Image img2 = KURWA[imgListView.FocusedItem.Index];
                    iv.ImgBox = img2;
                    iv.ShowDialog();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
		{
            albums = new List<Album>();
			albums = GetAlbums();
            albumListToolStripMenuItem.DropDownItems.Clear();
            foreach (var item in albums)
			{
                albumListToolStripMenuItem.DropDownItems.Add(item.Name);
			}
            if (albumListToolStripMenuItem.DropDownItems.Count < 1)
                albumListToolStripMenuItem.Enabled = false;
            else
                albumListToolStripMenuItem.Enabled = true;
        }

		public void AddNewAlbumToList(Album album)
        {
            albumListToolStripMenuItem.DropDownItems.Add(album.Name);
            albumListToolStripMenuItem.Enabled = true;
        }

        public void AddNewPhotoToList(Photo newPhoto)
        {
            photos.Clear(); //nie dublują się zdjęcia po wybraniu drugi raz tego samego albumu (po dodaniu nowego zdjęcia)
            imageListMin.Images.Add(newPhoto.Image);
            KURWA.Add(newPhoto.Image);
            imgListView.Items.Add(newPhoto.Name, i);
            i++;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion OtherMethods

        private void albumListToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            IfAlbumSelected = true;
            fileNames.Clear();  //nazwy plików są odpowiednie
            imgListView.Items.Clear(); //czyszczenie listy obrazków
            imageListMin.Images.Clear(); //miniaturki są takie jak powinny być
            KURWA = new List<Image>();
                GetPhotosFromDB(albums[albumListToolStripMenuItem.DropDownItems.IndexOf(e.ClickedItem)]);
                i = 0;
                foreach (Photo photo in photos)
                {
                    imageListMin.Images.Add(photo.Image);
                    KURWA.Add(photo.Image);
                    imgListView.Items.Add(photo.Name, i);
                    i++;
                }
            photos.Clear(); //wybranie tego samego albumu nie powoduje dodania do widoku niepotrzebnego zdjęcia
        }
    }
}
