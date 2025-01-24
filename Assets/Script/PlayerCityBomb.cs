using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCityBomb : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    [SerializeField] float speed;
    [SerializeField] Vector2 startPoint;


    // Start is called before the first frame update
    void Start()
    {
        playerObj.transform.position = startPoint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MiniGameRun();
    }

    void MiniGameRun()
    {
        if (playerObj.transform.position.x >= 10f)
        {
            playerObj.transform.position = new Vector2(startPoint.x, playerObj.transform.position.y - 1f);
        }
        playerObj.transform.Translate((Vector2.right * speed) * Time.deltaTime);
    }
}
