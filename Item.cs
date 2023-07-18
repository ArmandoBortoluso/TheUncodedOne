class Item{

    public readonly string itemName;

    public Item(string itemName){
        this.itemName = itemName;
    }

    public virtual void useItem(Chara target){}
}


class healthPotion : Item{

    public healthPotion() : base("Health Potion"){}

    public override void useItem(Chara target)
    {
        target.healthPoints += 10;
        target.healthPoints = target.healthPoints > target.totalMaxHealth ? target.totalMaxHealth : target.healthPoints;

        Console.WriteLine($"{target.charName} recovered health points!");
        
    }


}