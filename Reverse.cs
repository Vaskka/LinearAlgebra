namespace 矩阵类库
{
    /// <summary>
    /// 逆序数类
    /// </summary>
    class Reverse
    {
        //逆序数数组
        int[] Arrange;

        //逆序数结果
        int result;

        private Reverse() { }

        /// <summary>
        /// 构造逆序数的新实例
        /// </summary>
        /// <param name="a">待求的逆序数表</param>
        public Reverse(int[] a):this()
        {
            Arrange = (int[])a.Clone();
            result = 0;
            int temp = 0;
            for (int i = 0; i < Arrange.Length; i++)
            {
                if(i != Arrange.Length - 1)
                {
                    //计算当前位之后有多少比之小
                    for (int j = i + 1; j < Arrange.Length; j++)
                    {
                        if (Arrange[j] < Arrange[i])
                            temp++;
                        
                        else
                        {
                            if (Arrange[j] == Arrange[i])
                                throw (new ReverseMoreException());
                        }
                        
                    }
                    //将部分结果累加到总结果中
                    result += temp;
                    //部分归0
                    temp = 0;
                }
                
            }

        }

        public int Result
        {
            get
            {
                return result;
            }
        }


    }
}
