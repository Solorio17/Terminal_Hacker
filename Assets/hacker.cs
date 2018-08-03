using UnityEngine;

public class hacker : MonoBehaviour {

    //Game State
    int level;
    enum Screen { MainMenu, Password, WinScreen};
    Screen currentScreen = Screen.MainMenu;
    string levelPassword;

    string menuReminder = "You may type 'menu' at any time to return to the main menu!";
    //Arrays that hold the passwords for each level.
    string[] LevelOnePasswords = new string[] { "student", "teacher", "homework", "utensil", "project" };
    string[] LevelTwoPasswords = new string[] { "electricity", "security", "powering", "volts", "gridsystem" };
    string[] LevelThreePasswords = new string[] { "astronauts", "rocketships", "mathematics", "science", "engineers" };

    void Start () {
        ShowMainMenu();
    }

    //Basically the main menu
    void ShowMainMenu()
    {
        Terminal.WriteLine("                   Welcome Agent");
        Terminal.WriteLine("Your mission should you choose to accept it is to hack one of these locations and retrieve the secret data.");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("01_l0cAl H1gH ScH0oL");
        Terminal.WriteLine("02_c0lOrAd0 P0wEr gRid");
        Terminal.WriteLine("03__nAti0NaL aEr0NauTICs & SpAC3 aDmInIsTr4Ti0n");
        Terminal.WriteLine(" ");
        Terminal.WriteLine(menuReminder);
        Terminal.WriteLine(" ");
        Terminal.WriteLine("What do you choose?");

    }

    //Checks for the user input in any state of the game
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

    //Handles the user input, making sure its valid.
    void RunMainMenu(string menuInput)
    {
        bool isValidLevelNumber = (menuInput == "01" || menuInput == "02" || menuInput == "03");
        if (isValidLevelNumber)
        {
            level = int.Parse(menuInput);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid option in the form of '01, 02 or 03'");
        }
    }

    //Changes the current screen to password, and has the anagram feature for the password hint
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("You have chosen " + level);
        Terminal.WriteLine("Enter the secret password, Hint: " + levelPassword.Anagram());
    }

    //Makes sure to choose a random from the password arrays, depending on what level is chosen.
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                levelPassword = LevelOnePasswords[Random.Range(0, LevelOnePasswords.Length)];
                break;
            case 2:
                levelPassword = LevelTwoPasswords[Random.Range(0, LevelTwoPasswords.Length)];
                break;
            case 3:
                levelPassword = LevelThreePasswords[Random.Range(0, LevelThreePasswords.Length)];
                break;
            default:
                Debug.LogError("Invalid");
                break;

        }
    }

    //Checks for password match. If correct display win screen, its incorrect run askForPassword.
    void CheckPassword(string enteredPassword)
    {
        if(enteredPassword == levelPassword)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    //Handles displaying the win screen.
   void DisplayWinScreen()
    {
        currentScreen = Screen.WinScreen;
        ShowLevelReward();
    }

    //After entering correct password for the level, makes sure to display the ascii art for that level
   void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.ClearScreen(); 
                Terminal.WriteLine(@"
                        You're In!
                     ______________
                    / ~~~~~ ~~~~~ /
                   / ~~~~~~~~~~~ //
                  / ~~~~ ~~~~~~ //
                 / ~~~~~~~~~~~ //
                / ~~~ ~~~ ~~~ //
               / ~~~~~~~~~~~ //
              / ~~~ ~~~~~ ~ //
             /_____________//
             |____________|/
");
                break;

            case 2:
                Terminal.ClearScreen();
                Terminal.WriteLine(@"
                   
                You \\\\\ Buzzed In!
                     \\\\\
                      \\\\\
                     \\\\\\\ 
                      \\\\\
                       \\\\\
                        \\\\\
                       \\\\\\\
                        \\\\
                         \\\
                          \\
                           \\
                            \
                             \   
 ");
                break;
            case 3:
                Terminal.ClearScreen();
                Terminal.WriteLine(@"
                
  ******    __________________________
        ** |\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    ****** | __   __   __   __   __    \\\\
       *** |(__) (__) (__) (__) (__) Welcome to NASA!
    ****** |                           ////
        ** |__________________________///
  *****
 ");
                break;
        }
    }

    void Update () {
        
    }
}
