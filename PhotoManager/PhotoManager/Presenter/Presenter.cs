﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoManager.Model;
namespace PhotoManager
{
	class Presenter
	{
		IView view;
		Model.Model model;
		public Presenter(IView view, Model.Model model)
		{
			this.view = view;
			this.model = model;
			this.view.LoggingEvent += LoggingEvent;
            this.view.IVievRegister.CreateAccountEvent += CreateAccountEvent;
            this.view.IVievForm.AddPhotoEvent += AddPhotoEvent;
            this.view.IVievForm.IAddAlbumView.AddAlbumEvent += AddAlbumEvent;
			this.view.IVievForm.GetAlbums += GetAlbums;
            this.view.IVievForm.IAddAlbumView.RefreshAlbumListInForm1Event += RefreshAlbumListInForm1Event;
			this.view.IVievForm.GetPhotosFromDB += GetPhotosFromDB;
            this.view.IVievForm.SaveAlbum += SaveAlbumEvent;
            this.view.IVievForm.GetUserName += GetUserNameEvent;
            this.view.IVievForm.GetCurrentAlbum += GetAlbumName;
		}

		private List<Album> GetAlbums()
		{
           return model.GetAlbums();
		}

        private void LoggingEvent(User user)
        {
            view.ClearTextBoxes();
            try
            {
                if (model.checkPassword(user) == false)
                {
                    view.ShowMessage(false, "Incorrect login or password.");
                }
                else
                {
                    view.ClearTextBoxes();
                    view.hideLoggingWindow();
                    model.LoadForm1Instance();
                }

            }
            catch (Exception exc)
            {
                view.ShowMessage(false, exc.ToString());
            }
        }

        private void CreateAccountEvent(User user)
        {
            if (model.UserExists(user))
            {
                view.IVievRegister.ShowMessage(false, "A user with the same login already exists.");
                return;
            }
            if(model.EmailExists(user))
            {
                view.IVievRegister.ShowMessage(false, "An account with the same e-mail address already exists.");
                return;
            }
            if (model.CreateAccount(user))
            {
                view.IVievRegister.ClearTextBoxes();
                view.IVievRegister.ShowMessage(true, "An account was created sucessfully.");
                
            }
            else
                view.IVievRegister.ShowMessage(false, "Account creation failed. Try one more time.");
        }

        private void AddPhotoEvent(string imgPath, Photo photo)
        {
            view.IVievForm.AddNewPhotoToList(model.AddPhoto(imgPath, photo));
                //view.IVievForm.ShowMessage(false, "Error during adding a photo: " + photo.Name + ".");
        }

        private void AddAlbumEvent(Album album)
        {
            if (model.AddAlbum(album))
            {
                view.IVievForm.IAddAlbumView.ClearTextBoxes();
                view.IVievForm.IAddAlbumView.ShowMessage(true, "Album created successfully.");
            }
                
            else
                view.IVievForm.IAddAlbumView.ShowMessage(false, "Error during creating an album.");
        }

        private void RefreshAlbumListInForm1Event()
        {
            this.view.IVievForm.AddNewAlbumToList(model.NewAlbumListElement());
        }

		private void GetPhotosFromDB(Album album)
		{
			view.IVievForm.PhotoList = model.LoadPhotosToAlbum(album);
		}

        private void SaveAlbumEvent(string destinationPath)
        {
            if (model.SaveAlbum(destinationPath))
                view.IVievForm.ShowMessage(true, "All photos saved at: " + destinationPath + "!");
        }

        private void GetUserNameEvent()
        {
            view.IVievForm.UserName = model.GetUserName() + ".";
        }

        private void GetAlbumName()
        {
            view.IVievForm.AlbumName = "You are currently in the album named: " +  model.GetAlbumName() + ".";
        }

    }
}
