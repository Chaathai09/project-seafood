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

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        cityBombScoreText.text = cityBombScore.ToString();
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
}
