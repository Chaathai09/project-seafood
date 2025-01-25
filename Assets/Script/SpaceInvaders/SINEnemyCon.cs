using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINEnemyCon : MonoBehaviour, CityBombCondition
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -3f)
        {
            SINGameManager.Instance.EndGame();
        }
    }

    public void IsHit()
    {
        SINGameManager.Instance.AddScore();
        Destroy(this.gameObject);
    }
}
