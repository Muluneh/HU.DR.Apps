using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HU.DSP.Maths
{

    public class Operators
    {
        //in-place bit reverse shuffling of data
        List<Complex> SWAP(List<Complex> x,int npt)
        {
            int j = 1;
            int k = 0;
            for(int i=1;i<npt;++i)
            {
                if(i<j)
                {
                    double tr = x[j].real;
                    double ti = x[j].imag;
                    x[j].real= x[i].real;
                    x[j].imag= x[i].imag;
                    x[i].real = tr;
                    x[i].imag = ti;
                    k = npt / 2;
                    while (k < j)
                    {
                        j = j - k;
                        k = k / 2;
                    }

                }
                else
                {
                    k = npt / 2;
                    while(k<j)
                    {
                        j = j - k;
                        k = k / 2;
                    }
                }
                j = j + k;
            }
            return x;
        }

        //Function computes the DFT of a sequence using radix2 FFT
        //data -> float array that represent the array of complex samples
        //npt -> number of complex samples (N^2 order number) 
        //isign -> 1 to calculate FFT and -1 to calculate Reverse FFT
        List<Complex> fft(List<Complex> data, int npt, int isign)
        {

            //perform fft or ifft computation for each stage
            //in-place bit reverse shuffling of data
            data = SWAP(data, npt);


            int le,le1,ip;
            double ur, ui, wr, wi,tr,ti,temp;
            //calculate the number of stages: m=log2(npt),
            int m = 0;
            int irem = npt;
            while(irem>1)
            {
                irem = irem / 2;
                m = m + 1;
            }

            //perform the FFT computation for each stage
            for(int l=1;l<=m;l++)
            {
                le = (int)Math.Pow(2, l);
                le1 = le / 2;
                ur = 1.0;
                ui = 0;
                wr = Math.Cos(2*Math.PI / le);
                wi = isign * Math.Sin(2 * Math.PI / le);
                for(int j=1;j<= le1; ++j)
                {
                    int i = j;
                    while(i<=npt)
                    {
                        ip = i + le1;
                        tr = data[ip].real*ur-data[ip].imag*ui;
                        ti = data[ip].imag*ur-data[ip].real*ui;
                        data[ip].real = data[i].real - tr;
                        data[ip].imag = data[i].imag - ti;
                        data[i].real = data[i].real + tr;
                        data[i].imag = data[i].imag + ti;
                        i = i + le;
                    }
                    temp = ur * wr - ui * wi;
                    ui = ui * wr + ur * wi;
                    ur = temp;
                }
            }
            //if inverse fft is desired divide each coefficient by npt
            if(isign==-1)
            {
                  for(int i=1;i<= npt;++i)
                {
                    data[i].real = data[i].real / npt;
                    data[i].imag = data[i].imag / npt;
                }
            }

            return data;
        }
        List<Complex> dft(List<Complex> data, int npt, int isign)
        {

            //perform fft or ifft computation for each stage
            List<Complex> data_out = new List<Complex>();

            double  wr, wi, tr, ti;
     


                for (int k = 0; k < npt; k++)
                {
                
                    Complex datax= new Complex(0.0,0.0);
                    data_out.Add(datax);
                 for (int n = 0;n<npt;n++)
                    {
                        wr = Math.Cos(2 * Math.PI*n*k/npt);
                        wi = isign *(-1) *Math.Sin(2 * Math.PI*n*k/npt);
     
                        tr = data[n].real * wr + data[n].imag * wi;
                        ti = data[n].imag * wr + data[n].real * wi;

                        data_out[k].real = data_out[k].real + tr;
                        data_out[k].imag = data_out[k].imag + ti;
                    }
                }
            
            //if inverse fft is desired divide each coefficient by npt
            if (isign == -1)
            {
                for (int i = 1; i <= npt; ++i)
                {
                    data_out[i].real = data[i].real / npt;
                    data_out[i].imag = data[i].imag / npt;
                }
            }

            return data_out;
        }

       public List<List<Complex>> fft2d(List<List<double>> img,int r, int c, int inverse)
        {
            List<List<Complex>> img_fft = new List<List<Complex>>();
            img_fft = doubletocomplex(img, r, c);
            
            
           // int log2w = r >> 1;
           // int log2h = c >> 1;
            // Perform FFT on each row
            for (int y = 0; y < c; ++y)
            {
                List<Complex> row = new List<Complex>();
                for (int x = 0; x < r; ++x)
                {
                    //int rb = rev_bits(x, r);
                    row.Add(img_fft[x][y]);
                }
                //row = fft(row, log2w, inverse);
                row = dft(row, r, inverse);
                for (int x = 0; x < r; ++x)
                {
                    img_fft[x][y] = row[x];
                }
            }

            // Perform FFT on each column
            for (int x = 0; x < r; ++x)
            {
                List<Complex> column = new List<Complex>();
                for (int y = 0; y < c; ++y)
                {
                   // int rb = rev_bits(y, c);
                    column.Add(img_fft[x][y]);
                }
                //column = fft(column,log2h, inverse);
                column = dft(column, c, inverse);
                for (int y = 0; y < c; ++y)
                {
                    img_fft[x][y] = column[y];
                }
            }



            return img_fft;
        }
       public List<List<double[]>> PH_trinion_typeI_non_localized(List<List<double[]>> GLM,int len_x,int len_y)
        {
            List<List<double[]>> Trgb = new List<List<double[]>>();
            List<List<double>> G = new List<List<double>>();
            List<List<double>> L = new List<List<double>>();
            List<List<double>> M = new List<List<double>>();
            for (int x = 0; x < len_x; x++)
            {
                List<double> g_value = new List<double>();
                List<double> l_value = new List<double>();
                List<double> m_value = new List<double>();
                for (int y = 0; y < len_y; y++)
                {
                    g_value.Add(GLM[x][y][0]);
                    l_value.Add(GLM[x][y][1]);
                    m_value.Add(GLM[x][y][2]);


                }
                G.Add(g_value);
                L.Add(l_value);
                M.Add(m_value);
            }
            List<List<Complex>>  term1= fft2d(G, len_x,len_y, 1);
            List<List<Complex>>  term2= fft2d(L, len_x, len_y, 1);
            List<List<Complex>>  term3= fft2d(M, len_x, len_y, 1);

            for (int x = 0; x < len_x; x++)
            {
                List<double[]> row_Trgb = new List<double[]>();
                for (int y = 0; y < len_y; y++)
                {
                    double[] Trgb_value = new double[3];
                    Trgb_value[0] = term1[x][y].real + (-(term3[x][y].imag) + (term2[x][y].imag)) /Math.Sqrt(2.0);
                    Trgb_value[1] = term2[x][y].real + ((term1[x][y].imag) + (term3[x][y].imag)) / Math.Sqrt(2.0);
                    Trgb_value[2] = term3[x][y].real + (-(term1[x][y].imag) + (term2[x][y].imag)) / Math.Sqrt(2.0);

                    row_Trgb.Add(Trgb_value);
                }
                Trgb.Add(row_Trgb);
            }

            return Trgb;
        }
        public List<double[]> reshape(List<List<double[]>> data)
        {
            List<double[]> dataReshaped = new List<double[]>();
            double[] R = new double[9];
            double[] G = new double[9];
            double[] B = new double[9];
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    R[k] = data[i][j][0];
                    G[k] = data[i][j][1];
                    B[k] = data[i][j][2];
                    k++;

                }
            }
            dataReshaped.Add(R);
            dataReshaped.Add(G);
            dataReshaped.Add(B);
            return dataReshaped;
        }
        public List<List<double[]>> Vectorial_PCA_Transform_with_trinions(List<List<double[]>> GLM, int len_x, int len_y)
        {
            List<double[]> dataReshaped = new List<double[]>();
            dataReshaped = reshape(GLM);
            double[] mean = new double[3];

            //mean for each color value
            for (int i = 0; i < 3; i++)
            {
                double val = 0;
                for (int j = 0; j < 9; j++)
                {

                    val = val + dataReshaped[i][j];

                }

                mean[i] = val / 9;
            }
            // substract the mean from each color value  to calculate the covariance
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    dataReshaped[i][j] = dataReshaped[i][j] - mean[i];

                }
            }

            int rows1 = dataReshaped[0].Length;
            int cols1 = dataReshaped.Count;
            double[] Mat1 = new double[rows1 * cols1];


            
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    Mat1[i * cols1 + j] = dataReshaped[j][i];
                }
            }

            //tanspose
            double[] Mat2 = new double[rows1 * cols1];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    Mat2[j * rows1 + i] = Mat1[i * cols1 + j];
                }
            }

            int rows2 = cols1;
            int cols2 = rows1;
            // calculate the covariance 
            List<double[]> cov = new List<double[]>();
            cov = MatrixProduct(Mat2,Mat1, rows2,cols2,rows1,cols1);

            //mean for each color value
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    cov[i][j] = cov[i][j] / (9-1);

                }
            }
            //eigen value calculation
            double eig1 = 0.0;
            double eig2 = 0.0;
            double eig3 = 0.0;
            double p1 = Math.Pow(cov[0][1], 2) + Math.Pow(cov[0][2], 2) + Math.Pow(cov[1][2], 2);
            if (p1 == 0)
            {
                eig1 = cov[0][0];
                eig2 = cov[1][1];
                eig3 = cov[2][2];
            }
            else
            {
                double q = (cov[0][0]+ cov[1][1]+ cov[2][2])/ 3;   // trace means sum of diagonal elements
                List<double[]> qI = new List<double[]>();
                for (int i = 0; i < 3; i++)
                {
                    double[] qI_val = new double[3];
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == j)
                        {
                            qI_val[j] = q;
                        }
                        else
                        {
                            qI_val[j] = 0.0;
                        }

                    }
                    qI.Add(qI_val);
                }
                double p2 = Math.Pow((cov[0][0] - q),2) + Math.Pow((cov[1][1] - q), 2) + Math.Pow((cov[2][2] - q), 2) + (2*p1);
                double P = Math.Sqrt(p2/6);

                List<double[]> B = new List<double[]>();
                for (int i = 0; i < 3; i++)
                {
                    double[] B_val = new double[3];
                    for (int j = 0; j < 3; j++)
                    {
                        B_val[j] =(1/P) *(cov[i][j] - qI[i][j]);
                    }
                    B.Add(B_val);
                }
                // find the determinate of B
                double r = MatrixDeterminant(B)/ 2;
                if(r==Double.NaN)
                {

                }
                double phi;

                if (r <= -1)
                {
                    phi = Math.PI/ 3;
                }
                else if (r >= 1)
                {
                    phi = 0;
                }
                else
                {
                    phi = (Math.Acos(r))/ 3;
                }

                eig1 = q + (2* P* Math.Cos(phi));
                eig3 = q + (2* P* Math.Cos(phi + (2* Math.PI/ 3)));
                eig2 = 3 * q - (eig1 + eig3);
            }

            //EIGEN VECTOR CALCULATION
            List<double[]> l1 = new List<double[]>();
            List<double[]> l2 = new List<double[]>();
            List<double[]> l3 = new List<double[]>();
            for (int i = 0; i < 3; i++)
            {
                double[] l1_val = new double[3];
                double[] l2_val = new double[3];
                double[] l3_val = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        l1_val[j] = eig1;
                        l2_val[j] = eig2;
                        l3_val[j] = eig3;
                    }
                    else
                    {
                        l1_val[j] = 0.0;
                        l2_val[j] = 0.0;
                        l3_val[j] = 0.0;
                    }

                }
                l1.Add(l1_val);
                l2.Add(l2_val);
                l3.Add(l3_val);
            }
            List<double[]> a1 = new List<double[]>();
            List<double[]> a2 = new List<double[]>();
            List<double[]> a3 = new List<double[]>();
            for (int i = 0; i < 3; i++)
            {
                double[] a1_val = new double[3];
                double[] a2_val = new double[3];
                double[] a3_val = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    a1_val[j] = (cov[i][j] - l1[i][j]);
                    a2_val[j] = (cov[i][j] - l2[i][j]);
                    a3_val[j] = (cov[i][j] - l3[i][j]);
                }
                a1.Add(a1_val);
                a2.Add(a2_val);
                a3.Add(a3_val);
            }

            List<double[]> a21 = new List<double[]>();
            List<double[]> a22 = new List<double[]>();
            List<double[]> a23 = new List<double[]>();
             rows1 = 3;
             cols1 = 3;
            double[] Mata1 = new double[rows1 * cols1];
            double[] Mata2 = new double[rows1 * cols1];
            double[] Mata3 = new double[rows1 * cols1];
            
            for (int i = 0; i < cols1; i++)
            {
                for (int j = 0; j < rows1; j++)
                {
                    Mata1[i * rows1 + j] = a1[i][j];
                    Mata2[i * rows1 + j] = a2[i][j];
                    Mata3[i * rows1 + j] = a3[i][j];
                }
            }

            a21 = MatrixProduct(Mata2, Mata3, 3, 3, 3, 3);
            a22 = MatrixProduct(Mata1, Mata3, 3, 3, 3, 3);
            a23 = MatrixProduct(Mata1, Mata2, 3, 3, 3, 3);

            double[] m1 =new double[3];
            double[] m2 = new double[3];
            double[] m3 = new double[3];

            for (int i = 0; i < 3; i++)
            {
                m1[i] = 0.0;
                m2[i] = 0.0;
                m3[i] = 0.0;
                for (int j = 0; j < 3; j++)
                {
                    m1[i] = m1[i] + a21[i][j];
                    m2[i] = m2[i] + a22[i][j];
                    m3[i] = m3[i] + a23[i][j];
                }
                m1[i] = m1[i] / 3;
                m2[i] = m2[i] / 3;
                m3[i] = m3[i] / 3;
            }



            double[] vt1 = new double[3];
            double[] vt2 = new double[3];
            double[] vt3 = new double[3];
            for(int i=0;i<3;i++)
            {
                vt1[i] =a21[i][i] - m1[i];
                vt2[i] =a22[i][i] - m2[i]; 
                vt3[i] =a23[i][i] - m3[i];
            }
            double[] v1 = new double[3];
            double[] v2 = new double[3];
            double[] v3 = new double[3];

            if (vt1.Max()== vt1[0])
            {
                for (int i = 0; i < 3; i++)
                {
                    v1[i] = a21[0][i];
                }
            }
            else if(vt1.Max() == vt1[1])
            {
                for (int i = 0; i < 3; i++)
                {
                    v1[i] = a21[1][i];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    v1[i] = a21[2][i];
                }
            }

            if (vt2.Max() == vt2[0])
            {
                for (int i = 0; i < 3; i++)
                {
                    v2[i] = a22[0][i];
                }
            }
            else if(vt2.Max() == vt2[1])
            {
                for (int i = 0; i < 3; i++)
                {
                    v2[i] = a22[1][i];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    v2[i] = a22[2][i];
                }
            }
            if (vt3.Max() == vt3[0])
            {
                for (int i = 0; i < 3; i++)
                {
                    v3[i] = a23[0][i];
                }
            }
            else if(vt3.Max() == vt3[1])
            {
                for (int i = 0; i < 3; i++)
                {
                    v3[i] = a23[1][i];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    v3[i] = a23[2][i];
                }
            }

           double N1 = Math.Sqrt((Math.Pow(v1[0], 2) + Math.Pow(v1[1], 2) + Math.Pow(v1[2],2)));
           double N2 = Math.Sqrt((Math.Pow(v2[0],2) + Math.Pow(v2[1],2) + Math.Pow(v2[2],2)));
           double N3 = Math.Sqrt((Math.Pow(v3[0],2) + Math.Pow(v3[1],2) + Math.Pow(v3[2],2)));



              double[] Ve1 = new double[3];
              double[] Ve2 = new double[3];
              double[] Ve3 = new double[3];
            List<double[]> Eig_Vectors = new List<double[]>();
            for (int i = 0; i < 3; i++)
            {
                //double[] V_val = new double[3];
                Ve1[i] = v1[i] / N1;
                Ve2[i] = v2[i] / N2;
                Ve3[i] = v3[i] / N3;
                if (N1 == 0)
                {
                    Ve1[i] = 0;
                }
                if (N2 == 0)
                {
                    Ve2[i] = 0;
                }
                if (N3==0)
                {
                    Ve3[i] = 0;
                }
            }
            Eig_Vectors.Add(Ve1);
            Eig_Vectors.Add(Ve2);
            Eig_Vectors.Add(Ve3);
            // COMPUTING THE PCA

            List<double[]> Mx = new List<double[]>();
            for (int i = 0; i < 3; i++)
            {
               double[] Mx_val = new double[9];
                for (int j = 0; j < 9; j++)
                {

                    Mx_val[j] = mean[i];

                }
                Mx.Add(Mx_val);
            }

            rows1 = dataReshaped[0].Length;
            cols1 = dataReshaped.Count;
            Mat1 = new double[rows1 * cols1];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    Mat1[i * cols1 + j] = dataReshaped[j][i];
                }
            }
            rows2 = Eig_Vectors[0].Length;
            cols2 = Eig_Vectors.Count;
            Mat2 = new double[rows2 * cols2];
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    Mat2[i * cols2 + j] = Eig_Vectors[j][i];
                }
            }
            
            // calculate the covariance 
            List<double[]> PCA = new List<double[]>();
            PCA = MatrixProduct(Mat1, Mat2, rows1, cols1, rows2, cols2);

            List<double[]> PCA_new = new List<double[]>();
            for (int i = 0; i < cols2; i++)
            {
                double[] val = new double[rows1];
                for (int j = 0; j < rows1; j++)
                {
                    val[j] = (PCA[j][i] + Mx[i][j]);
                }
                PCA_new.Add(val);
            }


            List <List<double[]>> PCA_data = new List<List<double[]>>();
            

            
            for (int i = 0; i < PCA_new.Count; i++)
            {
                List<double[]> PCA_val = new List<double[]>();
                for (int k = 0; k < 3; k++)
                {
                    double[] RGB = new double[3];
                    RGB[0] = PCA_new[i][k];
                    RGB[1] = PCA_new[i][3*1+k];
                    RGB[2] = PCA_new[i][3*2+k];
                    PCA_val.Add(RGB);
                }
                PCA_data.Add(PCA_val);
            }
            
            return PCA_data;
        }
        List<List<Complex>> doubletocomplex(List<List<double>> img,int y,int x)
        {
            List<List<Complex>> comp = new List<List<Complex>>();
            for (int i = 0; i < x; i++)
            {
                List<Complex> comp_list = new List<Complex>();
                for (int j = 0; j < y; j++)
                {
                    Complex comp_value = new Complex(img[i][j],0.0);
                   // comp_value[0].real = img[i][j];

                    //comp_value[0].imag = 0.0;
                    comp_list.Add(comp_value);
                }
                comp.Add(comp_list);
            }

            return comp;
        }


        public List<double[]> MatrixProduct(double[] Mat1, double[] Mat2,int rows1, int cols1, int rows2, int cols2)
        {
            double[] output = new double[rows1*cols2];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    output[i * cols2 + j] = 0;
                }
            }

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    for (int k = 0; k < rows2; k++)
                    {
                        output[i * cols2 + j] += Mat1[i* cols1 + k] * Mat2[k * cols2 + j];
                    }
                }
            }

            List <double[]> product=new List<double[]>();
            for (int i = 0; i < rows1; i++)
            {
                double[] pro = new double[cols2];
                for (int j = 0; j < cols2; j++)
                {
                    pro[j]= output[i * cols2 + j];
                }
                product.Add(pro);
            }

            return product;
        }
        public double MatrixDeterminant(List<double[]> data)
        {
            int rows = data[0].Length;
            int cols = data.Count;
            double[] Mat = new double[rows * cols];

            double d = 1;                 /* d is the determinant*/
            int i,j, sign = 1, change;   /* i is just a counter, sign takes care of sign
							             * changes, change takes care of row swapping */

         
            for (i = 0; i < cols; i++)
            {
                for (j = 0; j < rows; j++)
                {
                    Mat[i * rows + j] = data[i][j];
                }
            }
            int size = rows;
            if (size > 2)
            {
                /* if the matrix is 3 x 3 or bigger */
                for (i = 0; i < size - 1; i++)
                { /* go through the first n-1 columns */
                    change = 0;            /* reset change */
                    if (Mat[i * size + i] != 0)
                    {   /* if c[i,i] is non-zero */
                        for (j = i + 1; j < size; j++)
                        { /* do each row */
                            double mult = -Mat[j * size + i] / Mat[i * size + i];
                            Mat=MultiplyAdd(mult, rows, i, j, Mat);
                            /*make c[i,j] = 0*/
                        }
                    }
                    else
                    { /* c[i,] = 0 */
                        for (j = i + 1; j < size; j++)
                        {     /* go down the rows */
                            if (Mat[j * size + i] != 0)
                            {       /* looking for a non-zero entry */
                                Mat=Interchange(rows, i, j, Mat); /* if found switch rows */                           
                                sign *= -1; /* changes sign of det */
                                change = 1; /* let program know we found one */
                                i--;   /* start over again with c[i,i] != 0 */
                                break; /* we're done */
                            }
                        }
                        if (change != 1)
                        { /* if we couldn't find a non-zero entry */
                            return 0;     /* det is 0*/
                        }
                    }
                }
                for (i = 0; i < size; i++)
                {
                    d *= Mat[i * size + i]; /* take prod of all c[i,i] */
                }
                return d * sign; /* make sure to mupltiply by sign changes */
            }
            else
            {
                /* if it's 2x2 then the formula is this */
                return Mat[0] * Mat[3] - Mat[2] * Mat[1];
            }
        }
        public double[] Interchange(int rows, int row1, int row2, double[] Mat)
        {
            double temp;
            int i;

            for (i = 0; i < rows; i++)
            {
                temp = Mat[row1 * rows + i];
                Mat[row1 * rows + i] = Mat[row2 * rows + i];
                Mat[row2 * rows + i] = temp;
            }

            return Mat;
        }

        public double[] MultiplyAdd(double mult, int rows, int row1, int row2,double[]Mat)
        {
            int i;
            int size = rows;
            for (i = 0; i < rows; i++)
            {
                Mat[row2 * size + i] += mult * Mat[row1 * size + i];
            }
            return Mat;
        }
    }
}
