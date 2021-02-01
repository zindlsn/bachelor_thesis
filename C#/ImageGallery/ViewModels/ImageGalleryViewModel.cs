using ImageGallery.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImageGallery.ViewModels
{
    public class ImageGalleryViewModel : ViewModelBase
    {

        private string _FristName = "Hello World VM";
        public string FirstName
        {
            set
            {
                _FristName = value;
                OnPropertyChanged();
            }
            get { return _FristName; }
        }

        private bool _Active = false;
        public bool Active
        {
            set
            {
                _Active = value;
                OnPropertyChanged();
            }
            get { return _Active; }
        }

        private ICommand myCommand2;
        public ICommand MyCommand2
        {
            get { return myCommand2 ?? (myCommand2 = new RelayCommand(p => doStuff2(),p=>canDoStuff())); }
        }
        private void doStuff2()
        {
            this.Active = !this.Active;
        }

        private bool canDoStuff() => true;
    }
}
