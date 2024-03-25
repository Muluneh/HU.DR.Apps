using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HU.DSP.Maths
{
    public class Matrix
    {
       public double findMax(List<List<double[]>> data)
        {
            List<double> LLLmax = new List<double>();
            foreach (List<double[]> l in data)
            {
                foreach (double[] ll in l)
                {
                    double maxVal = ll[0];
                    for (int i = 1; i < ll.Length; i++)
                    {
                        if (ll[i] > maxVal)
                            maxVal = ll[i];
                    }
                    LLLmax.Add(maxVal);
                }

            }
            double ma = LLLmax.Max();
            return ma;
        }
        public double findMax(List<double[]> data)
        {
            List<double> LLLmax = new List<double>();

                foreach (double[] ll in data)
                {
                    double maxVal = ll[0];
                    for (int i = 1; i < ll.Length; i++)
                    {
                        if (ll[i] > maxVal)
                            maxVal = ll[i];
                    }
                    LLLmax.Add(maxVal);
                }


            double ma = LLLmax.Max();
            return ma;
        }
        public double findMin(List<List<double[]>> data)
        {
            List<double> LLLmin = new List<double>();
            foreach (List<double[]> l in data)
            {
                foreach (double[] ll in l)
                {
                    double minVal = ll[0];
                    for (int i = 1; i < ll.Length; i++)
                    {
                        if (ll[i] < minVal)
                            minVal = ll[i];
                    }
                    LLLmin.Add(minVal);
                }

            }
            double mi = LLLmin.Min();
            return mi;
        }
        public double findMin(List<double[]> data)
        {
            List<double> LLLmin = new List<double>();

                foreach (double[] ll in data)
                {
                    double minVal = ll[0];
                    for (int i = 1; i < ll.Length; i++)
                    {
                        if (ll[i] < minVal)
                            minVal = ll[i];
                    }
                    LLLmin.Add(minVal);
                }

         
            double mi = LLLmin.Min();
            return mi;
        }
        public List<double[]> sumMean(List<List<double[]>> data)
        {
            double[] sum_mean_row = new double[3];
            double[] sum_mean_col = new double[3];
            
            List<double[]> sum_mean = new List<double[]>();
            for (int i = 0; i < 3; i++)
            {
                double[] sum_mean_val = new double[2];
                sum_mean_row[i] = 0.0;
                sum_mean_col[i] = 0.0;
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        sum_mean_row[i] = sum_mean_row[i] + (j + 1) * data[i][j][k];
                        sum_mean_col[i] = sum_mean_col[i] + (j + 1) * data[i][k][j];
                    }
                }
                sum_mean_val[0] = sum_mean_row[i];
                sum_mean_val[1] = sum_mean_col[i];
                sum_mean.Add(sum_mean_val);
               // sum_mean[i] = (sum_mean_row[i] + sum_mean_col[i]) / 2;
            }

            return sum_mean;
        }
        public List<double[]> sumVariance(List<List<double[]>> data, List<double[]> sum_mean)
        {
            double[] sum_Var_row = new double[3];
            double[] sum_Var_col = new double[3];

            List<double[]> sum_Var = new List<double[]>();
            for (int i = 0; i < 3; i++)
            {
                double[] sum_Var_val = new double[2];
                sum_Var_row[i] = 0.0;
                sum_Var_col[i] = 0.0;
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        sum_Var_row[i] = sum_Var_row[i] + Math.Pow((i + 1- sum_mean[k][0]),2) * data[i][j][k];
                        sum_Var_col[i] = sum_Var_col[i] + Math.Pow((j + 1- sum_mean[k][1]),2) * data[i][j][k];
                    }
                }
                sum_Var_val[0] = sum_Var_row[i];
                sum_Var_val[1] = sum_Var_col[i];
                sum_Var.Add(sum_Var_val);
            }

            return sum_Var;
        }
        public double mean(List<List<double[]>> data)
        {
            double val = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        val = val +  data[i][j][k];
                    }
                }
            }
            val = val / 9;
            return val;
        }
        public double[] Variance(List<List<double[]>> data, List<double[]> sum_mean)
        {
            double valmean = mean(data);
            double[] sum_Var_row = new double[3];
            double[] sum_Var_col = new double[3];

            double[] sum_Var = new double[3];
            for (int i = 0; i < 3; i++)
            {
                double[] sum_Var_val = new double[2];
                sum_Var_row[i] = 0.0;
                sum_Var_col[i] = 0.0;
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        
                        sum_Var_row[i] = sum_Var_row[i] + Math.Pow((i + 1 - valmean), 2) * data[i][j][k];
                        sum_Var_col[i] = sum_Var_col[i] + Math.Pow((j + 1 - valmean), 2) * data[i][j][k];
                    }
                }
                
                sum_Var[i] = (sum_Var_row[i] + sum_Var_col[i]) / 2;
                
            }

            return sum_Var;
        }

        
        public double[] ClusterProminence(List<List<double[]>> data, List<double[]> sum_mean)
        {


            //List<double[]> CP = new List<double[]>();
            double[] CP_val = new double[3];
            CP_val[0] = 0.0;
            CP_val[1] = 0.0;
            CP_val[2] = 0.0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        CP_val[i] = CP_val[i] + 0.5 * Math.Pow(((j + 1) + (1 + k) - (sum_mean[i][0] + sum_mean[i][1])), 4) * data[i][j][k];
                        
                    }

                }
            }

            return CP_val;
        }
    }
}
