using System;

namespace 矩阵类库
{
    /// <summary>
    /// 待求矩阵不是方阵
    /// </summary>
    class DetaminateNotSquareException :Exception
    {
        private string message = "待求矩阵不是方阵";

        public new string Message { get { return message; } }

        public DetaminateNotSquareException():base()
        {

        }

    }
}
