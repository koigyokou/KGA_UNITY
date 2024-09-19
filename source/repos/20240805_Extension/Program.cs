namespace _20240805_Extension
{
    public static class IDCheck
    {
        public static bool IsAllowedID(this string id)
        {
            foreach (var c in id)
            {
                
                switch (c)
                {
                    case '!':
                    case '@':
                    case '#':
                    case '$':
                    case '%':
                    case '^':
                    case '&':
                    case '*':
                        return false;
                }
            }

            
            return true;
        }
    }


    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("아이디를 입력하세요 : ");
            string id = Console.ReadLine();

            if (id.IsAllowedID())
            {
                Console.WriteLine("ID가 유효합니다.");
            }
            else
            {
                Console.WriteLine("ID에 허용되지 않는 특수문자가 있습니다.");
            }
        }
    }
}
