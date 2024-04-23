using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel.DataAnnotations;
using System.Runtime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography.X509Certificates;

namespace Snake
{
    internal class SnakeBody
    {
        public string direction;
        public int x;
        public int y;
        public Rectangle rectangle;

        public SnakeBody(string direction, int x, int y)
        {
            this.direction = direction;
            this.x = x;
            this.y = y;
            rectangle = new Rectangle();
            rectangle.Width = GameSettingsWindow.rectangleSize;
            rectangle.Height = GameSettingsWindow.rectangleSize;

            rectangle.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri($"assets/snake_body.png", UriKind.Relative))
            };
        }



    }
}
