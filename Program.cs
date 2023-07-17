Chara[] playersParty = new Chara[1];
Chara[] enemysParty = new Chara[1];
Boolean isPlayerTurn = true;

Console.Write("Please input the player's name:");
string? playerName = Console.ReadLine();

Console.WriteLine("The battle begins!, " + playerName);

Hero player = new Hero(10, playerName);
playersParty[0] = player;

Skeleton enemySke = new Skeleton(10);
enemysParty[0] = enemySke;


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

    Thread.Sleep(500);

}

