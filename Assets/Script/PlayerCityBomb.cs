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
    [SerializeField] Action gameState;
    [SerializeField] GameObject bombPrefap;
    [SerializeField] float delayTime;


    // Start is called before the first frame update
    void Start()
    {
        playerObj.transform.position = startPoint;
        useBombNum = bombNum;
        gameState = WaitForStart;
    }

    private void Update()
    {
        gameState();
        bombText.text = useBombNum.ToString();
    }

    void MiniGameRun()
    {
        if (playerObj.transform.position.x >= 10f)
        {
            playerObj.transform.position = new Vector2(startPoint.x, playerObj.transform.position.y - 1f);
            useBombNum = bombNum;
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
            ChangeState(MiniGameRun);
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
            useBombNum -= 1;
        }
    }

    public void IsHit()
    {
        OnHit();
    }

    void OnHit()
    {
        //do end game
        gameState = null;
    }

}
