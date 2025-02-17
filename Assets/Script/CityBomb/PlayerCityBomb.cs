using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCityBomb : MonoBehaviour, CityBombCondition
{
    [SerializeField] GameObject playerObj;
    [SerializeField] float speed;
    [SerializeField] Vector2 startPoint;
    [SerializeField] int bombNum;
    int useBombNum;
    [SerializeField] TMP_Text bombText;
    Action gameState;
    [SerializeField] GameObject bombPrefap;
    [SerializeField] float delayTime;
    List<GameObject> bombUIList = new();
    [SerializeField] GameObject bombPanal, bombPicPrefab;
    [SerializeField] AudioClip shotSound;


    // Start is called before the first frame update
    void Start()
    {
        playerObj.transform.position = startPoint;
        useBombNum = bombNum;
        for (int i = 0; i < bombNum; i++)
        {
            bombUIList.Add(Instantiate(bombPicPrefab, bombPanal.transform));
        }
        gameState = WaitForStart;
    }

    private void Update()
    {
        if (gameState != null)
            gameState();
        bombText.text = useBombNum.ToString();
    }

    void MiniGameRun()
    {
        if (playerObj.transform.position.x >= 10f)
        {
            playerObj.transform.position = new Vector2(startPoint.x, playerObj.transform.position.y - 1f);
            useBombNum = bombNum;

            foreach (GameObject go in bombUIList)
            {
                go.SetActive(true);
            }

            if (playerObj.transform.position.y < -4f)
            {
                EndMiniGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            DropBomb();
        }

        playerObj.transform.Translate((Vector2.right * speed) * Time.deltaTime);
    }

    void WaitForStart()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeState(MiniGameRun);
            CitybombGameManager.Instance.StartGame();
        }
    }

    void ChangeState(Action state)
    {
        gameState = state;
    }

    void DropBomb()
    {
        if (!(useBombNum < 1))
        {
            Vector2 temp = new Vector2(MathF.Round(playerObj.transform.position.x), playerObj.transform.position.y);
            Instantiate(bombPrefap, temp, playerObj.transform.rotation);
            bombUIList[bombNum - useBombNum].SetActive(false);
            useBombNum -= 1;
            CitybombGameManager.Instance.PlaySound(shotSound);
        }
    }

    public void IsHit()
    {
        EndMiniGame();
        CitybombGameManager.Instance.PlayerHit();
    }

    void EndMiniGame()
    {
        //do end game
        CitybombGameManager.Instance.EndGame();
        StartCoroutine(JustWait());
    }

    void Nothing()
    {
        //Now this will use for Load scene LOL
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CitybombGameManager.Instance.LoadScene(1);
        }
    }

    IEnumerator JustWait()
    {
        ChangeState(null);
        yield return new WaitForSeconds(2f);
        ChangeState(Nothing);
    }

}
