using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Witaj w grze Blackjack!");

        Deck deck = new Deck();
        deck.Shuffle();

        Hand playerHand = new Hand();
        Hand dealerHand = new Hand();

       