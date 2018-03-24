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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ex4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastX, lastY;
        private Rectangle lastRectangle;

        public MainWindow()
        {
            InitializeComponent();
        }

        private Rectangle CreateRectangle(double x, double y)
        {
            Random r = new Random();
            Rectangle rectangle = new Rectangle();
            canvas.Children.Add(rectangle);
            rectangle.SetValue(Canvas.LeftProperty, x);
            rectangle.SetValue(Canvas.TopProperty, y);
            lastX = x;
            lastY = y;
            rectangle.Stroke = new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255)));
            rectangle.StrokeThickness = 3;
            return rectangle;
        }

        private void ResizeRectangle(Rectangle rectangle, double x, double y)
        {
            double startX, startY;

            startX = lastX;
            startY = lastY;

            if (x - startX > 0)
            {
                rectangle.Width = x - startX;
            }
            else
            {
                rectangle.SetValue(Canvas.LeftProperty, x);
                rectangle.Width = startX - x;
            }

            if (y - startY > 0)
            {
                rectangle.Height = y - startY;
            }
            else
            {
                rectangle.SetValue(Canvas.TopProperty, y);
                rectangle.Height = startY - y;
            }

        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(canvas);
            Point pt = e.GetPosition(canvas);
            if (lastRectangle != null)
                lastRectangle.StrokeThickness = 1;
            lastRectangle = CreateRectangle(pt.X, pt.Y);
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double move = 4;
            double lastX, lastY;
            lastX = (double)lastRectangle.GetValue(Canvas.LeftProperty);
            lastY = (double)lastRectangle.GetValue(Canvas.TopProperty);
            switch (e.Key)
            {
                case Key.Up:
                    if (Keyboard.IsKeyDown(Key.LeftShift))
                    {
                        if (lastRectangle.Height - move > 0)
                            lastRectangle.Height -= move;
                    }
                    else
                    {
                        if (lastY - move > 0)
                        {
                            lastRectangle.SetValue(Canvas.TopProperty, lastY - move);
                            lastY -= move;
                        }
                    }
                    break;
                case Key.Down:
                    if (Keyboard.IsKeyDown(Key.LeftShift))
                    {
                        lastRectangle.Height += move;
                    }
                    else
                    {
                        lastRectangle.SetValue(Canvas.TopProperty, lastY + move);
                        lastY += move;
                    }
                    break;
                case Key.Left:
                    if (Keyboard.IsKeyDown(Key.LeftShift))
                    {
                        if (lastRectangle.Width - move >= 1)
                            lastRectangle.Width -= move;
                    }
                    else
                    {
                        if (lastX - move >= 1)
                        {
                            lastRectangle.SetValue(Canvas.LeftProperty, lastX - move);
                            lastX -= move;
                        }
                    }
                    break;
                case Key.Right:
                    if (Keyboard.IsKeyDown(Key.LeftShift))
                    {
                        lastRectangle.Width += move;
                    }
                    else
                    {
                        lastRectangle.SetValue(Canvas.LeftProperty, lastX + move);
                        lastX += move;
                    }
                    break;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(canvas);
            if (e.LeftButton == MouseButtonState.Pressed && lastRectangle != null)
            {
                ResizeRectangle(lastRectangle, pt.X, pt.Y);
            }
        }
    }
}
