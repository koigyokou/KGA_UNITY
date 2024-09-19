namespace _20240805_Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 인벤토리 배열 생성
            Inventory<Potion> potionInventory = new(10);  
                                                          
            potionInventory.Add(new Potion("체력 포션"));
            potionInventory.Add(new Potion("마나 포션"));
            potionInventory.Add(new Potion("경험치 포션"));
            potionInventory.Add(new Potion("활력 포션"));

            potionInventory.Remove();
            potionInventory.Remove();

            potionInventory.PrintItemNames();
        }
    }
    public abstract class Item
    // 추상 클래스 Item 생성
    {
        // 아이템 이름 저장
        public string Name { get; private set; }

        // 생성자에서 이름 초기화
        public Item(string name)                          
        { this.name = name; }                             
    }

    // 아이템의 자식 클래스인 포션클래스 생성
    public class Potion : Item                            
    {
        // 생성자에서 이름 초기화
        public Potion(string name) : base(name) { }       
    }

    // 클래스 자체를 제네릭으로 설정
    public class Inventory<T> where T : Item              
    {
        // 배열을 제네릭으로 생성
        public T[] _list;
        // 현재 가리키고 있는 데이터를 저장할 변수 선언
        public int _index;


        // 생성자에서 크기 초기화
        public Inventory(int size)                        
        {
            // 제네릭 배열 생성, 인자는 배열의 크기
            _list = new T[size];                          
        }

        // 아이템 추가 메서드 생성
        public void Add(T item)                           
        {
            // 배열 내에 인덱스가 있을 경우
            if (_index < _list.Length)                    
            {
                // 아이템 추가
                _list[_index] = item;                     
                _index++;                                 
            }                                             
                                                          
        }
        // 아이템 제거 메서드 생성
        public void Remove()                              
        {
            // 인덱스가 0보다 클 경우
            if (_index > 0)                               
            {                                             
                _index--;
                // 아이템 비우기
                _list[_index] = null;                     
            }                                             
        }

        // 모든 아이템 이름 출력 메서드 생성
        public void PrintItemNames()                      
        {                                                 
            Console.WriteLine("아이템 목록 :");

            // 리스트에 있는 모든 아이템클래스에 대해
            foreach (T item in _list)                     
            {                                             
                if (item != null)                         
                {
                    // 이름 출력
                    Console.WriteLine(item.Name);         
                }
            }
        }
    }
}

#region 과제2
//제네릭을 사용하면 메서드, 클래스, 구조체 또는 인터페이스를 사용 대상인 정확한 데이터 형식에 맞게 조정할 수 있습니다.
//형식 안전성. 제네릭을 사용하면 컴파일러에서 형식 안전성을 보장해야 하는 부담이 없어집니다. 컴파일 타임에 올바른 데이터 형식이 적용되므로 코드를 작성하여 데이터 형식을 테스트할 필요가 없습니다. 형식 캐스팅의 필요성과 런타임 오류 발생 가능성도 감소합니다.

//코드의 양이 감소하며 코드를 보다 쉽게 다시 사용할 수 있습니다. 기본 형식에서 상속하고 멤버를 재정의할 필요가 없습니다. 예를 들어 LinkedList<T> 은 즉시 사용할 수 있습니다. 다음 변수 선언을 사용하면 문자열의 연결된 목록을 만들 수 있습니다.
//성능 향상. 제네릭 컬렉션 형식은 값 형식을 boxing할 필요가 없기 때문에 일반적으로 값 형식 저장 및 조작 시 성능이 보다 우수합니다.
#endregion
