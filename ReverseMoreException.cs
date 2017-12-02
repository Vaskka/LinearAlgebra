using System;

namespace 矩阵类库
{
    /// <summary>
    /// 逆序数存在重复
    /// </summary>
    class ReverseMoreException :Exception
    {
        private string message = "逆序数存在重复";

        public string Message
        {
            get
            {
                return message;
            }
        }

        public ReverseMoreException():base()
        {

        }
    }
}
