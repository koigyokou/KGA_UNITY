namespace _20240712_day5
{
    internal class Program
    {
        enum place
        {
            마을, 사냥터, 상점
        }

        enum state
        {
            idle = 1, run, walk, dead = 9
        }

        #region 구조체 과제 선언부
        //            short형x, short형y 두가지를 가진 XYCoord라는 구조체를 선언한다.
        //정수형 Dmg, 실수형 Critical, 문자열형 Name을 가진 구조체 틀을 만들고 구조체 이름은 Weapon으로 선언한다.
        //방금 만들어진 구조체 틀을 활용하여, Sword와 Katana라는 객체를 만든 후, 본인이 원하는 수치를 각각 속성에 전부 추가한다.
        //Car라는 구조체를 만든 후, 다음의 내부 속성을 추가한다.
        //실수형 최고속도
        //정수형 자동차넘버
        //열거형 제조사(Honda, Audi, BMW, Kia 네가지 열거 속성 보유)
        //Item 이라는 구조체를 만든다. 이 아이템이라는 구조체는
        //문자열형인 아이템 이름, 정수형인 가격, 열거형인 아이템 타입(방어구, 무기, 소모품)의 속성을 가진다.
        //아이템이 3개 들어가는 인벤토리라는 배열을 만들고, 배열 속 세번째 요소에, 아이템명으로 “악몽의 꽃 견갑”, 가격은 500, 아이템의 타입은 방어구이다.
        //인벤토리의 모든 속 내용을 출력하는 함수를 작성한다.

        struct XYCoord
        {
            short x;
            short y;
        }
        struct Weapon
        {
            public int Dmg;
            public float Critical;
            public string Name;
        }
        enum vehicleBrand
        {
            Honda, Audi, BMW, Kia
        }
        struct Car
        {
            float maxSpeed;
            int vehicleNum;
            vehicleBrand vehicleBrand;
        }
        enum itemType
        {
            Armor, Weapon, Consumable
        }
        struct Item
        {
            public string name;
            public int price;
            public itemType itemType;
        }
        #endregion



        static void Main(string[] args)
        {
            #region 배열 과제
            //과제 1
            //4개의 정수를 담을 수 있는 배열을 하나 생성 후, 사용자에게 순서대로 값 입력 받아 순서대로 배열에 담기. 해당 문을 foreach로 출력해 보자
            //int 4개를 담을 배열을 선언
            //"1번 요소를 입력하여주십시오" 출력 후 입력받기
            //나머지 번호도 마찬가지로 입력
            //"입력된 요소는 다음과 같습니다" 다음 줄에 입력된 값들 4개 출력

            //int[] arr = new int[4];

            //Console.WriteLine("1번 요소를 입력하여주십시오");
            //int.TryParse(Console.ReadLine(), out arr[0]);

            //Console.WriteLine("2번 요소를 입력하여주십시오");
            //int.TryParse(Console.ReadLine(), out arr[1]);

            //Console.WriteLine("3번 요소를 입력하여주십시오");
            //int.TryParse(Console.ReadLine(), out arr[2]);

            //Console.WriteLine("4번 요소를 입력하여주십시오");
            //int.TryParse(Console.ReadLine(), out arr[3]);

            //Console.WriteLine("입력된 요소는 다음과 같습니다");
            //Console.WriteLine();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write($"{arr[i]}\t");
            //}
            //Console.WriteLine();




            //과제 2
            //4x4 16개의 정수를 담을 수 있는 2차원 배열을 만든 후, 반복문을 이용하여 3의 배수들로 채워 넣는다. 그 후 2행3열 요소와 3행 2열 요소를 바꾼 후 출력해 보자
            //int형 2차원 배열을 선언
            //반복문을 통하여 순서대로 3의 배수들로 채워넣음
            //2행3열 요소와 3행 2열 요소를 바꾼다
            //4x4의 형태로 들어있는 숫자들을 출력

            //int[,] arr = new int[4, 4];
            //int temp = 0;

            //for(int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for(int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        if (i == 0)
            //        {
            //            arr[i, j] = 3 + 3 * j;
            //        }
            //        else if (i == 1)
            //        {
            //            arr[i, j] = 15 + 3 * j;
            //        }
            //        else if (i == 2)
            //        {
            //            arr[i, j] = 27 + 3 * j;
            //        }
            //        else if (i == 3)
            //        {
            //            arr[i, j] = 39 + 3 * j;
            //        }

            //    }
            //}

            //for(int row = 0; row < 4; row++)
            //{
            //    for( int col = 0; col < 4; col++)
            //    {
            //        Console.Write($"{arr[row, col]}\t");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine("(2,3) 과 (3,2)를 바꿉니다");
            //temp = arr[1, 2];
            //arr[1, 2] = arr[2, 1];
            //arr[2, 1] = temp;

            //for (int row = 0; row < 4; row++)
            //{
            //    for (int col = 0; col < 4; col++)
            //    {
            //        Console.Write($"{arr[row, col]}\t");
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #region 열거형 과제

            //과제 1
            //switch (toDetermine)
            //{
            //    case place.마을:
            //        Console.WriteLine("마을로 이동합니다");
            //        break;

            //    case place.사냥터:
            //        Console.WriteLine("사냥터로 이동합니다");
            //        break;

            //    case place.상점:
            //        Console.WriteLine("상점으로 이동합니다");
            //        break;

            //    default:
            //        Console.WriteLine("1,2,3 어느것도 아니에요");
            //        break;

            //}

            ////과제 2
            ////플레이어의 현재 행동이 int state 로 정의되어 있습니다.
            ////state변수에 1이 담겨 있으면 idle, 2가 담겨있으면 run, 3이 들어있으면 walk , 9가 담겨있으면 죽은 상태 입니다.
            ////열거형을 활용하여 해당 코드를 어떻게 수정할 수 있는지 작성해주세요.
            ////유저에게 콘솔 입력으로 1,2,3,9 외의 입력이 들어오면, 옳지 못한 입력이라고 출력 후, 다시 입력을 요구하는 기능을 만드세요

            //state num = state.idle;
            //bool flag = true;

            //Console.WriteLine("Press Number : [1] idle  [2] run  [3] walk [9] dead\n");
            //Enum.TryParse(Console.ReadLine(), out num);

            //while (flag)
            //{
            //    switch ((int)num)
            //    {
            //        case 1:
            //            Console.WriteLine($"\n\t{num}");
            //            flag = false;
            //            break;
            //        case 2:
            //            Console.WriteLine($"\n\t{num}");
            //            flag = false;
            //            break;
            //        case 3:
            //            Console.WriteLine($"\n\t{num}");
            //            flag = false;
            //            break;
            //        case 9:
            //            Console.WriteLine($"\n\t{num}");
            //            flag = false;
            //            break;

            //        default:
            //            Console.WriteLine("Wrong Input! Please Retry!\n\t");
            //            Enum.TryParse(Console.ReadLine(), out num);
            //            break;
            //    }


            //}

            #endregion

            #region 구조체 과제 MAIN 함수
            //            short형x, short형y 두가지를 가진 XYCoord라는 구조체를 선언한다.
            //정수형 Dmg, 실수형 Critical, 문자열형 Name을 가진 구조체 틀을 만들고 구조체 이름은 Weapon으로 선언한다.
            //방금 만들어진 구조체 틀을 활용하여, Sword와 Katana라는 객체를 만든 후, 본인이 원하는 수치를 각각 속성에 전부 추가한다.
            //Car라는 구조체를 만든 후, 다음의 내부 속성을 추가한다.
            //실수형 최고속도
            //정수형 자동차넘버
            //열거형 제조사(Honda, Audi, BMW, Kia 네가지 열거 속성 보유)
            //Item 이라는 구조체를 만든다. 이 아이템이라는 구조체는
            //문자열형인 아이템 이름, 정수형인 가격, 열거형인 아이템 타입(방어구, 무기, 소모품)의 속성을 가진다.
            //아이템이 3개 들어가는 인벤토리라는 배열을 만들고, 배열 속 세번째 요소에, 아이템명으로 “악몽의 꽃 견갑”, 가격은 500, 아이템의 타입은 방어구이다.
            //인벤토리의 모든 속 내용을 출력하는 함수를 작성한다.

            Item[] items = new Item[3];
            Item thirdItem = new Item();
            thirdItem.name = "악몽의 꽃 견갑";
            thirdItem.price = 500;
            thirdItem.itemType = itemType.Armor;

            items[2] = thirdItem;

            Console.WriteLine("\nInformation Of 'thirdItem'\n");
            Console.WriteLine($"NAME\t {items[2].name}");
            Console.WriteLine();
            Console.WriteLine($"PRICE\t {items[2].price}");
            Console.WriteLine();
            Console.WriteLine($"TYPE\t {items[2].itemType}");

            #endregion

        }
    }
}
