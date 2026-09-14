using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorMakerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyColor_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string hexColor = txtColor.Text;
                Color color = (Color)ColorConverter.ConvertFromString(hexColor);

                colorPreview.Background = new SolidColorBrush(color);

                txtRGB.Text = $"RGB: {color.R}, {color.G}, {color.B}";

            } catch
            {
                MessageBox.Show(
                    "Hibás szín!!\nPélda: #FF5733",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }


        private void RandomColor_Click(object sender, RoutedEventArgs e)
        {

            int red = random.Next(0, 256);
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);

            Color color = Color.FromRgb((byte)red, (byte)green, (byte)blue);

            colorPreview.Background = new SolidColorBrush(color);

            string hexColor = $"#{red:X2}{green:X2}{blue:X2}";

            txtColor.Text = hexColor;

            if ((red+green+blue)/3 > 122)
            {
                textColorPreview.Foreground = new SolidColorBrush(Colors.Black);
            } else
            {
                textColorPreview.Foreground = new SolidColorBrush(Colors.White);
            }

            txtRGB.Text = $"Rgb: {red}, {green}, {blue}";
        }
    }
}