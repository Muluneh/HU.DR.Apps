using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HU.DSP.Maths;


namespace HU.DR.GUI.Aps
{
    public partial class frmDR : Form
    {
        string orginalImg = "";
        string grmImg = "";
        string textureImg = "";
        public frmDR()
        {
            InitializeComponent();
        }
        private void frmDR_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image File (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                orginalImg = open.FileName.ToString();

            }
            byte[] W = File.ReadAllBytes(orginalImg);
            picOrigianal.ImageLocation = orginalImg;
            picOrigianal.SizeMode = PictureBoxSizeMode.StretchImage;
            infoList.Items.Add("The Original image is loaded and ready for processing");
        }

        private void textureFutureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoList.Items.Add("Texture future extraction process is started");
            Bitmap img = new Bitmap(orginalImg);

            List<List<double>> K = new List<List<double>>();
            for (int x = 0; x < img.Width; x++)
            {
                List<double> K_val = new List<double>();
                for (int y = 0; y < img.Height; y++)
                {
                    double K3_value = new double();
                    Color pixelColor = img.GetPixel(x, y);
                    double[] rgb_value = new double[3];

                    rgb_value[0] = (double)pixelColor.R / (double)255;
                    rgb_value[1] = (double)pixelColor.G / (double)255;
                    rgb_value[2] = (double)pixelColor.B / (double)255;

                    K3_value = Math.Sqrt(Math.Pow(rgb_value[0], 2) + Math.Pow(rgb_value[1], 2) + Math.Pow(rgb_value[2], 2));
                    if (K3_value >= 0.047058)
                    {
                        K3_value = 1;
                    }
                    else
                    {
                        K3_value = 0;
                    }
                    K_val.Add(K3_value);
                }
                K.Add(K_val);
            }

            ColorConv glmConv = new ColorConv();
            List<List<double[]>> GLM = new List<List<double[]>>();
            List<List<double[]>> PCA_Q_Eax = new List<List<double[]>>();


            GLM = glmConv.rgb2glm(orginalImg);
            infoList.Items.Add("The RGB image is converted to GLM");

            int height = GLM[0].Count; // read from file
            int width = GLM.Count; // read from file



            List<List<double[]>> LLL_w = new List<List<double[]>>();
            List<List<double[]>> LLL_c = new List<List<double[]>>();

