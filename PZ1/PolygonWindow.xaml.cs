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
    /// Interaction logic for Polygon.xaml
    /// </summary>
    public partial class PolygonWindow : Window
    {
        public PolygonWindow()
        {
            InitializeComponent();

            this.comboBox_fillColor.ItemsSource = typeof(Colors).GetProperties();
            this.comboBox_fillColor.SelectedItem = typeof(Colors).GetProperties()[2];

            this.comboBox_borderColor.ItemsSource = typeof(Colors).GetProperties();
            this.comboBox_borderColor.SelectedItem = typeof(Colors).GetProperties()[2];
        }



        private bool IsValid()
        {
            bool conditionBorder = true;
            bool combo1 = true;
            bool combo2 = true;


       

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

            return  conditionBorder && combo1 && combo2;






        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            if(IsValid())
            {


                Polygon polygon = new Polygon();
                polygon.StrokeThickness = Double.Parse(this.txt_borderThickness.Text.Trim());



                SolidColorBrush fillColor = new SolidColorBrush();
                SolidColorBrush borderColor = new SolidColorBrush();


                Color selectedFillColor = (Color)(comboBox_fillColor.SelectedItem as PropertyInfo).GetValue(1, null);
                fillColor.Color = selectedFillColor;
                polygon.Fill = fillColor;

                Color selectedBorderColor = (Color)(comboBox_borderColor.SelectedItem as PropertyInfo).GetValue(1, null);
                borderColor.Color = selectedBorderColor;
                polygon.Stroke = borderColor;

                PointCollection newList = new PointCollection(MainWindow.polygonPoints);

                polygon.Points = newList;


                Canvas.SetTop(polygon, 0);
                Canvas.SetLeft(polygon, 0);

             

                MainWindow.polygonPoints.Clear();
               


                ((MainWindow)Application.Current.MainWindow).mainCanvas.Children.Add(polygon);

                MainWindow.redoList.Clear();

                this.Close();

             
            }
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
    }
}
