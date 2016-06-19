using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MTG_Helper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Buscador : Page
    {
        string[] selectionItems;

        public Buscador()
        {
            GenerateCardsList();
            this.InitializeComponent();
            myListBox.ItemsSource = selectionItems;
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
                MostrarDatosDeLaCartaSeleccionada(args.ChosenSuggestion.ToString());
            }
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MostrarDatosDeLaCartaSeleccionada(myListBox.SelectedItem.ToString());
        }

        private void MostrarDatosDeLaCartaSeleccionada(string nombreDeLaCarta)
        {

            //casos especiales if rarity equal "Basic Land"
            //datos iguales, cambia imagen y multiverseid

            var card = RetornaUnaCarta(nombreDeLaCarta);

            JObject cardJO = JObject.Parse(card);

            myStackPanel.Children.Clear();

            Thickness textMargin = new Thickness(0, 0, 0, 10);
            if (cardJO["name"] != null)
            {
                TextBlock name = new TextBlock();
                name.Text = (string)cardJO["name"];
                name.Margin = textMargin;
                myStackPanel.Children.Add(name);
            }
            if (cardJO["manaCost"] != null)
            {
                TextBlock manaCost = new TextBlock();
                manaCost.Text = (string)cardJO["manaCost"];
                manaCost.Margin = textMargin;
                myStackPanel.Children.Add(manaCost);
            }
            if (cardJO["text"] != null)
            {
                TextBlock text = new TextBlock();
                text.Text = (string)cardJO["text"];
                text.Width = 310;
                text.TextWrapping = TextWrapping.Wrap;
                text.Margin = textMargin;
                myStackPanel.Children.Add(text);
            }
            if (cardJO["flavor"] != null)
            {
                TextBlock flavor = new TextBlock();
                flavor.Text = (string)cardJO["flavor"];
                flavor.Width = 310;
                flavor.TextWrapping = TextWrapping.Wrap;
                flavor.Margin = textMargin;
                myStackPanel.Children.Add(flavor);
            }
            
            
            //(string)cardJO["cmc"];
            //(string)cardJO["colors"];
            //(string)cardJO["flavor"];
            //(string)cardJO["manaCost"];
            //(string)cardJO["multiverseid"];
            //(string)cardJO["name"];
            //(string)cardJO["number"];
            //(string)cardJO["rariry"];
            //(string)cardJO["power"];
            //(string)cardJO["text"];
            //(string)cardJO["thoughness"];
            //(string)cardJO["type"];

            myListBox.Visibility = Visibility.Collapsed;
            myStackPanel.Visibility = Visibility.Visible;
        }

        public string RetornaUnaCarta(string nombreDeLaCarta)
        {
            string actualSet = "SOI.txt"; 
            JObject jsonSet = JObject.Parse(File.ReadAllText(@actualSet)); //this method not work if the file not has json extencion
            JToken tokenCard;
            
            int multiverseid = FixCartasConMismoNombre(nombreDeLaCarta);
            if (multiverseid!=0)
            {
                tokenCard = jsonSet.SelectToken("$.cards[?(@.multiverseid ==" + multiverseid.ToString() + ")]");
            }
            else
            tokenCard = jsonSet.SelectToken("$.cards[?(@.name == '"+nombreDeLaCarta+"')]");
            
            return tokenCard.ToString();
        }

        private void GenerateCardsList()
        {
            selectionItems = System.IO.File.ReadAllLines(@"SOI_CardsName.txt");
        }

        private int FixCartasConMismoNombre(string nombreDeLaCarta)
        {
            int multiverseid;

            switch (nombreDeLaCarta)
            {
                case "Forest3":
                    multiverseid = 410066;
                    break;
                case "Forest2":
                    multiverseid = 410065;
                    break;
                case "Forest1":
                    multiverseid = 410064;
                    break;
                case "Mountain3":
                    multiverseid = 410063;
                    break;
                case "Mountain2":
                    multiverseid = 410062;
                    break;
                case "Mountain1":
                    multiverseid = 410061;
                    break;
                case "Swamp1":
                    multiverseid = 410060;
                    break;
                case "Swamp2":
                    multiverseid = 410059;
                    break;
                case "Swamp3":
                    multiverseid = 410058;
                    break;
                case "Island1":
                    multiverseid = 410057;
                    break;
                case "Island2":
                    multiverseid = 410056;
                    break;
                case "Island3":
                    multiverseid = 410055;
                    break;
                default:
                    multiverseid = 0;
                    break;
            }
            return multiverseid;
        }
    }
}
