using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MTG_Helper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BuscadorImagen : Page
    {
        private string suggestionChosed;
        private string[] selectionItems;

        public BuscadorImagen()
        {
            GenerateCardsList();
            this.InitializeComponent();
            myPanel.Visibility = Visibility.Collapsed;
            ProgressRing pr = new ProgressRing();
            pr.IsActive = true;
            pr.Height = 200;
            pr.Width = 200;
            pr.Margin = new Thickness(0,20,0,0);
            myPanel.Children.Add(pr);
        }

        private void MyAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var autoSuggestBox = (AutoSuggestBox)sender;
            var filtered = selectionItems.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
            autoSuggestBox.ItemsSource = filtered;
        }
        
        private void MyAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null) // bugFix
            {
                suggestionChosed = args.ChosenSuggestion.ToString();
                
                myPanel.Visibility = Visibility.Visible;
               
                //MyTextBlock.Text = "Carta Elegida: " + suggestionChosed;
                LoadImage();
            }

        }

        private void GenerateCardsList()
        {
            selectionItems = System.IO.File.ReadAllLines(@"Cards.txt");
        }

        

        private void LoadImage()
        {
            var url = CreateUrlWithCardNameAndId(suggestionChosed);
            Uri uri = new Uri(url, UriKind.Absolute);
            //IRandomAccessStream a = await RandomAccessStreamReference.CreateFromUri(uri).OpenReadAsync();
            //BitmapImage i = new BitmapImage();
            //await i.SetSourceAsync(a);
            //MyImage.Source = i;
            MyImage.Source = new BitmapImage(uri);
        }
        
        static string CreateUrlWithId(string multiverseId)
        {
            string urlStart = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=";
            string urlEnd = "&type=card";
            return urlStart + multiverseId + urlEnd;
        }

        static string CreateUrlWithCardNameAndId(string cardNameWithId)
        {
            var id = GetId(cardNameWithId);
            var url = CreateUrlWithId(id);
            return url;
        }

        static string GetId(string cardNamePlusId)
        {
            string id = null;
            var pos = 0;

            foreach (var item in cardNamePlusId)
            {
                pos++;
                if (item == ':') { id = cardNamePlusId.Substring(pos); }
            }
            return id;
        }
        
        private void MyImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            myPanel.Visibility = Visibility.Collapsed;
        }
    }
}
