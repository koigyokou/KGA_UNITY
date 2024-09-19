namespace _20240804_Class_Abstract
{
    internal class Program
    {

        #region 과제2
        //추상클래스 : 불완전하여 파생 클래스에서 구현해야 하는 클래스 및 클래스
        //오버라이드 : 자식 클래스에서 부모 클래스의 메서드를 재정의하여 사용하는 것
        //오버로딩 : 함수의이름은 하나만 주고 매개변수를 다르게 함으로써 함수를 여러개 만드는 것

        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public abstract class RPGClass
    {
        protected int STR = 10;
        protected int CON = 10;
        protected int INT = 10;
        public virtual void Description()
        {
            Console.WriteLine("RPGClass Description");
        }
    }

    public class Knight : RPGClass
    {
        new int STR = 10;
        new int CON = 10;
        new int INT = 8;

        public override void Description()
        {
            Console.WriteLine("Knight Class");
        }
        public void Strength()
        {
            Console.WriteLine($"STR : {STR}");
        }
        public void Constitution()
        {
            Console.WriteLine($"CON : {CON}");
        }
        public void Intelligence()
        {
            Console.WriteLine($"INT : {INT}");
        }
    }
    public class Giant : RPGClass
    {
        new int STR = 9;
        new int CON = 12;
        new int INT = 8;

        public override void Description()
        {
            Console.WriteLine("Knight Class");
        }
        public void Strength()
        {
            Console.WriteLine($"STR : {STR}");
        }
        public void Constitution()
        {
            Console.WriteLine($"CON : {CON}");
        }
        public void Intelligence()
        {
            Console.WriteLine($"INT : {INT}");
        }
    }
    public class Mage : RPGClass
    {
        new int STR = 8;
        new int CON = 7;
        new int INT = 13;

        public override void Description()
        {
            Console.WriteLine("Knight Class");
        }
        public void Strength()
        {
            Console.WriteLine($"STR : {STR}");
        }
        public void Constitution()
        {
            Console.WriteLine($"CON : {CON}");
        }
        public void Intelligence()
        {
            Console.WriteLine($"INT : {INT}");
        }
    }
}
