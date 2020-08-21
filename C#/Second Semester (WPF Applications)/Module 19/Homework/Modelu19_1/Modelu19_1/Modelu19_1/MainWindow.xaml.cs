using Microsoft.Win32;
using Modelu19_1.Models;
using Modelu19_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Modelu19_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            KeyEventHandler HandleKeyDownEvent = (object o, KeyEventArgs e) => { flg_ShiftIsPressed = (e.Key == Key.LeftShift || e.Key == Key.RightShift) ? true : false; };
            KeyEventHandler HandleKeyUpEvent = (object o, KeyEventArgs e) => { flg_ShiftIsPressed = (e.Key == Key.LeftShift || e.Key == Key.RightShift) ? false : true; };

            AddHandler(Keyboard.KeyDownEvent, HandleKeyDownEvent);
            AddHandler(Keyboard.KeyUpEvent, HandleKeyUpEvent);
        }

        enum ECurrentTool
        {
            Arrow,
            FillingTool,
            Pencil,
            Line,
            Ellipse,
            Rectangle,
            RoundedRectangle,
            Polygon,
            Triangle,
            FivePointStar,
            Heart
        }

        private bool flg_ShiftIsPressed;
        private Point m_position;

        private ECurrentTool m_CurrentTool;


        //SHAPES
        private Line m_line;
        private Ellipse m_ellipse;
        private Rectangle m_rectangle;
        private Polygon m_triangle;
        private Polygon m_polygon;
        private CHeart m_heart;
        private CFivePointStar m_FivePointStar;

        private Shape selectedShape;

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            m_position = e.GetPosition(canvas);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //Включили карандаш
                if(pencil.IsChecked == true)
                {
                    m_CurrentTool = ECurrentTool.Pencil;
                }
                else
                {
                    //Рассматриваем, включена ли какая-либо из фигур
                    if(ArrowButton.IsChecked == true) { m_CurrentTool = ECurrentTool.Arrow; }
                    if(filling_tool.IsChecked == true) { m_CurrentTool = ECurrentTool.FillingTool; }
                    if(shape_Line.IsChecked == true)  { m_CurrentTool = ECurrentTool.Line; }
                    if(shape_Ellipse.IsChecked == true) { m_CurrentTool = ECurrentTool.Ellipse; }
                    if(shape_Rectangle.IsChecked == true) { m_CurrentTool = ECurrentTool.Rectangle; }
                    if(shape_RoundedRectangle.IsChecked == true) { m_CurrentTool = ECurrentTool.RoundedRectangle; }
                    if(shape_Triangle.IsChecked == true) { m_CurrentTool = ECurrentTool.Triangle; }
                    if(shape_Polygon.IsChecked == true) { m_CurrentTool = ECurrentTool.Polygon; }
                    if(shape_Heart.IsChecked == true) { m_CurrentTool = ECurrentTool.Heart; }
                    if(shape_Fivepointstar.IsChecked == true) { m_CurrentTool = ECurrentTool.FivePointStar; }
                }

                if(m_CurrentTool != ECurrentTool.Arrow && m_CurrentTool != ECurrentTool.Arrow)
                {
                    if (filling_tool.IsChecked == true && selectedShape != null)
                    {
                        selectedShape.Fill = new SolidColorBrush(colorPicker1.SelectedColor);
                    }

                    switch (m_CurrentTool)
                    {
                        case ECurrentTool.Pencil:
                            m_position = e.GetPosition(canvas);
                            break;
                        case ECurrentTool.Line:
                            DrawShape(ref m_line, canvas, colorPicker1.SelectedColor);
                            break;
                        case ECurrentTool.Ellipse:
                            DrawShape(ref m_ellipse, canvas, colorPicker1.SelectedColor);
                            break;
                        case ECurrentTool.Rectangle:
                            DrawShape(ref m_rectangle, canvas, colorPicker1.SelectedColor);
                            break;
                        case ECurrentTool.RoundedRectangle:
                            DrawShape(ref m_rectangle, canvas, colorPicker1.SelectedColor);
                            m_rectangle.RadiusX = 20;
                            m_rectangle.RadiusY = 20;
                            break;
                        case ECurrentTool.Triangle:
                            DrawShape(ref m_triangle, canvas, colorPicker1.SelectedColor);
                            Point[] points_for_triangle = { m_position, m_position, m_position };
                            m_triangle.Points = new PointCollection(points_for_triangle);
                            break;
                        case ECurrentTool.Polygon:
                            if (m_polygon == null)
                            {
                                DrawShape(ref m_polygon, canvas, colorPicker1.SelectedColor);
                                Point[] points_for_complicated_shape = { m_position };
                                m_polygon.Points = new PointCollection(points_for_complicated_shape);
                                m_polygon.Points.Add(new Point(e.GetPosition(canvas).X, e.GetPosition(canvas).Y));
                            }
                            break;
                        case ECurrentTool.Heart:
                            DrawShape(ref m_heart, canvas, colorPicker1.SelectedColor);
                            break;
                        case ECurrentTool.FivePointStar:
                            DrawShape(ref m_FivePointStar, canvas, colorPicker1.SelectedColor);
                            break;
                    }

                    
                }
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                if (ArrowButton.IsChecked == true && selectedShape != null)
                {
                    double dx = e.GetPosition(canvas).X - m_position.X;
                    double dy = e.GetPosition(canvas).Y - m_position.Y;
                    selectedShape.Margin = new Thickness(selectedShape.Margin.Left + dx, selectedShape.Margin.Top + dy, 0, 0);
                    m_position = e.GetPosition(canvas);
                }

                

                if (pencil.IsChecked == true)
                {
                    Line line = new Line();
                    line.Stroke = SystemColors.WindowFrameBrush;
                    line.X1 = m_position.X;
                    line.Y1 = m_position.Y;
                    line.X2 = e.GetPosition(canvas).X;
                    line.Y2 = e.GetPosition(canvas).Y;
                    line.Stroke =  new SolidColorBrush(colorPicker1.SelectedColor);
                    m_position = e.GetPosition(canvas);
                    canvas.Children.Add(line);
                }
                else
                {
                    if (m_CurrentTool == ECurrentTool.Line && m_line != null)
                    {
                        m_line.X1 = m_position.X;
                        m_line.Y1 = m_position.Y;

                        if(!flg_ShiftIsPressed)
                        {
                            m_line.X2 = e.GetPosition(canvas).X;
                            m_line.Y2 = e.GetPosition(canvas).Y;
                        }
                        else
                        {
                            if((Math.Abs(m_position.X - e.GetPosition(canvas).X)) > (Math.Abs(m_position.Y - e.GetPosition(canvas).Y)))
                            {
                                m_line.X2 = e.GetPosition(canvas).X;
                                m_line.Y2 = m_position.Y;
                            }
                            else
                            {
                                m_line.X2 = m_position.X;
                                m_line.Y2 = e.GetPosition(canvas).Y;
                            }
                        }
                    }

                    if (m_CurrentTool == ECurrentTool.Ellipse && m_ellipse != null)
                    {
                        m_ellipse.Margin = new Thickness(
                            Math.Min(m_position.X, e.GetPosition(canvas).X),
                            Math.Min(m_position.Y, e.GetPosition(canvas).Y), 0, 0);

                        if (!flg_ShiftIsPressed)
                        {
                            m_ellipse.Width = Math.Abs(e.GetPosition(canvas).X - m_position.X);
                            m_ellipse.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                        else
                        {
                            m_ellipse.Width = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                            m_ellipse.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                    }

                    if(m_CurrentTool == ECurrentTool.Rectangle && m_rectangle != null)
                    {
                        m_rectangle.Margin = new Thickness(Math.Min(m_position.X, e.GetPosition(canvas).X), Math.Min(m_position.Y, e.GetPosition(canvas).Y), 0, 0);

                        if (!flg_ShiftIsPressed)
                        {
                            m_rectangle.Width = Math.Abs(e.GetPosition(canvas).X - m_position.X);
                            m_rectangle.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                        else
                        {
                            m_rectangle.Width = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                            m_rectangle.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                    }

                    if (m_CurrentTool == ECurrentTool.RoundedRectangle && m_rectangle != null)
                    {
                        m_rectangle.Margin = new Thickness(Math.Min(m_position.X, e.GetPosition(canvas).X), Math.Min(m_position.Y, e.GetPosition(canvas).Y), 0, 0);

                        if (!flg_ShiftIsPressed)
                        {
                            m_rectangle.Width = Math.Abs(e.GetPosition(canvas).X - m_position.X);
                            m_rectangle.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                        else
                        {
                            m_rectangle.Width = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                            m_rectangle.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                    }

                    if (m_CurrentTool == ECurrentTool.Triangle && m_triangle != null)
                    {
                        if (!flg_ShiftIsPressed)
                        {
                            m_triangle.Points[0] = new Point(m_position.X, e.GetPosition(canvas).Y);
                            m_triangle.Points[1] = new Point((m_position.X + e.GetPosition(canvas).X) / 2, m_position.Y);
                            m_triangle.Points[2] = e.GetPosition(canvas);
                        }
                        else
                        {
                            m_triangle.Points[0] = new Point(m_position.X, e.GetPosition(canvas).Y);
                            m_triangle.Points[1] = new Point((m_position.X + e.GetPosition(canvas).X) / 2, (m_position.Y + e.GetPosition(canvas).Y) / 2);
                            m_triangle.Points[2] = e.GetPosition(canvas);
                        }
                        
                    }
                    if(m_CurrentTool == ECurrentTool.Polygon && m_polygon != null)
                    {
                        var list = m_polygon.Points.ToList();
                        list[list.Count-1] = new Point(e.GetPosition(canvas).X, e.GetPosition(canvas).Y);
                        m_polygon.Points = new PointCollection(list.ToArray());
                    }

                    if(m_CurrentTool == ECurrentTool.Heart && m_heart != null)
                    {
                        m_heart.Margin = new Thickness(Math.Min(m_position.X, e.GetPosition(canvas).X), Math.Min(m_position.Y, e.GetPosition(canvas).Y), 0, 0);
                        if (!flg_ShiftIsPressed)
                        {
                            m_heart.Width = Math.Abs(e.GetPosition(canvas).X - m_position.X);
                            m_heart.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                        else
                        {
                            m_heart.Width = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                            m_heart.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                    }
                    if (m_CurrentTool == ECurrentTool.FivePointStar && m_FivePointStar != null)
                    {
                        m_FivePointStar.Margin = new Thickness(Math.Min(m_position.X, e.GetPosition(canvas).X), Math.Min(m_position.Y, e.GetPosition(canvas).Y), 0, 0);
                        if (!flg_ShiftIsPressed)
                        {
                            m_FivePointStar.Width = Math.Abs(e.GetPosition(canvas).X - m_position.X);
                            m_FivePointStar.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                        else
                        {
                            m_FivePointStar.Width = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                            m_FivePointStar.Height = Math.Abs(e.GetPosition(canvas).Y - m_position.Y);
                        }
                    }
                        
                }
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            m_ellipse = null;
            m_heart = null;
            m_FivePointStar = null;
            selectedShape = null;
            if (m_CurrentTool == ECurrentTool.Polygon && m_polygon != null)
            {
                Point point = new Point(e.GetPosition(canvas).X, e.GetPosition(canvas).Y);
                m_polygon.Points.Add(point);
            }
            else
            {
                m_polygon = null;
            }
        }

        private void ArrowButton_Checked(object sender, RoutedEventArgs e)
        {
            if(ArrowButton.IsChecked == true)
            {
                canvas.Cursor = Cursors.Arrow;
            }
            
            if(pencil.IsChecked == true)
            {
                canvas.Cursor = Cursors.Pen;
            }
        }

        private void ArrowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            canvas.Cursor = Cursors.Cross;
        }
         
        private void DrawShape<T>(ref T shape, Canvas canvas, Color color) where T : Shape, new()
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(color);
            shape = new T()
            {
                Fill = new SolidColorBrush(((MainViewModel)DataContext).BackgroundColor),
                Stroke = solidColorBrush
            };

            SubscribeOnMouseDownEvent(ref shape, canvas);
            canvas.Children.Add(shape);

        }

        private void SubscribeOnMouseDownEvent<T>(ref T shape, Canvas canvas) where T : Shape
        {
            shape.MouseDown += (o, args) =>
            {
                if (ArrowButton.IsChecked == true || filling_tool.IsChecked == true)
                {
                    canvas.Children.Remove((T)o);
                    canvas.Children.Add((T)o);
                    selectedShape = o as Shape;
                }
            };
        }

        private void NewSheet_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.RemoveRange(0, canvas.Children.Count);
        }

        private void FillingButton_Checked(object sender, RoutedEventArgs e)
        {
            canvas.Cursor = Cursors.Cross;
        }

        private void FillingButton_Unchecked(object sender, RoutedEventArgs e)
        {
            canvas.Cursor = Cursors.Arrow;
        }
    }
}
