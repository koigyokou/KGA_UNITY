namespace _20240819_DesignPattern
{
    internal class FactoryPattern
    {
    }
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual void IsUsable()
        {
            Console.WriteLine("Usable!");
        }
    }

    public class Potion : Item
    {
        public int BuffAmount { get; set; }
        public Potion()
        {
            Name = "HP Potion";
            Description = "Heal HP";
            BuffAmount = 100;
        }
        public override void IsUsable()
        {
            Console.WriteLine($"Used {Name}!! // {Description}");
        }
    }

    public class Weapon : Item
    {
        public int AttackPower { get; set; }
        public Weapon()
        {
            Name = "Sabi Dagger";
            Description = "rusted Dagger";
            AttackPower = 100;
        }
        public override void IsUsable()
        {
            Console.WriteLine($"Used {Name}!! // This is {Description}");
        }
    }
    public class Armor : Item
    {
        public int DefenceAmount { get; set; }
        public Armor()
        {
            Name = "Cursed Plate";
            Description = "Cursed Metealmade Armor";
            DefenceAmount = 100;
        }
        public override void IsUsable()
        {
            Console.WriteLine($"Used {Name}!! // {Description}");
        }
    }
    public class Food : Item
    {
        public int BuffAmount { get; set; }
        public Food()
        {
            Name = "HP Food";
            Description = "Heal HP";
            BuffAmount = 100;
        }
        public override void IsUsable()
        {
            Console.WriteLine($"Used {Name}!! // {Description}");
        }
    }

    public class ItemFactory
    {
        public Item Create(ItemType type)
        {
            switch (type)
            {
                case ItemType.Potion:
                    return new Potion();
                case ItemType.Weapon:
                    return new Weapon();
                case ItemType.Armor:
                    return new Armor();
                case ItemType.Food:
                    return new Food();
                default:
                    throw new ArgumentException("Can not find this item type");
            }
        }

    }
}
