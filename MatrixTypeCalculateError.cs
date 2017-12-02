using System;
using static System.Console;

namespace 矩阵类库
{
    /// <summary>
    /// 进行运算的矩阵类型发生错误
    /// </summary>
    public class MatrixTypeCalculateError : Exception
    {
        string ReasonMessage;

        string DeepReason;

        Operator? op = null;

        public MatrixTypeCalculateError() : base()
        {
            ReasonMessage = "进行运算的矩阵类型发生错误";
        }

        /// <summary>
        /// 构造矩阵运算的新异常
        /// </summary>
        /// <param name="o">异常运算符 (1 : '+', 2 : '-', 3 : '*', 5 : '乘方')</param>
        public MatrixTypeCalculateError(int o) : base()
        {
            ReasonMessage = "进行运算的矩阵类型发生错误";
            try
            {
                op = (Operator)o;
            }
            catch (NotImplementedException e)
            {
                WriteLine(e.Message);
            }
            switch (o)
            {
                case 1:
                    DeepReason = "加法运算时矩阵的类型不相同";
                    break;
                case 2:
                    DeepReason = "减法运算时矩阵的类型不相同";
                    break;
                case 3:
                    DeepReason = "乘法运算时矩阵的行列关系不正确(应该为:左操作数的行数=右操作数的列数)";
                    break;
                case 5:
                    DeepReason = "乘方运算时参数不是方阵";
                    break;
                default:
                    DeepReason = "向异常类传递的参数应该o∈{1,2,3,4}（未知的异常）";
                    break;
            }
        }

        /// <summary>
        /// 在控制台上打印异常信息
        /// </summary>
        public void ShowException()
        {
            try
            {
                switch (op)
                {
                    case (Operator)1:
                        WriteLine(ReasonMessage + "," + DeepReason);
                        break;
                    case (Operator)2:
                        WriteLine(ReasonMessage + "," + DeepReason);
                        break;
                    case (Operator)3:
                        WriteLine(ReasonMessage + "," + DeepReason);
                        break;
                    case (Operator)4:
                        WriteLine(ReasonMessage + "," + DeepReason);
                        break;
                    case (Operator)5:
                        WriteLine(ReasonMessage + "," + DeepReason);
                        break;
                    default:
                        WriteLine("无效的操作数信息");
                        break;

                }
            }
            catch (ArgumentNullException e)
            {
                WriteLine(e.Message);
            }
        }

    }
}
