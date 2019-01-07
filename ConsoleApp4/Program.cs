using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        

        /*-------------------------------------_____----------------____-----
        --------------------l----------/\-----l     ) ---- /\------     | ----
        --------------------l     --  /  \ ---l_____) ----/  \----- ____| ----
        --------------------l     -- /----\ --l      )---/----\----     | ------
        --------------------l_____--/      \--l______)--/      \----____| ------
        */

        public static int[] BinToArr(string a)
        {
            int[] Arr = new int[a.Length];
            for(int i = 0; i < a.Length; i++)
            {
                Arr[i] = Convert.ToInt32(a.Substring(i, 1), 2);
                //Array.Reverse(Arr);
            }
            Array.Reverse(Arr);
            return Arr;
        }

        /* public static string ArrToBin(int[] a)
         {
             //Array.Reverse(a);
             var binstr = "";
             for(int i = 0; i < a.Length; i++)
             {
                 binstr = binstr + Convert.ToString(a[i]);
             }
             //binstr = RemoveHighZeroes(binstr);
             return binstr;
         }*/

        public static string ArrToBin(int[] polynom)
        {
            StringBuilder stringline = new StringBuilder();
            for (int i = polynom.Length - 1; i >= 0; i--)
            {
                stringline.Append(Convert.ToString(polynom[i], 2));
            }
            return stringline.ToString();
        }

        public static int[] Addition(int[] a, int[] b)
        {
            int greatest_length = Math.Max(a.Length, b.Length);
            Array.Resize(ref a, greatest_length);
            Array.Resize(ref b, greatest_length);
            int[] c = new int[a.Length];
            for(int i = 0; i < a.Length; i++)
            {
                c[i] = a[i] ^ b[i];
            }

            return RemoveHighZeroes(c, greatest_length);
        }

        public static int[] LenghtControl(int[] a)
        {
            if (a.Length < 238)
            {
                Array.Resize(ref a, 239);
            }
            return a;
        }

        public static string GetBin()
        {
            Console.Write("\nEnter an element: ");
            string bin = Console.ReadLine();
            if (bin.Length < 239)
                /*for(int i = 0; i < (239 - bin.Length); i++)
                {
                    bin = "0" + bin;
                }*/
                while (bin.Length != 239)
                    bin = "0" + bin;
            return bin;
        }

        public static int[] Division(int[] a)
        {
            string gen = "100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000111";
            int[] genarr = BinToArr(gen);
            int[] result = a;
            var maxlenght = Math.Max(a.Length, genarr.Length);
            if (a.Length < genarr.Length)
            {
                return a;
            }
            else
            {
                int[] temp = new int[1];
                while (result.Length >= genarr.Length)
                {
                    temp = ShiftBits(genarr, result.Length - genarr.Length);
                    result = Addition(result, temp);
                }
            }
            //Array.Resize(ref result, 239);
            return LenghtControl(result);
        }



        public static int[] Multiplication(int[] a, int[] b)
        {
            var maxlenght = Math.Max(a.Length, b.Length);
            Array.Resize(ref a, maxlenght);
            Array.Resize(ref b, maxlenght);

            int[] temp = new int[1];
            int[] result = new int[1];
            for (int i = 0; i < a.Length; i++)
            {
                if (b[i] == 1)
                {
                    temp = ShiftBits(a, i);
                    result = Addition(result, temp);
                }
            }
            result = Division(result);
           

            return result;
        }

        public static int[] ShiftBits(int[] a, int n)
        {
            int[] result = new int[a.Length + n];
            for (int i = 0; i < a.Length; i++)
            {
                result[i + n] = a[i];
            }
            return result;
        }

        /* public static int[] Multiplication(int[] a, int[] b)
         {
             int greatest_length = Math.Max(a.Length, b.Length);
             Array.Resize(ref a, greatest_length);
             Array.Resize(ref b, greatest_length);
             Array.Reverse(a);
             Array.Reverse(b);
             int[] res = new int[a.Length];
             int[] temp = new int[a.Length];
             for(int i = 0; i < a.Length; i++)
             {
                 for(int j = 0; j < a.Length; j++)
                 {
                     res[i + j] = b[i] ^ a[j];
                 }
                 temp = res;
                 Array.Resize(ref res, 2*a.Length - 1);
                 ShiftArray(temp, i);
                 if (i > 0)
                 {
                     for (int k = 0; k < a.Length; k++)
                         temp[k] = res[k] | temp[k];
                 }
             }
             Array.Reverse(temp);
             return temp;
         }*/


        /*  public static int[] ShiftArray(int[] a, int n)
          {

              int[] b = new int[a.Length + n];
              Array.Resize(ref a, b.Length);
              for(int i = n; i < a.Length; i++)
              {
                  b[b.Length - i - 1] = a[b.Length - i - 1];
                  Array.Resize(ref b, 2*a.Length - 1);
              }
              return b;
          }*/





        public static int[] RemoveHighZeroes(int[] massive, int dimention)
        {
            int count = 0;
            var i = dimention - 1;
            while (massive[i] == 0)
            {
                count++;
                i--;
                if (i == -1) return massive;
            }
            int[] result = new int[massive.Length - count];
            for (int w = 0; w < massive.Length - count; w++)
                result[w] = massive[w];
            return result;
            //string b = a;//ArrToBin(a);
            //b = b.TrimStart('0');
            //return b;
        }

        public static int[] Square(int[] a)
        {
            int[] res = new int[2 * a.Length];
            for(int i = 0; i < a.Length; i++)
            {
             //   if (i % 2 == 0)
                    res[2*i] = a[i];
                //else
                //    res[i] = 0;
            }
           // res[2 * a.Length - 1] = a[a.Length - 1];
            res = Division(res);
            return res;
        }

        public static int[] Trace(int[] a)
        {
            int[] res = a;
            int[] temp = a;
            for(int i = 1; i < 239; i++)
            {
                temp = Square(temp);
                res = Addition(res, temp);
            }
            res = Division(res);
            return res;
        }

        public static int[] Power(int[] a, int[] n)
        {
            string one = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001";
            int[] result = new int[a.Length];
            result = BinToArr(one);
            for (int i = 0; i < a.Length; i++)
            {
                if (n[i] == 1)
                {
                    result = Multiplication(result, a);
                }
                a = Square(a);
            }
            return result;
        }

        public static int[] Inversed(int[] a)
        {
            var power = "11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111110";
            var power1 = BinToArr(power);
            var res = Power(a, power1);

            return res;
        } 


        static void Main(string[] args)
        {
            string bin1 = GetBin();
            string bin2 = GetBin();

            Console.Write("\n" + bin1);
            Console.Write("\n" + bin2);


            //var a = "100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000111";
            //Console.Write(a.Length);


            //int[] Arr1 = BinToArr(bin1);
            //int[] Arr2 = BinToArr(bin2);

            //int[] ResultMul = Multiplication(Arr1, Arr2);
            //Console.Write("\nResult: " + ArrToBin(ResultMul));
            //int[] ResultAdd = Addition(Arr1, Arr2);
            //Console.Write("\n Addition result: " + ArrToBin(ResultAdd));
            //string hex1 = GetNumbers();
            //string hex2 = GetNumbers();

            //ulong[] Arr2 = NumToArr(hex2);
            //ulong[] Arr1 = NumToArr(hex1);

            //ulong[] ResultNOK = NOK(Arr1, Arr2);
            //Console.Write("\n NOK result: " + ShowResult(ResultNOK));
            //ulong[] Result = LongAddition(Arr1, Arr2);
            //Console.Write("\nAddition: " + ShowResult(Result));

            //ulong[] ResultSub = LongSub(Arr1, Arr2);
            //Console.Write("\nSubstraction: " + ShowResult(ResultSub));

            //Console.Write("\nResult: " + LongCmp(hex1, hex2));

            //Console.Write("\nLongMulOneDigit")
            //ulong[] ResultPow = LongPowerWindow(hex1, hex2);
            //ulong[] ResultMul = LongMul(Arr1, Arr2);
            //ulong[] ResultDiv = LongDiv(Arr1, Arr2);
            //Console.Write("\nPower: " + ShowResult(ResultPow));
            //Console.Write("\nDivision: " + ShowResult(ResultDiv));
            //Console.Write("\nMultiplication: " + ShowResult(ResultMul));
            Console.Write("\nPress any key..");
            Console.ReadKey();

        }
    }
}




















