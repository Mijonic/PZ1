using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PZ1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public static List<ToggleButton> listToggleButtons = new List<ToggleButton>();
        public static Point mousePoint = new Point();
        public static PointCollection polygonPoints = new PointCollection();

        public static List<object> undoList = new List<object>();
        public static List<object> redoList = new List<object>();
        public static List<object> clearedElementsList = new List<object>();



        public MainWindow()
        {
            InitializeComponent();

            listToggleButtons.Add(this.tb_ellipse);
            listToggleButtons.Add(this.tb_image);
            listToggleButtons.Add(this.tb_polygon);
            listToggleButtons.Add(this.tb_rectangle);

            mainCanvas.ClipToBounds = true;

           
        }

        private void Tb_ellipse_Checked(object sender, RoutedEventArgs e)
        {

            listToggleButtons.ForEach(x => { if (x.Content.ToString() != "Ellipse") { x.IsChecked = false; } });

           
            
        }

        private void Tb_rectangle_Checked(object sender, RoutedEventArgs e)
        {

            listToggleButtons.ForEach(x => { if (x.Content.ToString() != "Rectangle") { x.IsChecked = false; } });

        }

        private void Tb_polygon_Checked(object sender, RoutedEventArgs e)
        {
            listToggleButtons.ForEach(x => { if (x.Content.ToString() != "Polygon") { x.IsChecked = false; } });
        }

        private void Tb_image_Checked(object sender, RoutedEventArgs e)
        {
            listToggleButtons.ForEach(x => { if (x.Content.ToString() != "Image") { x.IsChecked = false; } });
        }

        private void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            foreach (ToggleButton btn in listToggleButtons)
            {
                if (btn.IsChecked == true)
                {
                    
                    if (btn.Content.ToString().Equals("Polygon"))
                    {

                        if (polygonPoints.Count >= 3)
                        {
                            mousePoint = e.GetPosition(mainCanvas);
                            PolygonWindow polygonWindow = new PolygonWindow();
                            polygonWindow.Show();
                        }

                    }
                }
            }

         
            if ( e.OriginalSource is Shape  )
            {
                Shape shape = (Shape)e.OriginalSource;

              

                UpdateWindow updateWindow = new UpdateWindow(shape);
                updateWindow.Show();
                
                
            }


            }

        private void MainCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            mousePoint = e.GetPosition(mainCanvas);

            foreach (ToggleButton btn in listToggleButtons)
            {
                if (btn.IsChecked == true)
                {
                    if (btn.Content.ToString().Equals("Ellipse"))
                    {
                        polygonPoints.Clear();
                        EllipseWindow ew = new EllipseWindow();
                        ew.Show();

                    }
                    else if (btn.Content.ToString().Equals("Image"))
                    {
                        polygonPoints.Clear();
                        ImageWindow imageWindow = new ImageWindow();
                        imageWindow.Show();

                    }
                    else if (btn.Content.ToString().Equals("Rectangle"))
                    {
                        polygonPoints.Clear();
                        RectangleWindow rectangleWindow = new RectangleWindow();
                        rectangleWindow.Show();
                    }
                }
            }

            ToggleButton polygonToggle = listToggleButtons.Find(x => x.Content.Equals("Polygon"));

            if( polygonToggle?.IsChecked == true)
                polygonPoints.Add(e.GetPosition(mainCanvas));

            

           

           
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {


            polygonPoints.Clear();
            clearedElementsList.Clear();
            
            foreach(object element in mainCanvas.Children)
            {
                clearedElementsList.Add(element);
            }


            List<object> copyList = new List<object>();
            foreach(object elemnt in mainCanvas.Children)
            {
                copyList.Add(elemnt);
            }
                    
            undoList.Add(copyList);
            redoList.Clear();


            mainCanvas.Children.Clear();
            

        }

        private void Btn_undo_Click(object sender, RoutedEventArgs e)
        {
            if (mainCanvas.Children.Count != 0)
            {
                redoList.Add(mainCanvas.Children[mainCanvas.Children.Count - 1]);
                mainCanvas.Children.RemoveAt(mainCanvas.Children.Count - 1);

                if (undoList.Count != 0)
                    undoList.Remove(undoList[undoList.Count - 1]);

            }else
            {


                if(undoList.Count != 0 && clearedElementsList.Count != 0 )
                {
                    clearedElementsList.ForEach(x => mainCanvas.Children.Add((UIElement)x));
                    List<object> copyList = new List<object>();
                    clearedElementsList.ForEach(x => copyList.Add(x));

                    redoList.Add(copyList);


                    clearedElementsList.Clear();

                    if (undoList.Count != 0)
                        undoList.Remove(undoList[undoList.Count - 1]);
                }
                else if (undoList.Count != 0 && undoList[undoList.Count - 1] as List<object> != null)
                {
                    List<object> copyList = new List<object>();
                    foreach(object elemnt in (List<object>)undoList[undoList.Count - 1])
                    {
                        copyList.Add(elemnt);
                    }



                    copyList.ForEach(x => mainCanvas.Children.Add((UIElement)x));

                    redoList.Add(copyList);

                    if (undoList.Count != 0)
                        undoList.Remove(undoList[undoList.Count - 1]);
                }

             
            }


        }

        private void Btn_redo_Click(object sender, RoutedEventArgs e)
        {

            if (redoList.Count != 0)
            {
                 

                if ( redoList[redoList.Count-1] as List<object> != null)
                {

                    undoList.Add(redoList[redoList.Count - 1]);
                    

                    List<UIElement> removeElements = new List<UIElement>();

                    foreach(object element in (List<object>)redoList[redoList.Count - 1])
                    {
                        removeElements.Add((UIElement)element);
                    }
                    

                    removeElements.ForEach(x => mainCanvas.Children.Remove(x));
                    redoList.Remove(redoList[redoList.Count - 1]);


                }
                else
                {
                    undoList.Add(redoList[redoList.Count - 1]);
                    mainCanvas.Children.Add((UIElement)redoList[redoList.Count - 1]);
                    redoList.Remove(redoList[redoList.Count - 1]);

                }
                
                

             
                    
               
            }

        }
    }
}
