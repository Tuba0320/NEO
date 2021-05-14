using UnityEngine;
using System.Collections;

public class LogInManager : MonoBehaviour
{

    private GameObject guiTextLogIn; 
    private GameObject guiTextSignUp;

    private bool isLogIn;

    private bool logInButton;
    private bool signUpMenuButton;
    private bool signUpButton;
    private bool backButton;
    private bool scoreButton;
    private bool commentButton;
    private bool logOutButton;

    public string id;
    public string pw;
    public string mail;

    void Start()
    {

        FindObjectOfType<UserAuth>().logOut();

        guiTextLogIn = GameObject.Find("GUITextLogIn");
        guiTextSignUp = GameObject.Find("GUITextSignUp");

        isLogIn = true;
        guiTextSignUp.SetActive(false);
        guiTextLogIn.SetActive(true);

    }

    void OnGUI()
    {

        int btnW = 140, btnH = 50;
        GUI.skin.button.fontSize = 18;
        scoreButton = GUI.Button(new Rect(0 * btnW, 0, btnW, btnH), "Score Board");
        commentButton = GUI.Button(new Rect(1 * btnW, 0, btnW, btnH), "Comment");
        logOutButton = GUI.Button(new Rect(2 * btnW, 0, btnW, btnH), "Log Out");

        if (scoreButton)
        {
            Application.LoadLevel("Score");
        }

        if (logOutButton)
        {
            FindObjectOfType<UserAuth>().logOut();
        }


        if (isLogIn)
        {

            drawLogInMenu();

            if (logInButton)
                FindObjectOfType<UserAuth>().logIn(id, pw);

            if (signUpMenuButton)
                isLogIn = false;
        }

        else
        {

            drawSignUpMenu();

            if (signUpButton)
                FindObjectOfType<UserAuth>().signUp(id, mail, pw);

            if (backButton)
                isLogIn = true;
        }

        if (FindObjectOfType<UserAuth>().currentPlayer() != null)
            Application.LoadLevel("MenuScene");

    }

    private void drawLogInMenu()
    {
        guiTextSignUp.SetActive(false);
        guiTextLogIn.SetActive(true);

        GUI.skin.textField.fontSize = 20;
        int txtW = 150, txtH = 40;
        id = GUI.TextField(new Rect(Screen.width * 1 / 2, Screen.height * 1 / 3 - txtH * 1 / 2, txtW, txtH), id);
        pw = GUI.PasswordField(new Rect(Screen.width * 1 / 2, Screen.height * 1 / 2 - txtH * 1 / 2, txtW, txtH), pw, '*');

        int btnW = 180, btnH = 50;
        GUI.skin.button.fontSize = 20;
        logInButton = GUI.Button(new Rect(Screen.width * 1 / 4 - btnW * 1 / 2, Screen.height * 3 / 4 - btnH * 1 / 2, btnW, btnH), "Log In");
        signUpMenuButton = GUI.Button(new Rect(Screen.width * 3 / 4 - btnW * 1 / 2, Screen.height * 3 / 4 - btnH * 1 / 2, btnW, btnH), "Sign Up");

    }

    private void drawSignUpMenu()
    {
        guiTextLogIn.SetActive(false);
        guiTextSignUp.SetActive(true);

        int txtW = 150, txtH = 35;
        GUI.skin.textField.fontSize = 20;
        id = GUI.TextField(new Rect(Screen.width * 1 / 2, Screen.height * 1 / 4 - txtH * 1 / 2, txtW, txtH), id);
        pw = GUI.PasswordField(new Rect(Screen.width * 1 / 2, Screen.height * 2 / 5 - txtH * 1 / 2, txtW, txtH), pw, '*');
        mail = GUI.TextField(new Rect(Screen.width * 1 / 2, Screen.height * 11 / 20 - txtH * 1 / 2, txtW, txtH), mail);

        int btnW = 180, btnH = 50;
        GUI.skin.button.fontSize = 20;
        signUpButton = GUI.Button(new Rect(Screen.width * 1 / 4 - btnW * 1 / 2, Screen.height * 3 / 4 - btnH * 1 / 2, btnW, btnH), "Sign Up");
        backButton = GUI.Button(new Rect(Screen.width * 3 / 4 - btnW * 1 / 2, Screen.height * 3 / 4 - btnH * 1 / 2, btnW, btnH), "Back");
    }

}
