using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Condition
{
    timeCondition,
    positionCondition
}

public class BackgroundLoop : MonoBehaviour
{
    public Condition condition;
    public float startPositionX;
    public float endPositionX;
    public float speed = 5;
    public float timeInterval = 60;
    private float time = 0;
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.GetComponent<Transform>();
        //transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (condition == Condition.timeCondition)
        {
            if (time < timeInterval)
            {
                time += Time.deltaTime;
                transform.Translate(Vector2.left * speed * Time.deltaTime);

            }
            else
            {
                time = 0;
                transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
            }
        }
        else if(condition == Condition.positionCondition)
        {
            if(transform.position.x >= endPositionX){
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }else{
                transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
            }
        }
    }
}
