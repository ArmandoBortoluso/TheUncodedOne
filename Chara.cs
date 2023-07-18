class Chara{
    public int healthPoints;
    public readonly string? charName;
    public readonly int totalMaxHealth;

    protected int moventNumbers;

    protected List<string> moves;
    protected List<Item> inventory;

    public int InventoryCount { get; protected set;}

    public Chara(int health, string name){
        this.totalMaxHealth = health;
        this.healthPoints = health;
        this.charName = name;
        
    }

    public virtual void action(Chara target, int i){

        Actions.doNothing(this.charName);

    }

    public void showMovement(){
        int i = 1;
        foreach(string move in this.moves){

            Console.WriteLine($"{i}-{move}");
            i++;
        }
    }

    protected void numberOfMoves(){

        moventNumbers = this.moves.Count;
    }

    public string getMovementName(int i){
        return(this.moves[i]);
    }
    public int getNumberOfMoves(){
        return moventNumbers;
    }
    public void renderInventory(){
        Console.WriteLine("You have:");
        byte i = 1;
        foreach(Item it in this.inventory){
            Console.WriteLine($"{i} - {it.itemName}");
            i++;
        }
    }

    public Item returnItem(int index){
        Item currentItem = this.inventory[index];
        this.inventory.RemoveAt(index);
        this.InventoryCount = this.inventory.Count;
        return currentItem;
    }

}

class Hero : Chara{

    public Hero(int health, string name) : base(health, name){

        moves = new List<string>();
        moves.Add("PUNCH");
        moves.Add("OPEN INVENTORY");
        moves.Add("Do Nothing");
        numberOfMoves();

        this.inventory = new List<Item>();
        this.inventory.Add(new healthPotion());
        this.inventory.Add(new healthPotion());
        this.inventory.Add(new healthPotion());
        this.InventoryCount = inventory.Count;
    }

    public override void action(Chara target, int i)
    {
        string action = this.moves[i];

        switch(action){

            case "PUNCH":
            Actions.attack(this, "PUNCH", target, 1);
            break;

            case "OPEN INVENTORY":
            Actions.useItem(this);
            break;

            default:
            Actions.doNothing(this.charName);
            break;
        }   
    }
}

class Skeleton : Chara {

    public Skeleton():base(10, "Skeleton"){

        moves = new List<string>();
        moves.Add("BONE CRUNCH");
        moves.Add("OPEN INVENTORY");
        moves.Add("Do Nothing");
        numberOfMoves();

        this.inventory = new List<Item>();
        this.inventory.Add(new healthPotion());
        this.InventoryCount = this.inventory.Count;     
    }


    public override void action(Chara target, int i)
    {
        string action = this.moves[i];

        switch(action){

            case "BONE CRUNCH":
            int randDamage = new Random().Next(2);
            randDamage = randDamage == 0 ? 1 : 0;
            Actions.attack(this, "BONE CRUNCH", target, randDamage);
            break;

            case "OPEN INVENTORY":
            Actions.useItem(this);
            break;
                   
            default:
            Actions.doNothing(this.charName);
            break;
        }
    }
}


class UncodedOne : Chara {

    public UncodedOne() : base(15, "Uncoded One"){

        moves = new List<string>();
        moves.Add("UNRAVELING");
        moves.Add("OPEN INVENTORY");
        moves.Add("Do Nothing");
        numberOfMoves();

        this.inventory = new List<Item>();
        this.inventory.Add(new healthPotion());
        this.InventoryCount = this.inventory.Count;
    }

    public override void action(Chara target, int i)
    {
        string action = this.moves[i];

        switch(action){

            case "UNRAVELING":
            int randDamage = new Random().Next(2);
            randDamage = randDamage == 0 ? 2 : 0;
            Actions.attack(this, "UNRAVELING", target, randDamage);
            break;

            case "OPEN INVENTORY":
            Actions.useItem(this);
            break;

            default:
            Actions.doNothing(this.charName);
            break;
        }       
    }
}
