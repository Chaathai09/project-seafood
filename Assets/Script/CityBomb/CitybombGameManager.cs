using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CitybombGameManager : MonoBehaviour
{
    public static CitybombGameManager Instance;
    public int cityBombScore = 0;
    [SerializeField] int buildingScore;
    [SerializeField] TMP_Text cityBombScoreText, totelScoreText;
    [SerializeField] GameObject startHintUI, showScoreUI;
    [SerializeField] GameInfoObj gameInfoObj;
    [SerializeField] GameObject[] stageList;

    private void Awake()
    {
        Instance = this;
        stageList[Random.Range(0, stageList.Length)].SetActive(true);
    }

    private void Update()
    {
        cityBombScoreText.text = cityBombScore.ToString("000 000 000");
        totelScoreText.text = cityBombScore.ToString("000 000 000");
    }

    public void AddScore()
    {
        cityBombScore += buildingScore;
    }

    public void PlayerHit()
    {
        if (cityBombScore != 0)
            cityBombScore -= buildingScore;
    }

    public void StartGame()
    {
        startHintUI.SetActive(false);
    }

    public void EndGame()
    {
        showScoreUI.SetActive(true);
        gameInfoObj.AddScore(cityBombScore);
    }

    public void LoadScene(int sceneIndex)
    {
        gameInfoObj.currentLevel += 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
