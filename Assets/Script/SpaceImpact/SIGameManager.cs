using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SIGameManager : MonoBehaviour
{
    public static SIGameManager Instance;
    public int SIScore = 0;
    [SerializeField] TMP_Text siScoreText, siTimeText;
    [SerializeField] int getScore;
    [SerializeField] float timeLimit;
    [SerializeField] SIPlayer playerCon;
    Action gameState;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        siScoreText.text = SIScore.ToString();
        siTimeText.text = Mathf.Ceil(timeLimit).ToString();
        if (gameState != null)
        {
            gameState();
        }
    }

    public void AddScore()
    {
        SIScore += getScore;
    }

    public void StartGame()
    {
        gameState = TimeCount;
    }

    public void StopGame()
    {
        gameState = null;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EnemyObj"))
        {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PlayerObj"))
        {
            Destroy(obj);
        }
    }

    void TimeCount()
    {
        timeLimit -= Time.deltaTime;
        if (timeLimit <= 0f)
        {
            playerCon.EndGame();
        }
    }

}
