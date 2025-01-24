using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIPlayer : MonoBehaviour, CityBombCondition
{
    GameObject siPlayer;
    [SerializeField] float speed;
    Action gameState;
    Transform tempPos;
    [SerializeField] GameObject ammoprefap;
    [SerializeField] SIEnemyAI enemyAIMirror;
    [SerializeField] int playerHP;

    private void Awake()
    {
        siPlayer = this.gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameState = WaitForStart;
    }

    // Update is called once per frame
    void Update()
    {
        gameState();
    }

    void MiniGameRun()
    {
        tempPos = siPlayer.transform;

        tempPos.Translate(new Vector2((Input.GetAxisRaw("Horizontal") * speed) * Time.deltaTime, (Input.GetAxisRaw("Vertical") * speed) * Time.deltaTime));

        tempPos.position = new Vector2(Math.Clamp(tempPos.position.x, -8f, 8f), Math.Clamp(tempPos.position.y, -4f, 4f));

        siPlayer.transform.position = tempPos.position;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShotAmmo();
        }

        enemyAIMirror.EnemyMove();
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

    void ShotAmmo()
    {
        GameObject temp = Instantiate(ammoprefap, siPlayer.transform.position, siPlayer.transform.rotation);
        temp.tag = "PlayerObj";
        temp.gameObject.GetComponent<SIAmmo>().ammoFrom = "PlayerObj";
        enemyAIMirror.ShotAmmo();
    }

    public void IsHit()
    {
        
    }
}
