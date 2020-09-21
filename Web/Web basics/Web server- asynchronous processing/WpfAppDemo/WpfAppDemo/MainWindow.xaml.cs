using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
           ShowImageAsync(Image1, "https://http.cat/200");
           ShowImageAsync(Image2, "https://http.cat/400");
           ShowImageAsync(Image3, "https://http.cat/404");
           ShowImageAsync(Image4, "https://http.cat/300");
           ShowImageAsync(Image5, "https://http.cat/500");
           ShowImageAsync(Image6, "https://http.cat/600");
        }

        private async Task ShowImageAsync(Image image, string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url); //.GetAwaiter().GetResult(); //without await 
            byte[] imageBytes = await response
                .Content
                .ReadAsByteArrayAsync(); //does not include header
                                         //.GetAwaiter().GetResult(); without await

            //image.Source = LoadImage(imageBytes);
            //or
            image.Source = await Task.Run(() => LoadImage(imageBytes)); //if we need it faster
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
