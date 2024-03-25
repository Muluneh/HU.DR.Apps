using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HU.DSP.Maths
{
    public class ColorConv
    {

        public List<List<double[]>> rgb2ycbcr(string imgfile)
        {
            Bitmap img = new Bitmap(imgfile);


            double Y;
            double Cb;
            double Cr;
            List<List<double[]>> CBCR = new List<List<double[]>>();

            for (int x = 0; x < img.Width; x++)   //don't worry about bmp.height/width+2 its for my project
            {
                List<double[]> row_cbcr = new List<double[]>();

                for (int y = 0; y < img.Height; y++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    double[] rgb_value = new double[3];
                    double[] cbcr_value = new double[3];

                    rgb_value[0] = (double)pixelColor.R;
                    rgb_value[1] = (double)pixelColor.G;
                    rgb_value[2] = (double)pixelColor.B;


                    double R = rgb_value[0];

                    double G = rgb_value[1];

                    double B = rgb_value[2];

                    Y =((0.257 * R) + (0.504 * G) + (0.098 * B) + 16);
                    Cb = (-(0.148 * R) - (0.291 * G) + (0.439 * B) + 128);
                    Cr = ((0.439 * R) - (0.368 * G) - (0.071 * B) + 128);

                    cbcr_value[0] = Y/255;
                    cbcr_value[1] = Cb/255;
                    cbcr_value[2] = Cr/255;
                    row_cbcr.Add(cbcr_value);


                }
                CBCR.Add(row_cbcr);
            }

            return CBCR;

        }
        public List<List<double[]>> readRGB(string imgfile)
        {

            Bitmap img = new Bitmap(imgfile);
            List<List<double[]>> RGB = new List<List<double[]>>();
            for (int x = 0; x < img.Width; x++)
            {
                List<double[]> row_rgb = new List<double[]>();

                for (int y = 0; y < img.Height; y++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    double[] rgb_value = new double[3];

                    rgb_value[0] = (double)pixelColor.R / (double)255;
                    rgb_value[1] = (double)pixelColor.G/ (double)255;
                    rgb_value[2] = (double)pixelColor.B/ (double)255;

                    row_rgb.Add(rgb_value);

                }
                RGB.Add(row_rgb);
            }

            return RGB;
        }
        public Bitmap rgb2gray(string imgfile)
        {
            Bitmap img = new Bitmap(imgfile);

            Bitmap pic = new Bitmap(img.Width, img.Height);

            for (int x = 0; x < img.Width; x++)
            {

                for (int y = 0; y < img.Height; y++)
                {
                    Color origimg = img.GetPixel(x, y);
                    int grayscale = (int)((origimg.R * 0.3) + (origimg.G * 0.59) + (origimg.B * 0.11));

                    Color newimg = Color.FromArgb(grayscale, grayscale, grayscale);

                    pic.SetPixel(x, y, newimg);
                }
            }
            return pic;
        }

        public List<List<double[]>> rgb2cmyk(string imgfile)
        {

            Bitmap img = new Bitmap(imgfile);
            List<List<double[]>> RGB = new List<List<double[]>>();
            List<List<double[]>> CMYK = new List<List<double[]>>();
            List<List<double>> K = new List<List<double>>();

            for (int x = 0; x < img.Width; x++)
            {
                List<double[]> row_rgb = new List<double[]>();
                List<double[]> row_cmyk = new List<double[]>();
                List<double> row_k = new List<double>();

                for (int y = 0; y < img.Height; y++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    double[] rgb_value = new double[3];
                    double[] cmyk_value = new double[3];
                    double max_k = 0;


                    //RGB values from 0 to 255
                    //CMY results from 0 to 1

                    rgb_value[0] = (double)pixelColor.R/ (double)255;
                    rgb_value[1] = (double)pixelColor.G/ (double)255;
                    rgb_value[2] = (double)pixelColor.B/ (double)255;

                    /*cmyk_value[0] = 1 - (pixelColor.R / 255);
                    cmyk_value[1] = 1 - (pixelColor.G / 255);
                    cmyk_value[2] = 1 - (pixelColor.B / 255);*/

                    max_k = rgb_value.Max();
                    if (max_k == 0)
                    {
                        max_k = 0;
                    }
                    else
                    {
                        max_k = (1 - max_k);
                    }

                    if (max_k == 1)
                    {

                        cmyk_value[0] = 0;
                        cmyk_value[1] = 0;
                        cmyk_value[2] = 0;
                    }
                    else
                    {

                        cmyk_value[0] = ((1 - rgb_value[0] - max_k) / (1 - max_k));
                        cmyk_value[1] = ((1 - rgb_value[1] - max_k) / (1 - max_k));
                        cmyk_value[2] = ((1 - rgb_value[2] - max_k) / (1 - max_k));
                    }

                    row_rgb.Add(rgb_value);
                    row_k.Add(max_k);

                    row_cmyk.Add(cmyk_value);
                }
                RGB.Add(row_rgb);
                K.Add(row_k);
                CMYK.Add(row_cmyk);
            }
          
            return CMYK;
        }
        public List<List<double[]>> rgb2glm(string imgfile)
        {
            Bitmap img = new Bitmap(imgfile);

            List<List<double[]>> RGB = new List<List<double[]>>();
            List<List<double[]>> CBCR = new List<List<double[]>>();
            List<List<double[]>> CMYK = new List<List<double[]>>();
            List<List<double[]>> GLM = new List<List<double[]>>();

            CBCR = rgb2ycbcr(imgfile);
            CMYK = rgb2cmyk(imgfile);
            RGB = readRGB(imgfile);

            for (int x = 0; x < img.Width; x++)
            {

                List<double[]> row_glm = new List<double[]>();

                for (int y = 0; y < img.Height; y++)
                {

                    double[] glm_value = new double[3];

                    glm_value[0] = RGB[x][y][1];
                    glm_value[1] = CBCR[x][y][0];
                    glm_value[2] = 1-CMYK[x][y][1];

                    row_glm.Add(glm_value);
                    if (x == 583 && y == 661)
                    {

                    }
                }
                GLM.Add(row_glm);
            }

            return GLM;
        }


    }
}
