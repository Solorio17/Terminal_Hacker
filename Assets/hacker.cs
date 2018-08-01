using UnityEngine;

public class hacker : MonoBehaviour {

    //Game State
    int level;
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

    void RunMainMenu(string menuInput)
    {
        bool isValidLevelNumber = (menuInput == "01" || menuInput == "02");
        if (isValidLevelNumber)
        {
            level = int.Parse(menuInput);
            StartGame();
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
        switch (level)
        {
            case 1:
                levelPassword = LevelOnePasswords[Random.Range(0, LevelOnePasswords.Length)];
                break;
            case 2:
                levelPassword = LevelTwoPasswords[Random.Range(0, LevelTwoPasswords.Length)];
                break;
            default:
                Debug.LogError("Invalid");
                break;

        }
        Terminal.WriteLine("You have chosen " + level);
        Terminal.WriteLine("Now enter the secret password: ");
    }

    void CheckPassword(string enteredPassword)
    {
        if(enteredPassword == levelPassword)
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
