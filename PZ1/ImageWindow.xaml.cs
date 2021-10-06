using Microsoft.Win32;
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

namespace PZ1
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow()
        {
            InitializeComponent();

           
        }


        private bool IsValid()
        {
            bool conditionWidth = true;
            bool conditionHeight = true;
            bool conditionImage = true;


            #region validatingWidth
            if (this.txt_width.Text.Trim().Equals(""))
            {
                this.txt_width.BorderThickness = new Thickness(3, 3, 3, 3);
                this.width_error.Foreground = Brushes.DarkRed;
                this.txt_width.BorderBrush = Brushes.DarkRed;

                this.width_error.Visibility = Visibility.Visible;
                this.width_error.Content = "Morate popuniti ovo polje!";


                conditionWidth = false;

            }

            Double width;
            bool isValidWidth = Double.TryParse(this.txt_width.Text.Trim(), out width);

            if (!isValidWidth && conditionWidth)
            {
                this.txt_width.BorderThickness = new Thickness(3, 3, 3, 3);
                this.width_error.Foreground = Brushes.DarkRed;
                this.txt_width.BorderBrush = Brushes.DarkRed;
                this.width_error.Visibility = Visibility.Visible;
                this.width_error.Content = "Morate uneti broj u ovo polje!";

                conditionWidth = false;
            }


            if (width < 1 && conditionWidth)
            {
                this.txt_width.BorderThickness = new Thickness(3, 3, 3, 3);
                this.width_error.Foreground = Brushes.DarkRed;
                this.txt_width.BorderBrush = Brushes.DarkRed;
                this.width_error.Visibility = Visibility.Visible;
                this.width_error.Content = "Width ne moze biti manji od 1!";

                conditionWidth = false;
            }

            #endregion

            #region validatingHeight

            if (this.txt_height.Text.Trim().Equals(""))
            {
                this.txt_height.BorderThickness = new Thickness(3, 3, 3, 3);
                this.height_error.Foreground = Brushes.DarkRed;
                this.txt_height.BorderBrush = Brushes.DarkRed;
                this.height_error.Visibility = Visibility.Visible;
                this.height_error.Content = "Morate popuniti ovo polje!";

                conditionHeight = false;

            }

            Double height;
            bool isValidHeight = Double.TryParse(this.txt_height.Text.Trim(), out height);

            if (!isValidHeight && conditionHeight)
            {
                this.txt_height.BorderThickness = new Thickness(3, 3, 3, 3);
                this.height_error.Foreground = Brushes.DarkRed;
                this.txt_height.BorderBrush = Brushes.DarkRed;
                this.height_error.Visibility = Visibility.Visible;
                this.height_error.Content = "Morate uneti broj u ovo polje!";

                conditionHeight = false;
            }


            if (height < 1 && conditionHeight)
            {
                this.txt_height.BorderThickness = new Thickness(3, 3, 3, 3);
                this.height_error.Foreground = Brushes.DarkRed;
                this.txt_height.BorderBrush = Brushes.DarkRed;
                this.height_error.Visibility = Visibility.Visible;
                this.height_error.Content = "Height ne moze biti manji od 1!";

                conditionHeight = false;
            }

            #endregion

            #region validatingImage

            if (this.image_img.Source == null || this.image_img.Source.Equals(""))
            {
             
                this.img_error.Foreground = Brushes.DarkRed;
                this.img_error.Visibility = Visibility.Visible;
                this.img_error.Content = "Morate izabrati sliku!";

                conditionWidth = false;
            }

            #endregion

            return conditionWidth && conditionHeight && conditionImage;






        }

        private void Btn_browse_Click(object sender, RoutedEventArgs e)
        {

          
            this.img_error.Foreground = Brushes.Black;
            this.img_error.Visibility = Visibility.Hidden;
            this.img_error.Content = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                this.image_img.Source = new BitmapImage(fileUri);
               
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {

                Image image = new Image();
                image.Source = this.image_img.Source;
                image.Width = Double.Parse(this.txt_width.Text.Trim());
                image.Height = Double.Parse(this.txt_height.Text.Trim());
                image.Stretch = Stretch.Fill;


                Canvas.SetTop(image, MainWindow.mousePoint.Y);
                Canvas.SetLeft(image, MainWindow.mousePoint.X);


                ((MainWindow)Application.Current.MainWindow).mainCanvas.Children.Add(image);

                MainWindow.redoList.Clear();

                this.Close();
            }







        }

        private void Txt_width_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txt_width.BorderThickness = new Thickness(1, 1, 1, 1);
            this.width_error.Foreground = Brushes.Black;
            this.txt_width.BorderBrush = Brushes.DarkRed;
            this.width_error.Visibility = Visibility.Hidden;
            this.width_error.Content = "";
        }

        private void Txt_width_LostFocus(object sender, RoutedEventArgs e)
        {
            this.txt_width.BorderThickness = new Thickness(1, 1, 1, 1);
            this.txt_width.BorderBrush = Brushes.Azure;
        }

        private void Txt_height_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txt_height.BorderThickness = new Thickness(1, 1, 1, 1);
            this.height_error.Foreground = Brushes.Black;
            this.txt_height.BorderBrush = Brushes.DarkRed;
            this.height_error.Visibility = Visibility.Hidden;
            this.height_error.Content = "";
        }

        private void Txt_height_LostFocus(object sender, RoutedEventArgs e)
        {
            this.txt_height.BorderThickness = new Thickness(1, 1, 1, 1);
            this.txt_height.BorderBrush = Brushes.Azure;
        }
    }
}
    
