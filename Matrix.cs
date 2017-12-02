using System;
using static System.Console;
using static System.Convert;

namespace 矩阵类库
{
    public class Matrix
    {
        //矩阵的名字
        private string Name;

        //矩阵的元素
        private double[,] Elements;

        //矩阵元素总数
        private int? Count;

        //矩阵的行数
        private int? Rows;

        //矩阵的列数
        private int? Cols;

        //当前矩阵的行列式
        public double Det
        {
            get
            {
                Detaminate tempDetaminate = new Detaminate(Elements);
                return tempDetaminate.Result;
            }
        }

        public Matrix()
        {
            Name = "A";
            Elements = null;
            Count = null;
            Rows = null;
            Cols = null;
        }


        /// <summary>
        /// 为矩阵初始化
        /// </summary>
        /// <param name="n">矩阵名</param>
        /// <param name="rows">矩阵行数</param>
        /// <param name="cols">矩阵列数</param>
        public Matrix(string n, int? rows, int? cols) : this()
        {
            if (rows == 0 || cols == 0)
            {
                //行数为0时，默认为一行
                if (rows == 0)
                {
                    Name = n;
                    Rows = null;
                    Count = cols;
                    Elements = new double[1, (int)cols];
                }
                //列数为0时，默认为一列
                if (cols == 0)
                {
                    Name = n;
                    Cols = null;
                    Count = rows;
                    Elements = new double[(int)rows, 1];
                }

            }
            else
            {
                try
                {
                    Name = n;
                    Rows = rows;
                    Cols = cols;
                    Count = rows * cols;
                    Elements = new double[(int)rows, (int)cols];

                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }



        }


        /// <summary>
        /// 在控制台上为矩阵赋值
        /// </summary>
        public void SetMatrix()
        {
            WriteLine($"正在为 {Name} 矩阵({Rows}行，{Cols}列)赋值:");
            WriteLine();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    try
                    {
                        Write($"{Name} 矩阵的第 {i + 1} 行，第 {j + 1} 列的值为:");
                        Elements[i, j] = ToDouble(ReadLine());
                        WriteLine();
                        if (j == Cols - 1)
                        {
                            if (i != Rows - 1)
                                WriteLine("注意，下一行了！");
                        }

                    }
                    catch(FormatException e)
                    {
                        WriteLine(e.Message);
                        ReadKey();
                        Environment.Exit(0);
                    }
                    catch (ArrayTypeMismatchException e)
                    {
                        WriteLine(e.Message + "\t" + e.StackTrace);
                        ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
        }


        /// <summary>
        /// 在控制台上打印当前矩阵
        /// </summary>
        public void ShowMatrix()
        {
            WriteLine($"矩阵 {Name} =");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (j == 0)
                        Write("\t");
                    Write(Elements[i, j]);
                    Write(" ");
                    if (j == Cols - 1)
                        WriteLine();
                }
            }
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if ((left.Rows != right.Rows) || (left.Cols != right.Cols))
            {
                MatrixTypeCalculateError e = new MatrixTypeCalculateError(1);
                e.ShowException();
                ReadKey();
                Environment.Exit(0);
            }

            Matrix result = new Matrix($"result({left.Name} + {right.Name})", left.Rows, left.Cols);

            result.Count = left.Count;

            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < left.Cols; j++)
                {
                    result.Elements[i, j] = left.Elements[i, j] + right.Elements[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix element)
        {
            for (int i = 0; i < element.Rows; i++)
            {
                for (int j = 0; j < element.Cols; j++)
                {
                    element.Elements[i, j] = (-element.Elements[i, j]);
                }
            }
            return element;
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            if ((left.Rows != right.Rows) || (left.Cols != right.Cols))
            {
                MatrixTypeCalculateError e = new MatrixTypeCalculateError(2);
                e.ShowException();
                ReadKey();
                Environment.Exit(0);
            }

            Matrix result = new Matrix();

            result = left + (-right);
            result.Name = "result(" + left.Name + " - " + right.Name + ")";
            return result;
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.Cols != right.Rows)
            {
                MatrixTypeCalculateError e = new MatrixTypeCalculateError(3);
                e.ShowException();
                ReadKey();
                Environment.Exit(0);
            }

            Matrix result = new Matrix($"result({left.Name} * {right.Name})", left.Rows, right.Cols);

            double temp = 0;

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    for (int k = 0; k < left.Cols; k++)
                    {
                        temp += left.Elements[i, k] * right.Elements[k, j];
                    }
                    result.Elements[i, j] = temp;
                    temp = 0;
                }
            }
            return result;

        }

        public static Matrix pow(Matrix a, int x)
        {
            if (a.Cols != a.Rows)
            {
                MatrixTypeCalculateError e = new MatrixTypeCalculateError(5);
                e.ShowException();
                ReadKey();
                Environment.Exit(0);
            }

            Matrix result = new Matrix($"result({a.Name}^{x})", a.Rows, a.Cols);
            for(int i=0;i<result.Rows;i++)
            {
                for(int j=0;j<result.Cols;j++)
                {
                    result.Elements[i, j] = 1;
                }
            }
            if(x<0)
            {
                MatrixPowException e = new MatrixPowException();
                WriteLine(e.Message);
                ReadKey();
                Environment.Exit(0);
            }

            if (x == 0)
                return result;

            if (x == 1)
                return a;

            if (x == 2)
                return a * a;
            else
                return a * pow(a, x - 1);
        }

    }
}


