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

Boolean isPlayerDead = false;

//Instantiate user's player option
string? playOption;

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

//The battle starts here
foreach(List<Chara> group in enemyGroups){
    if(isPlayerDead){
        break;
    }

    Console.WriteLine("A new enemy group appeared!!!!");
    
    while(true){

        if(isPlayerTurn){
        
            foreach(Chara Charact in playersParty){
                if(playOption == "1" || playOption == "3"){

                    BattleTurn.humanTurn(Charact, group);

                } else {

                    BattleTurn.cpuTurn(Charact, group);
                }
            }
        } else {

            foreach(Chara Charact in group){
                if(playOption != "3"){

                    BattleTurn.cpuTurn(Charact, playersParty);
                    
                } else {

                    BattleTurn.humanTurn(Charact, playersParty);
                }
            
            }
        }

        isPlayerTurn = isPlayerTurn ? false : true; 

        if(group.Count == 0){

            Console.WriteLine("\nYou beated this group!!\n");
            break;

        } else if(playersParty.Count == 0){

            Console.WriteLine("You lost!\n");
            isPlayerDead = true;
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

