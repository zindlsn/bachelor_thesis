using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImageGallery.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Source from <see cref="https://stackoverflow.com/questions/36149863/how-to-write-a-viewmodelbase-in-mvvm"/>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
