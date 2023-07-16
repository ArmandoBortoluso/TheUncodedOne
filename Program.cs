Char[] playersParty = new Char[1];
Char[] enemysParty = new Char[1];
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
        
        foreach(Char charact in playersParty){
            Console.WriteLine($"It is {charact.charName}'s turn.");

            Actions.attack(charact, "PUNCH", enemysParty[0]);
        }

        isPlayerTurn = false;
        
    } else {

        foreach(Char charact in enemysParty){
            Console.WriteLine($"It is {charact.charName}'s turn.");
            Actions.attack(charact, "BONE CRUNCH", playersParty[0]);
        }
        isPlayerTurn = true;
    }

    Thread.Sleep(500);

}