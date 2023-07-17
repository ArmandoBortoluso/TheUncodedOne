class Chara{
    public int healthPoints;
    public readonly string? charName;
    public readonly int totalMaxHealth;

    public string move;

    public Chara(int health, string name){
        this.totalMaxHealth = health;
        this.healthPoints = health;
        this.charName = name;
        
    }

    public virtual void action(Chara user, Chara target){

        Actions.doNothing(this.charName);

    }


}

class Hero : Chara{

    public Hero(int health, string name) : base(health, name){
        this.move = "PUNCH";

    }

    public override void action(Chara user, Chara target)
    {
        string action = this.move;

        switch(action){

            case "PUNCH":
            Actions.attack(user, "PUNCH", target, 1);
            break;

            default:
            Console.WriteLine("You shouldn't be using this attack!");
            break;
        }
        
        
    }

}

class Skeleton : Chara {

    public Skeleton():base(10, "Skeleton"){

        this.move = "BONE CRUNCH";
        
    }


    public override void action(Chara user, Chara target)
    {
        string action = this.move;

        switch(action){

            case "BONE CRUNCH":
            int randDamage = new Random().Next(2);
            randDamage = randDamage == 0 ? 1 : 0;
            Actions.attack(user, "BONE CRUNCH", target, randDamage);
            break;

                        
            default:
            Console.WriteLine("You shouldn't be using this attack!");
            break;
        }
        
        
    }

}


class UncodedOne : Chara {

    public UncodedOne() : base(15, "Uncoded One"){

        this.move = "UNRAVELING";

    }

    public override void action(Chara user, Chara target)
    {
        string action = this.move;

        switch(action){

            case "UNRAVELING":
            int randDamage = new Random().Next(2);
            randDamage = randDamage == 0 ? 2 : 0;
            Actions.attack(user, "UNRAVELING", target, randDamage);
            break;

                        
            default:
            Console.WriteLine("You shouldn't be using this attack!");
            break;
        }
        
        
    }


}