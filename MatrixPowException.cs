using System;

namespace 矩阵类库
{
    /// <summary>
    /// 乘方运算幂指数不能为负数
    /// </summary>
    class MatrixPowException :Exception
    {
        private string message;

        public MatrixPowException():base()
        {
            message = "乘方运算幂指数不能为负数";
        }

        public new string Message
        {
            get
            {
                return message;
            }
        }

    }
}
