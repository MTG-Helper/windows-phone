using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace MTG_Helper.Model
{
    class TokenGenerator
    {

        private PlayerScoreboard view;
        private Canvas canvas;
        TextBlock resultText;
        TextBlock resultTextTwo;
        TextBlock resultValue;

        public TokenGenerator(PlayerScoreboard view)
        {
            this.view = view;
            this.canvas = new Canvas()
            {
                Width = 90,
                Height = 300,
                Margin = new Thickness(0, 0, 160, 0)
            };

            Rectangle color = new Rectangle();
            color.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
            color.StrokeThickness = 3;
            color.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            color.Opacity = 0.1;
            color.Width = 250;
            color.Height = 308;
            this.canvas.Children.Add(color);

            Button BackButton = new Button();
            BackButton.Content = "Back";
            BackButton.Click += new RoutedEventHandler(BackButton_Click);

            this.resultText = new TextBlock();
            this.resultText.FontSize = 25;
            this.resultText.FontStyle = Windows.UI.Text.FontStyle.Oblique;
            this.resultText.HorizontalAlignment = HorizontalAlignment.Center;

            this.resultTextTwo = new TextBlock();
            this.resultTextTwo.FontSize = 25;
            this.resultTextTwo.FontStyle = Windows.UI.Text.FontStyle.Oblique;
            this.resultTextTwo.HorizontalAlignment = HorizontalAlignment.Center;

            Canvas.SetTop(BackButton, 200);
            Canvas.SetLeft(BackButton, 98);
            Canvas.SetTop(resultText, 25);
            Canvas.SetLeft(resultText, 46);
            Canvas.SetTop(resultTextTwo, 46);
            Canvas.SetLeft(resultTextTwo, 46);


            this.canvas.Children.Add(BackButton);
            this.canvas.Children.Add(resultText);
            this.canvas.Children.Add(resultTextTwo);
        }

        public Canvas rollDice()
        {
            this.resultText.Text = "The result of";
            this.resultTextTwo.Text = "coin toss was :";

            Image actualDice = getRamdomDice().getRepresentation();
            Canvas.SetTop(actualDice, 95);
            Canvas.SetLeft(actualDice, 78);
            this.canvas.Children.Add(actualDice);
            return this.canvas;

        }

        public Canvas flipCoin()
        {
            this.resultText.Text = "The result of";
            this.resultTextTwo.Text = "dice roll was :";

            Image actualCoin = getRamdomCoin().getRepresentation();
            Canvas.SetTop(actualCoin, 95);
            Canvas.SetLeft(actualCoin, 78);
            this.canvas.Children.Add(actualCoin);
            return this.canvas;

        }

        private Dice getRamdomDice()
        {
            List<Dice> dices = new List<Dice>();
            dices.Add(new Dice(90, 90, 1));
            dices.Add(new Dice(90, 90, 2));
            dices.Add(new Dice(90, 90, 3));
            dices.Add(new Dice(90, 90, 4));
            dices.Add(new Dice(90, 90, 5));
            dices.Add(new Dice(90, 90, 6));
            return dices.ElementAt(new Random().Next(0, dices.Count()));
        }

        private Coin getRamdomCoin()
        {
            List<Coin> coins = new List<Coin>();
            coins.Add(new Coin(90, 90, 1));
            coins.Add(new Coin(90, 90, 2));
            return coins.ElementAt(new Random().Next(0, coins.Count()));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //view.BackButton_Click(sender, e);
        }

    }
}
