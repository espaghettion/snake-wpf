using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;

namespace Snake
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Uri iconUri = new Uri($"assets/icon.png", UriKind.Relative);
            this.Icon = BitmapFrame.Create(iconUri);
            this.DataContext = new MainViewModel();
            Messenger.Default.Register<CloseMainWindowMessage>(this, CloseMainWindow);
            InitializeComponent();

            DateTime startTime = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            timer.Start();
            void Timer_Tick(object sender, EventArgs e)
            {
                scoreBox.Content = "SCORE:" + MainViewModel.score;
                TimeSpan elapsedTime = DateTime.Now - startTime;
                string timeString = elapsedTime.ToString(@"mm\:ss");
                playTime.Content = timeString;
            }
        }

        void CloseMainWindow(CloseMainWindowMessage obj)
        {
            GameOverWindow gameOverWindow = new GameOverWindow();
            gameOverWindow.Show();
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Messenger.Default.Send(new KeyPressedMessage() { keyEventArgs = e });
        }
    }
}
