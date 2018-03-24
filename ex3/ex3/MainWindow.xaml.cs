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

namespace ex3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MarginSlider.Value = 5;
            PaddingSlider.Value = 5;
            BackgroundR.Value = BackgroundG.Value = BackgroundB.Value = 255;
            ForegroundR.Text = ForegroundG.Text = ForegroundB.Text = "0";
            ContentBox.Text = "Ala ma kota";
            FontFamilyBox.Text = Result.FontFamily.ToString();
            FontSizeBox.Text = Result.FontSize.ToString();
            Brush.Text = "Black";
            Thickness.Value = 1;
        }

        private void MarginSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Result.Margin = new Thickness(MarginSlider.Value);
        }

        private void PaddingSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Result.Padding = new Thickness(PaddingSlider.Value);
        }

        private void Background_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Result.Background = new SolidColorBrush(Color.FromRgb((byte)BackgroundR.Value, (byte)BackgroundG.Value, (byte)BackgroundB.Value));
        }

        private void Foreground_LostFocus(object sender, RoutedEventArgs e)
        {
            byte rColor, gColor, bColor;

            byte.TryParse(ForegroundR.Text, out rColor);
            byte.TryParse(ForegroundG.Text, out gColor);
            byte.TryParse(ForegroundB.Text, out bColor);

            Color color = Color.FromRgb(rColor, gColor, bColor);

            Result.Foreground = new SolidColorBrush(color);
        }

        private void Brush_TextValueChanged(object sender, EventArgs e)
        {
            try
            {
                Result.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Brush.Text));
            }
            catch (FormatException)
            {
                Result.BorderBrush = new SolidColorBrush(Colors.Black);
            }
        }

        private void Thickness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Result.BorderThickness = new Thickness(Thickness.Value);
        }

        private void ItalicCheckbox_Click(object sender, RoutedEventArgs e)
        {
            if (ItalicCheckbox.IsChecked == true)
            {
                Result.FontStyle = FontStyles.Italic;
            }
            else
            {
                Result.FontStyle = FontStyles.Normal;
            }
        }

        private void BoldCheckbox_Click(object sender, RoutedEventArgs e)
        {
            if (BoldCheckbox.IsChecked == true)
            {
                Result.FontWeight = FontWeights.Bold;
            }
            else
            {
                Result.FontWeight = FontWeights.Normal;
            }
        }

        private void FontFamily_LostFocus(object sender, RoutedEventArgs e)
        {
            Result.FontFamily = new FontFamily(FontFamilyBox.Text);
        }

        private void FontSize_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Result.FontSize = Convert.ToDouble(FontSizeBox.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "\nWpisz poprawną wartość dla rozmiaru czcionki.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message + "\nWpisz poprawną wartość dla rozmiaru czcionki.");
            }

        }

        private void Content_TextChanged(object sender, RoutedEventArgs e)
        {
            Result.Content = ContentBox.Text;
        }

        private void HorizontalAlignment_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            HorizontalAlignment alignment;

            Enum.TryParse(radio.Content.ToString(), out alignment);

            Result.HorizontalAlignment = alignment;
        }

        private void VerticalAlignment_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            VerticalAlignment alignment;

            Enum.TryParse(radio.Content.ToString(), out alignment);

            Result.VerticalAlignment = alignment;
        }

        private void HorizontalContentAlignment_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            HorizontalAlignment alignment;

            Enum.TryParse(radio.Content.ToString(), out alignment);

            Result.HorizontalContentAlignment = alignment;
        }

        private void VerticalContentAlignment_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            VerticalAlignment alignment;

            Enum.TryParse(radio.Content.ToString(), out alignment);

            Result.VerticalContentAlignment = alignment;
        }
    }
}
