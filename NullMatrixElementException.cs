using System;

namespace 矩阵类库
{
    /// <summary>
    /// 矩阵的元素不存在或未对矩阵赋值
    /// </summary>
    class NullMatrixElementException :Exception
    {
        private string message = "矩阵的元素不存在或未对矩阵赋值";

        public new string Message
        {
            get
            {
                return message;
            }
        }

        public NullMatrixElementException():base()
        {

        }

    }
}
