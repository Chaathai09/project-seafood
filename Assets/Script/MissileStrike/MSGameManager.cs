using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MSGameManager : MonoBehaviour
{
    static public MSGameManager Instance;
    [SerializeField] GameObject meteorPrefap;
    [SerializeField] float spawnDelay;
    int msScore = 0;
    [SerializeField] int getScore;
    [SerializeField] TMP_Text msScoreText, msHPText, msTimerText;
    [SerializeField] int playerHP;
    [SerializeField] MSPlayerCon playerCon;
    [SerializeField] float timeLimit;
    Action gameState;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        msScoreText.text = msScore.ToString();
        msHPText.text = playerHP.ToString();
        msTimerText.text = Mathf.Ceil(timeLimit).ToString();
        if (gameState != null)
        {
            gameState();
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

    public void StartInvoke()
    {
        InvokeRepeating("SpawnMeteor", 0f, spawnDelay);
        gameState = TimeCount;
    }
    public void StopInvoke()
    {
        CancelInvoke();
        gameState = null;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Meteor"))
        {
            obj.GetComponent<MeteorCon>().speed = 0f;
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Missile"))
        {
            obj.GetComponent<MissileCon>().speed = 0f;
        }
    }

    public void SpawnMeteor()
    {
        GameObject temp = Instantiate(meteorPrefap, new Vector2(UnityEngine.Random.Range(-6f, 6f), 8f), Quaternion.identity);
        float randomSize = UnityEngine.Random.Range(1f, 5f);
        temp.GetComponent<MeteorCon>().SetMeteor(randomSize);
    }

    public void AddScore(float size)
    {
        msScore = msScore + (int)Mathf.Round(size * getScore);
    }

    public void RemoveHP()
    {
        playerHP--;
        if (playerHP <= 0)
        {
            playerCon.EndGame();
        }
    }
}
