using System.Text;
using static System.Net.WebRequestMethods;

namespace _20240806_string_immutable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    //가변(Mutable)과 불변(Immutable)
    //    가변(Mutable)은 "변경할 수 있는"을 의미하며, 불변(Immutable)은 "변경할 수 없는"을 의미하는 단어입니다.
    //    이 단어는 프로그래밍 언어에서도 동일한 의미를 가집니다.변경 가능한 타입은 인스턴스가 생성된 후 값이 변경될 수 있지만, 
    //    변경 불가능한 타입은 인스턴스가 생성된 후 값을 변경할 수 없는 타입입니다.

    //    string은 변경할 수 없는 타입입니다. 문자열 변수는 스택(Stack) 에 생성되며, 힙(Heap) 에 생성되는 문자열 주소를 참조합니다. 
    //    string 타입의 값을 변경하면 힙에 새로운 문자열이 생성되고 스택에 존재하는 문자열 변수는 힙에 생성된 새로운 문자열 주소를 참조합니다.
    //    string 타입의 변수를 수정하면, 힙에 생성된 문자열 메모리 공간의 값을 변경하지 않으므로 string은 불변 클래스입니다.
    //        힙에 생성되었지만 사용되지 않는 문자열 "ABC"의 메모리 공간은 가비지 컬렉션에 의해 소멸됩니다.



    //    StringBuilder
    //    StringBuilder는 변경할 수 있는 타입입니다. string과 마찬가지로 StringBuilder 객체는 스택에 생성되며, 
    //    문자열은 힙에 생성되지만, 값을 추가하거나 변경하는 과정은 string과 다릅니다. 
    //    문자열을 추가하거나 변경하는 경우 힙에 새로운 메모리 공간을 생성하지 않으며 기존 메모리 공간에 값을 변경합니다.
    //    가변 객체는 힙 영역에 새로운 메모리 공간을 생성하지 않아도 되므로 불변 객체보다 메모리 누수가 적은 편입니다.


}
