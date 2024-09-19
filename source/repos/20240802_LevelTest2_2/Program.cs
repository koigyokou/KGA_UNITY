namespace _20240802_LevelTest2_2
{
    enum Skill { 백만볼트, 화염방사, 물총발사, 덩굴채찍 }
    internal class Program
    {
        static void Main(string[] args)
        {
            Monster[] monsters = new Monster[5];
            monsters[0] = new Pikachu();
            monsters[1] = new Charmander();
            monsters[2] = new Squirtle();
            monsters[3] = new Bulbasaur();
            monsters[4] = new Pikachu("털뭉치");

            foreach (Monster monster in monsters)
            {
                Console.WriteLine(monster.Name + "공격해 !");
                monster.Attack();
                Console.WriteLine();
            }
        }
    }
    public abstract class Monster
    {
        public string Name { get; set; }

        public abstract void Attack();
        
    }
    public class Pikachu : Monster
    {
        public Pikachu()
        {
            base.Name = "피카츄";
        }
        public Pikachu(string? name)
        {
            base.Name = name;
        }

        public override void Attack()
        {
            Console.WriteLine("백만볼트 ! ");
        }

    }
    public class Charmander : Monster
    {
        public Charmander()
        {
            base.Name = "파이리";
        }
        public Charmander(string? name)
        {
            base.Name = name;
        }

        public override void Attack()
        {
            Console.WriteLine("화염방사 ! ");
        }

    }
    public class Squirtle : Monster
    {
        public Squirtle()
        {
            base.Name = "꼬부기";
        }
        public Squirtle(string? name)
        {
            base.Name = name;
        }

        public override void Attack()
        {
            Console.WriteLine("물총발사 ! ");
        }

    }
    public class Bulbasaur : Monster
    {
        public Bulbasaur()
        {
            base.Name = "이상해씨";
        }
        public Bulbasaur(string? name)
        {
            base.Name = name;
        }

        public override void Attack()
        {
            Console.WriteLine("덩굴채찍 ! ");
        }

    }
}
