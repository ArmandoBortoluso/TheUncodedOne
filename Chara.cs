class Chara{
    public int healthPoints;
    public readonly string? charName;

    public Chara(int health, string name){
        this.healthPoints = health;
        this.charName = name;
    }


}

class Hero : Chara{

    public Hero(int health, string name) : base(health, name){

    }

}

class Skeleton : Chara {

    public Skeleton(int health):base(health, "Skeleton"){
        this.healthPoints = health;
    }

}