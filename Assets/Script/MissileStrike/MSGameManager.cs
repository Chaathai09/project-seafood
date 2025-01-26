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
    [SerializeField] TMP_Text msScoreText, msHPText, msTimerText, totelScoreText;
    [SerializeField] int playerHP;
    [SerializeField] MSPlayerCon playerCon;
    [SerializeField] float timeLimit;
    Action gameState;
    [SerializeField] GameObject startHintUI, showScoreUI;
    [SerializeField] GameInfoObj gameInfoObj;

    List<GameObject> hpUIList = new();
    [SerializeField] GameObject hpPanal, hpPicPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerHP; i++)
        {
            hpUIList.Add(Instantiate(hpPicPrefab, hpPanal.transform));
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        msScoreText.text = msScore.ToString("000 000 000");
        msHPText.text = playerHP.ToString();
        msTimerText.text = Mathf.Ceil(timeLimit).ToString();
        totelScoreText.text = msScore.ToString("000 000 000");
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
        startHintUI.SetActive(false);
        gameState = TimeCount;
    }
    public void StopInvoke()
    {
        CancelInvoke();
        showScoreUI.SetActive(true);
        gameInfoObj.AddScore(msScore);
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
        else
            hpUIList[playerHP].SetActive(false);
    }

    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
