using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    internal class ObjectInGame
    {
        public int x;
        public int y;
        public Rectangle rectangle = new Rectangle();

        public ObjectInGame(int x, int y)
        {
            this.x = x;
            this.y = y;
            rectangle = new Rectangle();
            rectangle.Width = GameSettingsWindow.rectangleSize;
            rectangle.Height = GameSettingsWindow.rectangleSize;
        }
    }
}
