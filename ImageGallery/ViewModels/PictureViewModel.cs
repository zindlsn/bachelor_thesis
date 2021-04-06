using ImageGallery.Models;
using ImageGallery.MVVM;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
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


        public BitmapImage OriginalImage { get; set; }
        public BitmapImage Thumbnail { get; set; }
        public bool IsThumbnailRequested { get; set; }

        public BitmapImage GalleryImage
        {
            get
            {
                return IsThumbnailRequested ? Thumbnail : OriginalImage;
            }
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

        internal Picture GetModel() => this.Model;

        /// <summary>
        /// Loads the image.
        /// </summary>
        /// <param name="filename"></param>
        internal async Task LoadImageAsync()
        {
            await Task.Run(() =>
            {
                using (FileStream fileStream = new FileStream(this.Path, FileMode.Open, FileAccess.Read))
                {
                    var loadedImage = new BitmapImage();
                    loadedImage.BeginInit();
                    loadedImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    loadedImage.CacheOption = BitmapCacheOption.OnLoad;
                    loadedImage.StreamSource = fileStream;
                    loadedImage.EndInit();
                    loadedImage.Freeze();

                    OriginalImage = loadedImage;
                }
            });
        }

        /// <summary>
        /// Copied from: https://www.codeproject.com/tips/626124/create-a-thumbnail-of-a-large-size-image-in-csharp
        /// </summary>
        /// <param name="lcFilename"></param>
        /// <param name="lnWidth"></param>
        /// <param name="lnHeight"></param>
        /// <returns></returns>
        internal async Task LoadThumbnailAsync()
        {
            this.Thumbnail = await Task.Run(() =>
            {
                try
                {
                    Image loadImage;
                    int width;
                    using (FileStream fileStream = new FileStream(this.Path, FileMode.Open, FileAccess.Read))
                    {
                        byte[] image = new byte[fileStream.Length];
                        fileStream.Read(image, 0, image.Length);
                        int desiredHeight = 100;

                        loadImage = Image.FromStream(new MemoryStream(image));

                        // portrait
                        double ratio = (double)loadImage.Width / (double)loadImage.Height;

                        // landscape
                        if (ratio > 1)
                        {
                            ratio = (1 / ratio) + 1;
                        }

                        width = (int)(desiredHeight * ratio);

                        var bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = new MemoryStream(image);
                        bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                        bitmapImage.DecodePixelHeight = desiredHeight;
                        bitmapImage.DecodePixelWidth = width;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();
                        return bitmapImage;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }

        static Size GetThumbnailSize(Image original)
        {
            // Maximum size of any dimension.
            const int maxPixels = 40;

            // Width and height.
            int originalWidth = original.Width;
            int originalHeight = original.Height;

            // Compute best factor to scale entire image based on larger dimension.
            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)maxPixels / originalWidth;
            }
            else
            {
                factor = (double)maxPixels / originalHeight;
            }

            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }
    }
}
