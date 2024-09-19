namespace _20240715_day6_func
{

    internal class Program
    {
        #region 과제 1
        static void BigNum(int a, int b, int c, int d)
        {
            int[] arr = { a, b, c, d };
            int bigNum = arr.Max();
            Console.WriteLine(bigNum);

        }
        #endregion

        #region 과제 2
        static void BigSum(float a, float b, float c, float d, float e)
        {
            float[] arr = { a, b, c, d, e };
            Array.Sort(arr);
            float max = arr[4];
            float secondMax = arr[3];
            Console.WriteLine(secondMax + max);
        }
        #endregion
        #region 과제 3
        static bool IsSubLessThenHundred ( int a , int b )
        {
            int sub = 0;
            sub = a - b;
            if (Math.Abs(sub) < 100)
                return true;
            else
                return false;
        }
        #endregion
        static void Main(string[] args)
        {
            #region 과제 1
            //BigNum(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            #endregion

            #region 과제 2
            //float a=0.0f;
            //float b=0.0f;
            //float c=0.0f;
            //float d=0.0f;
            //float e=0.0f;

            //float.TryParse(Console.ReadLine(), out a);
            //float.TryParse(Console.ReadLine(), out b);
            //float.TryParse(Console.ReadLine(), out c);
            //float.TryParse(Console.ReadLine(), out d);
            //float.TryParse(Console.ReadLine(), out e);
            //BigSum(a,b,c,d,e);
            #endregion

            #region 과제 3
            bool result = true;

            result = IsSubLessThenHundred(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            Console.Write(result);
            #endregion

        }
    }
}
