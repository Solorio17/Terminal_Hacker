using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour {

    //Game State
    string levelMessage;
    enum Screen { MainMenu, Password, WinScreen};
    Screen currentScreen = Screen.MainMenu;
    string levelPassword;

    string[] LevelOnePasswords = new string[] { "students", "teachers", "homework", "utensils", "projects" };
    string[] LevelTwoPasswords = new string[] { "electricity", "security", "powering", "personnel", "gridsystem" };

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
        if (input == "menu".ToLower())
        {
            Terminal.ClearScreen();
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "01")
        {
            levelPassword = "not a high school";
            levelMessage = "01_l0cAl H1gH ScH0oL";
            StartGame();
        }
        else if (input == "02")
        {
            levelPassword = "im a grid system";
            levelMessage = "02_c0lOrAd0 P0wEr gRid";
            StartGame();
        }
        else if (input == "03")
        {
            Terminal.WriteLine("You have chosen 03__nAti0NaL aEr0NauTICs & SpAC3 aDmInIsTr4Ti0n");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid option in the form of '01, 02 or 03'");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen " + levelMessage);
        Terminal.WriteLine("Now enter the secret password: ");
    }

    void CheckPassword(string password)
    {
        if(password == levelPassword)
        {
            Terminal.WriteLine("Correct!");
        }
        else
        {
            Terminal.WriteLine("Wrong!");
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
