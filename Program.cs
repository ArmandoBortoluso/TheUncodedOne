List<Chara> playersParty = new List<Chara>();
List<Chara> enemysParty = new List<Chara>();
Boolean isPlayerTurn = true;

Console.Write("Please input the player's name:");
string? playerName = Console.ReadLine();

Console.WriteLine("The battle begins!, " + playerName);

Hero player = new Hero(10, playerName);
playersParty.Add(player);

Skeleton enemySke = new Skeleton(10);
enemysParty.Add(enemySke);


while(true){
    Console.WriteLine("\n");

    if(isPlayerTurn){
        
        foreach(Chara Charact in playersParty){
            Console.WriteLine($"It is {Charact.charName}'s turn.");

           Charact.action(Charact, enemysParty[0], "PUNCH");
        }

        isPlayerTurn = false;
        
    } else {

        foreach(Chara Charact in enemysParty){
            Console.WriteLine($"It is {Charact.charName}'s turn.");
            Charact.action(Charact, playersParty[0], "BONE CRUNCH");
        }
        isPlayerTurn = true;
    }

    verifyParty(playersParty);
    verifyParty(enemysParty);

    if(enemysParty.Count == 0){

        Console.WriteLine("You beat them!");
        break;

    } else if(playersParty.Count == 0){

        Console.WriteLine("You lost!");
        break;
    }




    Thread.Sleep(1000);

}



void verifyParty(List<Chara> party){

    List<int> indexForRemoval = new List<int>();

    foreach(Chara chara in party){
        if(chara.healthPoints == 0) indexForRemoval.Add(party.IndexOf(chara));
    }

    if(indexForRemoval.Count != 0){
        foreach(int i in indexForRemoval){
            party.RemoveAt(i);
        }
    }


}

