using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINEnemyGroupCon : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefap;
    [SerializeField] int startPos, row;
    [SerializeField] float moveTime, minusTime;
    float goDriction = 0.5f;
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


        StartCoroutine(EnemyMove());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EnemyMove()
    {
        yield return new WaitForSeconds(moveTime);
        if (this.transform.position.x >= startPos + 8 || this.transform.position.x <= -(startPos + 8))
        {
            StartCoroutine(EnemyMoveDown());
        }
        else
        {
            this.transform.Translate(new Vector2(goDriction, 0f));
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMoveDown()
    {
        this.transform.Translate(new Vector2(0f, -1f));
        goDriction *= -1f;
        yield return new WaitForSeconds(moveTime);
        this.transform.Translate(new Vector2(goDriction, 0f));
        StartCoroutine(EnemyMove());
    }

    public void MinusTime()
    {
        moveTime -= minusTime;
    }
}
