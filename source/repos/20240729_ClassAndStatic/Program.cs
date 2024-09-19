namespace _20240729_ClassAndStatic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 : Add 2 : Subtract 3 : Multiply 4 : Divide 5 : Sqaured");

            MyCalculator.num1 = double.Parse(Console.ReadLine());
            MyCalculator.num2 = double.Parse(Console.ReadLine());
            MyCalculator._operator = double.Parse(Console.ReadLine());

            if (MyCalculator._operator == 1)
            {
                MyCalculator.Add();
                Console.WriteLine($"Result : {MyCalculator.result}"); 
            }
            else if (MyCalculator._operator == 2)
            {
                MyCalculator.Subtract();
                Console.WriteLine($"Result : {MyCalculator.result}");
            }
            else if (MyCalculator._operator == 3)
            {
                MyCalculator.Multiply();
                Console.WriteLine($"Result : {MyCalculator.result}");
            }
            else if (MyCalculator._operator == 4)
            {
                MyCalculator.Divide();
                Console.WriteLine($"Result : {MyCalculator.result}");
            }
            else if (MyCalculator._operator == 5)
            {
                MyCalculator.Sqaured();
                Console.WriteLine($"Result : {MyCalculator.result}");
            }
            else
            {
                Console.WriteLine("Wrong operator. Retry");
            } 
                


        }

        class MyCalculator
        {
            static public double num1;
            static public double num2;
            static public double result;
            static public double _operator;

            static public double Add()
            {
                result = num1 + num2;
                return result;
            }
            static public double Subtract()
            {
                result = num1 - num2;
                return result;
            }
            static public double Multiply()
            {
                result = num1 * num2;
                return result;
            }
            static public double Divide()
            {
                if (num2 == 0)
                {
                    Console.WriteLine("Can't divide by 0");
                    return 0;
                }
                else
                {
                    result = num1 / num2;
                    return result;
                }
            }
            static public double Sqaured()
            {
                result = Math.Pow(num1, num2);
                return result;
            }
        }
    }
}
