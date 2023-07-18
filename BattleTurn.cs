static class BattleTurn{

    public static void humanTurn(Chara protag, List<Chara> enemies){

        short movementIndex;
        short enemyIndex;
        Item currentItem;

        Console.WriteLine($"It is {protag.charName}'s turn.\nYou have the following actions:");
        protag.showMovement();

        while(true){

            if(Int16.TryParse(Console.ReadLine(), out movementIndex) && verifySelection(movementIndex, protag.getNumberOfMoves())){

                if(String.Equals(protag.getMovementName(movementIndex - 1), "OPEN INVENTORY")){

                    protag.renderInventory();
                    Console.Write("Which one do you want? ");
                    if(Int16.TryParse(Console.ReadLine(), out movementIndex) && verifySelection(movementIndex, protag.InventoryCount)){
                            currentItem = protag.returnItem(movementIndex - 1);
                            currentItem.useItem(protag);
                            return;
                    }
                }

                if(verifySelection(movementIndex, protag.getNumberOfMoves())){
                    Console.WriteLine("Please select a target:");
                    writeCharaOnScreen(enemies);
                    

                    if(Int16.TryParse(Console.ReadLine(), out enemyIndex) && verifySelection(enemyIndex, enemies.Count)){
                        movementIndex -= 1;
                        enemyIndex -= 1;

                        protag.action(enemies[enemyIndex], movementIndex);
                        verifyParty(enemies);
                        return;
                        
                    }
                }
            }

            Console.WriteLine("Sorry, I didn't get that... Could you repeat it?");
        }
    }

    public static void cpuTurn(Chara protag, List<Chara> enemies){
        Item current;

        int currentHealth = protag.healthPoints;
        if((protag.healthPoints <= (protag.totalMaxHealth * 0.5)) && protag.InventoryCount > 0){
            Random rand = new Random();
            if(rand.Next(5) == 1){
                current = protag.returnItem(0);
                current.useItem(protag);
                return;
            }
        }

        

        protag.action(enemies[0], 0);
        verifyParty(enemies);
    }

    //Write group's character status on the screen
    private static void writeCharaOnScreen(List<Chara> group){
        short i = 1;
        foreach(Chara c in group){
            Console.WriteLine($"{i}-{c.charName} - ( {c.healthPoints}/{c.totalMaxHealth} )");
            i++;
        }
    }

    //Verify user input
    private static Boolean verifySelection(int select, int size){

        if(select <= size && select > 0){
            return true;
        } else {
            return false;
        }
    }


    //Verify group consistence
    private static void verifyParty(List<Chara> party){

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


    public static void statusRender(List<Chara> playerParty, List<Chara> enemyParty){

        Console.WriteLine("============================================= BATTLE ============================================");

        foreach(Chara c in playerParty){
            Console.WriteLine($"{c.charName}       ({c.healthPoints}/{c.totalMaxHealth})");
        }


        Console.WriteLine("---------------------------------------------- VS -----------------------------------------------");

        foreach(Chara c in enemyParty){
            Console.WriteLine($"                                                                  {c.charName}      ({c.healthPoints}/{c.totalMaxHealth})");
        }
    }

}