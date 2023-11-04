using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AsciiGen2
{
    public  class BitmapAscii : Form1
    {
        List<Color> colorList = new List<Color>();
        //int Xsize = 0;
        //int Ysize = 0;

        public BitmapAscii(int x, int y)
        {
            Xsize = x;
            Ysize = y;
        }




        public string Asciitize(Bitmap image)
        {
            double greyscale = 0;
            string asciiGrey = "";
            string asciiFinal = "";

            for(int h = 0; h < image.Height; h+= Ysize)
            {
                for(int w = 0; w < image.Width; w+= Xsize)
                {
                    GetColorList(image, w, h);
                    greyscale = AverageColor(colorList);
                    asciiGrey = GreyToString(greyscale);
                    asciiFinal += ToString(asciiGrey);

                }
                asciiFinal += "\r\n";
            }
            
            return asciiFinal;
        }

        
        public void GetColorList(Bitmap image, int w, int h)
        {
            Color color;
            
            for (int y = 0; y < Ysize; y++)
            {
                for(int x = 0; x < Xsize; x++)
                {
                    color = image.GetPixel(w,h);
                    colorList.Add(color);
                }
            }
        }
        double AveragePixel(int r, int g, int b)
        {
            double sumRGB = 0;
            double greyscale = 0;
            double normGrey = 0;
            //getting sum of the RGB values
            sumRGB = r + g + b;
            //breaking down sum into greyscale
            greyscale = sumRGB / 3;
            //breaking down into normalized greyscale 
            normGrey = greyscale / 255;
            return normGrey;
        }
        double AverageColor(List<Color> colors)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            int averageR = 0;
            int averageG = 0;
            int averageB = 0;
            double returnValue;
            foreach (Color color in colorList)
            {
                r += color.R;
                g += color.G;
                b += color.B;
            }
            colorList.Clear();
            //getting average RGB by divinding sum of red for each pixel in kernel
            averageR = Convert.ToInt32(r / (Xsize * Ysize));
            averageG = Convert.ToInt32(g / (Xsize * Ysize));
            averageB = Convert.ToInt32(b / (Xsize * Ysize));
            returnValue = AveragePixel(averageR, averageG, averageB);
            return returnValue;
        }

        string GreyToString(double pixel)
        {
            string[] asciiChars = new string[6] { "@", "#", "*", "+", ".", " " };
            string asciiStr = "";
            if (pixel >= 0 && pixel <= .16)
            {
                asciiStr = asciiChars[0];
            }
            else if (pixel > .16 && pixel <= .33)
            {
                asciiStr = asciiChars[1];
            }
            else if(pixel > .33 && pixel <= .5)
            {
                asciiStr = asciiChars[2];
            }
            else if(pixel > .5 && pixel <= .66)
            {
                asciiStr = asciiChars[3];
            }
            else if(pixel > .66 && pixel <= .80)
            {
                asciiStr = asciiChars[4];
            }
            else if(pixel > .80 && pixel <= 1)
            {
                asciiStr = asciiChars[5];
            }

            return asciiStr;
        }
        string ToString(string asciiStr)
        {
            string completeStr = "";
            completeStr += asciiStr;


            return completeStr;
        }
    }
}
