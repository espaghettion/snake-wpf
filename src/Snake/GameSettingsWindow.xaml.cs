using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Snake
{
    public partial class GameSettingsWindow : Window
    {
        public static int rectangleSize;
        public static int gridSize;
        public static int gameSpeed;
        public static bool wallMode = false;

        public GameSettingsWindow()
        {
            Uri iconUri = new Uri($"assets/icon.png", UriKind.Relative);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
            rectangleSize = 20;
            gridSize = 30;
            gameSpeed = 150;
            wallMode = false;
        }

        private void SmallMapButton_Click(object sender, RoutedEventArgs e)
        {
            rectangleSize = 30;
            gridSize = 20;
            MapSizeLabel.Content = SmallMapButton.Content;
        }

        private void NormalMapButton_Click(object sender, RoutedEventArgs e)
        {
            rectangleSize = 20;
            gridSize = 30;
            MapSizeLabel.Content = NormalMapButton.Content;
        }

        private void LargeMapButton_Click(object sender, RoutedEventArgs e)
        {
            rectangleSize = 15;
            gridSize = 40;
            MapSizeLabel.Content = LargeMapButton.Content;
        }

        private void SlowSpeedButton_Click(object sender, RoutedEventArgs e)
        {
            gameSpeed = 200;
            SpeedLabel.Content = SlowSpeedButton.Content;
        }

        private void NormalSpeedButton_Click(object sender, RoutedEventArgs e)
        {
            gameSpeed = 150;
            SpeedLabel.Content = NormalSpeedButton.Content;
        }

        private void FastSpeedButton_Click(object sender, RoutedEventArgs e)
        {
            gameSpeed = 100;
            SpeedLabel.Content = FastSpeedButton.Content;
        }

        private void NormalModeButton_Click(object sender, RoutedEventArgs e)
        {
            ModeLabel.Content = NormalModeButton.Content;
            wallMode = false;
        }

        private void WallModeButton_Click(object sender, RoutedEventArgs e)
        {
            ModeLabel.Content = WallModeButton.Content;
            wallMode = true;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
