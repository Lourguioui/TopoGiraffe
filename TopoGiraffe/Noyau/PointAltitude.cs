﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace TopoGiraffe.Noyau
{
    public class PointAltitude
    {
        public Point point;
        public double altitude;
        private Ellipse cercle;
        public Polygon triangle = new Polygon();
        private TypePoint typePoint;
        public TextBlock altitudeTextBlock = new TextBlock();
        static int nbPoints = 0;

        public PointAltitude(Point aPoint, double anAltitude, int index)
        {
            point = aPoint;
            altitude = anAltitude;

            if (index == 0)
            {
                typePoint = TypePoint.COTE;
            }
            else
            {
                typePoint = TypePoint.SOMMET;


            }


            altitudeTextBlock.Text = altitude.ToString();
            altitudeTextBlock.FontSize = 9;
            altitudeTextBlock.Height = 10;
            altitudeTextBlock.Width = 20;





        }



        public PointAltitude(double anAltitude, int index)
        {

            altitude = anAltitude;
            if (index == 0)
            {
                typePoint = TypePoint.COTE;
            }
            else
            {
                typePoint = TypePoint.SOMMET;
            }


            altitudeTextBlock.Text = altitude.ToString();
            altitudeTextBlock.FontSize = 9;
            altitudeTextBlock.Height = 10;
            altitudeTextBlock.Width = 20;



        }


        public void MakeTriangleSommet(Canvas canvas)
        {


            triangle.Points.Add(new Point(point.X - 5, point.Y + 5));
            triangle.Points.Add(new Point(point.X + 5, point.Y + 5));
            triangle.Points.Add(new Point(point.X, point.Y - 5));

            triangle.Fill = Brushes.Red;
            triangle.Width = 20;
            triangle.Height = 20;
            triangle.Stretch = Stretch.Fill;

            Canvas.SetLeft(triangle, point.X - (triangle.Width / 2));
            Canvas.SetTop(triangle, point.Y - (triangle.Height / 2));
            canvas.Children.Add(triangle);



            // adding text

            DisplayAltitudeTextBox(canvas);



        }

        public void MakeTriangleCote(Canvas canvas)
        {



            triangle.Points.Add(new Point(point.X - 5, point.Y + 5));
            triangle.Points.Add(new Point(point.X + 5, point.Y + 5));
            triangle.Points.Add(new Point(point.X, point.Y - 5));

            triangle.Fill = Brushes.Black;
            triangle.Width = 15;
            triangle.Height = 15;
            triangle.Stretch = Stretch.Fill;

            Canvas.SetLeft(triangle, point.X - (triangle.Width / 2));
            Canvas.SetTop(triangle, point.Y - (triangle.Height / 2));
            canvas.Children.Add(triangle);

            // adding altitude text
            DisplayAltitudeTextBox(canvas);


        }


        public void DrawShape(Canvas canvas)
        {
            if (this.typePoint == TypePoint.COTE)
            {
                MakeTriangleCote(canvas);
            }
            else
            {
                MakeTriangleSommet(canvas);
            }
        }


        public void DisplayAltitudeTextBox(Canvas canvas)
        {

            Canvas.SetLeft(altitudeTextBlock, point.X - (altitudeTextBlock.Width / 2));
            Canvas.SetTop(altitudeTextBlock, point.Y - (altitudeTextBlock.Height / 2) - 20);
            canvas.Children.Add(altitudeTextBlock);
        }


    }


    enum TypePoint { SOMMET, COTE }

}
