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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {

        private Shape selectedShape;

        private string fillColorField;
        private string borderColorField;
        private double borderThicknessField;

        public UpdateWindow(Shape shape)
        {
            InitializeComponent();


            this.comboBox_fillColor.ItemsSource = typeof(Colors).GetProperties();
            this.comboBox_borderColor.ItemsSource = typeof(Colors).GetProperties();

            this.selectedShape = shape;
            this.fillColorField = this.selectedShape.Fill.ToString();
            this.borderColorField = this.selectedShape.Stroke.ToString();
            this.borderThicknessField = this.selectedShape.StrokeThickness;

            Color comboFillColor = (Color)ColorConverter.ConvertFromString(fillColorField);
            this.comboBox_fillColor.SelectedItem = typeof(Colors).GetProperties()[ExtractIndexSelectedColor(comboFillColor)];


            Color comboBorderColor = (Color)ColorConverter.ConvertFromString(borderColorField);
            this.comboBox_borderColor.SelectedItem = typeof(Colors).GetProperties()[ExtractIndexSelectedColor(comboBorderColor)];

            this.txt_borderThickness.Text = borderThicknessField.ToString();
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

            return conditionBorder && combo1 && combo2;







        }


        private int ExtractIndexSelectedColor(Color color)
        {
            PropertyInfo[] properties = typeof(Colors).GetProperties();
            int i = 0;
            foreach (PropertyInfo property in properties)
            {
                Color tempColor = (Color)property.GetValue(null, null);

                if (tempColor == color)
                    return i;


                i++;
            }

            return -1;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            if( IsValid() )
            {
                this.selectedShape.StrokeThickness = Double.Parse(this.txt_borderThickness.Text.Trim());


                SolidColorBrush fillColor = new SolidColorBrush();
                SolidColorBrush borderColor = new SolidColorBrush();


                Color selectedFillColor = (Color)(comboBox_fillColor.SelectedItem as PropertyInfo).GetValue(1, null);
                fillColor.Color = selectedFillColor;
                this.selectedShape.Fill = fillColor;

                Color selectedBorderColor = (Color)(comboBox_borderColor.SelectedItem as PropertyInfo).GetValue(1, null);
                borderColor.Color = selectedBorderColor;
                this.selectedShape.Stroke = borderColor;

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
