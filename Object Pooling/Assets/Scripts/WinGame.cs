using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinGame : MonoBehaviour, IGameStateObserver
{
    //this is an implementaton of the Observer pattern
    [SerializeField] Image winBackground;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text scoreText;

    public void UpdateState(string EndState, float timer)
    {
        if (EndState == "Win")
        {
        winBackground.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);

        Time.timeScale = 0;

        scoreText.text = "Score: " + Convert.ToString(timer);
        }
    }

}
