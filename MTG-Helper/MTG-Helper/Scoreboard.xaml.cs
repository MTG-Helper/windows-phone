using MTG_Helper.Model;
using System;
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
using MTG_Helper.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MTG_Helper
{
    public sealed partial class Scoreboard : Page
    {

        private PlayerScoreboardAppModel boardAppModel;
        private StackPanel PlayerScoreboardPanel;

        public Scoreboard()
        {
            this.initializeComponents();
        }

        /// <summary>
        /// Initialize the components for this class.
        /// </summary>
        private void initializeComponents()
        {
            this.InitializeComponent();
            this.boardAppModel = new PlayerScoreboardAppModel(this);
            this.PlayerScoreboardPanel = new StackPanel();
            this.scrollViewer.Content = this.PlayerScoreboardPanel;

        }

        /// <summary>
        /// Add one player scoreboard on screen.
        /// </summary>
        private void AddPlayerScoreboardButton_Click(object sender, RoutedEventArgs e)
        {
            this.PlayerScoreboardPanel.Children.Add(this.boardAppModel.addAPlayerScoreboard());
        }

        /// <summary>
        /// Remove the last player scoreboard on screen.
        /// </summary>
        private void removePlayerScoreboardButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.PlayerScoreboardPanel.Children.Count > 0)
            {
                this.PlayerScoreboardPanel.Children.Remove((Canvas)this.PlayerScoreboardPanel.Children.Last());
            }
        }

        /// <summary>
        /// Remove the selected player scoreboard on screen.
        /// </summary>
        public void removeSpecificPlayerScoreBoard(Canvas canvas)
        {
            this.PlayerScoreboardPanel.Children.Remove(canvas);
        }

        /// <summary>
        /// Reset all player scoreboard on screen.
        /// </summary>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (object child in PlayerScoreboardPanel.Children)
            {
                ((PlayerScoreboard)((Canvas)child).DataContext).reset();
            }
        }

        /// <summary>
        /// Comeback to the player scoreboard view.
        /// </summary>
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.scrollViewer.Content = this.PlayerScoreboardPanel;
        }

        /// <summary>
        /// Flip a coin.
        /// </summary>
        private void CoinButton_Click(object sender, RoutedEventArgs e)
        {
            //this.scrollViewer.Content = (new TokenGenerator(this)).flipCoin();

        }

        /// <summary>
        /// Roll a dice.
        /// </summary>
        private void RollDiceButton_Click(object sender, RoutedEventArgs e)
        {
            //this.scrollViewer.Content = (new TokenGenerator(this)).rollDice();
        }
    }
}
