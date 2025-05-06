using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour, IGameStateObserver
{
    [SerializeField] Image gameOverBackground;
    [SerializeField] TMP_Text timerText;
    public static LoseGame Instance { get; set; }

    public void UpdateState(string EndState, float timer)
    { 
        if (EndState == "Lose") 
        {
            timerText.gameObject.SetActive(false);
        gameOverBackground.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
