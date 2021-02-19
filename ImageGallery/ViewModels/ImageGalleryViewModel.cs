﻿using ImageGallery.Models;
using ImageGallery.MVVM;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ImageGallery.ViewModels
{
    /// <summary>
    /// Describes a viewmodel for the image gallery.
    /// </summary>
    public class ImageGalleryViewModel : ViewModelBase
    {
        /// <summary>
        /// Saves the loaded <see cref="PictureViewModel"/>s.
        /// </summary>
        public ObservableCollection<PictureViewModel> Pictures { get; set; } = new ObservableCollection<PictureViewModel>();

        private bool _IsLoading = false;

        /// <summary>
        /// Shows, if it is loading the pictures.
        /// </summary>
        public bool IsLoading
        {
            set
            {
                _IsLoading = value;
                if (_IsLoading)
                {
                    this.Status = "Is Loading";
                }
                else
                {
                    this.Status = "Done";
                }
                OnPropertyChanged();
            }
            get { return _IsLoading; }
        }


        private PictureViewModel _DisplayPicture;
        /// <summary>
        /// Sets the current Status message.
        /// </summary>
        public PictureViewModel DisplayPicture
        {
            set
            {
                _DisplayPicture = value;
                OnPropertyChanged();
            }
            get { return _DisplayPicture; }
        }

        private String _Status;
        /// <summary>
        /// Sets the current Status message.
        /// </summary>
        public String Status
        {
            set
            {
                _Status = value;
                OnPropertyChanged();
            }
            get { return _Status; }
        }

        private ICommand _OpenFileDialogCommand;
        /// <summary>
        /// Command for opening the file dialog for choosing pictures.
        /// </summary>
        public ICommand OpenFileDialogCommand => _OpenFileDialogCommand ??= new AsyncCommand(async p => await OpenFileDialogAsync().ConfigureAwait(false), CanLoadPictures);

        private Boolean CanLoadPictures() => true;

        /// <summary>
        /// Opens the file dialog, to select the images 
        /// which will be shown.
        /// </summary>
        private async Task OpenFileDialogAsync()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg;*.JPG|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                this.IsLoading = true;

                this.Pictures = new ObservableCollection<PictureViewModel>(await LoadPicturesAsync(openFileDialog));
                this.IsLoading = false;
            }
        }

        private async Task<List<PictureViewModel>> LoadPicturesAsync(OpenFileDialog openFileDialog) =>
            await Task.Run(() =>
            {
                List<PictureViewModel> pictures = new List<PictureViewModel>();
                foreach (string filename in new List<string>(openFileDialog.FileNames))
                {
                    PictureViewModel newPicture = PictureViewModel.CreateNew();
                    newPicture.Title = Path.GetFileName(filename);
                    newPicture.Path = Path.GetFullPath(filename);
                    newPicture.SetImageSize(filename);
                    newPicture.SetFileSize(filename);
                    newPicture.CreationDate = File.GetCreationTimeUtc(Path.GetFullPath(filename));
                    Pictures.Add(newPicture);
                }
                return pictures;
            });
    }
}
