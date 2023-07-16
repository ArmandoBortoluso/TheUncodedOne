class Char{
    public int healthPoints;
    public readonly string? charName;

    public Char(int health, string name){
        this.healthPoints = health;
        charName = name;
    }


}

class Skeleton : Char {

    public Skeleton(int health):base(health, "Skeleton"){
        this.healthPoints = health;
    }

}