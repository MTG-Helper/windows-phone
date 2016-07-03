using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace MTG_Helper.Model
{
    public class PlayerScoreboardPostix
    {
        private Canvas myCanvas;
        private PlayerScoreboard owner;
        private PlayerScoreboardAppModel appModel;
        private TextBlock playerLifePointsNumberTextBlock;
        private TextBlock playerPoisonPointNumberTextBlock;
        private Rectangle color;
        private TextBox playerNameTextBox;

        public PlayerScoreboardPostix(PlayerScoreboardAppModel appModel)
        {
            this.appModel = appModel;
            this.owner = this.appModel.createNewScoreBoard();
            this.initializeCanvas();

        }

        private void initializeCanvas()
        {
            this.myCanvas = new Canvas();
            this.myCanvas.Width = 250;
            this.myCanvas.Height = 150;
            this.myCanvas.Margin = new Thickness(0, 0, 0, 20);
            this.myCanvas.DataContext = this.owner;

            this.color = new Rectangle();
            this.color.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
            this.color.StrokeThickness = 3;
            this.color.Fill = this.getRamdomColor();
            this.color.Width = 250;
            this.color.Height = 150;
            this.myCanvas.Children.Add(color);

            this.playerNameTextBox = new TextBox();
            this.playerNameTextBox.FontSize = 20;
            this.playerNameTextBox.MaxLength = 18;
            this.playerNameTextBox.BorderThickness = new Thickness(0, 0, 0, 0);
            this.playerNameTextBox.Background = new SolidColorBrush(Windows.UI.Colors.Transparent);
            this.playerNameTextBox.HorizontalAlignment = HorizontalAlignment.Center;
            this.playerNameTextBox.Margin = new Thickness(5, 0, 0, 0);
            this.playerNameTextBox.TextChanged += new TextChangedEventHandler(ChangePositionOnRename);
            this.owner.changeName(this.getRamdomName());
            Binding bindingName = new Binding();
            bindingName.Path = new PropertyPath("playerName");
            bindingName.Source = this.owner;
            BindingOperations.SetBinding(this.playerNameTextBox, TextBox.TextProperty, bindingName);

            TextBlock playerLifePointsTextBlock = new TextBlock();
            playerLifePointsTextBlock.FontSize = 16;
            playerLifePointsTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            playerLifePointsTextBlock.Margin = new Thickness(15, 0, 0, 0);
            playerLifePointsTextBlock.Text = "LIFE POINTS: ";

            TextBlock playerPoisonPointsTextBlock = new TextBlock();
            playerPoisonPointsTextBlock.FontSize = 16;
            playerPoisonPointsTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            playerPoisonPointsTextBlock.Margin = new Thickness(15, 0, 0, 0);
            playerPoisonPointsTextBlock.Text = "POISON COUNTERS: ";

            this.playerLifePointsNumberTextBlock = new TextBlock();
            this.playerLifePointsNumberTextBlock.FontSize = 20;
            this.playerLifePointsNumberTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            this.playerLifePointsNumberTextBlock.Margin = new Thickness(15, 0, 0, 0);
            Binding bindingLifePoints = new Binding();
            bindingLifePoints.Path = new PropertyPath("lifePoints");
            bindingLifePoints.Source = this.owner;
            BindingOperations.SetBinding(this.playerLifePointsNumberTextBlock, TextBlock.TextProperty, bindingLifePoints);

            this.playerPoisonPointNumberTextBlock = new TextBlock();
            this.playerPoisonPointNumberTextBlock.FontSize = 20;
            this.playerPoisonPointNumberTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            this.playerPoisonPointNumberTextBlock.Margin = new Thickness(15, 0, 0, 0);
            Binding bindingPoisonPoints = new Binding();
            bindingPoisonPoints.Path = new PropertyPath("poisonPoints");
            bindingPoisonPoints.Source = this.owner;
            BindingOperations.SetBinding(this.playerPoisonPointNumberTextBlock, TextBlock.TextProperty, bindingPoisonPoints);

            TextBlock lpTextBlock = new TextBlock();
            lpTextBlock.FontSize = 20;
            lpTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            lpTextBlock.Margin = new Thickness(15, 0, 0, 0);
            lpTextBlock.Text = "LP: ";

            TextBlock ppTextBlock = new TextBlock();
            ppTextBlock.FontSize = 20;
            ppTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            ppTextBlock.Margin = new Thickness(15, 0, 0, 0);
            ppTextBlock.Text = "PC: ";

            Button plusOneLpButton = new Button();
            plusOneLpButton.Name = "+1";
            plusOneLpButton.Content = "+1";
            plusOneLpButton.Margin = new Thickness(15, 0, 0, 0);
            plusOneLpButton.Click += new RoutedEventHandler(addOneLifePointsButtonCLick);

            Button subOneLpButton = new Button();
            subOneLpButton.Name = "-1";
            subOneLpButton.Content = "-1";
            subOneLpButton.Margin = new Thickness(15, 0, 0, 0);
            subOneLpButton.Click += new RoutedEventHandler(subOneLifePointsButtonCLick);

            Button plusFiveLpButton = new Button();
            plusFiveLpButton.Name = "+5";
            plusFiveLpButton.Content = "+5";
            plusFiveLpButton.Margin = new Thickness(15, 0, 0, 0);
            plusFiveLpButton.Click += new RoutedEventHandler(addFiveLifePointsButtonCLick);

            Button subFiveLpButton = new Button();
            subFiveLpButton.Name = "-5";
            subFiveLpButton.Content = "-5";
            subFiveLpButton.Margin = new Thickness(15, 0, 0, 0);
            subFiveLpButton.Click += new RoutedEventHandler(subFiveLifePointsButtonCLick);

            Button plusOnePpButton = new Button();
            plusOnePpButton.Name = "+1";
            plusOnePpButton.Content = "+1";
            plusOnePpButton.Margin = new Thickness(15, 0, 0, 0);
            plusOnePpButton.Click += new RoutedEventHandler(addOnePoisonPointsButtonCLick);

            Button subOnePpButton = new Button();
            subOnePpButton.Name = "-1";
            subOnePpButton.Content = "-1";
            subOnePpButton.Margin = new Thickness(15, 0, 0, 0);
            subOnePpButton.Click += new RoutedEventHandler(subOnePoisonPointsButtonCLick);

            Button plusFivePpButton = new Button();
            plusFivePpButton.Name = "+5";
            plusFivePpButton.Content = "+5";
            plusFivePpButton.Margin = new Thickness(15, 0, 0, 0);
            plusFivePpButton.Click += new RoutedEventHandler(addFivePoisonPointsButtonCLick);

            Button subFivePpButton = new Button();
            subFivePpButton.Name = "-5";
            subFivePpButton.Content = "-5";
            subFivePpButton.Margin = new Thickness(15, 0, 0, 0);
            subFivePpButton.Click += new RoutedEventHandler(subFivePoisonPointsButtonCLick);

            Button deleteButton = new Button();
            deleteButton.Name = "DeleteButton";
            deleteButton.Content = "X";
            deleteButton.Click += new RoutedEventHandler(deleteButtonCLick);

            Button changeColorButton = new Button();
            changeColorButton.Name = "ChangeColorButton";
            changeColorButton.Content = "C";
            changeColorButton.Click += new RoutedEventHandler(changeColorButtonCLick);

            Canvas.SetTop(playerNameTextBox, 0);
            Canvas.SetLeft(playerNameTextBox, 105 + (this.playerNameTextBox.Text.Count() * (-4.4)));
            this.myCanvas.Children.Add(playerNameTextBox);

            Canvas.SetTop(playerLifePointsTextBlock, 30);
            Canvas.SetLeft(playerLifePointsTextBlock, 0);
            this.myCanvas.Children.Add(playerLifePointsTextBlock);

            Canvas.SetTop(playerLifePointsNumberTextBlock, 26);
            Canvas.SetLeft(playerLifePointsNumberTextBlock, 90);
            this.myCanvas.Children.Add(playerLifePointsNumberTextBlock);

            Canvas.SetTop(playerPoisonPointNumberTextBlock, 46);
            Canvas.SetLeft(playerPoisonPointNumberTextBlock, 145);
            this.myCanvas.Children.Add(playerPoisonPointNumberTextBlock);

            Canvas.SetTop(playerPoisonPointsTextBlock, 50);
            Canvas.SetLeft(playerPoisonPointsTextBlock, 0);
            this.myCanvas.Children.Add(playerPoisonPointsTextBlock);

            Canvas.SetTop(lpTextBlock, 75);
            Canvas.SetLeft(lpTextBlock, 0);
            this.myCanvas.Children.Add(lpTextBlock);

            Canvas.SetTop(subFiveLpButton, 75);
            Canvas.SetLeft(subFiveLpButton, 30);
            this.myCanvas.Children.Add(subFiveLpButton);

            Canvas.SetTop(subOneLpButton, 75);
            Canvas.SetLeft(subOneLpButton, 71);
            this.myCanvas.Children.Add(subOneLpButton);

            Canvas.SetTop(plusOneLpButton, 75);
            Canvas.SetLeft(plusOneLpButton, 120);
            this.myCanvas.Children.Add(plusOneLpButton);

            Canvas.SetTop(plusFiveLpButton, 75);
            Canvas.SetLeft(plusFiveLpButton, 165);
            this.myCanvas.Children.Add(plusFiveLpButton);

            Canvas.SetTop(ppTextBlock, 112);
            Canvas.SetLeft(ppTextBlock, 0);
            this.myCanvas.Children.Add(ppTextBlock);

            Canvas.SetTop(subFivePpButton, 112);
            Canvas.SetLeft(subFivePpButton, 30);
            this.myCanvas.Children.Add(subFivePpButton);

            Canvas.SetTop(subOnePpButton, 112);
            Canvas.SetLeft(subOnePpButton, 71);
            this.myCanvas.Children.Add(subOnePpButton);

            Canvas.SetTop(plusOnePpButton, 112);
            Canvas.SetLeft(plusOnePpButton, 120);
            this.myCanvas.Children.Add(plusOnePpButton);

            Canvas.SetTop(plusFivePpButton, 112);
            Canvas.SetLeft(plusFivePpButton, 165);
            this.myCanvas.Children.Add(plusFivePpButton);

            Canvas.SetTop(deleteButton, 0);
            Canvas.SetLeft(deleteButton, 217);
            this.myCanvas.Children.Add(deleteButton);

            Canvas.SetTop(changeColorButton, 0);
            Canvas.SetLeft(changeColorButton, 4);
            this.myCanvas.Children.Add(changeColorButton);
        }

        private SolidColorBrush getRamdomColor()
        {
            List<SolidColorBrush> colors = new List<SolidColorBrush>();
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Beige));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Chocolate));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.DarkCyan));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.DarkSalmon));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Aquamarine));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Gray));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Honeydew));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.LemonChiffon));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.MistyRose));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.MediumSeaGreen));
            return colors.ElementAt(new Random().Next(0, colors.Count() - 1));
        }

        private String getRamdomName()
        {
            List<String> names = new List<String>();
            names.Add("Ajani Goldmane");
            names.Add("Ashiok");
            names.Add("Nicol Bolas");
            names.Add("Chandra Nalaar");
            names.Add("Dack Fayden");
            names.Add("Daretti");
            names.Add("Domri Rade");
            names.Add("Elspeth Tirel");
            names.Add("Garruk Wildspeaker");
            names.Add("Gideon Jura");
            names.Add("Jace Beleren");
            names.Add("Karn");
            names.Add("Kiora");
            names.Add("Koth");
            names.Add("Liliana Vess");
            names.Add("Nahiri");
            names.Add("Narset");
            names.Add("Nissa Revane");
            names.Add("Ob Nixilis");
            names.Add("Ral Zarek");
            names.Add("Sarkhan Vol");
            names.Add("Sorin Markov");
            names.Add("Teferi ");
            names.Add("Tezzeret");
            names.Add("Tibalt");
            names.Add("Tamiyo");
            names.Add("Ugin");
            names.Add("Venser");
            names.Add("Vraska");
            names.Add("Xenagos");
            return names.ElementAt(new Random().Next(0, names.Count() - 1));
        }

        public Canvas getShape()
        {
            return this.myCanvas;
        }

        public void ChangePositionOnRename(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(playerNameTextBox, 105 + (playerNameTextBox.Text.Count() * (-4.4)));
        }

        private void addOneLifePointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.addOneLifePoints();
        }

        private void addFiveLifePointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.addFiveLifePoints();
        }

        private void subOneLifePointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.subOneLifePoints();
        }

        private void subFiveLifePointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.subFiveLifePoints();
        }

        private void addOnePoisonPointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.addOnePoisonPoint();
        }

        private void addFivePoisonPointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.addFivePoisonPoints();
        }

        private void subOnePoisonPointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.subOnePoisonPoint();
        }

        private void subFivePoisonPointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.subFivePoisonPoints();
        }

        private void deleteButtonCLick(object sender, RoutedEventArgs e)
        {
            this.appModel.removeSpecificPlayerScoreBoard(this.myCanvas);
        }

        private void changeColorButtonCLick(object sender, RoutedEventArgs e)
        {
            this.color.Fill = this.getRamdomColor();
        }

    }
}
