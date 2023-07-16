class Char{
    public int healthPoints;
    public readonly string? charName;

    public Char(int health, string name){
        this.healthPoints = health;
        this.charName = name;
    }


}

class Hero : Char{

    public Hero(int health, string name) : base(health, name){

    }

}

class Skeleton : Char {

    public Skeleton(int health):base(health, "Skeleton"){
        this.healthPoints = health;
    }

}