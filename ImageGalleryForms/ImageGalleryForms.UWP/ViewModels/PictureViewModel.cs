using ImageGallery.MVVM;
using ImageGalleryShared.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Media.Imaging;

namespace ImageGalleryForms.UWP.ViewModels
{
    /// <summary>
    /// Represents a viewmodel of the model <see cref="Picture"/>.
    /// </summary>
    public class PictureViewModel : ViewModelBase<Picture>
    {
        public PictureViewModel(Picture Model) : base(Model)
        {
        }

        public string Path
        {
            get
            {
                return this.Model.Path;
            }
            set
            {
                if (this.Model.Path != value)
                {
                    this.Model.Path = value;
                }
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return this.Model.CreationDate;
            }
            set
            {
                if (this.Model.CreationDate != value)
                {
                    this.Model.CreationDate = value;
                }
            }
        }

        public string Title
        {
            get
            {
                return this.Model.Title;
            }
            set
            {
                if (this.Model.Title != value)
                {
                    this.Model.Title = value;
                }
            }
        }

        public long Size
        {
            get
            {
                return this.Model.Size;
            }
            set
            {
                if (this.Model.Size != value)
                {
                    this.Model.Size = value;
                }
            }
        }


        public BitmapImage Image { get; set; }
        public StorageItemThumbnail Thumbnail { get; set; }

        /// <summary>
        /// Creates a new ViewModel.
        /// </summary>
        /// <returns></returns>
        internal static PictureViewModel CreateNew()
        {
            PictureViewModel newViewModel = new PictureViewModel(new Picture());
            return newViewModel;
        }

        /// <summary>
        /// Sets the filesize of the file.
        /// </summary>
        /// <param name="filename"></param>
        internal void SetFileSize(string filename)
        {
            FileInfo imageInfo = new FileInfo(System.IO.Path.GetFullPath(filename));
            long sizeInBytes = imageInfo.Length;
            this.Size = sizeInBytes;
        }

        internal Picture GetModel() => this.Model;

        /// <summary>
        /// Loads the thumbnail.
        /// </summary>
        /// <param name="filename"></param>
        internal async Task LoadThumbnailAsync(string filename)
        {
            var _file = await StorageFile.GetFileFromPathAsync(System.IO.Path.GetFullPath(filename));
            this.Thumbnail = await _file.GetThumbnailAsync(ThumbnailMode.ListView);
        }

        /// <summary>
        /// Loads the image.
        /// </summary>
        /// <param name="filename"></param>
        internal async Task LoadImageAsync(string filename)
        {
            await Task.Run(() =>
            {
                this.Image = new BitmapImage(new Uri(System.IO.Path.GetFullPath(filename)));
            });
        }
    }
}
