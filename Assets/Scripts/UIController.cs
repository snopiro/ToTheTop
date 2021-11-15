using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text timerText = null;
    [SerializeField] Text winTextUI = null;
    [SerializeField] public Button button1 = null;
    [SerializeField] public Button button2 = null;

    void Start()
    {
        HideWinText();
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }

    public void HideWinText()
    {
        winTextUI.text = "";
        winTextUI.gameObject.SetActive(false);
    }

    public void ShowWinText(string textToShow)
    {
        winTextUI.text = textToShow;
        winTextUI.gameObject.SetActive(true);
    }

    public void ShowButtons()
    {
        button1.gameObject.SetActive(true);
        button1.GetComponentInChildren<Text>().text = "Restart";
        button2.gameObject.SetActive(true);
        button2.GetComponentInChildren<Text>().text = "Exit";
    }

    public void UpdateTimer(float time)
    {
        timerText.text = ((int)time).ToString();
    }

    public void hideTimer()
    {
        timerText.gameObject.SetActive(false);
    }
}
