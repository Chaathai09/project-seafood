using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SIGameManager : MonoBehaviour
{
    public static SIGameManager Instance;
    public int SIScore = 0;
    [SerializeField] TMP_Text siScoreText, siTimeText, totelScoreText;
    [SerializeField] int getScore;
    [SerializeField] float timeLimit;
    [SerializeField] SIPlayer playerCon;
    Action gameState;

    [SerializeField] GameObject[] spawnEnemyList;

    [SerializeField] GameObject startHintUI, showScoreUI;
    [SerializeField] GameInfoObj gameInfoObj;
    private void Awake()
    {
        Instance = this;
        playerCon.enemyAIMirror = Instantiate(spawnEnemyList[UnityEngine.Random.Range(0, spawnEnemyList.Length)], new Vector2(7f, 0f), Quaternion.identity).GetComponent<SIEnemyAI>();
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
        totelScoreText.text = SIScore.ToString("000 000 000");
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
        startHintUI.SetActive(false);
        gameState = TimeCount;
    }

    public void StopGame()
    {
        gameState = null;
        showScoreUI.SetActive(true);
        gameInfoObj.AddScore(SIScore);
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EnemyObj"))
        {
            if (obj.layer == 0)
                Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PlayerObj"))
        {
            if (obj.layer == 0)
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

    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

}
