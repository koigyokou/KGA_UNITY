namespace _20240805_DelegateAndEvent
{
    internal class Program
    {
        
        public class Player
        {
            private Armor curArmor;
            public Action OnArmorConditionChanged;

            public void Equip(Armor armor)
            {
                Console.WriteLine($"플레이어가 {armor.name} 을/를 착용합니다.");
                curArmor = armor;
                OnArmorConditionChanged += curArmor.DecreaseDurability;
                curArmor.OnBreak += UnEquip;
            }

            public void UnEquip()
            {
                Console.WriteLine($"플레이어가 {curArmor.name} 을/를 해제합니다.");
                OnArmorConditionChanged -= curArmor.DecreaseDurability;
                curArmor.OnBreak -= UnEquip;
                curArmor = null;
            }

            public void Hit()
            {
                Console.WriteLine("Hit");
                OnArmorConditionChanged?.Invoke();
            }
        }

        public class Armor
        {
            public string name;
            private int durability;

            public event Action OnBreak;

            public Armor(string name, int durability)
            {
                this.name = name;
                this.durability = durability;
            }

            public void DecreaseDurability()
            {
                durability--;
                if (durability <= 0)
                {
                    Break();
                }
            }

            private void Break()
            {
                OnBreak?.Invoke();
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Armor ammor = new Armor("갑옷", 3);

            player.Equip(ammor);

            player.Hit();
            player.Hit();
            player.Hit();
        }
    }
}
