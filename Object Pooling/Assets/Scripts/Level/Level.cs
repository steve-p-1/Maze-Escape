using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static float timer;
    public static Level Instance { get; set; }

    [SerializeField] float startingTime;

    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Image gameOverBackground;
    [SerializeField] Image winBackground;
    [SerializeField] GameObject exitGate;
    [SerializeField] GameObject exitGateReal;


    List<IGameStateObserver> GameStateObservers = new();

    IExitContract exiting;
  

    public int dropsToCollect = 1;

    private void Awake()
    {

        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

    }


    void Start()
    {
        ResetLevel();

        GameStateObservers.Add(gameObject.GetComponent<LoseGame>());
        GameStateObservers.Add((IGameStateObserver)gameObject.GetComponent<WinGame>());

        exiting = BasicLocator.GetExitService();
    }


    void ResetLevel()
    {
        winBackground.gameObject.SetActive(false);
        gameOverBackground.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
        Debug.Log(dropsToCollect);

        Time.timeScale = 1;

        timer = startingTime;
    }


    public void SetDropsToCollect(int c)
    {
        if (c > 0) exitGate.SetActive(true);
        dropsToCollect = c;
    }

    private void FixedUpdate()
    {
        if (timer <= 0)
        {
            EndGame("Lose", 0);
        }
        else
        {
            timer -= Time.deltaTime;
            timerText.text = Convert.ToString(Math.Round(timer));
        }
    }




    public void CollectDrops()
    {
        if (dropsToCollect > 1)
        {
            dropsToCollect -= 1;
        }
        else
        {
            //triggers service locator and proxy scripts
            //exitGate.SetActive(false);
            exiting.SpawnExit(exitGate);
        }
    }

    // this is where the Observer patterns are instantiated
    public void EndGame(string endState, float timer)
    {
        foreach (IGameStateObserver aGameStateObserver in GameStateObservers)
        {
            aGameStateObserver.UpdateState(endState, timer);
        }
    }
}
