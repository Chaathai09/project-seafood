using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINGameManager : MonoBehaviour
{
    static public SINGameManager Instance;
    [SerializeField] SINEnemyGroupCon enemyCon;
    [SerializeField] SINPlayerCon PlayerCon;
    int sinScore = 0;
    [SerializeField] int getScore;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        sinScore += getScore;
        enemyCon.MinusTime();
    }

    public void GameStart()
    {
        enemyCon.StartMove();
    }

    public void EndGame()
    {
        enemyCon.isRun = false;
        enemyCon.StopAllCoroutines();
        PlayerCon.EndGame();
    }
}
