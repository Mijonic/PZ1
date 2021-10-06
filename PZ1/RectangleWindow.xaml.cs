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
    /// Interaction logic for Rectangle.xaml
    /// </summary>
    public partial class RectangleWindow : Window
    {
        public RectangleWindow()
        {
            InitializeComponent();

            this.comboBox_fillColor.ItemsSource = typeof(Colors).GetProperties();
            this.comboBox_fillColor.SelectedItem = typeof(Colors).GetProperties()[2];

            this.comboBox_borderColor.ItemsSource = typeof(Colors).GetProperties();
            this.comboBox_borderColor.SelectedItem = typeof(Colors).GetProperties()[2];
        }


        private bool IsValid()
        {
            bool conditionWidth = true;
            bool conditionHeight = true;
            bool conditionBorder = true;
            bool combo1 = true;
            bool combo2 = true;


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

            #region validatingBorderThickness

            if (this.txt_borderThickness.Text.Trim().Equals(""))
            {
                this.txt_borderThickness.BorderThickness = new Thickness(3, 3, 3, 3);
                this.thickness_error.Foreground = Brushes.DarkRed;
                this.txt_borderThickness.BorderBrush = Brushes.DarkRed;
                this.thickness_error.Visibility = Visibility.Visible;
                this.thickness_error.Content = "Morate popuniti ovo polje!";

                conditionBorder = false;

            }

            Double borderThickness;
            bool isValidThickness = Double.TryParse(this.txt_borderThickness.Text.Trim(), out borderThickness);

            if (!isValidThickness && conditionBorder)
            {
                this.txt_borderThickness.BorderThickness = new Thickness(3, 3, 3, 3);
                this.thickness_error.Foreground = Brushes.DarkRed;
                this.txt_borderThickness.BorderBrush = Brushes.DarkRed;
                this.thickness_error.Visibility = Visibility.Visible;
                this.thickness_error.Content = "Morate uneti broj u ovo polje!";

                conditionBorder = false;
            }


            if (borderThickness < 0 && conditionBorder)
            {
                this.txt_borderThickness.BorderThickness = new Thickness(3, 3, 3, 3);
                this.thickness_error.Foreground = Brushes.DarkRed;
                this.txt_borderThickness.BorderBrush = Brushes.DarkRed;
                this.thickness_error.Visibility = Visibility.Visible;
                this.thickness_error.Content = "Thickness ne moze biti negativan broj!";

                conditionBorder = false;
            }


            #endregion

            #region validatingComboBoxes

            if (this.comboBox_fillColor.SelectedItem == null)
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

            return conditionWidth && conditionHeight && conditionBorder && combo1 && combo2;






        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
               
                Rectangle rectangleObject =new Rectangle();

                rectangleObject.Height = Double.Parse(this.txt_height.Text.Trim());
                rectangleObject.Width = Double.Parse(this.txt_width.Text.Trim());
                rectangleObject.StrokeThickness = Double.Parse(this.txt_borderThickness.Text.Trim());


                SolidColorBrush fillColor = new SolidColorBrush();
                SolidColorBrush borderColor = new SolidColorBrush();


                Color selectedFillColor = (Color)(comboBox_fillColor.SelectedItem as PropertyInfo).GetValue(1, null);
                fillColor.Color = selectedFillColor;
                rectangleObject.Fill = fillColor;

                Color selectedBorderColor = (Color)(comboBox_borderColor.SelectedItem as PropertyInfo).GetValue(1, null);
                borderColor.Color = selectedBorderColor;
                rectangleObject.Stroke = borderColor;




                Canvas.SetTop(rectangleObject, MainWindow.mousePoint.Y);
                Canvas.SetLeft(rectangleObject, MainWindow.mousePoint.X);


                ((MainWindow)Application.Current.MainWindow).mainCanvas.Children.Add(rectangleObject);

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

        private void Txt_borderThickness_GotFocus(object sender, RoutedEventArgs e)
        {

            this.txt_borderThickness.BorderThickness = new Thickness(1, 1, 1, 1);
            this.thickness_error.Foreground = Brushes.Black;
            this.txt_borderThickness.BorderBrush = Brushes.DarkRed;
            this.thickness_error.Visibility = Visibility.Hidden;
            this.thickness_error.Content = "";

        }

        private void Txt_borderThickness_LostFocus(object sender, RoutedEventArgs e)
        {
            this.txt_borderThickness.BorderThickness = new Thickness(1, 1, 1, 1);
            this.txt_borderThickness.BorderBrush = Brushes.Azure;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
