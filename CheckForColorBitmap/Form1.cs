using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckForColorBitmap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var allPngs = Directory.GetFiles(@"C:\Users\kstaples\Documents\Projects\ILM Script\ILM\Images\","*.png", SearchOption.AllDirectories);
            foreach (var png in allPngs)
            {
                if (hasColor(@png))
                {
                    File.Delete(@png);
                }
            }
        }

        private bool hasColor(string path)
        {
            List<Color> listOfColors1 = new List<Color>();
            var img = new Bitmap(@path);

            FileInfo fi = new FileInfo(@path);
            for (var x = 1; x < img.Width; x++)
            {
                for (var y = 1; y < img.Height; y++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    var sumOfRGB = pixelColor.B + pixelColor.G + pixelColor.R;
                    var avgOfRGB = sumOfRGB / 3;
                    var valPixelB = Convert.ToDecimal(pixelColor.B);
                    var valPixelG = Convert.ToDecimal(pixelColor.G);
                    var valPixelR = Convert.ToDecimal(pixelColor.R);
                    if (valPixelR - avgOfRGB > 5 || valPixelG - avgOfRGB > 5 || valPixelB - avgOfRGB > 5)
                    {
                        Console.WriteLine("{0} has a color", fi, Name);
                        img.Dispose();
                        return true;
                    }
                }
            }

            img.Dispose();
            return false;
        }

    }

}
