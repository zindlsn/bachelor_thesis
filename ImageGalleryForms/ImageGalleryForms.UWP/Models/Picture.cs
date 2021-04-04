using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.Models
{
    /// <summary>
    /// Stefan Zindl
    /// Represents a model of an image.
    /// </summary>
    public class GalleryImage
    {
        public long Size { get; set; }
        public String Title { get; set; }
        public String Path { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
