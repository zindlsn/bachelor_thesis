using ImageGallery.Models;
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
        public ObservableCollection<PictureViewModel> Pictures { get; } = new ObservableCollection<PictureViewModel>();

        private bool _IsLoading;

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



        private ICommand _ClosePictureCommand;

        public ICommand ClosePictureCommand => _ClosePictureCommand ??= new RelayCommandd(p => ClosePicture(), p => CanClosePicture());

        public void ClosePicture()
        {
            this.DisplayPicture = null;
        }

        public bool CanClosePicture() => !this.IsLoading && this.DisplayPicture != null;
        private bool CanLoadPictures() => !this.IsLoading;

        /// <summary>
        /// Shows if the picture can be shown.
        /// </summary>
        /// <returns></returns>
        public bool CanDisplayPicture() => !IsLoading && this.DisplayPicture == null;

        private ICommand _OpenFileDialogCommand;
        /// <summary>
        /// Command for opening the file dialog for choosing pictures.
        /// </summary>
        public ICommand OpenFileDialogCommand => _OpenFileDialogCommand ??= new AsyncCommand(async p => await OpenFileDialogAsync(), CanLoadPictures);

        /// <summary>
        /// Opens the file dialog, to select the images 
        /// which will be shown.
        /// </summary>
        private async Task OpenFileDialogAsync()
        {
            this.IsLoading = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg;*.JPG|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                this.Pictures.Clear();
                try
                {
                    foreach (string filename in openFileDialog.FileNames)
                    {
                        this.Pictures.Add(await LoadPictureAsync(filename));
                    }
                }
                catch (Exception)
                {

                }
                finally
                {

                    this.IsLoading = false;
                }
            }
        }

        private static async Task<PictureViewModel> LoadPictureAsync(string filename)
        {
            return await Task.Run(() =>
             {
                 PictureViewModel newPicture = PictureViewModel.CreateNew();
                 newPicture.Title = Path.GetFileName(filename);
                 newPicture.Path = Path.GetFullPath(filename);
                 newPicture.LoadImage(filename);
                 newPicture.CreationDate = File.GetCreationTimeUtc(Path.GetFullPath(filename));
                 return newPicture;
             });
        }
    }
}
