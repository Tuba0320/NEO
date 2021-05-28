using UnityEngine;
using System.Collections;
using NCMB;
using System.Collections.Generic;

public class UserAuth : MonoBehaviour
{

    private string currentPlayerName;
    private UserAuth instance = null;

    public void logIn(string id, string pw)
    {

        NCMBUser.LogInAsync(id, pw, (NCMBException e) =>
        {
            if (e == null)
            {
                currentPlayerName = id;
            }
        });
    }

    public void signUp(string id, string mail, string pw)
    {

        NCMBUser user = new NCMBUser();
        user.UserName = id;
        user.Email = mail;
        user.Password = pw;
        user.SignUpAsync((NCMBException e) =>
        {

            if (e == null)
            {
                currentPlayerName = id;
            }
        });
    }

    public void logOut()
    {

        NCMBUser.LogOutAsync((NCMBException e) =>
        {
            if (e == null)
            {
                currentPlayerName = null;
            }
        });
    }

    public string currentPlayer()
    {
        return currentPlayerName;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            string name = gameObject.name;
            gameObject.name = name + "(Singleton)";

            GameObject duplicater = GameObject.Find(name);
            if (duplicater != null)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.name = name;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
