using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace MTG_Helper.Model
{
    class Coin
    {
        public int width { get; }
        public int height { get; }
        private int value;

        public Coin(int width, int height, int value)
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
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/head.png", UriKind.Absolute))
                    };

                case 2:
                    return new Image
                    {
                        Width = this.width,
                        Height = this.height,
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/tail.png", UriKind.Absolute))
                    };

                default:
                    return new Image
                    {
                        Width = this.width,
                        Height = this.height,
                        Source = new BitmapImage(new Uri("ms-appx:/Resources/head.png", UriKind.Absolute))
                    };

            }
        }

        public String getValue()
        {
            switch (this.value)
            {
                case 1:
                    return "Head";

                case 2:
                    return "Tail";

                default:
                    return "Head";
            }
        }

    }
}
