using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Ink;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Media.Animation;
using System.Security.Cryptography.X509Certificates;

namespace Snake
{
    internal class MainViewModel
    {
        private Canvas _gameField;
        public Canvas gameField
        {
            get { return _gameField; }
            set { _gameField = value; }
        }

        TransformGroup transformGroup = new TransformGroup();
        RotateTransform rotateTransform = new RotateTransform();
        List<SnakeBody> snake;
        ObjectInGame[] food;
        List<ObjectInGame> items;
        List<ObjectInGame> walls;
        public Random randomNumber;
        public bool incorrectFoodPosition;
        public bool incorrectItemPosition;
        public bool incorrectWallPosition;
        public static bool gameOver;
        public static int num = 0;
        public static ItemEffect itemEffect = new ItemEffect();
        public static bool canSpawn = false;
        public static double speed = GameSettingsWindow.gameSpeed;
        public static int size = GameSettingsWindow.rectangleSize;
        public static int grid = GameSettingsWindow.gridSize;
        public int j = 0;
        public static int score = 0;
        Thread thread1;

        void UpdateGameField()
        {
            gameField.Children.Clear();

            foreach (SnakeBody obj in snake)
            {
                Canvas.SetLeft(obj.rectangle, obj.x);
                Canvas.SetTop(obj.rectangle, obj.y);

                gameField.Children.Add(obj.rectangle);
            }

            foreach (ObjectInGame fd in food)
            {
                Canvas.SetLeft(fd.rectangle, fd.x);
                Canvas.SetTop(fd.rectangle, fd.y);

                gameField.Children.Add(fd.rectangle);
            }

            foreach (ObjectInGame item in items)
            {
                Canvas.SetLeft(item.rectangle, item.x);
                Canvas.SetTop(item.rectangle, item.y);

                gameField.Children.Add(item.rectangle);
            }

            foreach (ObjectInGame wall in walls)
            {
                Canvas.SetLeft(wall.rectangle, wall.x);
                Canvas.SetTop(wall.rectangle, wall.y);

                gameField.Children.Add(wall.rectangle);
            }
        }

        void ChangeSnakeDirection(KeyPressedMessage obj)
        {
            {
                if (obj.keyEventArgs.Key == Key.W && snake[0].direction != "Down")
                {
                    snake[0].direction = "Up";
                    rotateTransform.Angle = 270;
                }
                if (obj.keyEventArgs.Key == Key.A && snake[0].direction != "Right")
                {
                    snake[0].direction = "Left";
                    rotateTransform.Angle = 180;
                }
                if (obj.keyEventArgs.Key == Key.S && snake[0].direction != "Up")
                {
                    snake[0].direction = "Down";
                    rotateTransform.Angle = 90;
                }
                if (obj.keyEventArgs.Key == Key.D && snake[0].direction != "Left")
                {
                    snake[0].direction = "Right";
                    rotateTransform.Angle = 0;
                }
            }
        }

        void MoveSnake()
        {
            CheckCollision();

            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i].x = snake[i - 1].x;
                snake[i].y = snake[i - 1].y;
                snake[i].direction = snake[i - 1].direction;
            }

