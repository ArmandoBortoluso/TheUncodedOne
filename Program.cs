//TODO: FIND A WAY TO GIVE PARTY'S CONTROL TO THE CPU OR THE PLAYER
//
//

//Instatiate enemies and player
List<Chara> playersParty = new List<Chara>();
List<Chara> enemysPartyOne = new List<Chara>();
List<Chara> enemysPartyTwo = new List<Chara>();
List<Chara> enemysPartyThree = new List<Chara>();
List<List<Chara>> enemyGroups = new List<List<Chara>>();

//Decides if is the player's turn
Boolean isPlayerTurn = true;

//Instantiate user's options
string? playOption;
short movementIndex;
short enemyIndex;


Console.Write("Please input the player's name:");
string? playerName = Console.ReadLine();
Hero player = new Hero(10, playerName);
playersParty.Add(player);

//Instantiate game enemy characters
Skeleton skeOne = new Skeleton();
Skeleton skeTwo = new Skeleton();
Skeleton skeThree = new Skeleton();
UncodedOne boss = new UncodedOne();
enemysPartyOne.Add(skeOne);
enemysPartyTwo.Add(skeTwo);
enemysPartyTwo.Add(skeThree);
enemysPartyThree.Add(boss);

//Add enemy characters to the their groups
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

foreach(List<Chara> group in enemyGroups){

    Console.WriteLine("A new enemy group appeared!!!!");
    

    while(true){

        if(isPlayerTurn){
        
            foreach(Chara Charact in playersParty){

                battleTurn(Charact, group);
            }
        
    } else {

        foreach(Chara Charact in group){
            battleTurn(Charact, playersParty);
        }
    }

    isPlayerTurn = isPlayerTurn ? false : true; 

    verifyParty(playersParty);
    verifyParty(group);

    if(group.Count == 0){

        Console.WriteLine("\nYou beated this group!!\n");
        break;

    } else if(playersParty.Count == 0){

        Console.WriteLine("You lost!\n");
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


//Method that controls players choices and turn result
void battleTurn(Chara protag, List<Chara> enemies){

    Console.WriteLine($"It is {protag.charName}'s turn.\nYou have the following actions:");
    protag.showMovement();

    if(playOption == "1" || playOption == "3"){

        while(true){

            if(Int16.TryParse(Console.ReadLine(), out movementIndex) && verifySelection(movementIndex, protag.getNumberOfMoves())){

                if(verifySelection(movementIndex, protag.getNumberOfMoves())){
                    Console.WriteLine("Please select a target:");
                    writeCharaOnScreen(enemies);
                    

                    if(Int16.TryParse(Console.ReadLine(), out enemyIndex) && verifySelection(enemyIndex, enemies.Count)){
                        movementIndex -= 1;
                        enemyIndex -= 1;

                        protag.action(enemies[enemyIndex], movementIndex);
                        return;
                        
                    }
                }
            }

            Console.WriteLine("Sorry, I didn't get that... Could you repeat it?");
        }
    }
}

//Verify group consistence
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

//Write group's character status on the screen
void writeCharaOnScreen(List<Chara> group){
    short i = 1;
    foreach(Chara c in group){
        Console.WriteLine($"{i}-{c.charName} - {c.healthPoints}/{c.totalMaxHealth}");
        i++;
    }
}

//Verify user input
Boolean verifySelection(int select, int size){

    if(select <= size && select > 0){
        return true;
    } else {
        return false;
    }
}

