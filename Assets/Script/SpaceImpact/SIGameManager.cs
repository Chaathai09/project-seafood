using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SIGameManager : MonoBehaviour
{
    public static SIGameManager Instance;
    public int SIScore = 0;
    [SerializeField] TMP_Text siScoreText;
    [SerializeField] int getScore;

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
    }

    public void AddScore()
    {
        SIScore += getScore;
    }

}