            switch (snake[0].direction)
            {
                case "Up":
                    snake[0].y -= size;
                    break;

                case "Left":
                    snake[0].x -= size;
                    break;

                case "Down":
                    snake[0].y += size;
                    break;

                case "Right":
                    snake[0].x += size;
                    break;
            }

        }

        void IncreaseSnakeLength()
        {
            string direction = snake[0].direction;


            if (snake[0].x == food[0].x && snake[0].y == food[0].y)
            {
                snake.Insert(1, new SnakeBody(direction, food[0].x, food[0].y));
                GenerateNewFood();

                if (GameSettingsWindow.wallMode == true)
                {
                    GenerateWall();
                }
            }

            if (items.Count != 0)
            {
                if (snake[0].x == items[0].x && snake[0].y == items[0].y)
                {
                    itemEffect.isActive = true;
                    itemEffect.StartEffect();
                    switch (num)
                    {
                        case 0:
                            if (snake.Count > 1)
                            {
                                snake.RemoveAt(snake.Count - 1);
                            }
                            score += 5;
                            break;

                        default:
                            break;
                    }


                    items.RemoveAt(0);
                }

            }
            GenerateNewItem();

        }

        void GenerateNewFood()
        {
            score++;
            int x = 1;
            int y = 1;

            while (incorrectFoodPosition == true)
            {
                x = randomNumber.Next(1, grid) * size;
                y = randomNumber.Next(1, grid) * size;

                incorrectFoodPosition = false;

                for (int i = 0; i < snake.Count; i++)
                {
                    if (snake[i].x == x && snake[i].y == y)
                    {
                        incorrectFoodPosition = true;
                    }
                }

                for (int i = 0; i < walls.Count; i++)
                {
                    if (walls[i].x == x && walls[i].y == y)
                    {
                        incorrectFoodPosition = true;
                    }
                }
            }

            food[0].x = x;
            food[0].y = y;
            incorrectFoodPosition = true;
        }

        void GenerateWall()
        {
            int x = 1;
            int y = 1;

            while (incorrectWallPosition == true)
            {
                x = randomNumber.Next(1, grid) * size;
                y = randomNumber.Next(1, grid) * size;

                incorrectWallPosition = false;

                for (int i = 0; i < snake.Count; i++)
                {
                    if (snake[i].x == x && snake[i].y == y)
                    {
                        incorrectWallPosition = true;
                    }
                }

                for (int i = 0; i < walls.Count; i++)
                {
                    if (walls[i].x == x && walls[i].y == y)
                    {
                        incorrectWallPosition = true;
                    }
                }

                if (food[0].x == x && food[0].y == y)
                {
                    incorrectWallPosition = true;
                }

                if (items.Count != 0)
                {
                    if (items[0].x == x && items[0].y == y)
                    {
                        incorrectWallPosition = true;
                    }
                }
            }

            ObjectInGame wall = new ObjectInGame(x, y);
            wall.rectangle.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri($"assets/wall.png", UriKind.Relative))
            };
            walls.Add(wall);
            walls[j].x = x;
            walls[j].y = y;
            incorrectWallPosition = true;
            j++;
        }

        void GenerateNewItem()
        {
            if (canSpawn)
            {
                int x = 1;
                int y = 1;

                items.Insert(0, new ObjectInGame(x, y));

                num = randomNumber.Next(4);
                switch (num)
                {
                    case 0:
                        items[0].rectangle.Fill = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri($"assets/golden_apple.png", UriKind.Relative))
                        };
                        break;

                    case 1:
                        items[0].rectangle.Fill = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri($"assets/wings.png", UriKind.Relative))
                        };
                        break;

                    case 2:
                        items[0].rectangle.Fill = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri($"assets/weights.png", UriKind.Relative))
                        };
                        break;

                    case 3:
                        items[0].rectangle.Fill = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri($"assets/metentite.png", UriKind.Relative))
                        };
                        break;
                }


                while (incorrectItemPosition == true)
                {
                    x = randomNumber.Next(1, grid) * size;
                    y = randomNumber.Next(1, grid) * size;

                    incorrectItemPosition = false;

                    for (int i = 0; i < snake.Count; i++)
                    {
                        if (snake[i].x == x && snake[i].y == y)
                        {
                            incorrectItemPosition = true;
                        }
                    }

                    for (int i = 0; i < walls.Count; i++)
                    {
                        if (walls[i].x == x && walls[i].y == y)
                        {
                            incorrectItemPosition = true;
                        }
                    }
                }

                items[0].x = x;
                items[0].y = y;
                incorrectItemPosition = true;
                canSpawn = false;
            }

        }

        public class ItemEffect
        {
            public System.Timers.Timer timer;
            public bool isActive;

            public void StartEffect()
            {
                timer = new System.Timers.Timer(10000);
                timer.Elapsed += EndEffect;
                timer.AutoReset = false;
                timer.Enabled = true;
                canSpawn = false;

                switch (num)
                {
                    case 2:
                        speed = GameSettingsWindow.gameSpeed * 1.5;
                        break;

                    case 3:
                        speed = GameSettingsWindow.gameSpeed / 1.5;
                        break;

                    default:
                        break;
                }
            }

            public void EndEffect(Object source, ElapsedEventArgs e)
            {
                itemEffect.isActive = false;
                speed = GameSettingsWindow.gameSpeed;
                canSpawn = true;
            }
        }

        void CheckCollision()
        {
            for (int i = 2; i < snake.Count; i++)
            {
                if (num == 1 && itemEffect.isActive)
                {
                    break;
                }

                if (snake[0].x == snake[i].x && snake[0].y == snake[i].y)
                {
                    gameOver = true;
                }
            }

            for (int i = 2; i < snake.Count; i++)
            {
                if (snake[0].x > 585 || snake[0].x < 0 || snake[0].y > 585 || snake[0].y < 0)
                {
                    gameOver = true;
                }
            }

            for (int i = 0; i < walls.Count; i++)
            {
                if (snake[0].x == walls[i].x && snake[0].y == walls[i].y)
                {
                    gameOver = true;
                }
            }
        }

        void RunTheGame()
        {
            while (!gameOver)
            {
                gameField.Dispatcher.Invoke(() =>
                {
                    IncreaseSnakeLength();
                    MoveSnake();
                    UpdateGameField();
                });

                Thread.Sleep(Convert.ToInt32(speed));
            }

            gameField.Dispatcher.Invoke(() =>
            {
                Messenger.Default.Send(new CloseMainWindowMessage());
            });
        }
        public MainViewModel()
        {
            Messenger.Default.Register<KeyPressedMessage>(this, ChangeSnakeDirection);

            gameField = new Canvas();

            incorrectFoodPosition = true;
            incorrectItemPosition = true;
            incorrectWallPosition = true;

            gameOver = false;

            randomNumber = new Random();

            snake = new List<SnakeBody>();
            food = new ObjectInGame[1];
            items = new List<ObjectInGame>();
            walls = new List<ObjectInGame>();

            food[0] = new ObjectInGame(size * 10, 300);
            items.Add(new ObjectInGame(size * 15, size * 15));
            snake.Add(new SnakeBody("Right", size * 4, 300));
            snake.Add(new SnakeBody("Right", size * 3, 300));
            snake.Add(new SnakeBody("Right", size * 2, 300));
            snake[0].rectangle.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri($"assets/snake_head.png", UriKind.Relative))
            };
            items[0].rectangle.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri($"assets/golden_apple.png", UriKind.Relative))
            };
            food[0].rectangle.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri($"assets/tomato.png", UriKind.Relative))
            };

            rotateTransform.CenterX = snake[0].rectangle.Width / 2;
            rotateTransform.CenterY = snake[0].rectangle.Height / 2;
            transformGroup.Children.Add(rotateTransform);
            snake[0].rectangle.RenderTransform = transformGroup;

            UpdateGameField();

            thread1 = new Thread(() => RunTheGame());
            thread1.Start();
        }

    }
}
