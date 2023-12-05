using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Security.Principal;
using System;
using System.Linq;
using System.Reflection.Emit;

namespace ConsoleGames.Games; // here use name of your project

public class Wordle : Game
{
    // PUBLIC PROPERTIES (Eigenschaften)S
    public override string Name => "Wordle";
    public override string Description => "Erraten Sie das Geheime Wort bevor sie keine Leben mehr haben";
    public override string Rules => "Errate das gesuchte Wort in möglichst wenig Versuchen.";
    public override string Credits => "Gian Engel, giaengel@ksr.ch";
    public override int Year => 2023;
    public override bool TheHigherTheBetter => false;
    public override int LevelMax => 5;
    public override Score HighScore { get; set; }
    // No variable declarations in this area!!




    public override Score Play(int level)
    {
        bool gameover = false;
        string input = null;
        string secretWord = readsecretword(ref level);


    while (!gameover) { 
            Console.WriteLine(secretWord); 
            Console.WriteLine("Versuche das Wort zu erraten!");
            input = Console.ReadLine();
            input = input.ToUpper();
            

            if (input == secretWord)
            {
                Console.WriteLine("Glückwunsch du hast das Wort " + secretWord + " richtig erraten");
                gameover = true;


            }
            else if (input != secretWord)
            {
                for (int bStab = 0; bStab < secretWord.Length; bStab++)
                    {
                    int bStab2 = 0;
                      if (input[bStab] == secretWord[bStab])
                        {
                            Console.WriteLine("Der " + (bStab + 1) + " Buchstabe ist gleich.");
                            gameover = false;

                        }
                      else if (input[bStab] == secretWord[bStab2] && bStab != bStab2)
                    {
                        Console.WriteLine("Der " + (bStab2 + 1) + " gibt es in beiden Wörtern.");
                        bStab2++;
                        gameover = false;

                    }
                    else 
                    {
                        gameover = false;
                    }

                    }






            }

     
    }

        return new Score();
       
    }


    private string readsecretword (ref int level)
    {
        string[] wordsSimple = new string[] { "Hund", "Elfe", "Haus", "Auto", "Edel", "Fett", "Bube", "Buch", "Chef", "Brav", "Mond", "Baum", "Zeit", "Wind", "Brot", "Boot", "Lied", "Ball", "Kind", "Leid", "Wolf", "Gold", "Faul", "Kamm", "Tuch" };
        string[] wordsMedium = new string[] {"Medium" };
        string[] wordsAdvanced = new string[] { "Advanced"};

        Random rand = new Random();
        string secretWord = "";
        if (level == 0)
        {
            secretWord = wordsSimple[rand.Next(0, wordsSimple.Length)];
        }
        if (level == 1)
        {
            secretWord = wordsMedium[rand.Next(0, wordsMedium.Length)];

        }
        if (level == 2)
        {
            secretWord = wordsAdvanced[rand.Next(0, wordsAdvanced.Length)];
        }



        secretWord = secretWord.ToUpper();
        return secretWord;


    }


}