using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    [SerializeField] Button startButton, exitButton, loginButton, createAccountButton, createAccountButton2;
    [SerializeField] InputField Username, Password, Username1, Password1, Password2;
    [SerializeField] GameObject LoginDetailsScreen, AccountCreationScreen, PostLoginScreen;
    [SerializeField] Text WelcomeBackText;
    // Start is called before the first frame update
    void Start()
    {
        LoginDetailsScreen.SetActive(true);
        AccountCreationScreen.SetActive(false);
        PostLoginScreen.SetActive(false);
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
        loginButton.onClick.AddListener(Login);
        createAccountButton.onClick.AddListener(GoToCreateAccount);
        createAccountButton2.onClick.AddListener(CreateAccount);
    }

    void StartGame()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex + 1);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void Login()
    {
        if(Username.text != "" && Password.text != "")
        {
            LoginDetailsScreen.SetActive(false);
            WelcomeBackText.text = "Welcome Back, " + Username.text;
            PostLoginScreen.SetActive(true);
        }
    }

    void GoToCreateAccount()
    {
        LoginDetailsScreen.SetActive(false);
        AccountCreationScreen.SetActive(true);
    }

    void CreateAccount()
    {
        if (Username1.text != "" && Password1.text != "" && Password1.text == Password2.text)
        {
            AccountCreationScreen.SetActive(false);
            LoginDetailsScreen.SetActive(true);
        }
    }
}
