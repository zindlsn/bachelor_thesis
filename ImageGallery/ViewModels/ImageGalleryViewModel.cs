using ImageGallery.MVVM;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private bool _IsThumbnailRequested = false;

        /// <summary>
        /// Shows, if it is loading the pictures.
        /// </summary>
        public bool IsThumbnailRequested
        {
            set
            {
                _IsThumbnailRequested = value;
                OnPropertyChanged();
            }
            get { return _IsThumbnailRequested; }
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
            this.Pictures.Clear();
            try
            {
                var dialog = new FolderBrowserDialog()
                {
                    Description = "Time to select a folder",
                    UseDescriptionForTitle = true,
                    SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                        + Path.DirectorySeparatorChar,
                    ShowNewFolderButton = true
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = Directory.GetFiles(dialog.SelectedPath);
                    foreach (string path in files)
                    {
                        try
                        {
                            this.Pictures.Add(await LoadPictureAsync(path));
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Image could not be loaded. {ex.Message}");
                            break;
                        }
                    }
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

        private async Task<PictureViewModel> LoadPictureAsync(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be empty");
            }
            PictureViewModel newPicture = PictureViewModel.CreateNew();
            newPicture.Path = path;
            newPicture.IsThumbnailRequested = this.IsThumbnailRequested;

            try
            {
                newPicture.Title = Path.GetFileName(path);
                if (this.IsThumbnailRequested)
                {
                    await newPicture.LoadThumbnailAsync();
                }
                else
                {
                    await newPicture.LoadImageAsync();
                }
            }
            catch (ArgumentException)
            {
                throw;
            }

            return newPicture;
        }
    }
}
