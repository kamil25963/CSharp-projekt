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
	public partial class Main : Form, IMainViev
	{
        #region Fields
        private List<String> fileNames = new List<string>();
		private static Main instance = null;
		private List<Album> albums;
		private List<Photo> photos; //from db
		private List<Image> ImageList;
		private bool IfAlbumSelected = false;
		private int i = 0; //indekser do wyświetlania zdjęć
        //private int indexOfLastActiveMenuSTripItem = -1;
		#endregion Fields

		#region Events
		public event Action<string, Photo> AddPhotoEvent;
		public event Func<List<Album>> GetAlbums;
		public event Action<Album> GetPhotosFromDB;
		public event Action<string> SaveAlbum;
		public event Action GetUserName;
		public event Action GetCurrentAlbum;
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
				if (instance == null || instance.IsDisposed)
					instance = new Main();
				return instance;
			}
		}

		public static Main Instance
		{
			set { instance = value; }
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
			set { photos = value; }
		}

		public string UserName
		{
			set { UserNameInfoLabel.Text += value; }
		}

		public string AlbumName
		{
			set { AlbumInfoLabel.Text = value; }
		}
		#endregion Properties

		#region MenuMethods
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (albumListToolStripMenuItem.DropDownItems.Count == 0)
			{
				ShowMessage(false, "Create an album first!");
				return;
			}
			if (!IfAlbumSelected)
			{
				ShowMessage(false, "Select an album first!");
				return;
			}

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
                        if (FileWithThisNameExists(fi.Name))
                        {
                            
                            fileNames.Add(fi.Name);

                            if (AddPhotoEvent != null)
                            {
                                AddPhotoEvent(fi.FullName, new Photo(null, fi.Name, fi.CreationTime, ImageFormat.Jpeg, fi.Length)); //albums bo albumsComboBox zawierajątylko NAME 
                            }
                        }
                        else
                            MessageBox.Show("File with name " + fi.Name + " is already exists in this album", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

					}
				}
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

					Image img2 = ImageList[imgListView.FocusedItem.Index];
					iv.ImgBox = img2;
					iv.ShowDialog();
				}
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			if (GetUserName != null)
				GetUserName();
			albums = new List<Album>();
			// if (GetAlbums != null)
			albums = GetAlbums();
			//else
			//    return;
			albumListToolStripMenuItem.DropDownItems.Clear();
			foreach (var item in albums)
			{
				albumListToolStripMenuItem.DropDownItems.Add(item.Name);
			}
			if (albumListToolStripMenuItem.DropDownItems.Count < 1)
				albumListToolStripMenuItem.Enabled = false;
			else
			{
				albumListToolStripMenuItem.Enabled = true;
				LoadPhotosForAlbumWithIndex(0);
			}

		}

		public void AddNewAlbumToList(Album album)
		{
			albumListToolStripMenuItem.DropDownItems.Add(album.Name);
			albumListToolStripMenuItem.Enabled = true;
		}

		public void AddNewPhotoToList(Photo newPhoto)
		{
			//photos.Clear(); //nie dublują się zdjęcia po wybraniu drugi raz tego samego albumu (po dodaniu nowego zdjęcia)
			imageListMin.Images.Add(newPhoto.Image);
			ImageList.Add(newPhoto.Image);
			imgListView.Items.Add(newPhoto.Name, i);
			i++;
		}

		#endregion OtherMethods
		private void LoadPhotosForAlbumWithIndex(int index)
		{
           /* if (indexOfLastActiveMenuSTripItem != index)
            {*/
                if (photos != null)
                    photos.Clear();
                //try { photos.Clear(); } catch (Exception e) }
                //indexOfLastActiveMenuSTripItem = index; 
                IfAlbumSelected = true;
                fileNames.Clear();  //nazwy plików są odpowiednie
                imgListView.Items.Clear(); //czyszczenie listy obrazków
                imageListMin.Images.Clear(); //miniaturki są takie jak powinny być
                ImageList = new List<Image>();
                GetPhotosFromDB(albums[index]);
                i = 0;
                foreach (Photo photo in photos)
                {
                    imageListMin.Images.Add(photo.Image);
                    ImageList.Add(photo.Image);
                    fileNames.Add(photo.Name);
                    imgListView.Items.Add(photo.Name, i);
                    i++;
                }

                //photos.Clear(); //wybranie tego samego albumu nie powoduje dodania do widoku niepotrzebnego zdjęcia
                if (GetCurrentAlbum != null)
                    GetCurrentAlbum();
           /* }
            else
            {
                return;
            }*/
		}
		private void albumListToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			LoadPhotosForAlbumWithIndex(albumListToolStripMenuItem.DropDownItems.IndexOf(e.ClickedItem));
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
            DialogResult result = MessageBox.Show("Do you want co close an application?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == result)
            {
                this.Dispose();
                Application.Exit();
            }
            else
                e.Cancel = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want co close an application?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(DialogResult.Yes == result)
            {
                this.Dispose();
                Application.Exit();
            }
        }

		private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
		{

            DialogResult result = MessageBox.Show("Do you want to log out?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == result)
            {
                this.Dispose();
                Application.Restart();
            }
            
		}		

		private void saveAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (FolderBrowserDialog ofd = new FolderBrowserDialog())
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string destinationPath = ofd.SelectedPath;
                    if (SaveAlbum != null)
                        SaveAlbum(destinationPath);
                }

            }
        }

        private bool FileWithThisNameExists(string newFileName)
        {
            foreach(string fName in fileNames)
            {
                FileInfo fi = new FileInfo(fName);
                if (newFileName.Equals(fName))
                    return false;
            }
            return true;

        }

        private void DelateButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LICZBA ZDJĘ: "+ photos.Count);
            Console.Write(photos[imgListView.FocusedItem.Index].ID + " | " + photos[imgListView.FocusedItem.Index].Name);
            //Console.WriteLine(imageListMin.);
        }

        private void imgListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Console.WriteLine();
                ImageMenuStrip.Show(Cursor.Position);
            }
        }

        private void delateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Console.WriteLine(imgListView.SelectedItems.Count);
        }
    }
}
