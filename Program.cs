﻿Char[] playersParty = new Char[1];
Char[] enemysParty = new Char[1];

Console.WriteLine("The battle begins!");

Skeleton friendlySke = new Skeleton(10);
playersParty[0] = friendlySke;

Skeleton enemySke = new Skeleton(10);
enemysParty[0] = enemySke;

Boolean isPlayerTurn = true;

while(true){
    Console.WriteLine("\n");

    if(isPlayerTurn){
        
        foreach(Char charact in playersParty){
            Actions.doNothing(charact.charName);
        }

        isPlayerTurn = false;
        
    } else {

        foreach(Char charact in enemysParty){

            Actions.doNothing(charact.charName);
        }
        isPlayerTurn = true;
    }

    Thread.Sleep(500);

}