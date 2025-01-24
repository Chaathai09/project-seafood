using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CitybombGameManager : MonoBehaviour
{
    public static CitybombGameManager Instance;
    public int cityBombScore = 0;
    [SerializeField] int buildingScore;
    [SerializeField] TMP_Text cityBombScoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        cityBombScoreText.text = cityBombScore.ToString();
    }

    public void AddScore()
    {
        cityBombScore += buildingScore;
    }
}
