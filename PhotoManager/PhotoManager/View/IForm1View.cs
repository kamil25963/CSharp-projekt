﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoManager.Model;

namespace PhotoManager
{
	public interface IForm1View
	{
        event Action<string, Photo> AddPhotoEvent;
		event Func<List<Album>> GetAlbums;
        //event Action<Album> RefreshAlbumList;
		IAddAlbumView IAddAlbumView { get; }
        void AddNewAlbumToList(Album album);
	}
}
