using ImageGallery.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.ViewModels
{
    public class LicenseViewModel : ViewModelBase<Models.License>
    {
        public LicenseViewModel(Models.License model) : base(model)
        {

        }
        public string Title
        {
            get
            {
                return this.Model.Title;
            }
            set
            {
                this.Model.Title = value;
            }
        }
        public string Text
        {
            get
            {
                return this.Model.Text;
            }
            set
            {
                this.Model.Text = value;
            }
        }
        public Uri Website
        {
            get
            {
                return this.Model.Website;
            }
            set
            {
                this.Model.Website = value;
            }
        }
        public DateTime LastUpdated
        {
            get
            {
                return this.Model.LastUpdated;
            }
            set
            {
                this.Model.LastUpdated = value;
            }
        }

        public string Version
        {
            get
            {
                return this.Model.Version;
            }
            set
            {
                this.Model.Version = value;
            }
        }

        public static LicenseViewModel Create()
        {
            return new LicenseViewModel(new Models.License());
        }
    }
}
