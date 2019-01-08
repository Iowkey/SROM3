# SROM_1_

















public static int[,] MulMatrix()
        {
            int[,] lambda = new int[239, 239];
            for (int i = 0; i < 239; i++)
            {
                for (int j = 0; j < 239; j++)
                {
                    if (((2 ^ i + 2 ^ j) % 239 == 1) || ((2 ^ i - 2 ^ j) % 239 == 1) || ((-(2 ^ i) + 2 ^ j) % 239 == 1) || ((-(2 ^ i) - (2 ^ j)) % 239 == 1))
                        lambda[i, j] = 1;
                    else
                        lambda[i, j] = 0;
                    // Console.Write("{0}\t", lambda[i, j]);
                }
            }
            return lambda;
        }

        public static int[] NBMultiplication(int[] a, int[] b)
        {
            Array.Resize(ref a, 239);
            Array.Resize(ref b, 239);
            int[,] lambda = MulMatrix();
            int[] res = new int[239];
            for (int i = 0; i < 239; i++)
            {
                a = LoopShiftL(a, i);
                b = LoopShiftL(b, i);
                int[,] c = Transpose(b);
                res[i] = MulMatrix2(MulMatrix1(a, lambda), c);
            }
            return res;
        }

        public static int[,] MulMatrix1(int[] a, int[,] b)
        {
            Array.Resize(ref a, 239);
            int[,] res = new int[1, 239];
            int[,] temp = new int[1, 239];
            for(int k = 0; k < 239; k++)
            {
                temp[0, k] = a[k];
            }
            res[0, 0] = 0;
            for (int i = 0; i < 239; i++)
            {
                res[0, i] += temp[0, i] * b[i, i];
                res[0, i] = res[0, i] % 2;
            }
            return res;
        }

        public static int MulMatrix2(int[,] a, int[,] b)
        {
            int res;
            int[,] temp = new int[1, 1];
            for (int i = 0; i < 239; i++)
            {
                temp[0, 0] += a[0, i] * b[i, 0];
                //temp[0, 0] = temp[0, i] % 2;
            }
            temp[0, 0] = temp[0, 0] % 2;
            res = temp[0, 0];
            return res;
        }

        public static int[] LoopShiftR(int[] a, int n)
        {
            int[] b = new int[a.Length];
            int i = 0;
            int k = n;
            while(i < b.Length)
            {
                b[i] = a[(a.Length - k) % a.Length];
                i++;
                k--;
            }
            return b;
        }

        public static int[] LoopShiftL(int[] a, int n)
        {
            int[] b = new int[a.Length];
            int i = 0;
            int k = n;
            while(i < b.Length)
            {
                b[i] = a[k % b.Length];
                i++;
                k++;
            }
            return b;
        }

        public static int[,] Transpose(int[] a)
        {
            Array.Resize(ref a, 239);
            //int[] res = new int[239];
            int[,] temp = new int[239, 1];
            int[,] b = new int[1, 239];
            for(int k = 0; k < 239; k++)
            {
                b[0, k] = a[k];
            }
            for(int i = 0; i < 239; i++)
            {
                temp[i, 0] = b[0, i];
            }
            //for(int j = 0; j < 239; j++)
            //{
            //    res[j] = temp[j, 1];
            //}
            //return res;
            return temp;
        }
