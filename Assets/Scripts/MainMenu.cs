using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(StartGame);
        button2.onClick.AddListener(ExitGame);
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
}
