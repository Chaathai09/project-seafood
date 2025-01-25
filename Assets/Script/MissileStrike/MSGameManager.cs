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
    [SerializeField] TMP_Text msScoreText, msHPText;
    [SerializeField] int playerHP;
    [SerializeField] MSPlayerCon playerCon;
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
    }

    public void StartInvoke()
    {
        InvokeRepeating("SpawnMeteor", 0f, spawnDelay);
    }
    public void StopInvoke()
    {
        CancelInvoke();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Meteor"))
        {
            obj.GetComponent<MeteorCon>().speed = 0f;
        }
    }

    public void SpawnMeteor()
    {
        GameObject temp = Instantiate(meteorPrefap, new Vector2(Random.Range(-6f, 6f), 8f), Quaternion.identity);
        float randomSize = Random.Range(1f, 5f);
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
