using ImageGallery.Models;
using ImageGallery.MVVM;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace ImageGallery.ViewModels
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
        /// Loads the image.
        /// </summary>
        /// <param name="filename"></param>
        internal void LoadImage(string filename)
        {
            using (FileStream fileStream = new FileStream(System.IO.Path.GetFullPath(filename), FileMode.Open, FileAccess.Read))
            {
                var loadedImage = new BitmapImage();
                loadedImage.BeginInit();
                loadedImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                loadedImage.CacheOption = BitmapCacheOption.OnLoad;
                loadedImage.StreamSource = fileStream;
                loadedImage.EndInit();
                loadedImage.Freeze();

                Image = loadedImage;
            }
        }
    }
}