            for (int x = 0; x < width - 2; x++)
            {
                List<double[]> PCA_Q_Eax_val = new List<double[]>();
                for (int y = 0; y < height - 2; y++)
                {

                    List<List<double[]>> GLM9 = new List<List<double[]>>();
                    List<List<double[]>> LLL = new List<List<double[]>>();
                    for (int j = 0; j < 3; j++)
                    {
                        List<double[]> glm3 = new List<double[]>();
                        for (int i = 0; i < 3; i++)
                        {
                            double[] glm_value = new double[3];

                            glm_value[0] = GLM[x + j][y + i][0];
                            glm_value[1] = GLM[x + j][y + i][1];
                            glm_value[2] = GLM[x + j][y + i][2];
                            glm3.Add(glm_value);
                        }
                        GLM9.Add(glm3);
                    }
                    Operators dsp = new Operators();
                    LLL = dsp.PH_trinion_typeI_non_localized(GLM9, 3, 3);
                    List<List<double[]>> rrr = new List<List<double[]>>();



                    rrr = dsp.Vectorial_PCA_Transform_with_trinions(LLL, 3, 3);
                    //find the min and max value
                    Matrix mat = new Matrix();

                    double mi = mat.findMin(rrr);

                    //normalizing the value of LLç between 0 and 1
                    List<List<double[]>> rrrnew = new List<List<double[]>>();

                    foreach (List<double[]> l in rrr)
                    {
                        double mi1 = mat.findMin(l);
                        List<double[]> LLLnewval = new List<double[]>();
                        if (mi1 < 0.0)
                        {
                            foreach (double[] ll in l)
                            {
                                double[] llx = new double[ll.Length];
                                for (int i = 0; i < ll.Length; i++)
                                {

                                    llx[i] = ll[i] + Math.Abs(mi);
                                }

                                LLLnewval.Add(llx);
                            }
                            rrrnew.Add(LLLnewval);
                        }
                        else
                        {
                            LLLnewval = l;
                            rrrnew.Add(LLLnewval);
                        }

                    }

                    double ma = mat.findMax(rrrnew);
                    List<List<double[]>> rrrnew1 = new List<List<double[]>>();

                    foreach (List<double[]> l in rrrnew)
                    {
                        double ma1 = mat.findMax(l);
                        List<double[]> LLLnewval = new List<double[]>();
                        if (ma1 > 1)
                        {
                            for (int j = 0; j < l[0].Length; j++)
                            {
                                double[] llx = new double[l[0].Length];
                                for (int i = 0; i < l[0].Length; i++)
                                {

                                    llx[i] = l[j][i] / ma;
                                }

                                LLLnewval.Add(llx);
                            }
                            rrrnew1.Add(LLLnewval);
                        }
                        else
                        {
                            LLLnewval = l;
                            rrrnew1.Add(LLLnewval);
                        }
                    }

                    List<double[]> sum_mean = new List<double[]>();
                    List<double[]> Var_mean = new List<double[]>();
                    double[] CP = new double[3];
                    mat = new Matrix();
                    sum_mean = mat.sumMean(rrrnew1);
                    //Var_mean = mat.sumVariance(LLLnew, sum_mean);
                    //double[] vari = new double[3];
                    // vari = mat.Variance(LLLnew, sum_mean);
                    CP = mat.ClusterProminence(rrrnew1, sum_mean);
                    ///calculate PCA_Q_Eax_val
                    double[] PCA = new double[3];

                    double mask_k = K[x][y];
                    PCA[0] = (CP[0] / 9.456) * mask_k; //9.456;
                    PCA[1] = (CP[1] / 750000) * mask_k;// 750000;
                    PCA[2] = (CP[2] / 2890000) * mask_k;// 2890000;

                    if (PCA[0] > 1)
                    {
                        PCA[0] = 1;
                    }
                    if (PCA[1] > 1)
                    {
                        PCA[1] = 1;

                    }
                    if (PCA[2] > 1)
                    {
                        PCA[2] = 1;
                    }
                    PCA_Q_Eax_val.Add(PCA);
                }
                PCA_Q_Eax.Add(PCA_Q_Eax_val);
            }


