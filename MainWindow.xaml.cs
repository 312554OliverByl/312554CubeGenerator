/* March 22, 2019
 * Oliver Byl
 * Cube generator.
 */
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

namespace _312554Checkerboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private const int TILE_SIZE = 80;
        private const int CUBE_SIZE = 4;

        public MainWindow()
        {
            InitializeComponent();

            CubeGenerator generator = new CubeGenerator();
            generator.TileSize = 80;
            generator.CubeSize = 4;

            canvas.Children.Add(generator.Generate());
            /*//Generate the top side.
            RotateTransform topRotate = new RotateTransform();
            topRotate.Angle = 45;
            ScaleTransform topScale = new ScaleTransform();
            topScale.ScaleY = 0.5;
            TranslateTransform topTranslate = new TranslateTransform();
            topTranslate.X = 400;
            topTranslate.Y = 40;

            TransformGroup topTransforms = new TransformGroup();
            topTransforms.Children.Add(topRotate);
            topTransforms.Children.Add(topScale);
            topTransforms.Children.Add(topTranslate);
            generateSide(topTransforms, Brushes.LightGray, true);

            //Generate the left side.
            SkewTransform leftSkew = new SkewTransform();
            leftSkew.AngleY = 21.4;
            ScaleTransform leftScale = new ScaleTransform();
            leftScale.ScaleX = 0.71;
            leftScale.ScaleY = 0.9;
            TranslateTransform leftTranslate = new TranslateTransform();
            leftTranslate.X = 173;
            leftTranslate.Y = 153;

            TransformGroup leftTransforms = new TransformGroup();
            leftTransforms.Children.Add(leftSkew);
            leftTransforms.Children.Add(leftScale);
            leftTransforms.Children.Add(leftTranslate);
            generateSide(leftTransforms, Brushes.DarkGray, false);

            //Generate the right side.
            SkewTransform rightSkew = new SkewTransform();
            rightSkew.AngleY = -21.4;
            ScaleTransform rightScale = new ScaleTransform();
            rightScale.ScaleX = 0.71;
            rightScale.ScaleY = 0.9;
            TranslateTransform rightTranslate = new TranslateTransform();
            rightTranslate.X = 400;
            rightTranslate.Y = 265;

            TransformGroup rightTransforms = new TransformGroup();
            rightTransforms.Children.Add(rightSkew);
            rightTransforms.Children.Add(rightScale);
            rightTransforms.Children.Add(rightTranslate);
            generateSide(rightTransforms, Brushes.Gray, true);*/
        }
        
        //Generates a side with certain transformations and a certain "white" color.
        private void generateSide(TransformGroup transformations, Brush whiteColor, bool reflectColors)
        {
            Canvas side = new Canvas();
            side.RenderTransform = transformations;

            for (int yTile = 0; yTile < CUBE_SIZE; yTile++)
            {
                for(int xTile = 0; xTile < CUBE_SIZE; xTile++)
                {
                    int xOffset = (yTile % 2 == 0 ? 0 : 1) + (reflectColors ? 0 : 1);
                    Brush color = Brushes.Black;
                    if ((xTile + xOffset) % 2 == 0)
                        color = whiteColor;

                    Rectangle rectangle = new Rectangle
                    {
                        Width = TILE_SIZE,
                        Height = TILE_SIZE,
                        Fill = color
                    };
                    Canvas.SetLeft(rectangle, xTile * TILE_SIZE);
                    Canvas.SetTop(rectangle, yTile * TILE_SIZE);
                    side.Children.Add(rectangle);
                }
            }
            
            canvas.Children.Add(side);
        }
    }
}