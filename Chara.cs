class Chara{
    public int healthPoints;
    public readonly string? charName;
    public readonly int totalMaxHealth;

    public Chara(int health, string name){
        this.totalMaxHealth = health;
        this.healthPoints = health;
        this.charName = name;
        
    }

    public virtual void action(Chara user, Chara target, string action){

        Actions.doNothing(this.charName);

    }


}

class Hero : Chara{

    public Hero(int health, string name) : base(health, name){

    }

    public override void action(Chara user, Chara target, string action)
    {

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

    public Skeleton(int health):base(health, "Skeleton"){
        
    }

    public override void action(Chara user, Chara target, string action)
    {

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