using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace MTG_Helper.Model
{
    class Dice
    {
        public int width { get; }
        public int height { get; }
        private int value;

        public Dice(int width, int height, int value)
        {
            this.width = width;
            this.height = height;
            this.value = value;
        }

        public Image getRepresentation()
        {

            switch (this.value)
            {
                case 1:
                    return new Image
                    {
                        Width = this.width,
                        Height = this.height,
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/diceOne.png", UriKind.Absolute))
                    };

                case 2:
                    return new Image
                    {
                        Width = this.width,
                        Height = this.height,
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/diceTwo.png", UriKind.Absolute))
                    };

                case 3:
                    return new Image
                    {
                        Width = this.width,
                        Height = this.height,
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/diceThree.png", UriKind.Absolute))
                    };

                case 4:
                    return new Image
                    {
                        Width = this.width,
                        Height = this.height,
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/diceFour.png", UriKind.Absolute))
                    };

                case 5:
                    return new Image
                    {
                        Width = this.width,
                        Height = this.height,
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/diceFive.png", UriKind.Absolute))
                    };

                case 6:
                    return new Image
                    {
                        Width = this.width,
                        Height = this.height,
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/diceSix.png", UriKind.Absolute))
                    };
                default:
                    return new Image
                    {
                        Width = this.width,
                        Height = this.height,
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/diceOne.png", UriKind.Absolute))
                    };
            }
        }

        public String getValue()
        {
            switch (this.value)
            {
                case 1:
                    return "One";

                case 2:
                    return "Two";

                case 3:
                    return "Three";

                case 4:
                    return "Four";

                case 5:
                    return "Five";

                case 6:
                    return "Six";

                default:
                    return "One";
            }
        }

    }
}
