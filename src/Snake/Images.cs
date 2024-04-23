using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Snake
{
    internal class Images
    {
        public ImageSource snakeBody = LoadImage("snake_body.png");
        public ImageSource snakeHead = LoadImage("snake_head.png");
        public ImageSource goldenApple = LoadImage("golden_apple.png");
        public ImageSource metentite = LoadImage("metentite.png");
        public ImageSource food = LoadImage("tomato.png");
        public ImageSource wall = LoadImage("wall.png");
        public ImageSource weights = LoadImage("weights.png");
        public ImageSource wings = LoadImage("wings.png");

        private static ImageSource LoadImage(string fileName)
        {
            return new BitmapImage(new Uri($"assets/{fileName}", UriKind.Relative));
        }
    }
}
