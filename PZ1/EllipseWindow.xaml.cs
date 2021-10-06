using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for EllipseWindow.xaml
    /// </summary>
    public partial class EllipseWindow : Window
    {
        public EllipseWindow()
        {
            InitializeComponent();

            this.comboBox_fillColor.ItemsSource = typeof(Colors).GetProperties();
            this.comboBox_fillColor.SelectedItem = typeof(Colors).GetProperties()[2];

            this.comboBox_borderColor.ItemsSource = typeof(Colors).GetProperties();
            this.comboBox_borderColor.SelectedItem = typeof(Colors).GetProperties()[2];
        }


        private bool IsValid()
        {
            bool conditionX = true;
            bool conditionY = true;
            bool conditionBorder = true;
            bool combo1 = true;
            bool combo2 = true;

            #region validatingRadiusX
            if ( this.txt_radiusX.Text.Trim().Equals(""))
            {
                this.txt_radiusX.BorderThickness = new Thickness(3, 3, 3, 3);
                this.radiusX_error.Foreground = Brushes.DarkRed;
                this.txt_radiusX.BorderBrush = Brushes.DarkRed;
              
                this.radiusX_error.Visibility = Visibility.Visible;
                this.radiusX_error.Content = "Morate popuniti ovo polje!";


                conditionX = false;

            }

            Double radiusX;
            bool isValidRadiusX = Double.TryParse(this.txt_radiusX.Text.Trim(), out radiusX);

            if( !isValidRadiusX && conditionX)
            {
                this.txt_radiusX.BorderThickness = new Thickness(3, 3, 3, 3);
                this.radiusX_error.Foreground = Brushes.DarkRed;
                this.txt_radiusX.BorderBrush = Brushes.DarkRed;
                this.radiusX_error.Visibility = Visibility.Visible;
                this.radiusX_error.Content = "Morate uneti broj u ovo polje!";

                conditionX = false;
            }


            if( radiusX < 1 && conditionX)
            {
                this.txt_radiusX.BorderThickness = new Thickness(3, 3, 3, 3);
                this.radiusX_error.Foreground = Brushes.DarkRed;
                this.txt_radiusX.BorderBrush = Brushes.DarkRed;
                this.radiusX_error.Visibility = Visibility.Visible;
                this.radiusX_error.Content = "Radius X mora biti veci ili jednak broju 1!";

                conditionX = false;
            }

            #endregion

            #region validatingRadiusY

            if (this.txt_radiusY.Text.Trim().Equals(""))
            {
                this.txt_radiusY.BorderThickness = new Thickness(3, 3, 3, 3);
                this.radiusY_error.Foreground = Brushes.DarkRed;
                this.txt_radiusY.BorderBrush = Brushes.DarkRed;
                this.radiusY_error.Visibility = Visibility.Visible;
                this.radiusY_error.Content = "Morate popuniti ovo polje!";

                conditionY = false;

            }

            Double radiusY;
            bool isValidRadiusY = Double.TryParse(this.txt_radiusY.Text.Trim(), out radiusY);

            if (!isValidRadiusY && conditionY)
            {
                this.txt_radiusY.BorderThickness = new Thickness(3, 3, 3, 3);
                this.radiusY_error.Foreground = Brushes.DarkRed;
                this.txt_radiusY.BorderBrush = Brushes.DarkRed;
                this.radiusY_error.Visibility = Visibility.Visible;
                this.radiusY_error.Content = "Morate uneti broj u ovo polje!";

                conditionY = false;
            }


            if (radiusY < 1 && conditionY)
            {
                this.txt_radiusY.BorderThickness = new Thickness(3, 3, 3, 3);
                this.radiusY_error.Foreground = Brushes.DarkRed;
                this.txt_radiusY.BorderBrush = Brushes.DarkRed;
                this.radiusY_error.Visibility = Visibility.Visible;
                this.radiusY_error.Content = "Radius Y mora biti veci ili jednak broju 1!";

                conditionY = false;
            }



            #endregion

            #region validatingBorderThickness

            if (this.txt_borderThickness.Text.Trim().Equals(""))
            {
                this.txt_borderThickness.BorderThickness = new Thickness(3, 3, 3, 3);
                this.borderThickness_error.Foreground = Brushes.DarkRed;
                this.txt_borderThickness.BorderBrush = Brushes.DarkRed;
                this.borderThickness_error.Visibility = Visibility.Visible;
                this.borderThickness_error.Content = "Morate popuniti ovo polje!";

                conditionBorder = false;

            }

            Double borderThickness;
            bool isValidThickness = Double.TryParse(this.txt_borderThickness.Text.Trim(), out borderThickness);

            if (!isValidThickness && conditionBorder)
            {
                this.txt_borderThickness.BorderThickness = new Thickness(3, 3, 3, 3);
                this.borderThickness_error.Foreground = Brushes.DarkRed;
                this.txt_borderThickness.BorderBrush = Brushes.DarkRed;
                this.borderThickness_error.Visibility = Visibility.Visible;
                this.borderThickness_error.Content = "Morate uneti broj u ovo polje!";

                conditionBorder = false;
            }


            if (borderThickness < 0 && conditionBorder)
            {
                this.txt_borderThickness.BorderThickness = new Thickness(3, 3, 3, 3);
                this.borderThickness_error.Foreground = Brushes.DarkRed;
                this.txt_borderThickness.BorderBrush = Brushes.DarkRed;
                this.borderThickness_error.Visibility = Visibility.Visible;
                this.borderThickness_error.Content = "Thickness ne moze biti negativan broj!";

                conditionBorder = false;
            }


            #endregion

            #region validatingComboBoxes

            if(this.comboBox_fillColor.SelectedItem == null)
            {
                this.comboBox_fillColor.BorderThickness = new Thickness(3, 3, 3, 3);            
                this.comboBox_fillColor.BorderBrush = Brushes.DarkRed;

                combo1 = false;
            }

            if (this.comboBox_borderColor.SelectedItem == null)
            {
                this.comboBox_borderColor.BorderThickness = new Thickness(3, 3, 3, 3);
                this.comboBox_borderColor.BorderBrush = Brushes.DarkRed;

                combo2 = false;
            }

            #endregion

            return conditionX && conditionY && conditionBorder && combo1 && combo2;
               



        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {

            
            if(IsValid())
            {
               
                Ellipse ellipse = new Ellipse();
                ellipse.Width = Double.Parse(this.txt_radiusX.Text);
                ellipse.Height = Double.Parse(this.txt_radiusY.Text);
                ellipse.StrokeThickness = Double.Parse(this.txt_borderThickness.Text);

              
                SolidColorBrush fillColor = new SolidColorBrush();
                SolidColorBrush borderColor = new SolidColorBrush();
              

                Color selectedFillColor = (Color)(comboBox_fillColor.SelectedItem as PropertyInfo).GetValue(1, null);
                fillColor.Color = selectedFillColor;
                ellipse.Fill = fillColor;

                Color selectedBorderColor = (Color)(comboBox_borderColor.SelectedItem as PropertyInfo).GetValue(1, null);
                borderColor.Color = selectedBorderColor;
                ellipse.Stroke = borderColor;


              

                Canvas.SetTop(ellipse, MainWindow.mousePoint.Y);
                Canvas.SetLeft(ellipse, MainWindow.mousePoint.X);

               ((MainWindow)Application.Current.MainWindow).mainCanvas.Children.Add(ellipse);

                MainWindow.redoList.Clear();

                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Txt_radiusX_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txt_radiusX.BorderThickness = new Thickness(1, 1, 1, 1);
            this.radiusX_error.Foreground = Brushes.Black;
            this.txt_radiusX.BorderBrush = Brushes.DarkRed;
            this.radiusX_error.Visibility = Visibility.Hidden;
            this.radiusX_error.Content = "";
        }

        private void Txt_radiusY_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txt_radiusY.BorderThickness = new Thickness(1, 1, 1, 1);
            this.radiusY_error.Foreground = Brushes.DarkRed;
            this.txt_radiusY.BorderBrush = Brushes.DarkRed;
            this.radiusY_error.Visibility = Visibility.Hidden;
            this.radiusY_error.Content = "";
        }

        private void Txt_borderThickness_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txt_borderThickness.BorderThickness = new Thickness(1, 1, 1, 1);
            this.borderThickness_error.Foreground = Brushes.DarkRed;
            this.txt_borderThickness.BorderBrush = Brushes.DarkRed;
            this.borderThickness_error.Visibility = Visibility.Hidden;
            this.borderThickness_error.Content = "";
        }

        private void Txt_borderThickness_LostFocus(object sender, RoutedEventArgs e)
        {
            this.txt_borderThickness.BorderThickness = new Thickness(1, 1, 1, 1);
            this.txt_borderThickness.BorderBrush = Brushes.Azure;

        }

       

        private void Txt_radiusY_LostFocus(object sender, RoutedEventArgs e)
        {
            this.txt_radiusY.BorderThickness = new Thickness(1, 1, 1, 1);
            this.txt_radiusY.BorderBrush = Brushes.Azure;
        }

        private void Txt_radiusX_LostFocus(object sender, RoutedEventArgs e)
        {
            this.txt_radiusX.BorderThickness = new Thickness(1, 1, 1, 1);
            this.txt_radiusX.BorderBrush = Brushes.Azure;
        }
    }
}
