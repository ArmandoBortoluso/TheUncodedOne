//Instatiate enemies and player

List<Chara> playersParty = new List<Chara>();
List<Chara> enemysPartyOne = new List<Chara>();
List<Chara> enemysPartyTwo = new List<Chara>();
List<Chara> enemysPartyThree = new List<Chara>();
List<List<Chara>> enemyGroups = new List<List<Chara>>();
Boolean isPlayerTurn = true;
string? playOption;
Console.Write("Please input the player's name:");
string? playerName = Console.ReadLine();
Hero player = new Hero(10, playerName);
playersParty.Add(player);

Skeleton skeOne = new Skeleton();
Skeleton skeTwo = new Skeleton();
Skeleton skeThree = new Skeleton();
UncodedOne boss = new UncodedOne();
enemysPartyOne.Add(skeOne);
enemysPartyTwo.Add(skeTwo);
enemysPartyTwo.Add(skeThree);
enemysPartyThree.Add(boss);

enemyGroups.Add(enemysPartyOne);
enemyGroups.Add(enemysPartyTwo);
enemyGroups.Add(enemysPartyThree);

Console.Write("How do you want to play?\n1-Player Vs. Computer\n2-Computer Vs Computer\n3-Player Vs Player.\n 1, 2 or 3 ?");
playOption = Console.ReadLine();

while(playOption != "1" && playOption != "2" && playOption != "3"){
    Console.Write("Sorry, I didn't quite get that... Could you write again?");
    playOption = Console.ReadLine();
}

Console.WriteLine("The battle begins!, " + playerName);



Console.WriteLine("\n");

foreach(List<Chara> group in enemyGroups){

    Console.WriteLine("A new enemy group appeared!!!!");
    

    while(true){

        if(isPlayerTurn){
        
            foreach(Chara Charact in playersParty){
                Console.WriteLine($"It is {Charact.charName}'s turn.");

            Charact.action(Charact, group[0]);
            }

            isPlayerTurn = false;
        
    } else {

        foreach(Chara Charact in group){
            Console.WriteLine($"It is {Charact.charName}'s turn.");
            Charact.action(Charact, playersParty[0]);
        }
        isPlayerTurn = true;
    }

    verifyParty(playersParty);
    verifyParty(group);

    if(group.Count == 0){

        Console.WriteLine("\nYou beat this group!!\n");
        break;

    } else if(playersParty.Count == 0){

        Console.WriteLine("You lost!");
        break;
    }

    Thread.Sleep(1000);
    }

}
    
        



if(playersParty.Count == 0){
    Console.WriteLine("You were defeated!");
} else {
    Console.WriteLine("You won!");
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

