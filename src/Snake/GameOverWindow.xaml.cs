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
using System.IO.Enumeration;

namespace Snake
{
    public partial class GameOverWindow : Window
    {
        public static List<string> scoreList = new List<string>();
        public string name = "";
        public GameOverWindow()
        {
            Uri iconUri = new Uri($"assets/icon.png", UriKind.Relative);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
            ScoreBox.Content = "SCORE:" + MainViewModel.score;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            name = NameBox.Text;
            New_Score(MainViewModel.score, name);
            this.Close();
        }
        private void New_Score(int score, string name)
        {
            string filename = "highscore.txt";
            if (File.Exists(filename))
            {
                scoreList = File.ReadAllLines(filename).ToList();
                scoreList.Add(name + "  " + score.ToString());
                var sortedScoreList = scoreList.OrderByDescending(ss => int.Parse(ss.Substring(ss.LastIndexOf("  ") + 1)));
                File.WriteAllLines(filename, sortedScoreList.ToArray());
            }
            else
            {
                scoreList.Add(name + "  " + score.ToString());
                var sortedScoreList = scoreList.OrderByDescending(ss => int.Parse(ss.Substring(ss.LastIndexOf("  ") + 1)));
                File.WriteAllLines(filename, sortedScoreList.ToArray());
            }

        }

    }
}
