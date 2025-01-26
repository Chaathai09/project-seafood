using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SINGameManager : MonoBehaviour
{
    static public SINGameManager Instance;
    [SerializeField] SINEnemyGroupCon enemyCon;
    [SerializeField] SINPlayerCon PlayerCon;
    int sinScore = 0;
    [SerializeField] int getScore;
    [SerializeField] TMP_Text sinScoreText, totelScoreText;

    [SerializeField] GameObject startHintUI, showScoreUI;
    [SerializeField] GameInfoObj gameInfoObj;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        sinScoreText.text = sinScore.ToString();
        totelScoreText.text = sinScore.ToString("000 000 000");
    }

    public void AddScore()
    {
        sinScore += getScore;
        enemyCon.MinusTime();
    }

    public void GameStart()
    {
        enemyCon.StartMove();
        startHintUI.SetActive(false);
    }

    public void EndGame()
    {
        showScoreUI.SetActive(true);
        gameInfoObj.AddScore(sinScore);
        enemyCon.isRun = false;
        enemyCon.StopAllCoroutines();
        PlayerCon.EndGame();
    }

    public void LoadScene(int sceneIndex)
    {
        gameInfoObj.currentLevel += 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
