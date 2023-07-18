static class Actions{

    public static void doNothing(String charName){
        Console.WriteLine(charName + " did NOTHING!");
    }

    public static void attack(Chara user, string attackName, Chara target, int damage){

        target.healthPoints -= damage;

        target.healthPoints = target.healthPoints < 0? 0 : target.healthPoints;

        Console.WriteLine(user.charName + " used " + attackName + " on " + target.charName );
        Console.WriteLine(attackName + " dealt " + damage + " damage to " + target.charName + ".");
        Console.WriteLine(target.charName + " is now at " + target.healthPoints + "/" + target.totalMaxHealth +".");

    }

    public static void useItem(Chara target){

        Console.WriteLine("Select the item to use");
        target.renderInventory();
        short option;

        while(true){

            if(Int16.TryParse(Console.ReadLine(), out option)){

                if(option <= target.InventoryCount && option > 0){
                    option -= 1;
                    Item currentItem = target.returnItem(option);
                    currentItem.useItem(target);
                    break;
                }
            }

            Console.Write("Sorry, I didn't get that?");

        }

    }
}