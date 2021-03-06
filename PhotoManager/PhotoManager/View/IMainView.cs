﻿using System;
using System.Collections.Generic;
using PhotoManager.Model;

namespace PhotoManager
{
    public interface IMainViev
	{
        event Action<string, Photo> AddPhotoEvent;
		event Func<List<Album>> GetAlbums;
        event Action<Album> GetPhotosFromDB;
        event Action<string> SaveAlbum;
        event Action GetUserName;
        event Action GetCurrentAlbum;
        event Action<List<Photo>> DeletePhoto;
        event Action GetDescriptionForAlbum;
		IAddAlbumView IAddAlbumView { get; }
        List<Photo> PhotoList { set; }
        string UserName { set; }
        string AlbumName { set; }
        string AlbumDescription { set; }
        void AddNewAlbumToList(Album album);
        void AddNewPhotoToList(Photo newPhotos);
        void ShowMessage(bool success, string message);
    }
}
