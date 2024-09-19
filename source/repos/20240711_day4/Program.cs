namespace _20240711_day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //과제 1
            //사용자로부터 정수를 하나 입력받고, 그 수만큼 반복하는 문구 출력하기
            //"몇회 반복하시겠습니까?" 출력
            //입력을 받기
            //"n 회 반복중입니다"을 반복적으로 출력.n에는 현재 반복회차 표시하기

            //int num;
            //int count;
            //int countNum=1;
            //Console.WriteLine("몇회 반복하시겠습니까?");
            //int.TryParse(Console.ReadLine(), out num);
            //count = num;

            //while (true)
            //{
            //    Console.WriteLine($"{countNum}회 반복중입니다");
            //    count--;
            //    countNum++;
            //    if (count == 0)
            //        break;
            //}


            //과제 2
            //사용자로부터 정수 두 개를 입력 받고 입력한 값을 포함, 그 사이에 있는 모든 정수의 합을 구하는 프로그램.
            //예를 들어 유저가 4와 7을 입력하였다면 4 + 5 + 6 + 7의 결과값인 22를 출력해야 한다
            //"두 수 사이의 합을 구합니다. 시작할 작은 수를 입력하여주세요" 출력
            //시작할 수 입력 받기
            //"끝 수를 입력해주세요" 출력
            //마지막 수 입력 받기
            //반복문을 통하여 시작부터 끝 수까지 합을 임의의 변수에 저장
            //반복문이 끝난 후 "n1과 n2 사이 숫자의 합은 n3입니다" 출력

            //int num1;
            //int num2;
            //int countm;
            //int countM;
            //int numForSum = 0;
            //int numForSub = 0;
            //int result;

            //Console.WriteLine("두 수 사이의 합을 구합니다. 시작할 작은 수를 입력하여주세요");
            //int.TryParse(Console.ReadLine(), out num1);
            //Console.WriteLine("끝 수를 입력해주세요");
            //int.TryParse(Console.ReadLine(), out num2);
            //countM = num2;
            //countm = num1;

            //while (true)
            //{
            //    numForSum += countM;
            //    countM--;
            //    while (countm > 0)
            //    {
            //        countm--;
            //        numForSub += countm;
            //                        }
            //    if (countM == 0)
            //    {
            //        result = numForSum-numForSub;
            //        Console.WriteLine($"{num1}과 {num2} 사이 숫자의 합은 {result}입니다");
            //        break;
            //    }
            //}





            //과제3
            //유저로부터 정수 하나를 입력받고, 입력받은 수의 구구단을 출력하는 프로그램 제작.예를 들어 3을 입력 받으면 3단에 대한 구구단 출력. 단, 유저가 입력한 수가 9를 초과하거나 숫자가 아닌 것을 입력하면 정상적인 입력이 아닐 경우, 제대로 된 입력이 나올때까지 무한 반복하는 예외처리도 있어야 한다
            //"출력하고자 하는 구구단을 입력해주시길 바랍니다" 출력
            //유저로부터 1~9까지의 숫자를 입력받음
            //"3x1 = 3, 3x2 =6, 3x3 = 9" 등등 해당 구구단 출력
            //만약 1~9가 아닌 숫자 혹은 문자열이 들어오면 다시 입력하라고 반복시키기
            //int num;
            //int count = 1;
            //int result;
            //bool status = true;

            //while (status)
            //{

            //    Console.WriteLine("출력하고자 하는 구구단을 입력해주시길 바랍니다");
            //    int.TryParse(Console.ReadLine(), out num);

            //    if (num <= 0 || num > 9)
            //    continue;

            //    while (true)
            //    {
            //        result = num * count;
            //        Console.WriteLine($"{num} * {count} = {result}");
            //        count++;

            //        if (count == 10)
            //        {
            //            status = false;
            //            break;
            //        }
            //    }
            //}



            //과제4-1
            //for (int line = 1; line <= 5; line++)
            //{
            //    for(int dot  = 1; dot <= line; dot++)
            //    {
            //        Console.Write("*");
            //    }

            //    Console.WriteLine();
            //}

            //과제 4-3
            //for (int line = 5; line >= 1; line--)
            //{
            //    for (int dot = 1; dot <= line; dot++)
            //    {
            //        Console.Write("*");
            //    }

            //    Console.WriteLine();
            //}

            //과제 4-2
            //for (int line = 0; line < 5; line++)
            //{
            //    for (int dot = 0; dot < 5; dot++)
            //    {
            //        if (4 - line > dot)
            //            Console.Write(" ");
            //        else
            //            Console.Write("*");
            //    }

            //    Console.WriteLine();

            //}


            //과제 4-4
            //for (int line = 0; line < 5; line++)
            //{
            //    for (int dot = 0; dot < 5; dot++)
            //    {
            //        if (line <= dot)
            //            Console.Write("*");
            //        else
            //            Console.Write(" ");
            //    }
            //    Console.WriteLine();
            //}
            
        }
    }
}
