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
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Snake
{
    public partial class HighScoreWindow : Window
    {
        public Label[] scores;
        public string line;
        public HighScoreWindow()
        {
            Uri iconUri = new Uri($"assets/icon.png", UriKind.Relative);
            this.Icon = BitmapFrame.Create(iconUri);

            InitializeComponent();
            if (File.Exists("highscore.txt"))
            {
                StreamReader sr = new StreamReader("highscore.txt");
                scores = new Label[10] { Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10 };
                for (int i = 0; i < scores.Length; i++)
                {
                    line = sr.ReadLine();
                    if (line == null) break;
                    scores[i].Content = (i + 1) + ". " + line;
                }
                sr.Close();
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }
    }
}
