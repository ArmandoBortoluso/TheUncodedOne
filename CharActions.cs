static class Actions{

    public static void doNothing(String charName){
        Console.WriteLine(charName + " did NOTHING!");
    }

    public static void attack(Char user, string attackName, Char target){

        Console.WriteLine(user.charName + "used " + attackName + " on " + target.charName );

    }
}