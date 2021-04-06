using System;

namespace ImageGallery.Models
{
    public class License
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Uri Website { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Version { get; set; }
    }
}
