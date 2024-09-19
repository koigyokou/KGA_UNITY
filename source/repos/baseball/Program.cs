namespace baseball
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] computerNumArr = { 1, 2, 3 };
            int[] userNumArr = new int[3];
            int userNum = 0;
            int inningCount = 1;
            int strike = 0;
            int ball = 0;
            bool isOut = false;

            while (inningCount <= 11)
            {
                Console.WriteLine($"Please Enter 3-digit 'different' Number\t// current : {inningCount} Inning");
                int.TryParse(Console.ReadLine(), out userNum);
                userNumArr[0] = (userNum / 100) % 10;
                userNumArr[1] = (userNum / 10) % 10;
                userNumArr[2] = userNum % 10;

                if (userNumArr[0] == userNumArr[1] || userNumArr[0] == userNumArr[2] || userNumArr[1] == userNumArr[2])
                    continue;

                for (int i = 0; i < computerNumArr.Length; i++)
                {
                    for (int j = 0; j < userNumArr.Length; j++)
                    {
                        if (computerNumArr[i] == userNumArr[j])
                        {
                            if (i == j)
                            {
                                strike++;
                                isOut = false;
                            }
                            else
                            {
                                ball++;
                                isOut = false;
                            }
                        }

                    }

                }

                if (strike > 0 || ball > 0)
                {
                    Console.WriteLine($"\t{strike} STRIKE");
                    Console.WriteLine($"\t{ball} BALL");
                    Console.WriteLine();
                    Console.WriteLine();

                    if (strike == 3)
                    {
                        Console.WriteLine("\tVICTORY\n");
                        break;
                    }

                    strike = 0;
                    ball = 0;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tOUT");
                    Console.WriteLine();
                    isOut = true;
                }


                inningCount++;
            }

            if(isOut)
            Console.WriteLine("\tLOSE\n");
        }
    }
}