            Bitmap pic = new Bitmap(width, height);
            for (int x = 0; x < width - 2; x++)
            {
                List<double[]> row_rgb = new List<double[]>();
                row_rgb = PCA_Q_Eax.ElementAt(x);
                for (int y = 0; y < height - 2; y++)
                {
                    double[] rgb_read = new double[3];
                    rgb_read = row_rgb.ElementAt(y);
                    pic.SetPixel(x, y, Color.FromArgb((int)(rgb_read[0] * 255), (int)(rgb_read[1] * 255), (int)(rgb_read[2] * 255)));
                }

            }
            picProcessed.Image = pic;
            picProcessed.SizeMode = PictureBoxSizeMode.StretchImage;
            infoList.Items.Add("Texture future extraction is successfully completed");
        }

        private void gLMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(orginalImg);
            ColorConv glmConv = new ColorConv();
            List<List<double[]>> GLM = new List<List<double[]>>();

            GLM = glmConv.rgb2glm(orginalImg);

            int height = GLM[0].Count; // read from file
            int width = GLM.Count; // read from file


            Bitmap pic = new Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                List<double[]> row_rgb = new List<double[]>();
                row_rgb = GLM.ElementAt(x);
                for (int y = 0; y < height; y++)
                {
                    double[] rgb_read = new double[3];
                    rgb_read = row_rgb.ElementAt(y);
                    pic.SetPixel(x, y, Color.FromArgb((int)(rgb_read[0] * 255), (int)(rgb_read[1] * 255), (int)(rgb_read[2] * 255)));
                }
            }
            picProcessed.Image = pic;
            picProcessed.SizeMode = PictureBoxSizeMode.StretchImage;
            infoList.Items.Add("The RGB image is converted to GLM");
        }

        private void cMYKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<List<double[]>> CMYK = new List<List<double[]>>();
            ColorConv cmykConv = new ColorConv();
            CMYK = cmykConv.rgb2cmyk(orginalImg);

            int height = CMYK[0].Count; // read from file
            int width = CMYK.Count; // read from file
            Bitmap pic = new Bitmap(width, height);


            for (int x = 0; x < width; x++)
            {
                List<double[]> row_rgb = new List<double[]>();
                row_rgb = CMYK.ElementAt(x);
                for (int y = 0; y < height; y++)
                {
                    double[] rgb_read = new double[3];
                    rgb_read = row_rgb.ElementAt(y);
                    pic.SetPixel(x, y, Color.FromArgb((int)(rgb_read[0] * 255), (int)(rgb_read[1] * 255), (int)(rgb_read[2] * 255)));
                }

            }
            picProcessed.Image = pic;
            picProcessed.SizeMode = PictureBoxSizeMode.StretchImage;
            infoList.Items.Add("The RGB image is converted to CMYK");
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(orginalImg);
            ColorConv grayConv = new ColorConv();
            Bitmap pic = new Bitmap(img.Width, img.Height);
            pic = grayConv.rgb2gray(orginalImg);
            picProcessed.Image = pic;
            picProcessed.SizeMode = PictureBoxSizeMode.StretchImage;
            infoList.Items.Add("The RGB image is converted to Gray Scale");
        }

        private void cBRCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorConv cbrcConv = new ColorConv();
            List<List<double[]>> CBCR = new List<List<double[]>>();

            CBCR = cbrcConv.rgb2ycbcr(orginalImg);
            int height = CBCR[0].Count; // read from file
            int width = CBCR.Count; // read from file


            Bitmap pic = new Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                List<double[]> row_rgb = new List<double[]>();
                row_rgb = CBCR.ElementAt(x);
                for (int y = 0; y < height; y++)
                {
                    double[] rgb_read = new double[3];
                    rgb_read = row_rgb.ElementAt(y);
                    pic.SetPixel(x, y, Color.FromArgb((int)(rgb_read[0] * 255), (int)(rgb_read[1] * 255), (int)(rgb_read[2] * 255)));
                }
            }
            picProcessed.Image = pic;
            picProcessed.SizeMode = PictureBoxSizeMode.StretchImage;
            infoList.Items.Add("The RGB image is converted to CBRC");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "Image File (*.jpg)|*.jpg";
            dialog.Filter = "Image File (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {


                picProcessed.Image.Save(dialog.FileName, ImageFormat.Jpeg);

            }
            infoList.Items.Add("The image is successfuly saved");
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void picProcessed_Click(object sender, EventArgs e)
        {

        }

        private void nN1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap img = new Bitmap(picProcessed.Image);

            int width = img.Width;
            int height = img.Height;
            List<List<double[]>> PCA = new List<List<double[]>>();
            for (int x = 0; x < width; x++)
            {
                List<double[]> img_val = new List<double[]>();
                for (int y = 0; y < height; y++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    double[] rgb_value = new double[3];

                    rgb_value[0] = (double)pixelColor.R / (double)255;
                    rgb_value[1] = (double)pixelColor.G / (double)255;
                    rgb_value[2] = (double)pixelColor.B / (double)255;

                    img_val.Add(rgb_value);
                }
                PCA.Add(img_val);
            }

            List<double[]> W1 = new List<double[]>();//3X5 Matrix weight between input and hiden layer
            List<double[]> B1 = new List<double[]>();//1X5 Matrix biase in hiden layer
            List<double> W2 = new List<double>();//5X1 Matrix weight between hiden and output layer
            double B2 = new double();// biase at the output layer
            B2 = -0.454;

            double[] W15 = new double[5];
            double[] W25 = new double[5];
            double[] W35 = new double[5];

            W15[0] = 0.4807;
            W15[1] = 0.5227;
            W15[2] = -0.2399;
            W15[3] = 0.3085;
            W15[4] = -0.3144;
            W1.Add(W15);
            W25[0] = 1.1178;
            W25[1] = 0.9293;
            W25[2] = -0.5976;
            W25[3] = -3.1806;
            W25[4] = -1.3383;
            W1.Add(W25);
            W35[0] = 5.8916;
            W35[1] = 2.6835;
            W35[2] = 0.4069;
            W35[3] = 4.4095;
            W35[4] = -0.1576;
            W1.Add(W35);

            double[] B = new double[5];
            B[0] = -0.8244;
            B[1] = -0.3323;
            B[2] = -0.9267;
            B[3] = -0.079;
            B[4] = -0.7836;
            B1.Add(B);

            W2.Add(1.0251);
            W2.Add(-1.2819);
            W2.Add(-0.5784);
            W2.Add(0.6746);
            W2.Add(-0.9176);

            List<List<double[]>> CL_O_1 = new List<List<double[]>>();
            List<List<double[]>> SSg_1 = new List<List<double[]>>();
            for (int x = 0; x < width; x++)
            {
                List<double[]> CL_O_1_val = new List<double[]>();
                List<double[]> SSg_val = new List<double[]>();

                for (int y = 0; y < height; y++)
                {


                    int rows1 = 1;
                    int cols1 = 3;
                    double[] MatPx = new double[rows1 * cols1];
                    for (int i = 0; i < rows1; i++)
                    {
                        for (int j = 0; j < cols1; j++)
                        {
                            MatPx[i * cols1 + j] = PCA[x][y][j];
                        }
                    }


                    int rows2 = 3;
                    int cols2 = 5;
                    double[] MatW1 = new double[rows2 * cols2];
                    for (int i = 0; i < rows2; i++)
                    {
                        for (int j = 0; j < cols2; j++)
                        {
                            MatW1[i * cols2 + j] = W1[i][j];
                        }
                    }
                    Operators ops = new Operators();


                    List<double[]> HI1 = new List<double[]>();
                    HI1 = ops.MatrixProduct(MatPx, MatW1, rows1, cols1, rows2, cols2);

                    List<double[]> HO1 = new List<double[]>();
                    double[] Ho = new double[5];
                    for (int i = 0; i < 5; i++)
                    {
                        HI1[0][i] = HI1[0][i] + B1[0][i];
                        Ho[i] = 2 / (1 + Math.Exp(-2 * HI1[0][i]));
                    }
                    HO1.Add(Ho);

                    rows1 = 1;
                    cols1 = 5;
                    double[] MatHo = new double[rows1 * cols1];
                    for (int i = 0; i < rows1; i++)
                    {
                        for (int j = 0; j < cols1; j++)
                        {
                            MatHo[i * cols1 + j] = HO1[i][j];
                        }
                    }


                    rows2 = 5;
                    cols2 = 1;
                    double[] MatW2 = new double[rows2 * cols2];
                    for (int i = 0; i < rows2; i++)
                    {
                        for (int j = 0; j < cols2; j++)
                        {
                            MatW2[i * cols2 + j] = W2[i];
                        }
                    }

                    List<double[]> CLO1 = new List<double[]>();
                    CLO1 = ops.MatrixProduct(MatHo, MatW2, rows1, cols1, rows2, cols2);

                    double[] CLO1_val = new double[1];
                    CLO1_val[0] = CLO1[0][0] + B2;

                    if (CLO1_val[0] > -0.1687)
                    {
                        CLO1_val[0] = 1;
                        double[] rgb_value = new double[3];

                        rgb_value[0] = 0.0;
                        rgb_value[1] = 0.0;
                        rgb_value[2] = 1.0;
                        SSg_val.Add(rgb_value);
                    }

                    else
                    {
                        CLO1_val[0] = 0;

                        double[] rgb_value = new double[3];
                        rgb_value[0] = 0.0;
                        rgb_value[1] = 0.0;
                        rgb_value[2] = 0.0;
                        SSg_val.Add(rgb_value);

                    }
                    CL_O_1_val.Add(CLO1_val);

                }
                SSg_1.Add(SSg_val);
                CL_O_1.Add(CL_O_1_val);
            }

            Bitmap pic = new Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                List<double[]> row_rgb = new List<double[]>();
                row_rgb = SSg_1.ElementAt(x);
                for (int y = 0; y < height; y++)
                {
                    double[] rgb_read = new double[3];
                    rgb_read = row_rgb.ElementAt(y);
                    pic.SetPixel(x, y, Color.FromArgb((int)(rgb_read[0] * 255), (int)(rgb_read[1] * 255), (int)(rgb_read[2] * 255)));
                }
            }
            picProcessed.Image = pic;
            picProcessed.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void sVMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nN2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nN3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void brightnesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
