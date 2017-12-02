namespace 矩阵类库
{
    class Detaminate
    {
        //行列式阶数
        int rank;

        //行列式内容
        double[,] dex;

        //行列式结果
        double result;

        //临时储存阶数全排列
        int[] tempAllArr;

        public double Result
        {
            get
            {
                return result;
            }
        }


        private Detaminate() { }

        /// <summary>
        /// 构造行列式的新实例
        /// </summary>
        /// <param name="a">待求行列式的二维数组</param>
        public Detaminate(double[,] a):this()
        {
            dex = (double[,])a.Clone();
            if (dex.GetLength(0) != dex.GetLength(1))
            {
                throw new DetaminateNotSquareException();
            }
            rank = dex.GetLength(0);
            result = 0;

            //为临时数组分配内存
            tempAllArr = new int[rank];

            //采用递归的办法获得阶数的全排列
            SetAllArr_Recursion(rank);
        }

        //检查是否临时数组内是否存在重复数字
        private bool CheckGetAllArr_Recursion()
        {
            for(int i = 0; i < rank; i++)
            {
                for(int j = 0; j < rank; j++)
                {
                    if (i == j)
                        continue;
                    else
                    {
                        if (tempAllArr[i] == tempAllArr[j])
                            return false;
                    }
                }
            }
            return true;
        }

        //将得到的符合条件的部分结果累加到result中
        private void GetPartResult()
        {
            if (CheckGetAllArr_Recursion())//当本次获得的排列不存在重复时，计算累乘结果并累加到最终结果中
            {
                
                Reverse tempReverse = new Reverse(tempAllArr);
                double partMulti = 1;
                for(int i = 0; i < rank; i++)
                {
                    partMulti *= dex[i, tempAllArr[i] - 1];
                }

                //不能整除2说明为负
                if (tempReverse.Result % 2 != 0)
                    partMulti = -partMulti;

                result += partMulti;

            }
        }

        //递归求排列
        private void SetAllArr_Recursion(int n)
        {
            if (n == 0)
            {
                GetPartResult();
                return;
            }

            for(int i = 1; i <= rank; i++)
            {
                tempAllArr[n - 1] = i;
                SetAllArr_Recursion(n - 1);
            }

        }

    }
}
