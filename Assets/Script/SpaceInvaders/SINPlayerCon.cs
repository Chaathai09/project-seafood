using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINPlayerCon : MonoBehaviour
{
    [SerializeField] float speed;
    Transform tempPos;
    [SerializeField] GameObject ammoprefap;
    [SerializeField] float deleyTime;
    bool canShot = true;
    Action gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = WaitForStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != null)
            gameState();
    }

    IEnumerator ShotAmmo()
    {
        Instantiate(ammoprefap, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(deleyTime);
        canShot = true;
    }

    void ChangeState(Action state)
    {
        gameState = state;
    }

    void WaitForStart()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SINGameManager.Instance.GameStart();
            ChangeState(MiniGameRun);
        }
    }
    void MiniGameRun()
    {
        tempPos = this.transform;
        tempPos.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f));
        tempPos.position = new Vector2(Mathf.Clamp(tempPos.position.x, -8.5f, 8.5f), tempPos.position.y);
        this.transform.position = tempPos.position;

        if (Input.GetKeyDown(KeyCode.Z) && canShot)
        {
            canShot = false;
            StartCoroutine(ShotAmmo());
        }
    }

    public void EndGame()
    {
        gameState = null;
    }
}
