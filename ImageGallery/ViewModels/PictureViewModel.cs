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

        public String Width { get; set; }
        public String Height { get; set; }
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

        /// <summary>
        /// Set the values of <see cref="Width"/> <see cref="Height"/> of the picture.
        /// </summary>
        /// <param name="imageSize"></param>
        internal void SetImageSize(String filename)
        {
            Size imageSize;
            using (FileStream fileStream = new FileStream(System.IO.Path.GetFullPath(filename), FileMode.Open, FileAccess.Read))
            {
                BitmapFrame frame = BitmapFrame.Create(fileStream, BitmapCreateOptions.DelayCreation, BitmapCacheOption.None);
                imageSize = new Size(frame.PixelWidth, frame.PixelHeight);
            }
            this.Width = imageSize.Width.ToString();
            this.Height = imageSize.Height.ToString();
        }

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

        internal void Send()
        {
            Console.WriteLine(this.Model.Path);
        }

        internal Picture GetModel() => this.Model;
    }
}
