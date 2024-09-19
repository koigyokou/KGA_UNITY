namespace _20240730_ClassInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
        }
    }

    public class RPGClass
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
