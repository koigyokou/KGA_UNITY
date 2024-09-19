using System.Security.AccessControl;

namespace _20240802_LevelTest2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Util util = new Util();
            dynamic x = Console.ReadLine();
            dynamic y = Console.ReadLine();
            Console.WriteLine($"Before : ({x} , {y})");
            util.Swap(ref x, ref y);
            Console.WriteLine($"After : ({x} , {y})");

        }
    }

    public class Util
    {
         
        public void Swap(ref dynamic x , ref dynamic y)
        {
            (x,y) = (y,x);
        }
    }
}
