using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSPlayerCon : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] GameObject missilePrefap, missileSpawnPoint;
    [SerializeField] float deleyTime;
    bool canShot = true;
    Action gameState;
    [SerializeField] AudioClip shotSound;
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
        Instantiate(missilePrefap, missileSpawnPoint.transform.position, this.transform.rotation);
        MSGameManager.Instance.PlaySound(shotSound);
        yield return new WaitForSeconds(deleyTime);
        canShot = true;
    }

    void WaitForStart()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MSGameManager.Instance.StartInvoke();
            ChangeState(MiniGameRun);
        }
    }

    void ChangeState(Action state)
    {
        gameState = state;
    }

    void MiniGameRun()
    {
        this.transform.Rotate(new Vector3(0f, 0f, Input.GetAxisRaw("Horizontal")), -turnSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Z) && canShot)
        {
            canShot = false;
            StartCoroutine(ShotAmmo());
        }
    }

    public void EndGame()
    {
        MSGameManager.Instance.StopInvoke();
        StartCoroutine(JustWait());
    }

    void Nothing()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MSGameManager.Instance.LoadScene(1);
        }
    }

    IEnumerator JustWait()
    {
        ChangeState(null);
        yield return new WaitForSeconds(2f);
        ChangeState(Nothing);
    }
}
