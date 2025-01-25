using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINEnemyGroupCon : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefap;
    [SerializeField] int startPos, row;
    [SerializeField] float moveTime, minusTime;
    float goDriction = 0.5f;
    public bool isRun = true;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = startPos; j <= startPos * -1; j++)
            {
                Instantiate(enemyPrefap, transform.TransformPoint(new Vector2(j, i * -1)), Quaternion.identity, this.transform);
            }
        }

        this.transform.position = new Vector2(-(startPos + 8) + 1, 4);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMove()
    {
        StartCoroutine(EnemyMove());
    }

    IEnumerator EnemyMove()
    {
        yield return new WaitForSeconds(moveTime);
        if (this.transform.position.x >= startPos + 8 || this.transform.position.x <= -(startPos + 8))
        {
            CheckIsRun("EnemyMoveDown");
        }
        else
        {
            this.transform.Translate(new Vector2(goDriction, 0f));
            CheckIsRun("EnemyMove");
        }
    }

    IEnumerator EnemyMoveDown()
    {
        this.transform.Translate(new Vector2(0f, -1f));
        goDriction *= -1f;
        yield return new WaitForSeconds(moveTime);
        this.transform.Translate(new Vector2(goDriction, 0f));
        CheckIsRun("EnemyMove");
    }

    public void MinusTime()
    {
        moveTime -= minusTime;
    }

    void CheckIsRun(string action)
    {
        if (isRun)
        {
            StartCoroutine(action);
        }
    }
}
