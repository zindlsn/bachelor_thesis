using ImageGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageGallery.Pages
{
    /// <summary>
    /// Interaction logic for ImageGalleryPage.xaml
    /// </summary>
    public partial class ImageGalleryPage : Page
    {
        ImageGalleryViewModel Model;
        public ImageGalleryPage()
        {
            InitializeComponent();

            Model = new ImageGalleryViewModel();
            this.DataContext = Model;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PictureViewModel viewModel = this.PictureList.SelectedItem as PictureViewModel;
            this.Model.DisplayPicture = viewModel;
        }
    }
}
