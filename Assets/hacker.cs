using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour {

    // Use this for initialization
    void Start () {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.WriteLine("Welcome Agent");
        Terminal.WriteLine("Your mission should you choose to accept it is to hack one of these locations and retrieve the secret data.");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("01_l0cAl H1gH ScH0oL");
        Terminal.WriteLine("02_c0lOrAd0 P0wEr gRid");
        Terminal.WriteLine("03__nAti0NaL aEr0NauTICs & SpAC3 aDmInIsTr4Ti0n");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("What do you choose?");

    }



    void OnUserInput(string input)
    {
        Terminal.ClearScreen();
        if (input == "menu".ToLower())
        {
            ShowMainMenu();
        }
        else if(input == "01")
        {
            Terminal.WriteLine("You have chosen 01_l0cAl H1gH ScH0oL");
        }
        else if(input == "02")
        {
            Terminal.WriteLine("You have chosen 02_c0lOrAd0 P0wEr gRid");
        }
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
