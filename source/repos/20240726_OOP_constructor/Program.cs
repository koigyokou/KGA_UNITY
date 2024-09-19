using System.ComponentModel.DataAnnotations;

namespace _20240726_OOP_constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int test = 1;

            Trainer trainer = new Trainer("Red");
            for (int i = 1; i <= 6; i++)
            {
                trainer.AddMonster(i);
            }

            // test if limitation works
            trainer.AddMonster(test);
        }
    }

    public class Monster
    {
        int num;
        int level;
        int hp;

        public Monster(int num,int level, int hp)
        {
            this.num = num;
            this.level = level;
            this.hp = hp;
            Console.WriteLine($"Monster Info [ NO. : {num}\tLEVEL : {level}\tHP : {hp} ]");
        }
    }
    public class Trainer
    {
        private string name;
        public int monsterCount;
        Monster[] monsters = new Monster[6];


        public Trainer(string name)
        {
            this.name = name;
            monsterCount = 0;
            Console.WriteLine($"[ TRAINER : {name} ]");
            Console.WriteLine();
        }

        public void AddMonster(int monsterNum)
        {
            if (monsterCount >= monsters.Length)
            {
                Console.WriteLine("Warning !! Max Monster");
                return;
            }


            monsters[monsterCount++] = new Monster(monsterNum,1,100);
            Console.WriteLine("Monster Added");
            Console.WriteLine();

        }

    }
}
