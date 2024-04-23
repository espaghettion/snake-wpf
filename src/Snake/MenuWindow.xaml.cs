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
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            Uri iconUri = new Uri($"assets/icon.png", UriKind.Relative);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            GameSettingsWindow gameSettingsWindow = new GameSettingsWindow();
            gameSettingsWindow.Show();
            this.Close();
        }

        private void HighScoreButton_Click(object sender, RoutedEventArgs e)
        {
            HighScoreWindow highScoreWindow = new HighScoreWindow();
            highScoreWindow.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
